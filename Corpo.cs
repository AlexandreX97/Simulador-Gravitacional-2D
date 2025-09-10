using System;

namespace SimGrav2D
{
    public class Corpo
    {
        // Nome do corpo
        public string Nome { get; set; }

        // Massa em kg
        public double Massa { get; set; }

        // Densidade em kg/m^3
        public double Densidade { get; set; }

        // Posição (m)
        public double PosX { get; set; }
        public double PosY { get; set; }

        // Velocidade (m/s)
        public double VelX { get; set; }
        public double VelY { get; set; }

        // Raio calculado em metros (a partir de massa e densidade)
        public double Raio { get; private set; }

        // Construtor principal
        public Corpo(string nome, double massa, double densidade, double posX, double posY, double velX = 0, double velY = 0)
        {
            Nome = nome;
            Massa = massa;
            Densidade = densidade;
            PosX = posX;
            PosY = posY;
            VelX = velX;
            VelY = velY;
            AtualizarRaio();
        }

        // Atualiza o raio de acordo com a massa e densidade: r = cube_root(3m / (4πρ))
        public void AtualizarRaio()
        {
            if (Densidade <= 0) Densidade = 1.0; // proteção mínima
            Raio = Math.Pow((3.0 * Massa) / (4.0 * Math.PI * Densidade), 1.0 / 3.0);
        }

        // Retorna o volume (m^3) assumindo esfera
        public double Volume()
        {
            return (4.0 / 3.0) * Math.PI * Math.Pow(Raio, 3);
        }
    }
}
