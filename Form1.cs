namespace SimGrav2D
{
    public partial class Form1 : Form
    {
       
        // Timer responsável por atualizar a simulação
        private Timer timerSimulacao;

        public Form1()
        {

            InitializeComponent();

            // Evento para quando o Form é redimensionado
            this.Resize += Form1_Resize;

            // Evento para quando o painel for redimensionado
            panelSimulacao.Resize += panelSimulacao_Resize;

            // Timer
            timerSimulacao = new Timer();
            timerSimulacao.Interval = 30; // ~33 FPS
            timerSimulacao.Tick += TimerSimulacao_Tick;

            // Desenho no painel central
            panelSimulacao.Paint += panelSimulacao_Paint;

            // Botões
            btnCarregar.Click += btnCarregar_Click;
            btnSalvar.Click += btnSalvar_Click;
            btnIniciar.Click += btnIniciar_Click;
            btnPausar.Click += btnPausar_Click;

            // Menu
            menuArquivoCarregar.Click += menuArquivoCarregar_Click;
            menuArquivoSalvar.Click += menuArquivoSalvar_Click;
            menuArquivoSair.Click += menuArquivoSair_Click;
            menuSimulacaoIniciar.Click += menuSimulacaoIniciar_Click;
            menuSimulacaoPausar.Click += menuSimulacaoPausar_Click;
        }

        // Quando o formulário muda de tamanho
        private void Form1_Resize(object sender, EventArgs e)
        {
            panelSimulacao.Invalidate(); // força redesenho
        }

        // Quando o painel muda de tamanho
        private void panelSimulacao_Resize(object sender, EventArgs e)
        {
            panelSimulacao.Invalidate(); // força redesenho
        }

        // Desenho
        private void panelSimulacao_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // Exemplo: desenha um corpo no centro
            int x = panelSimulacao.Width / 2;
            int y = panelSimulacao.Height / 2;
            int raio = 20;

            g.FillEllipse(Brushes.White, x - raio, y - raio, raio * 2, raio * 2);

            // Futuramente: desenhar os corpos da simulação
        }

        private void TimerSimulacao_Tick(object sender, EventArgs e)
        {
            // Atualiza posições da simulação 

            panelSimulacao.Invalidate(); // força redesenho
        }

        private void btnCarregar_Click(object sender, EventArgs e)
        {
            // carregar configuração
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            // implementar salvar
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            timerSimulacao.Start(); // Inicia simulação
        }

        private void btnPausar_Click(object sender, EventArgs e)
        {
            timerSimulacao.Stop(); // Pausa simulação
        }

        // Menu de Arquivo
        private void menuArquivoCarregar_Click(object sender, EventArgs e)
        {
            btnCarregar_Click(sender, e);
        }

        private void menuArquivoSalvar_Click(object sender, EventArgs e)
        {
            btnSalvar_Click(sender, e);
        }

        private void menuArquivoSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Menu de Simulação
        private void menuSimulacaoIniciar_Click(object sender, EventArgs e)
        {
            btnIniciar_Click(sender, e);
        }

        private void menuSimulacaoPausar_Click(object sender, EventArgs e)
        {
            btnPausar_Click(sender, e);
        }

        // Status Bar
        private void statusInfo_Click(object sender, EventArgs e)
        {
            // Exemplo de atualização de status

        }
    }
}
