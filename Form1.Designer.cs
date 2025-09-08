namespace SimGrav2D
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            menuStripPrincipal = new MenuStrip();
            menuArquivo = new ToolStripMenuItem();
            menuArquivoCarregar = new ToolStripMenuItem();
            menuArquivoSalvar = new ToolStripMenuItem();
            menuArquivoSair = new ToolStripMenuItem();
            menuSimulacao = new ToolStripMenuItem();
            menuSimulacaoIniciar = new ToolStripMenuItem();
            menuSimulacaoPausar = new ToolStripMenuItem();
            menuSimulacaoReiniciar = new ToolStripMenuItem();
            menuExibicao = new ToolStripMenuItem();
            menuExibicaoTrajetorias = new ToolStripMenuItem();
            menuExibicaoVetores = new ToolStripMenuItem();
            panelLateral = new Panel();
            btnPausar = new Button();
            btnIniciar = new Button();
            btnSalvar = new Button();
            btnCarregar = new Button();
            statusPrincipal = new StatusStrip();
            statusInfo = new ToolStripStatusLabel();
            panelSimulacao = new Panel();
            menuStripPrincipal.SuspendLayout();
            panelLateral.SuspendLayout();
            statusPrincipal.SuspendLayout();
            SuspendLayout();
            // 
            // menuStripPrincipal
            // 
            menuStripPrincipal.BackColor = SystemColors.ControlDark;
            menuStripPrincipal.Items.AddRange(new ToolStripItem[] { menuArquivo, menuSimulacao, menuExibicao });
            menuStripPrincipal.Location = new Point(0, 0);
            menuStripPrincipal.Name = "menuStripPrincipal";
            menuStripPrincipal.Size = new Size(800, 24);
            menuStripPrincipal.TabIndex = 0;
            menuStripPrincipal.Text = "menuStrip1";
            //menuStripPrincipal.ItemClicked += menuStrip1_ItemClicked;
            // 
            // menuArquivo
            // 
            menuArquivo.DropDownItems.AddRange(new ToolStripItem[] { menuArquivoCarregar, menuArquivoSalvar, menuArquivoSair });
            menuArquivo.Name = "menuArquivo";
            menuArquivo.Size = new Size(61, 20);
            menuArquivo.Text = "Arquivo";
            // 
            // menuArquivoCarregar
            // 
            menuArquivoCarregar.Name = "menuArquivoCarregar";
            menuArquivoCarregar.Size = new Size(180, 22);
            menuArquivoCarregar.Text = "Carregar";
            // 
            // menuArquivoSalvar
            // 
            menuArquivoSalvar.Name = "menuArquivoSalvar";
            menuArquivoSalvar.Size = new Size(180, 22);
            menuArquivoSalvar.Text = "Salvar Estado";
            // 
            // menuArquivoSair
            // 
            menuArquivoSair.Name = "menuArquivoSair";
            menuArquivoSair.Size = new Size(180, 22);
            menuArquivoSair.Text = "Sair";
            // 
            // menuSimulacao
            // 
            menuSimulacao.DropDownItems.AddRange(new ToolStripItem[] { menuSimulacaoIniciar, menuSimulacaoPausar, menuSimulacaoReiniciar });
            menuSimulacao.Name = "menuSimulacao";
            menuSimulacao.Size = new Size(74, 20);
            menuSimulacao.Text = "Simulação";
            // 
            // menuSimulacaoIniciar
            // 
            menuSimulacaoIniciar.Name = "menuSimulacaoIniciar";
            menuSimulacaoIniciar.Size = new Size(180, 22);
            menuSimulacaoIniciar.Text = "Iniciar";
            // menuSimulacaoIniciar.Click += iniciarToolStripMenuItem_Click;
            // 
            // menuSimulacaoPausar
            // 
            menuSimulacaoPausar.Name = "menuSimulacaoPausar";
            menuSimulacaoPausar.Size = new Size(180, 22);
            menuSimulacaoPausar.Text = "Pausar";
            // 
            // menuSimulacaoReiniciar
            // 
            menuSimulacaoReiniciar.Name = "menuSimulacaoReiniciar";
            menuSimulacaoReiniciar.Size = new Size(180, 22);
            menuSimulacaoReiniciar.Text = "Reiniciar";
            // 
            // menuExibicao
            // 
            menuExibicao.DropDownItems.AddRange(new ToolStripItem[] { menuExibicaoTrajetorias, menuExibicaoVetores });
            menuExibicao.Name = "menuExibicao";
            menuExibicao.Size = new Size(63, 20);
            menuExibicao.Text = "Exibição";
            // 
            // menuExibicaoTrajetorias
            // 
            menuExibicaoTrajetorias.Name = "menuExibicaoTrajetorias";
            menuExibicaoTrajetorias.Size = new Size(180, 22);
            menuExibicaoTrajetorias.Text = "Mostrar Trajetórias";
            // 
            // menuExibicaoVetores
            // 
            menuExibicaoVetores.Name = "menuExibicaoVetores";
            menuExibicaoVetores.Size = new Size(180, 22);
            menuExibicaoVetores.Text = "Mostrar Vetores";
            // 
            // panelLateral
            // 
            panelLateral.BackColor = SystemColors.ControlDark;
            panelLateral.Controls.Add(btnPausar);
            panelLateral.Controls.Add(btnIniciar);
            panelLateral.Controls.Add(btnSalvar);
            panelLateral.Controls.Add(btnCarregar);
            panelLateral.Dock = DockStyle.Left;
            panelLateral.Location = new Point(0, 24);
            panelLateral.Name = "panelLateral";
            panelLateral.Size = new Size(76, 426);
            panelLateral.TabIndex = 1;
            // 
            // btnPausar
            // 
            btnPausar.Location = new Point(0, 90);
            btnPausar.Name = "btnPausar";
            btnPausar.Size = new Size(75, 23);
            btnPausar.TabIndex = 3;
            btnPausar.Text = "Pausar";
            btnPausar.UseVisualStyleBackColor = true;
            btnPausar.Click += btnPausar_Click;
            // 
            // btnIniciar
            // 
            btnIniciar.Location = new Point(0, 61);
            btnIniciar.Name = "btnIniciar";
            btnIniciar.Size = new Size(75, 23);
            btnIniciar.TabIndex = 2;
            btnIniciar.Text = "Iniciar";
            btnIniciar.UseVisualStyleBackColor = true;
            btnIniciar.Click += btnIniciar_Click;
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(0, 32);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(75, 23);
            btnSalvar.TabIndex = 1;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // btnCarregar
            // 
            btnCarregar.Location = new Point(0, 3);
            btnCarregar.Name = "btnCarregar";
            btnCarregar.Size = new Size(75, 23);
            btnCarregar.TabIndex = 0;
            btnCarregar.Text = "Carregar";
            btnCarregar.UseVisualStyleBackColor = true;
            btnCarregar.Click += btnCarregar_Click;
            // 
            // statusPrincipal
            // 
            statusPrincipal.Items.AddRange(new ToolStripItem[] { statusInfo });
            statusPrincipal.Location = new Point(76, 428);
            statusPrincipal.Name = "statusPrincipal";
            statusPrincipal.Size = new Size(724, 22);
            statusPrincipal.TabIndex = 2;
            statusPrincipal.Text = "statusStrip1";
            // 
            // statusInfo
            // 
            statusInfo.Name = "statusInfo";
            statusInfo.Size = new Size(119, 17);
            statusInfo.Text = "Corpos: 0 | Tempo: 0s";
            // statusInfo.Click += toolStripStatusLabel1_Click;
            // 
            // panelSimulacao
            // 
            panelSimulacao.BackColor = Color.Black;
            panelSimulacao.Dock = DockStyle.Fill;
            panelSimulacao.Location = new Point(76, 24);
            panelSimulacao.Name = "panelSimulacao";
            panelSimulacao.Size = new Size(724, 404);
            panelSimulacao.TabIndex = 4;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panelSimulacao);
            Controls.Add(statusPrincipal);
            Controls.Add(panelLateral);
            Controls.Add(menuStripPrincipal);
            MainMenuStrip = menuStripPrincipal;
            Name = "Form1";
            Text = "Simulador Gravitacional 2D";
            menuStripPrincipal.ResumeLayout(false);
            menuStripPrincipal.PerformLayout();
            panelLateral.ResumeLayout(false);
            statusPrincipal.ResumeLayout(false);
            statusPrincipal.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

#endregion

        private MenuStrip menuStripPrincipal;
        private ToolStripMenuItem menuArquivo;
        private ToolStripMenuItem menuArquivoCarregar;
        private ToolStripMenuItem menuArquivoSalvar;
        private ToolStripMenuItem menuArquivoSair;
        private ToolStripMenuItem menuSimulacao;
        private ToolStripMenuItem menuSimulacaoIniciar;
        private ToolStripMenuItem menuSimulacaoPausar;
        private ToolStripMenuItem menuSimulacaoReiniciar;
        private ToolStripMenuItem menuExibicao;
        private ToolStripMenuItem menuExibicaoTrajetorias;
        private ToolStripMenuItem menuExibicaoVetores;
        private Panel panelLateral;
        private Button btnCarregar;
        private Button btnSalvar;
        private Button btnIniciar;
        private Button btnPausar;
        private StatusStrip statusPrincipal;
        private ToolStripStatusLabel statusInfo;
        private Panel panelSimulacao; // <- corrigido
        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "Form1";
        }

        #endregion
    }
}
