using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SimGrav2D
{
    public partial class Form1 : Form
    {
        private Universo universo;
        private readonly Timer timer;
        private readonly SalvarArquivosTexto saver = new SalvarArquivosTexto();

        // Área "física" em metros que mapearemos para pixels
        private readonly double worldXMin = -1.0e7;
        private readonly double worldXMax = 1.0e7;
        private readonly double worldYMin = -1.0e7;
        private readonly double worldYMax = 1.0e7;

        private readonly int nCorpos = 25;
        private readonly int totalIteracoes = 5000;

        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;

            // deltaT em segundos
            double dt = 0.5;
            universo = new Universo(dt);
            universo.CriarAleatorio(
                nCorpos,
                (worldXMin, worldXMax, worldYMin, worldYMax),
                (1.0e12, 1.0e16),          // massas "astronômicas" mas pequenas para manter estável
                (500.0, 5000.0),           // densidades típicas rochosas
                seed: 42
            );

            // Exporta configuração inicial
            string pasta = AppDomain.CurrentDomain.BaseDirectory;
            string cfgPath = Path.Combine(pasta, "universo_inicial.txt");
            universo.ExportarConfiguracaoInicial(saver, cfgPath, totalIteracoes);

            // Prepara arquivo de estados
            string estadosPath = Path.Combine(pasta, "universo_estados.txt");
            if (File.Exists(estadosPath)) File.Delete(estadosPath);

            // Timer para simulação + gravação step-by-step
            timer = new Timer();
            timer.Interval = 16; // ~60 FPS
            int i = 0;
            timer.Tick += (s, e) =>
            {
                i++;
                universo.Passo();

                // Grava cada iteração no arquivo de estados
                if (i == 1)
                {
                    saver.IniciarArquivoEstados(estadosPath, universo.Corpos.Count, totalIteracoes, universo.DeltaT);
                    saver.GravarEstadoIteracao(estadosPath, universo, 0);
                }
                else
                {
                    saver.GravarEstadoIteracao(estadosPath, universo, i);
                }

                Invalidate(); // repintar
                if (i >= totalIteracoes)
                {
                    timer.Stop();
                }
            };
            timer.Start();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            g.Clear(Color.Black);

            // Mapeamento simples mundo->tela
            float W = ClientSize.Width;
            float H = ClientSize.Height;
            float pad = 20f;

            foreach (var c in universo.Corpos)
            {
                // Normaliza posição para [0..1]
                double nx = (c.PosX - worldXMin) / (worldXMax - worldXMin);
                double ny = (c.PosY - worldYMin) / (worldYMax - worldYMin);

                float px = (float)(pad + nx * (W - 2 * pad));
                float py = (float)(pad + (1.0 - ny) * (H - 2 * pad)); // inverte Y para desenho

                // Escala do raio para pixels (apenas para visualização)
                double maxWorldRadius = (worldXMax - worldXMin) * 0.02;
                float pr = (float)Math.Max(2.0, Math.Min(30.0, c.Raio / maxWorldRadius * (W - 2 * pad)));

                // Desenha círculo
                using var brush = new SolidBrush(Color.White);
                g.FillEllipse(brush, px - pr, py - pr, pr * 2, pr * 2);
            }
        }
    }
}
