namespace EnvioFacilServerManager.Src.Forms
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mnStripPrincipal = new System.Windows.Forms.MenuStrip();
            this.arquivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gerenciarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sMSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mercadoPagoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panPrincipal = new System.Windows.Forms.Panel();
            this.tbCtrlPrincipal = new System.Windows.Forms.TabControl();
            this.tabSmsEnvio = new System.Windows.Forms.TabPage();
            this.grdSmsEnvio = new System.Windows.Forms.DataGridView();
            this.grdSmsEnvio_ColStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grdSmsEnvio_ColCodigoDestinatario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grdSmsEnvio_ColNumMensagens = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grdSmsEnvio_CodLote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grdSmsEnvio_DataCadastro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grdSmsEnvio_DataAgendamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panCabecalhoSmsEnvio = new System.Windows.Forms.Panel();
            this.lblSmsEnvio_Status = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabSmsRetorno = new System.Windows.Forms.TabPage();
            this.panCabecalhoPrincipal = new System.Windows.Forms.Panel();
            this.panCabecalho_SaldoGeral = new System.Windows.Forms.Panel();
            this.lblDscSaldoGeral = new System.Windows.Forms.Label();
            this.lblSaldoGeral = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.mnStripPrincipal.SuspendLayout();
            this.panPrincipal.SuspendLayout();
            this.tbCtrlPrincipal.SuspendLayout();
            this.tabSmsEnvio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSmsEnvio)).BeginInit();
            this.panCabecalhoSmsEnvio.SuspendLayout();
            this.panCabecalhoPrincipal.SuspendLayout();
            this.panCabecalho_SaldoGeral.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnStripPrincipal
            // 
            this.mnStripPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arquivoToolStripMenuItem,
            this.gerenciarToolStripMenuItem});
            this.mnStripPrincipal.Location = new System.Drawing.Point(0, 0);
            this.mnStripPrincipal.Name = "mnStripPrincipal";
            this.mnStripPrincipal.Size = new System.Drawing.Size(864, 24);
            this.mnStripPrincipal.TabIndex = 0;
            this.mnStripPrincipal.Text = "menuStrip1";
            // 
            // arquivoToolStripMenuItem
            // 
            this.arquivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sairToolStripMenuItem});
            this.arquivoToolStripMenuItem.Name = "arquivoToolStripMenuItem";
            this.arquivoToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.arquivoToolStripMenuItem.Text = "Arquivo";
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            this.sairToolStripMenuItem.Text = "Sair";
            // 
            // gerenciarToolStripMenuItem
            // 
            this.gerenciarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sMSToolStripMenuItem,
            this.emailToolStripMenuItem,
            this.mercadoPagoToolStripMenuItem});
            this.gerenciarToolStripMenuItem.Name = "gerenciarToolStripMenuItem";
            this.gerenciarToolStripMenuItem.Size = new System.Drawing.Size(128, 20);
            this.gerenciarToolStripMenuItem.Text = "Gerenciadores ativos";
            // 
            // sMSToolStripMenuItem
            // 
            this.sMSToolStripMenuItem.Checked = true;
            this.sMSToolStripMenuItem.CheckOnClick = true;
            this.sMSToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.sMSToolStripMenuItem.Name = "sMSToolStripMenuItem";
            this.sMSToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.sMSToolStripMenuItem.Text = "SMS";
            // 
            // emailToolStripMenuItem
            // 
            this.emailToolStripMenuItem.Checked = true;
            this.emailToolStripMenuItem.CheckOnClick = true;
            this.emailToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.emailToolStripMenuItem.Name = "emailToolStripMenuItem";
            this.emailToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.emailToolStripMenuItem.Text = "E-mail";
            // 
            // mercadoPagoToolStripMenuItem
            // 
            this.mercadoPagoToolStripMenuItem.Checked = true;
            this.mercadoPagoToolStripMenuItem.CheckOnClick = true;
            this.mercadoPagoToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mercadoPagoToolStripMenuItem.Name = "mercadoPagoToolStripMenuItem";
            this.mercadoPagoToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.mercadoPagoToolStripMenuItem.Text = "Mercado Pago";
            // 
            // panPrincipal
            // 
            this.panPrincipal.Controls.Add(this.tbCtrlPrincipal);
            this.panPrincipal.Controls.Add(this.panCabecalhoPrincipal);
            this.panPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panPrincipal.Location = new System.Drawing.Point(0, 24);
            this.panPrincipal.Name = "panPrincipal";
            this.panPrincipal.Size = new System.Drawing.Size(864, 520);
            this.panPrincipal.TabIndex = 4;
            // 
            // tbCtrlPrincipal
            // 
            this.tbCtrlPrincipal.Controls.Add(this.tabSmsEnvio);
            this.tbCtrlPrincipal.Controls.Add(this.tabSmsRetorno);
            this.tbCtrlPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbCtrlPrincipal.Location = new System.Drawing.Point(0, 39);
            this.tbCtrlPrincipal.Name = "tbCtrlPrincipal";
            this.tbCtrlPrincipal.SelectedIndex = 0;
            this.tbCtrlPrincipal.Size = new System.Drawing.Size(864, 481);
            this.tbCtrlPrincipal.TabIndex = 4;
            // 
            // tabSmsEnvio
            // 
            this.tabSmsEnvio.Controls.Add(this.grdSmsEnvio);
            this.tabSmsEnvio.Controls.Add(this.panCabecalhoSmsEnvio);
            this.tabSmsEnvio.Location = new System.Drawing.Point(4, 22);
            this.tabSmsEnvio.Name = "tabSmsEnvio";
            this.tabSmsEnvio.Padding = new System.Windows.Forms.Padding(3);
            this.tabSmsEnvio.Size = new System.Drawing.Size(856, 455);
            this.tabSmsEnvio.TabIndex = 0;
            this.tabSmsEnvio.Text = "SMS [envio]";
            this.tabSmsEnvio.UseVisualStyleBackColor = true;
            // 
            // grdSmsEnvio
            // 
            this.grdSmsEnvio.AllowUserToAddRows = false;
            this.grdSmsEnvio.AllowUserToDeleteRows = false;
            this.grdSmsEnvio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdSmsEnvio.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.grdSmsEnvio_ColStatus,
            this.grdSmsEnvio_ColCodigoDestinatario,
            this.grdSmsEnvio_ColNumMensagens,
            this.grdSmsEnvio_CodLote,
            this.grdSmsEnvio_DataCadastro,
            this.grdSmsEnvio_DataAgendamento});
            this.grdSmsEnvio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdSmsEnvio.Location = new System.Drawing.Point(3, 72);
            this.grdSmsEnvio.Name = "grdSmsEnvio";
            this.grdSmsEnvio.ReadOnly = true;
            this.grdSmsEnvio.Size = new System.Drawing.Size(850, 380);
            this.grdSmsEnvio.TabIndex = 1;
            // 
            // grdSmsEnvio_ColStatus
            // 
            this.grdSmsEnvio_ColStatus.HeaderText = "Status";
            this.grdSmsEnvio_ColStatus.Name = "grdSmsEnvio_ColStatus";
            this.grdSmsEnvio_ColStatus.ReadOnly = true;
            // 
            // grdSmsEnvio_ColCodigoDestinatario
            // 
            this.grdSmsEnvio_ColCodigoDestinatario.HeaderText = "Cód. destinatário";
            this.grdSmsEnvio_ColCodigoDestinatario.Name = "grdSmsEnvio_ColCodigoDestinatario";
            this.grdSmsEnvio_ColCodigoDestinatario.ReadOnly = true;
            this.grdSmsEnvio_ColCodigoDestinatario.Width = 132;
            // 
            // grdSmsEnvio_ColNumMensagens
            // 
            this.grdSmsEnvio_ColNumMensagens.HeaderText = "Nº mensagens";
            this.grdSmsEnvio_ColNumMensagens.Name = "grdSmsEnvio_ColNumMensagens";
            this.grdSmsEnvio_ColNumMensagens.ReadOnly = true;
            // 
            // grdSmsEnvio_CodLote
            // 
            this.grdSmsEnvio_CodLote.HeaderText = "Cód. lote";
            this.grdSmsEnvio_CodLote.Name = "grdSmsEnvio_CodLote";
            this.grdSmsEnvio_CodLote.ReadOnly = true;
            // 
            // grdSmsEnvio_DataCadastro
            // 
            this.grdSmsEnvio_DataCadastro.HeaderText = "Data cadastro";
            this.grdSmsEnvio_DataCadastro.Name = "grdSmsEnvio_DataCadastro";
            this.grdSmsEnvio_DataCadastro.ReadOnly = true;
            this.grdSmsEnvio_DataCadastro.Width = 132;
            // 
            // grdSmsEnvio_DataAgendamento
            // 
            this.grdSmsEnvio_DataAgendamento.HeaderText = "Data agendamento";
            this.grdSmsEnvio_DataAgendamento.Name = "grdSmsEnvio_DataAgendamento";
            this.grdSmsEnvio_DataAgendamento.ReadOnly = true;
            this.grdSmsEnvio_DataAgendamento.Width = 132;
            // 
            // panCabecalhoSmsEnvio
            // 
            this.panCabecalhoSmsEnvio.BackColor = System.Drawing.Color.Azure;
            this.panCabecalhoSmsEnvio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panCabecalhoSmsEnvio.Controls.Add(this.lblSmsEnvio_Status);
            this.panCabecalhoSmsEnvio.Controls.Add(this.label3);
            this.panCabecalhoSmsEnvio.Controls.Add(this.label2);
            this.panCabecalhoSmsEnvio.Dock = System.Windows.Forms.DockStyle.Top;
            this.panCabecalhoSmsEnvio.Location = new System.Drawing.Point(3, 3);
            this.panCabecalhoSmsEnvio.Name = "panCabecalhoSmsEnvio";
            this.panCabecalhoSmsEnvio.Size = new System.Drawing.Size(850, 69);
            this.panCabecalhoSmsEnvio.TabIndex = 0;
            // 
            // lblSmsEnvio_Status
            // 
            this.lblSmsEnvio_Status.AutoSize = true;
            this.lblSmsEnvio_Status.Location = new System.Drawing.Point(50, 10);
            this.lblSmsEnvio_Status.Name = "lblSmsEnvio_Status";
            this.lblSmsEnvio_Status.Size = new System.Drawing.Size(61, 13);
            this.lblSmsEnvio_Status.TabIndex = 2;
            this.lblSmsEnvio_Status.Text = "Desativado";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Próxima verificação:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Status:";
            // 
            // tabSmsRetorno
            // 
            this.tabSmsRetorno.Location = new System.Drawing.Point(4, 22);
            this.tabSmsRetorno.Name = "tabSmsRetorno";
            this.tabSmsRetorno.Padding = new System.Windows.Forms.Padding(3);
            this.tabSmsRetorno.Size = new System.Drawing.Size(733, 325);
            this.tabSmsRetorno.TabIndex = 1;
            this.tabSmsRetorno.Text = "SMS [retorno]";
            this.tabSmsRetorno.UseVisualStyleBackColor = true;
            // 
            // panCabecalhoPrincipal
            // 
            this.panCabecalhoPrincipal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panCabecalhoPrincipal.Controls.Add(this.panCabecalho_SaldoGeral);
            this.panCabecalhoPrincipal.Controls.Add(this.label1);
            this.panCabecalhoPrincipal.Dock = System.Windows.Forms.DockStyle.Top;
            this.panCabecalhoPrincipal.Location = new System.Drawing.Point(0, 0);
            this.panCabecalhoPrincipal.Name = "panCabecalhoPrincipal";
            this.panCabecalhoPrincipal.Size = new System.Drawing.Size(864, 39);
            this.panCabecalhoPrincipal.TabIndex = 2;
            // 
            // panCabecalho_SaldoGeral
            // 
            this.panCabecalho_SaldoGeral.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panCabecalho_SaldoGeral.Controls.Add(this.lblDscSaldoGeral);
            this.panCabecalho_SaldoGeral.Controls.Add(this.lblSaldoGeral);
            this.panCabecalho_SaldoGeral.Dock = System.Windows.Forms.DockStyle.Right;
            this.panCabecalho_SaldoGeral.Location = new System.Drawing.Point(741, 0);
            this.panCabecalho_SaldoGeral.Name = "panCabecalho_SaldoGeral";
            this.panCabecalho_SaldoGeral.Size = new System.Drawing.Size(123, 39);
            this.panCabecalho_SaldoGeral.TabIndex = 3;
            // 
            // lblDscSaldoGeral
            // 
            this.lblDscSaldoGeral.AutoSize = true;
            this.lblDscSaldoGeral.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDscSaldoGeral.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblDscSaldoGeral.Location = new System.Drawing.Point(3, 0);
            this.lblDscSaldoGeral.Name = "lblDscSaldoGeral";
            this.lblDscSaldoGeral.Size = new System.Drawing.Size(34, 13);
            this.lblDscSaldoGeral.TabIndex = 2;
            this.lblDscSaldoGeral.Text = "Saldo";
            // 
            // lblSaldoGeral
            // 
            this.lblSaldoGeral.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaldoGeral.ForeColor = System.Drawing.Color.Green;
            this.lblSaldoGeral.Location = new System.Drawing.Point(6, 10);
            this.lblSaldoGeral.Name = "lblSaldoGeral";
            this.lblSaldoGeral.Size = new System.Drawing.Size(112, 23);
            this.lblSaldoGeral.TabIndex = 1;
            this.lblSaldoGeral.Text = "...";
            this.lblSaldoGeral.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(864, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Gerenciador do EnvioFácil";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 544);
            this.Controls.Add(this.panPrincipal);
            this.Controls.Add(this.mnStripPrincipal);
            this.MainMenuStrip = this.mnStripPrincipal;
            this.Name = "frmPrincipal";
            this.Text = "frmPrincipal";
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.mnStripPrincipal.ResumeLayout(false);
            this.mnStripPrincipal.PerformLayout();
            this.panPrincipal.ResumeLayout(false);
            this.tbCtrlPrincipal.ResumeLayout(false);
            this.tabSmsEnvio.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSmsEnvio)).EndInit();
            this.panCabecalhoSmsEnvio.ResumeLayout(false);
            this.panCabecalhoSmsEnvio.PerformLayout();
            this.panCabecalhoPrincipal.ResumeLayout(false);
            this.panCabecalho_SaldoGeral.ResumeLayout(false);
            this.panCabecalho_SaldoGeral.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnStripPrincipal;
        private System.Windows.Forms.ToolStripMenuItem arquivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gerenciarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sMSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem emailToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mercadoPagoToolStripMenuItem;
        private System.Windows.Forms.Panel panPrincipal;
        private System.Windows.Forms.TabControl tbCtrlPrincipal;
        private System.Windows.Forms.TabPage tabSmsEnvio;
        private System.Windows.Forms.DataGridView grdSmsEnvio;
        private System.Windows.Forms.Panel panCabecalhoSmsEnvio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabSmsRetorno;
        private System.Windows.Forms.Panel panCabecalhoPrincipal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn grdSmsEnvio_ColStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn grdSmsEnvio_ColCodigoDestinatario;
        private System.Windows.Forms.DataGridViewTextBoxColumn grdSmsEnvio_ColNumMensagens;
        private System.Windows.Forms.DataGridViewTextBoxColumn grdSmsEnvio_CodLote;
        private System.Windows.Forms.DataGridViewTextBoxColumn grdSmsEnvio_DataCadastro;
        private System.Windows.Forms.DataGridViewTextBoxColumn grdSmsEnvio_DataAgendamento;
        private System.Windows.Forms.Label lblSmsEnvio_Status;
        private System.Windows.Forms.Panel panCabecalho_SaldoGeral;
        private System.Windows.Forms.Label lblSaldoGeral;
        private System.Windows.Forms.Label lblDscSaldoGeral;
    }
}