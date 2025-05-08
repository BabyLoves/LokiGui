namespace LokiGui
{
    partial class Form1
    {
        /// <summary>
        /// Variáveis necessárias para os componentes do formulário.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Método necessário para a limpeza de recursos.
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para inicializar os componentes.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            comboBoxSource = new ComboBox();
            comboBoxTarget = new ComboBox();
            btnStartStop = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            menuStrip1 = new MenuStrip();
            geralToolStripMenuItem = new ToolStripMenuItem();
            recarregarDispositivosToolStripMenuItem = new ToolStripMenuItem();
            sobreToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // comboBoxSource
            // 
            comboBoxSource.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSource.FormattingEnabled = true;
            comboBoxSource.Location = new Point(12, 50);
            comboBoxSource.Name = "comboBoxSource";
            comboBoxSource.Size = new Size(260, 23);
            comboBoxSource.TabIndex = 0;
            // 
            // comboBoxTarget
            // 
            comboBoxTarget.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxTarget.FormattingEnabled = true;
            comboBoxTarget.Location = new Point(12, 103);
            comboBoxTarget.Name = "comboBoxTarget";
            comboBoxTarget.Size = new Size(260, 23);
            comboBoxTarget.TabIndex = 1;
            // 
            // btnStartStop
            // 
            btnStartStop.Location = new Point(12, 141);
            btnStartStop.Name = "btnStartStop";
            btnStartStop.Size = new Size(260, 23);
            btnStartStop.TabIndex = 2;
            btnStartStop.Text = "Ativar";
            btnStartStop.UseVisualStyleBackColor = true;
            btnStartStop.Click += btnStartStop_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 259);
            label1.Name = "label1";
            label1.Size = new Size(208, 15);
            label1.TabIndex = 3;
            label1.Text = "Copyright © 2025 Marlon Daniel Jesus";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 85);
            label2.Name = "label2";
            label2.Size = new Size(123, 15);
            label2.TabIndex = 4;
            label2.Text = "Dispositivo de destino";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 32);
            label3.Name = "label3";
            label3.Size = new Size(122, 15);
            label3.TabIndex = 5;
            label3.Text = "Dispositivo de origem";
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.Silver;
            menuStrip1.Items.AddRange(new ToolStripItem[] { geralToolStripMenuItem, sobreToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(279, 24);
            menuStrip1.TabIndex = 6;
            menuStrip1.Text = "menuStrip1";
            // 
            // geralToolStripMenuItem
            // 
            geralToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { recarregarDispositivosToolStripMenuItem });
            geralToolStripMenuItem.ForeColor = SystemColors.ActiveCaptionText;
            geralToolStripMenuItem.Name = "geralToolStripMenuItem";
            geralToolStripMenuItem.Size = new Size(46, 20);
            geralToolStripMenuItem.Text = "Geral";
            // 
            // recarregarDispositivosToolStripMenuItem
            // 
            recarregarDispositivosToolStripMenuItem.Name = "recarregarDispositivosToolStripMenuItem";
            recarregarDispositivosToolStripMenuItem.Size = new Size(195, 22);
            recarregarDispositivosToolStripMenuItem.Text = "Recarregar dispositivos";
            recarregarDispositivosToolStripMenuItem.Click += recarregarDispositivosToolStripMenuItem_Click;
            // 
            // sobreToolStripMenuItem
            // 
            sobreToolStripMenuItem.Name = "sobreToolStripMenuItem";
            sobreToolStripMenuItem.Size = new Size(49, 20);
            sobreToolStripMenuItem.Text = "Sobre";
            sobreToolStripMenuItem.Click += sobreToolStripMenuItem_Click;
            // 
            // Form1
            // 
            ClientSize = new Size(279, 283);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnStartStop);
            Controls.Add(comboBoxTarget);
            Controls.Add(comboBoxSource);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Loki Áudio";
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxSource;
        private System.Windows.Forms.ComboBox comboBoxTarget;
        private System.Windows.Forms.Button btnStartStop;
        private Label label1;
        private Label label2;
        private Label label3;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem geralToolStripMenuItem;
        private ToolStripMenuItem sobreToolStripMenuItem;
        private ToolStripMenuItem recarregarDispositivosToolStripMenuItem;
    }
}
