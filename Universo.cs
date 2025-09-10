using System;

namespace SimGrav2D
{
    public class Universo
    {
        // Array fixo de corpos: o roteiro exige uso de vetor
        public Corpo[] Corpos { get; private set; }

        // Quantos elementos válidos existem no array (0..Count-1)
        public int Count { get; private set; }

        // Constante gravitacional (SI)
        public double G { get; set; } = 6.674184e-11;

        // Pequeno valor para evitar divisão por zero
        private const double epsilon = 1e-9;

        // Cria um universo com capacidade fixa (tamanho do vetor)
        public Universo(int capacidade)
        {
            if (capacidade <= 0) capacidade = 1;
            Corpos = new Corpo[capacidade];
            Count = 0;
        }

        // Adiciona um corpo se houver espaço. Retorna true se inserido
        public bool AdicionarCorpo(Corpo corpo)
        {
            if (corpo == null) return false;
            if (Count >= Corpos.Length) return false;
            Corpos[Count++] = corpo;
            return true;
        }

        // Remove o corpo na posição index (compacta o vetor)
        public bool RemoverCorpoAt(int index)
        {
            if (index < 0 || index >= Count) return false;
            for (int k = index; k < Count - 1; k++)
            {
                Corpos[k] = Corpos[k + 1];
            }
            Corpos[--Count] = null;
            return true;
        }

        // Roda a simulação por iteracoes passos com passo de tempo deltaT
        // Se for necessário gravar/desenhar, passe um callback que recebe (iteração, snapshot dos corpos)
        public void Rodar(int iteracoes, double deltaT, Action<int, Corpo[]> estadoCallback = null)
        {
            for (int it = 0; it < iteracoes; it++)
            {
                double[] fx = new double[Count];
                double[] fy = new double[Count];

                // calcula todas as forças entre pares
                CalcularForcas(fx, fy);

                // integra posições e velocidades por passo (cinemática)
                Integrar(fx, fy, deltaT);

                // verifica colisões e faz fusões (inelásticas)
                TratarColisoes();

                // retorna cópia dos corpos atuais para quem chamou (gravar/desenhar)
                estadoCallback?.Invoke(it, ObterSnapshot());
            }
        }

        // Calcula os vetores de força (fx, fy) para cada corpo
        private void CalcularForcas(double[] fx, double[] fy)
        {
            for (int i = 0; i < Count; i++)
            {
                fx[i] = 0.0;
                fy[i] = 0.0;
            }

            for (int i = 0; i < Count; i++)
            {
                for (int j = i + 1; j < Count; j++)
                {
                    double dx = Corpos[j].PosX - Corpos[i].PosX;
                    double dy = Corpos[j].PosY - Corpos[i].PosY;
                    double r2 = dx * dx + dy * dy;
                    double r = Math.Sqrt(r2);

                    // evita divisão por zero
                    if (r < epsilon) r = epsilon;

                    // lei da gravitação universal
                    double force = G * Corpos[i].Massa * Corpos[j].Massa / (r * r);

                    double ux = dx / r;
                    double uy = dy / r;

                    double fxij = force * ux;
                    double fyij = force * uy;

                    // ação e reação
                    fx[i] += fxij;
                    fy[i] += fyij;
                    fx[j] -= fxij;
                    fy[j] -= fyij;
                }
            }
        }

        // Integra posição/velocidade usando fórmula: s = s0 + v0*t + 0.5*a*t^2 ; v = v0 + a*t
        private void Integrar(double[] fx, double[] fy, double dt)
        {
            for (int i = 0; i < Count; i++)
            {
                var c = Corpos[i];

                double ax = fx[i] / c.Massa;
                double ay = fy[i] / c.Massa;

                c.PosX += c.VelX * dt + 0.5 * ax * dt * dt;
                c.PosY += c.VelY * dt + 0.5 * ay * dt * dt;

                c.VelX += ax * dt;
                c.VelY += ay * dt;

                // atualiza raio caso a massa/densidade tenham mudado
                c.AtualizarRaio();
            }
        }

        // Trata colisões: fusao inelastica (conserva quantidade de movimento e soma volumes para densidade)
        private void TratarColisoes()
        {
            for (int i = 0; i < Count; i++)
            {
                for (int j = i + 1; j < Count; j++)
                {
                    double dx = Corpos[j].PosX - Corpos[i].PosX;
                    double dy = Corpos[j].PosY - Corpos[i].PosY;
                    double dist = Math.Sqrt(dx * dx + dy * dy);

                    if (dist <= (Corpos[i].Raio + Corpos[j].Raio))
                    {
                        double m1 = Corpos[i].Massa;
                        double m2 = Corpos[j].Massa;
                        double newM = m1 + m2;

                        // posição no centro de massa
                        double newX = (m1 * Corpos[i].PosX + m2 * Corpos[j].PosX) / newM;
                        double newY = (m1 * Corpos[i].PosY + m2 * Corpos[j].PosY) / newM;

                        // velocidade pela conservação do momento
                        double newVx = (m1 * Corpos[i].VelX + m2 * Corpos[j].VelX) / newM;
                        double newVy = (m1 * Corpos[i].VelY + m2 * Corpos[j].VelY) / newM;

                        // calcula volumes e nova densidade: densidade = massa / volume
                        double vol1 = Corpos[i].Volume();
                        double vol2 = Corpos[j].Volume();
                        double newVol = vol1 + vol2;
                        double newDensity = newM / newVol;

                        // escolhe nome (mantém do maior)
                        string nome = (m1 >= m2) ? Corpos[i].Nome : Corpos[j].Nome;

                        // cria corpo resultante
                        Corpo merged = new Corpo(nome, newM, newDensity, newX, newY, newVx, newVy);

                        // substitui i por merged e remove j
                        Corpos[i] = merged;
                        RemoverCorpoAt(j);

                        // ajusta j para reavaliar novas colisões com o corpo recém criado
                        j--;
                    }
                }
            }
        }

        // Retorna uma cópia do vetor de corpos contendo apenas os elementos válidos
        public Corpo[] ObterSnapshot()
        {
            Corpo[] snapshot = new Corpo[Count];
            for (int i = 0; i < Count; i++) snapshot[i] = Corpos[i];
            return snapshot;
        }
    }
}
