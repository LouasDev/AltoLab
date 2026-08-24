namespace AltoLab.Forms
{
    partial class FrmConsultaOS
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
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
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.DataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTituloTela = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.chkPeriodo = new System.Windows.Forms.CheckBox();
            this.dtpInicial = new System.Windows.Forms.DateTimePicker();
            this.lblAte = new System.Windows.Forms.Label();
            this.dtpFinal = new System.Windows.Forms.DateTimePicker();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.btnLimparFiltros = new System.Windows.Forms.Button();
            this.dgvOrdensServico = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClienteNome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEquipamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDataAbertura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValorTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEditar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdensServico)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTituloTela
            // 
            this.lblTituloTela.AutoSize = true;
            this.lblTituloTela.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTituloTela.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTituloTela.Location = new System.Drawing.Point(20, 15);
            this.lblTituloTela.Name = "lblTituloTela";
            this.lblTituloTela.Size = new System.Drawing.Size(321, 28);
            this.lblTituloTela.TabIndex = 0;
            this.lblTituloTela.Text = "Consulta de Ordens de Serviço";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(25, 62);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(46, 17);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "Status:";
            // 
            // cboStatus
            // 
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Items.AddRange(new object[] {
            "Todos",
            "Aberta",
            "Em andamento",
            "Concluída",
            "Entregue"});
            this.cboStatus.Location = new System.Drawing.Point(70, 58);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.SelectedIndex = 0;
            this.cboStatus.Size = new System.Drawing.Size(150, 24);
            this.cboStatus.TabIndex = 2;
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(240, 62);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(51, 17);
            this.lblCliente.TabIndex = 3;
            this.lblCliente.Text = "Cliente:";
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(290, 58);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(180, 27);
            this.txtCliente.TabIndex = 4;
            // 
            // chkPeriodo
            // 
            this.chkPeriodo.AutoSize = true;
            this.chkPeriodo.Location = new System.Drawing.Point(490, 61);
            this.chkPeriodo.Name = "chkPeriodo";
            this.chkPeriodo.Size = new System.Drawing.Size(68, 21);
            this.chkPeriodo.TabIndex = 5;
            this.chkPeriodo.Text = "Período:";
            this.chkPeriodo.CheckedChanged += new System.EventHandler(this.ChkPeriodo_CheckedChanged);
            // 
            // dtpInicial
            // 
            this.dtpInicial.Location = new System.Drawing.Point(555, 58);
            this.dtpInicial.Enabled = false;
            this.dtpInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInicial.Name = "dtpInicial";
            this.dtpInicial.Size = new System.Drawing.Size(110, 27);
            this.dtpInicial.TabIndex = 6;
            // 
            // lblAte
            // 
            this.lblAte.AutoSize = true;
            this.lblAte.Location = new System.Drawing.Point(670, 62);
            this.lblAte.Name = "lblAte";
            this.lblAte.Size = new System.Drawing.Size(25, 17);
            this.lblAte.TabIndex = 7;
            this.lblAte.Text = "até";
            // 
            // dtpFinal
            // 
            this.dtpFinal.Enabled = false;
            this.dtpFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFinal.Location = new System.Drawing.Point(700, 58);
            this.dtpFinal.Name = "dtpFinal";
            this.dtpFinal.Size = new System.Drawing.Size(110, 27);
            this.dtpFinal.TabIndex = 8;
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(165)))), ((int)(((byte)(233)))));
            this.btnFiltrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFiltrar.FlatAppearance.BorderSize = 0;
            this.btnFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltrar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnFiltrar.ForeColor = System.Drawing.Color.White;
            this.btnFiltrar.Location = new System.Drawing.Point(830, 53);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(90, 34);
            this.btnFiltrar.TabIndex = 9;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = false;
            this.btnFiltrar.Click += new System.EventHandler(this.BtnFiltrar_Click);
            // 
            // btnLimparFiltros
            // 
            this.btnLimparFiltros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimparFiltros.Location = new System.Drawing.Point(20, 95);
            this.btnLimparFiltros.Name = "btnLimparFiltros";
            this.btnLimparFiltros.Size = new System.Drawing.Size(130, 32);
            this.btnLimparFiltros.TabIndex = 10;
            this.btnLimparFiltros.Text = "Limpar Filtros";
            this.btnLimparFiltros.UseVisualStyleBackColor = true;
            this.btnLimparFiltros.Click += new System.EventHandler(this.BtnLimparFiltros_Click);
            // 
            // dgvOrdensServico
            // 
            this.dgvOrdensServico.AllowUserToAddRows = false;
            this.dgvOrdensServico.AllowUserToDeleteRows = false;
            this.dgvOrdensServico.BackgroundColor = System.Drawing.Color.White;
            this.dgvOrdensServico.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvOrdensServico.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvOrdensServico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvOrdensServico.ColumnHeadersDefaultCellStyle = this.DataGridViewCellStyle1;
            this.dgvOrdensServico.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colClienteNome,
            this.colEquipamento,
            this.colStatus,
            this.colDataAbertura,
            this.colValorTotal});
            this.dgvOrdensServico.DefaultCellStyle = this.DataGridViewCellStyle2;
            this.dgvOrdensServico.EnableHeadersVisualStyles = false;
            this.dgvOrdensServico.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.dgvOrdensServico.Location = new System.Drawing.Point(20, 135);
            this.dgvOrdensServico.MultiSelect = false;
            this.dgvOrdensServico.Name = "dgvOrdensServico";
            this.dgvOrdensServico.ReadOnly = true;
            this.dgvOrdensServico.RowHeadersVisible = false;
            this.dgvOrdensServico.RowTemplate.Height = 32;
            this.dgvOrdensServico.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrdensServico.Size = new System.Drawing.Size(944, 330);
            this.dgvOrdensServico.TabIndex = 11;
            this.dgvOrdensServico.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_CellDoubleClick);
            // 
            // DataGridViewCellStyle1
            // 
            this.DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.DataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            // 
            // DataGridViewCellStyle2
            // 
            this.DataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.DataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(242)))), ((int)(((byte)(254)))));
            this.DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            // 
            // colId
            // 
            this.colId.DataPropertyName = "Id";
            this.colId.HeaderText = "Nº OS";
            this.colId.Name = "Id";
            this.colId.ReadOnly = true;
            this.colId.Width = 60;
            // 
            // colClienteNome
            // 
            this.colClienteNome.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colClienteNome.DataPropertyName = "ClienteNome";
            this.colClienteNome.HeaderText = "Cliente";
            this.colClienteNome.Name = "ClienteNome";
            this.colClienteNome.ReadOnly = true;
            // 
            // colEquipamento
            // 
            this.colEquipamento.DataPropertyName = "Equipamento";
            this.colEquipamento.HeaderText = "Equipamento";
            this.colEquipamento.Name = "Equipamento";
            this.colEquipamento.ReadOnly = true;
            this.colEquipamento.Width = 200;
            // 
            // colStatus
            // 
            this.colStatus.DataPropertyName = "Status";
            this.colStatus.HeaderText = "Status";
            this.colStatus.Name = "Status";
            this.colStatus.ReadOnly = true;
            this.colStatus.Width = 120;
            // 
            // colDataAbertura
            // 
            this.colDataAbertura.DataPropertyName = "DataAbertura";
            this.colDataAbertura.DefaultCellStyle = this.DataGridViewCellStyle3;
            this.colDataAbertura.HeaderText = "Abertura";
            this.colDataAbertura.Name = "DataAbertura";
            this.colDataAbertura.ReadOnly = true;
            this.colDataAbertura.Width = 110;
            // 
            // DataGridViewCellStyle3
            // 
            this.DataGridViewCellStyle3.Format = "dd/MM/yyyy HH:mm";
            this.DataGridViewCellStyle3.NullValue = null;
            // 
            // colValorTotal
            // 
            this.colValorTotal.DataPropertyName = "ValorTotal";
            this.colValorTotal.DefaultCellStyle = this.DataGridViewCellStyle4;
            this.colValorTotal.HeaderText = "Valor Total";
            this.colValorTotal.Name = "ValorTotal";
            this.colValorTotal.ReadOnly = true;
            this.colValorTotal.Width = 110;
            // 
            // DataGridViewCellStyle4
            // 
            this.DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.DataGridViewCellStyle4.Format = "C2";
            this.DataGridViewCellStyle4.NullValue = null;
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(165)))), ((int)(((byte)(233)))));
            this.btnEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditar.FlatAppearance.BorderSize = 0;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnEditar.ForeColor = System.Drawing.Color.White;
            this.btnEditar.Location = new System.Drawing.Point(740, 480);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(224, 42);
            this.btnEditar.TabIndex = 12;
            this.btnEditar.Text = "EDITAR OS SELECIONADA";
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.BtnEditar_Click);
            // 
            // FrmConsultaOS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(994, 574);
            this.Controls.Add(this.lblTituloTela);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.cboStatus);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.chkPeriodo);
            this.Controls.Add(this.dtpInicial);
            this.Controls.Add(this.lblAte);
            this.Controls.Add(this.dtpFinal);
            this.Controls.Add(this.btnFiltrar);
            this.Controls.Add(this.btnLimparFiltros);
            this.Controls.Add(this.dgvOrdensServico);
            this.Controls.Add(this.btnEditar);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmConsultaOS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta de Ordens de Serviço — AltoLab";
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdensServico)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTituloTela;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.CheckBox chkPeriodo;
        private System.Windows.Forms.DateTimePicker dtpInicial;
        private System.Windows.Forms.Label lblAte;
        private System.Windows.Forms.DateTimePicker dtpFinal;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Button btnLimparFiltros;
        private System.Windows.Forms.DataGridView dgvOrdensServico;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClienteNome;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEquipamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDataAbertura;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValorTotal;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.DataGridViewCellStyle DataGridViewCellStyle1;
        private System.Windows.Forms.DataGridViewCellStyle DataGridViewCellStyle2;
        private System.Windows.Forms.DataGridViewCellStyle DataGridViewCellStyle3;
        private System.Windows.Forms.DataGridViewCellStyle DataGridViewCellStyle4;
    }
}
