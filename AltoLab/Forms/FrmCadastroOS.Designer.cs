namespace AltoLab.Forms
{
    partial class FrmCadastroOS
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
            this.lblTituloTela = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.cboCliente = new System.Windows.Forms.ComboBox();
            this.lblEquipamento = new System.Windows.Forms.Label();
            this.txtEquipamento = new System.Windows.Forms.TextBox();
            this.lblProblema = new System.Windows.Forms.Label();
            this.txtProblema = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.grpItens = new System.Windows.Forms.GroupBox();
            this.lblServico = new System.Windows.Forms.Label();
            this.cboServico = new System.Windows.Forms.ComboBox();
            this.lblValorServico = new System.Windows.Forms.Label();
            this.txtValorServico = new System.Windows.Forms.TextBox();
            this.btnAdicionarItem = new System.Windows.Forms.Button();
            this.btnRemoverItem = new System.Windows.Forms.Button();
            this.dgvItensOS = new System.Windows.Forms.DataGridView();
            this.colServicoId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.grpItens.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItensOS)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTituloTela
            // 
            this.lblTituloTela.AutoSize = true;
            this.lblTituloTela.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTituloTela.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTituloTela.Location = new System.Drawing.Point(20, 15);
            this.lblTituloTela.Name = "lblTituloTela";
            this.lblTituloTela.Size = new System.Drawing.Size(227, 28);
            this.lblTituloTela.TabIndex = 0;
            this.lblTituloTela.Text = "Nova Ordem de Serviço";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(25, 60);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(77, 17);
            this.lblCliente.TabIndex = 1;
            this.lblCliente.Text = "Cliente (*):";
            // 
            // cboCliente
            // 
            this.cboCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCliente.FormattingEnabled = true;
            this.cboCliente.Location = new System.Drawing.Point(25, 80);
            this.cboCliente.Name = "cboCliente";
            this.cboCliente.Size = new System.Drawing.Size(400, 25);
            this.cboCliente.TabIndex = 2;
            // 
            // lblEquipamento
            // 
            this.lblEquipamento.AutoSize = true;
            this.lblEquipamento.Location = new System.Drawing.Point(25, 120);
            this.lblEquipamento.Name = "lblEquipamento";
            this.lblEquipamento.Size = new System.Drawing.Size(113, 17);
            this.lblEquipamento.TabIndex = 3;
            this.lblEquipamento.Text = "Equipamento (*):";
            // 
            // txtEquipamento
            // 
            this.txtEquipamento.Location = new System.Drawing.Point(25, 140);
            this.txtEquipamento.Name = "txtEquipamento";
            this.txtEquipamento.Size = new System.Drawing.Size(400, 27);
            this.txtEquipamento.TabIndex = 4;
            // 
            // lblProblema
            // 
            this.lblProblema.AutoSize = true;
            this.lblProblema.Location = new System.Drawing.Point(25, 180);
            this.lblProblema.Name = "lblProblema";
            this.lblProblema.Size = new System.Drawing.Size(148, 17);
            this.lblProblema.TabIndex = 5;
            this.lblProblema.Text = "Problema Relatado (*):";
            // 
            // txtProblema
            // 
            this.txtProblema.Location = new System.Drawing.Point(25, 200);
            this.txtProblema.Multiline = true;
            this.txtProblema.Name = "txtProblema";
            this.txtProblema.Size = new System.Drawing.Size(400, 70);
            this.txtProblema.TabIndex = 6;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(25, 285);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(46, 17);
            this.lblStatus.TabIndex = 7;
            this.lblStatus.Text = "Status:";
            // 
            // cboStatus
            // 
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Items.AddRange(new object[] {
            "Aberta",
            "Em andamento",
            "Concluída",
            "Entregue"});
            this.cboStatus.Location = new System.Drawing.Point(25, 305);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.SelectedIndex = 0;
            this.cboStatus.Size = new System.Drawing.Size(200, 25);
            this.cboStatus.TabIndex = 8;
            this.cboStatus.SelectedIndexChanged += new System.EventHandler(this.CboStatus_SelectedIndexChanged);
            // 
            // grpItens
            // 
            this.grpItens.Controls.Add(this.lblServico);
            this.grpItens.Controls.Add(this.cboServico);
            this.grpItens.Controls.Add(this.lblValorServico);
            this.grpItens.Controls.Add(this.txtValorServico);
            this.grpItens.Controls.Add(this.btnAdicionarItem);
            this.grpItens.Controls.Add(this.btnRemoverItem);
            this.grpItens.Location = new System.Drawing.Point(450, 50);
            this.grpItens.Name = "grpItens";
            this.grpItens.Size = new System.Drawing.Size(440, 160);
            this.grpItens.TabIndex = 9;
            this.grpItens.TabStop = false;
            this.grpItens.Text = "Serviços da OS";
            // 
            // lblServico
            // 
            this.lblServico.AutoSize = true;
            this.lblServico.Location = new System.Drawing.Point(15, 28);
            this.lblServico.Name = "lblServico";
            this.lblServico.Size = new System.Drawing.Size(52, 17);
            this.lblServico.TabIndex = 0;
            this.lblServico.Text = "Serviço:";
            // 
            // cboServico
            // 
            this.cboServico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboServico.FormattingEnabled = true;
            this.cboServico.Location = new System.Drawing.Point(15, 48);
            this.cboServico.Name = "cboServico";
            this.cboServico.Size = new System.Drawing.Size(300, 25);
            this.cboServico.TabIndex = 1;
            this.cboServico.SelectedIndexChanged += new System.EventHandler(this.CboServico_SelectedIndexChanged);
            // 
            // lblValorServico
            // 
            this.lblValorServico.AutoSize = true;
            this.lblValorServico.Location = new System.Drawing.Point(325, 32);
            this.lblValorServico.Name = "lblValorServico";
            this.lblValorServico.Size = new System.Drawing.Size(74, 17);
            this.lblValorServico.TabIndex = 2;
            this.lblValorServico.Text = "Valor (R$):";
            // 
            // txtValorServico
            // 
            this.txtValorServico.Location = new System.Drawing.Point(325, 48);
            this.txtValorServico.Name = "txtValorServico";
            this.txtValorServico.Size = new System.Drawing.Size(95, 27);
            this.txtValorServico.TabIndex = 3;
            this.txtValorServico.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtValorServico.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtValorServico_KeyPress);
            // 
            // btnAdicionarItem
            // 
            this.btnAdicionarItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(165)))), ((int)(((byte)(233)))));
            this.btnAdicionarItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdicionarItem.FlatAppearance.BorderSize = 0;
            this.btnAdicionarItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdicionarItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnAdicionarItem.ForeColor = System.Drawing.Color.White;
            this.btnAdicionarItem.Location = new System.Drawing.Point(15, 88);
            this.btnAdicionarItem.Name = "btnAdicionarItem";
            this.btnAdicionarItem.Size = new System.Drawing.Size(130, 34);
            this.btnAdicionarItem.TabIndex = 4;
            this.btnAdicionarItem.Text = "+ Adicionar";
            this.btnAdicionarItem.UseVisualStyleBackColor = false;
            this.btnAdicionarItem.Click += new System.EventHandler(this.BtnAdicionarItem_Click);
            // 
            // btnRemoverItem
            // 
            this.btnRemoverItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnRemoverItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemoverItem.FlatAppearance.BorderSize = 0;
            this.btnRemoverItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoverItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnRemoverItem.ForeColor = System.Drawing.Color.White;
            this.btnRemoverItem.Location = new System.Drawing.Point(155, 88);
            this.btnRemoverItem.Name = "btnRemoverItem";
            this.btnRemoverItem.Size = new System.Drawing.Size(190, 34);
            this.btnRemoverItem.TabIndex = 5;
            this.btnRemoverItem.Text = "- Remover Selecionado";
            this.btnRemoverItem.UseVisualStyleBackColor = false;
            this.btnRemoverItem.Click += new System.EventHandler(this.BtnRemoverItem_Click);
            // 
            // dgvItensOS
            // 
            this.dgvItensOS.AllowUserToAddRows = false;
            this.dgvItensOS.AllowUserToDeleteRows = false;
            this.dgvItensOS.BackgroundColor = System.Drawing.Color.White;
            this.dgvItensOS.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvItensOS.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvItensOS.ColumnHeadersDefaultCellStyle = this.DataGridViewCellStyle1;
            this.dgvItensOS.ColumnHeadersHeight = 35;
            this.dgvItensOS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvItensOS.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colServicoId,
            this.colDescricao,
            this.colValor});
            this.dgvItensOS.DefaultCellStyle = this.DataGridViewCellStyle2;
            this.dgvItensOS.EnableHeadersVisualStyles = false;
            this.dgvItensOS.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.dgvItensOS.Location = new System.Drawing.Point(450, 220);
            this.dgvItensOS.MultiSelect = false;
            this.dgvItensOS.Name = "dgvItensOS";
            this.dgvItensOS.ReadOnly = true;
            this.dgvItensOS.RowHeadersVisible = false;
            this.dgvItensOS.RowTemplate.Height = 32;
            this.dgvItensOS.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItensOS.Size = new System.Drawing.Size(440, 170);
            this.dgvItensOS.TabIndex = 10;
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
            // colServicoId
            // 
            this.colServicoId.DataPropertyName = "ServicoId";
            this.colServicoId.HeaderText = "ServicoId";
            this.colServicoId.Name = "ServicoId";
            this.colServicoId.ReadOnly = true;
            this.colServicoId.Visible = false;
            // 
            // colDescricao
            // 
            this.colDescricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDescricao.DataPropertyName = "Descricao";
            this.colDescricao.HeaderText = "Serviço";
            this.colDescricao.Name = "Descricao";
            this.colDescricao.ReadOnly = true;
            // 
            // colValor
            // 
            this.colValor.DataPropertyName = "Valor";
            this.colValor.DefaultCellStyle = this.DataGridViewCellStyle3;
            this.colValor.HeaderText = "Valor";
            this.colValor.Name = "Valor";
            this.colValor.ReadOnly = true;
            this.colValor.Width = 120;
            // 
            // DataGridViewCellStyle3
            // 
            this.DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.DataGridViewCellStyle3.Format = "C2";
            this.DataGridViewCellStyle3.NullValue = null;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = false;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(165)))), ((int)(((byte)(233)))));
            this.lblTotal.Location = new System.Drawing.Point(450, 400);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(440, 30);
            this.lblTotal.TabIndex = 11;
            this.lblTotal.Text = "VALOR TOTAL: R$ 0,00";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSalvar
            // 
            this.btnSalvar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(165)))), ((int)(((byte)(233)))));
            this.btnSalvar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalvar.FlatAppearance.BorderSize = 0;
            this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnSalvar.ForeColor = System.Drawing.Color.White;
            this.btnSalvar.Location = new System.Drawing.Point(450, 445);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(440, 46);
            this.btnSalvar.TabIndex = 12;
            this.btnSalvar.Text = "SALVAR ORDEM DE SERVIÇO";
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new System.EventHandler(this.BtnSalvar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(25, 510);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(200, 42);
            this.btnCancelar.TabIndex = 13;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // FrmCadastroOS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(914, 594);
            this.Controls.Add(this.lblTituloTela);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.cboCliente);
            this.Controls.Add(this.lblEquipamento);
            this.Controls.Add(this.txtEquipamento);
            this.Controls.Add(this.lblProblema);
            this.Controls.Add(this.txtProblema);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.cboStatus);
            this.Controls.Add(this.grpItens);
            this.Controls.Add(this.dgvItensOS);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnCancelar);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmCadastroOS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nova Ordem de Serviço — AltoLab";
            this.grpItens.ResumeLayout(false);
            this.grpItens.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItensOS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTituloTela;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.ComboBox cboCliente;
        private System.Windows.Forms.Label lblEquipamento;
        private System.Windows.Forms.TextBox txtEquipamento;
        private System.Windows.Forms.Label lblProblema;
        private System.Windows.Forms.TextBox txtProblema;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.GroupBox grpItens;
        private System.Windows.Forms.Label lblServico;
        private System.Windows.Forms.ComboBox cboServico;
        private System.Windows.Forms.Label lblValorServico;
        private System.Windows.Forms.TextBox txtValorServico;
        private System.Windows.Forms.Button btnAdicionarItem;
        private System.Windows.Forms.Button btnRemoverItem;
        private System.Windows.Forms.DataGridView dgvItensOS;
        private System.Windows.Forms.DataGridViewTextBoxColumn colServicoId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValor;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.DataGridViewCellStyle DataGridViewCellStyle1;
        private System.Windows.Forms.DataGridViewCellStyle DataGridViewCellStyle2;
        private System.Windows.Forms.DataGridViewCellStyle DataGridViewCellStyle3;
    }
}
