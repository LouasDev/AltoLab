namespace AltoLab.Forms
{
    partial class FrmDespesas
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
            this.lblBusca = new System.Windows.Forms.Label();
            this.txtBusca = new System.Windows.Forms.TextBox();
            this.grpForm = new System.Windows.Forms.GroupBox();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.cboCategoria = new System.Windows.Forms.ComboBox();
            this.txtCategoriaOutra = new System.Windows.Forms.TextBox();
            this.lblValor = new System.Windows.Forms.Label();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.lblData = new System.Windows.Forms.Label();
            this.dtpData = new System.Windows.Forms.DateTimePicker();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.dgvDespesas = new System.Windows.Forms.DataGridView();
            this.lblResumoGasto = new System.Windows.Forms.Label();
            this.lblResumoGanho = new System.Windows.Forms.Label();
            this.lblResumoSaldo = new System.Windows.Forms.Label();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDataDespesa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDespesas)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTituloTela
            // 
            this.lblTituloTela.AutoSize = true;
            this.lblTituloTela.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTituloTela.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTituloTela.Location = new System.Drawing.Point(20, 15);
            this.lblTituloTela.Name = "lblTituloTela";
            this.lblTituloTela.Size = new System.Drawing.Size(224, 28);
            this.lblTituloTela.TabIndex = 0;
            this.lblTituloTela.Text = "Controle de Despesas";
            // 
            // lblBusca
            // 
            this.lblBusca.AutoSize = true;
            this.lblBusca.Location = new System.Drawing.Point(430, 55);
            this.lblBusca.Name = "lblBusca";
            this.lblBusca.Size = new System.Drawing.Size(219, 17);
            this.lblBusca.TabIndex = 1;
            this.lblBusca.Text = "Buscar por descrição ou categoria:";
            // 
            // txtBusca
            // 
            this.txtBusca.Location = new System.Drawing.Point(649, 51);
            this.txtBusca.Name = "txtBusca";
            this.txtBusca.Size = new System.Drawing.Size(215, 27);
            this.txtBusca.TabIndex = 2;
            this.txtBusca.TextChanged += new System.EventHandler(this.TxtBusca_TextChanged);
            // 
            // grpForm
            // 
            this.grpForm.Controls.Add(this.lblDescricao);
            this.grpForm.Controls.Add(this.txtDescricao);
            this.grpForm.Controls.Add(this.lblCategoria);
            this.grpForm.Controls.Add(this.cboCategoria);
            this.grpForm.Controls.Add(this.txtCategoriaOutra);
            this.grpForm.Controls.Add(this.lblValor);
            this.grpForm.Controls.Add(this.txtValor);
            this.grpForm.Controls.Add(this.lblData);
            this.grpForm.Controls.Add(this.dtpData);
            this.grpForm.Location = new System.Drawing.Point(20, 90);
            this.grpForm.Name = "grpForm";
            this.grpForm.Size = new System.Drawing.Size(360, 260);
            this.grpForm.TabIndex = 3;
            this.grpForm.TabStop = false;
            this.grpForm.Text = "Dados da Despesa";
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(15, 30);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(87, 17);
            this.lblDescricao.TabIndex = 0;
            this.lblDescricao.Text = "Descrição (*):";
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(15, 50);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(325, 27);
            this.txtDescricao.TabIndex = 1;
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Location = new System.Drawing.Point(15, 90);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(68, 17);
            this.lblCategoria.TabIndex = 2;
            this.lblCategoria.Text = "Categoria:";
            // 
            // cboCategoria
            // 
            this.cboCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategoria.FormattingEnabled = true;
            this.cboCategoria.Items.AddRange(new object[] {
            "Fixa",
            "Variável",
            "Compra de peças",
            "Outra"});
            this.cboCategoria.Location = new System.Drawing.Point(15, 110);
            this.cboCategoria.Name = "cboCategoria";
            this.cboCategoria.Size = new System.Drawing.Size(200, 25);
            this.cboCategoria.TabIndex = 3;
            this.cboCategoria.SelectedIndexChanged += new System.EventHandler(this.CboCategoria_SelectedIndexChanged);
            // 
            // txtCategoriaOutra
            // 
            this.txtCategoriaOutra.Location = new System.Drawing.Point(220, 110);
            this.txtCategoriaOutra.Name = "txtCategoriaOutra";
            this.txtCategoriaOutra.Size = new System.Drawing.Size(120, 27);
            this.txtCategoriaOutra.TabIndex = 4;
            this.txtCategoriaOutra.Visible = false;
            // 
            // lblValor
            // 
            this.lblValor.AutoSize = true;
            this.lblValor.Location = new System.Drawing.Point(15, 150);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(97, 17);
            this.lblValor.TabIndex = 5;
            this.lblValor.Text = "Valor (R$) (*):";
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(15, 170);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(160, 27);
            this.txtValor.TabIndex = 6;
            this.txtValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtValor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtValor_KeyPress);
            // 
            // lblData
            // 
            this.lblData.AutoSize = true;
            this.lblData.Location = new System.Drawing.Point(15, 210);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(116, 17);
            this.lblData.TabIndex = 7;
            this.lblData.Text = "Data da Despesa:";
            // 
            // dtpData
            // 
            this.dtpData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpData.Location = new System.Drawing.Point(15, 230);
            this.dtpData.Name = "dtpData";
            this.dtpData.Size = new System.Drawing.Size(160, 27);
            this.dtpData.TabIndex = 8;
            // 
            // btnNovo
            // 
            this.btnNovo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnNovo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNovo.FlatAppearance.BorderSize = 0;
            this.btnNovo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNovo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnNovo.ForeColor = System.Drawing.Color.White;
            this.btnNovo.Location = new System.Drawing.Point(20, 380);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(82, 38);
            this.btnNovo.TabIndex = 9;
            this.btnNovo.Text = "Novo";
            this.btnNovo.UseVisualStyleBackColor = false;
            this.btnNovo.Click += new System.EventHandler(this.BtnNovo_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(165)))), ((int)(((byte)(233)))));
            this.btnSalvar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalvar.FlatAppearance.BorderSize = 0;
            this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnSalvar.ForeColor = System.Drawing.Color.White;
            this.btnSalvar.Location = new System.Drawing.Point(112, 380);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(82, 38);
            this.btnSalvar.TabIndex = 10;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new System.EventHandler(this.BtnSalvar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnExcluir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExcluir.FlatAppearance.BorderSize = 0;
            this.btnExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcluir.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnExcluir.ForeColor = System.Drawing.Color.White;
            this.btnExcluir.Location = new System.Drawing.Point(204, 380);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(82, 38);
            this.btnExcluir.TabIndex = 11;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = false;
            this.btnExcluir.Click += new System.EventHandler(this.BtnExcluir_Click);
            // 
            // btnLimpar
            // 
            this.btnLimpar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpar.Location = new System.Drawing.Point(296, 380);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(84, 38);
            this.btnLimpar.TabIndex = 12;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.BtnLimpar_Click);
            // 
            // dgvDespesas
            // 
            this.dgvDespesas.AllowUserToAddRows = false;
            this.dgvDespesas.AllowUserToDeleteRows = false;
            this.dgvDespesas.BackgroundColor = System.Drawing.Color.White;
            this.dgvDespesas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDespesas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvDespesas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDespesas.ColumnHeadersDefaultCellStyle = this.DataGridViewCellStyle1;
            this.dgvDespesas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colDescricao,
            this.colCategoria,
            this.colValor,
            this.colDataDespesa});
            this.dgvDespesas.DefaultCellStyle = this.DataGridViewCellStyle2;
            this.dgvDespesas.EnableHeadersVisualStyles = false;
            this.dgvDespesas.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.dgvDespesas.Location = new System.Drawing.Point(400, 85);
            this.dgvDespesas.MultiSelect = false;
            this.dgvDespesas.Name = "dgvDespesas";
            this.dgvDespesas.ReadOnly = true;
            this.dgvDespesas.RowHeadersVisible = false;
            this.dgvDespesas.RowTemplate.Height = 32;
            this.dgvDespesas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDespesas.Size = new System.Drawing.Size(464, 363);
            this.dgvDespesas.TabIndex = 8;
            this.dgvDespesas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_CellClick);
            // 
            // lblResumoGasto
            // 
            this.lblResumoGasto.AutoSize = true;
            this.lblResumoGasto.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblResumoGasto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblResumoGasto.Location = new System.Drawing.Point(20, 462);
            this.lblResumoGasto.Name = "lblResumoGasto";
            this.lblResumoGasto.Size = new System.Drawing.Size(170, 17);
            this.lblResumoGasto.TabIndex = 13;
            this.lblResumoGasto.Text = "Total Gasto: R$ 0,00";
            // 
            // lblResumoGanho
            // 
            this.lblResumoGanho.AutoSize = true;
            this.lblResumoGanho.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblResumoGanho.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblResumoGanho.Location = new System.Drawing.Point(20, 488);
            this.lblResumoGanho.Name = "lblResumoGanho";
            this.lblResumoGanho.Size = new System.Drawing.Size(180, 17);
            this.lblResumoGanho.TabIndex = 14;
            this.lblResumoGanho.Text = "Total Ganho (mês): R$ 0,00";
            // 
            // lblResumoSaldo
            // 
            this.lblResumoSaldo.AutoSize = true;
            this.lblResumoSaldo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblResumoSaldo.Location = new System.Drawing.Point(20, 514);
            this.lblResumoSaldo.Name = "lblResumoSaldo";
            this.lblResumoSaldo.Size = new System.Drawing.Size(130, 17);
            this.lblResumoSaldo.TabIndex = 15;
            this.lblResumoSaldo.Text = "Saldo: R$ 0,00";
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
            this.colId.HeaderText = "Código";
            this.colId.Name = "Id";
            this.colId.ReadOnly = true;
            this.colId.Visible = false;
            this.colId.Width = 60;
            // 
            // colDescricao
            // 
            this.colDescricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDescricao.DataPropertyName = "Descricao";
            this.colDescricao.HeaderText = "Descrição";
            this.colDescricao.Name = "Descricao";
            this.colDescricao.ReadOnly = true;
            // 
            // colCategoria
            // 
            this.colCategoria.DataPropertyName = "Categoria";
            this.colCategoria.HeaderText = "Categoria";
            this.colCategoria.Name = "Categoria";
            this.colCategoria.ReadOnly = true;
            this.colCategoria.Width = 120;
            // 
            // colValor
            // 
            this.colValor.DataPropertyName = "Valor";
            this.colValor.DefaultCellStyle = this.DataGridViewCellStyle3;
            this.colValor.HeaderText = "Valor";
            this.colValor.Name = "Valor";
            this.colValor.ReadOnly = true;
            this.colValor.Width = 100;
            // 
            // DataGridViewCellStyle3
            // 
            this.DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.DataGridViewCellStyle3.Format = "C2";
            this.DataGridViewCellStyle3.NullValue = null;
            // 
            // colDataDespesa
            // 
            this.colDataDespesa.DataPropertyName = "DataDespesa";
            this.colDataDespesa.DefaultCellStyle = this.DataGridViewCellStyle4;
            this.colDataDespesa.HeaderText = "Data";
            this.colDataDespesa.Name = "DataDespesa";
            this.colDataDespesa.ReadOnly = true;
            this.colDataDespesa.Width = 130;
            // 
            // DataGridViewCellStyle4
            // 
            this.DataGridViewCellStyle4.Format = "dd/MM/yyyy";
            this.DataGridViewCellStyle4.NullValue = null;
            // 
            // FrmDespesas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(894, 534);
            this.Controls.Add(this.lblTituloTela);
            this.Controls.Add(this.lblBusca);
            this.Controls.Add(this.txtBusca);
            this.Controls.Add(this.grpForm);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.dgvDespesas);
            this.Controls.Add(this.lblResumoGasto);
            this.Controls.Add(this.lblResumoGanho);
            this.Controls.Add(this.lblResumoSaldo);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmDespesas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Controle de Despesas — AltoLab";
            this.Shown += new System.EventHandler(this.FrmDespesas_Shown);
            this.grpForm.ResumeLayout(false);
            this.grpForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDespesas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTituloTela;
        private System.Windows.Forms.Label lblBusca;
        private System.Windows.Forms.TextBox txtBusca;
        private System.Windows.Forms.GroupBox grpForm;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.ComboBox cboCategoria;
        private System.Windows.Forms.TextBox txtCategoriaOutra;
        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.DateTimePicker dtpData;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.DataGridView dgvDespesas;
        private System.Windows.Forms.Label lblResumoGasto;
        private System.Windows.Forms.Label lblResumoGanho;
        private System.Windows.Forms.Label lblResumoSaldo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDataDespesa;
        private System.Windows.Forms.DataGridViewCellStyle DataGridViewCellStyle1;
        private System.Windows.Forms.DataGridViewCellStyle DataGridViewCellStyle2;
        private System.Windows.Forms.DataGridViewCellStyle DataGridViewCellStyle3;
        private System.Windows.Forms.DataGridViewCellStyle DataGridViewCellStyle4;
    }
}
