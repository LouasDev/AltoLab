namespace AltoLab.Forms
{
    partial class FrmDashboard
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.cardOsAbertas = new System.Windows.Forms.Panel();
            this.lblOsAbertasValor = new System.Windows.Forms.Label();
            this.lblOsAbertasRotulo = new System.Windows.Forms.Label();
            this.cardConcluidasMes = new System.Windows.Forms.Panel();
            this.lblConcluidasValor = new System.Windows.Forms.Label();
            this.lblConcluidasRotulo = new System.Windows.Forms.Label();
            this.cardFaturamentoMes = new System.Windows.Forms.Panel();
            this.lblFaturamentoValor = new System.Windows.Forms.Label();
            this.lblFaturamentoRotulo = new System.Windows.Forms.Label();
            this.cardDespesasMes = new System.Windows.Forms.Panel();
            this.lblDespesasValor = new System.Windows.Forms.Label();
            this.lblDespesasRotulo = new System.Windows.Forms.Label();
            this.cardSaldoMes = new System.Windows.Forms.Panel();
            this.lblSaldoValor = new System.Windows.Forms.Label();
            this.lblSaldoRotulo = new System.Windows.Forms.Label();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.lblAtualizadoEm = new System.Windows.Forms.Label();
            this.cardOsAbertas.SuspendLayout();
            this.cardConcluidasMes.SuspendLayout();
            this.cardFaturamentoMes.SuspendLayout();
            this.cardDespesasMes.SuspendLayout();
            this.cardSaldoMes.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTitulo.Location = new System.Drawing.Point(30, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(197, 28);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Painel de Controle";
            // 
            // cardOsAbertas
            // 
            this.cardOsAbertas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.cardOsAbertas.Controls.Add(this.lblOsAbertasValor);
            this.cardOsAbertas.Controls.Add(this.lblOsAbertasRotulo);
            this.cardOsAbertas.Location = new System.Drawing.Point(30, 80);
            this.cardOsAbertas.Name = "cardOsAbertas";
            this.cardOsAbertas.Size = new System.Drawing.Size(260, 120);
            this.cardOsAbertas.TabIndex = 1;
            // 
            // lblOsAbertasValor
            // 
            this.lblOsAbertasValor.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblOsAbertasValor.ForeColor = System.Drawing.Color.White;
            this.lblOsAbertasValor.Location = new System.Drawing.Point(0, 15);
            this.lblOsAbertasValor.Name = "lblOsAbertasValor";
            this.lblOsAbertasValor.Size = new System.Drawing.Size(260, 55);
            this.lblOsAbertasValor.TabIndex = 0;
            this.lblOsAbertasValor.Text = "0";
            this.lblOsAbertasValor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOsAbertasRotulo
            // 
            this.lblOsAbertasRotulo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblOsAbertasRotulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblOsAbertasRotulo.Location = new System.Drawing.Point(0, 75);
            this.lblOsAbertasRotulo.Name = "lblOsAbertasRotulo";
            this.lblOsAbertasRotulo.Size = new System.Drawing.Size(260, 30);
            this.lblOsAbertasRotulo.TabIndex = 1;
            this.lblOsAbertasRotulo.Text = "OS Abertas";
            this.lblOsAbertasRotulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cardConcluidasMes
            // 
            this.cardConcluidasMes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.cardConcluidasMes.Controls.Add(this.lblConcluidasValor);
            this.cardConcluidasMes.Controls.Add(this.lblConcluidasRotulo);
            this.cardConcluidasMes.Location = new System.Drawing.Point(330, 80);
            this.cardConcluidasMes.Name = "cardConcluidasMes";
            this.cardConcluidasMes.Size = new System.Drawing.Size(260, 120);
            this.cardConcluidasMes.TabIndex = 2;
            // 
            // lblConcluidasValor
            // 
            this.lblConcluidasValor.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblConcluidasValor.ForeColor = System.Drawing.Color.White;
            this.lblConcluidasValor.Location = new System.Drawing.Point(0, 15);
            this.lblConcluidasValor.Name = "lblConcluidasValor";
            this.lblConcluidasValor.Size = new System.Drawing.Size(260, 55);
            this.lblConcluidasValor.TabIndex = 0;
            this.lblConcluidasValor.Text = "0";
            this.lblConcluidasValor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblConcluidasRotulo
            // 
            this.lblConcluidasRotulo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblConcluidasRotulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblConcluidasRotulo.Location = new System.Drawing.Point(0, 75);
            this.lblConcluidasRotulo.Name = "lblConcluidasRotulo";
            this.lblConcluidasRotulo.Size = new System.Drawing.Size(260, 30);
            this.lblConcluidasRotulo.TabIndex = 1;
            this.lblConcluidasRotulo.Text = "Concluídas (mês)";
            this.lblConcluidasRotulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cardFaturamentoMes
            // 
            this.cardFaturamentoMes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.cardFaturamentoMes.Controls.Add(this.lblFaturamentoValor);
            this.cardFaturamentoMes.Controls.Add(this.lblFaturamentoRotulo);
            this.cardFaturamentoMes.Location = new System.Drawing.Point(630, 80);
            this.cardFaturamentoMes.Name = "cardFaturamentoMes";
            this.cardFaturamentoMes.Size = new System.Drawing.Size(260, 120);
            this.cardFaturamentoMes.TabIndex = 3;
            // 
            // lblFaturamentoValor
            // 
            this.lblFaturamentoValor.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblFaturamentoValor.ForeColor = System.Drawing.Color.White;
            this.lblFaturamentoValor.Location = new System.Drawing.Point(0, 15);
            this.lblFaturamentoValor.Name = "lblFaturamentoValor";
            this.lblFaturamentoValor.Size = new System.Drawing.Size(260, 55);
            this.lblFaturamentoValor.TabIndex = 0;
            this.lblFaturamentoValor.Text = "R$ 0,00";
            this.lblFaturamentoValor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFaturamentoRotulo
            // 
            this.lblFaturamentoRotulo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblFaturamentoRotulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblFaturamentoRotulo.Location = new System.Drawing.Point(0, 75);
            this.lblFaturamentoRotulo.Name = "lblFaturamentoRotulo";
            this.lblFaturamentoRotulo.Size = new System.Drawing.Size(260, 30);
            this.lblFaturamentoRotulo.TabIndex = 1;
            this.lblFaturamentoRotulo.Text = "Faturamento (mês)";
            this.lblFaturamentoRotulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cardDespesasMes
            // 
            this.cardDespesasMes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.cardDespesasMes.Controls.Add(this.lblDespesasValor);
            this.cardDespesasMes.Controls.Add(this.lblDespesasRotulo);
            this.cardDespesasMes.Location = new System.Drawing.Point(30, 230);
            this.cardDespesasMes.Name = "cardDespesasMes";
            this.cardDespesasMes.Size = new System.Drawing.Size(260, 120);
            this.cardDespesasMes.TabIndex = 4;
            // 
            // lblDespesasValor
            // 
            this.lblDespesasValor.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblDespesasValor.ForeColor = System.Drawing.Color.White;
            this.lblDespesasValor.Location = new System.Drawing.Point(0, 15);
            this.lblDespesasValor.Name = "lblDespesasValor";
            this.lblDespesasValor.Size = new System.Drawing.Size(260, 55);
            this.lblDespesasValor.TabIndex = 0;
            this.lblDespesasValor.Text = "R$ 0,00";
            this.lblDespesasValor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDespesasRotulo
            // 
            this.lblDespesasRotulo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDespesasRotulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblDespesasRotulo.Location = new System.Drawing.Point(0, 75);
            this.lblDespesasRotulo.Name = "lblDespesasRotulo";
            this.lblDespesasRotulo.Size = new System.Drawing.Size(260, 30);
            this.lblDespesasRotulo.TabIndex = 1;
            this.lblDespesasRotulo.Text = "Despesas (mês)";
            this.lblDespesasRotulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cardSaldoMes
            // 
            this.cardSaldoMes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.cardSaldoMes.Controls.Add(this.lblSaldoValor);
            this.cardSaldoMes.Controls.Add(this.lblSaldoRotulo);
            this.cardSaldoMes.Location = new System.Drawing.Point(330, 230);
            this.cardSaldoMes.Name = "cardSaldoMes";
            this.cardSaldoMes.Size = new System.Drawing.Size(560, 120);
            this.cardSaldoMes.TabIndex = 5;
            // 
            // lblSaldoValor
            // 
            this.lblSaldoValor.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblSaldoValor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.lblSaldoValor.Location = new System.Drawing.Point(0, 15);
            this.lblSaldoValor.Name = "lblSaldoValor";
            this.lblSaldoValor.Size = new System.Drawing.Size(560, 55);
            this.lblSaldoValor.TabIndex = 0;
            this.lblSaldoValor.Text = "R$ 0,00";
            this.lblSaldoValor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSaldoRotulo
            // 
            this.lblSaldoRotulo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSaldoRotulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblSaldoRotulo.Location = new System.Drawing.Point(0, 75);
            this.lblSaldoRotulo.Name = "lblSaldoRotulo";
            this.lblSaldoRotulo.Size = new System.Drawing.Size(560, 30);
            this.lblSaldoRotulo.TabIndex = 1;
            this.lblSaldoRotulo.Text = "Saldo do Mês (Faturamento - Despesas)";
            this.lblSaldoRotulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(165)))), ((int)(((byte)(233)))));
            this.btnAtualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAtualizar.FlatAppearance.BorderSize = 0;
            this.btnAtualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAtualizar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnAtualizar.ForeColor = System.Drawing.Color.White;
            this.btnAtualizar.Location = new System.Drawing.Point(770, 25);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(120, 40);
            this.btnAtualizar.TabIndex = 6;
            this.btnAtualizar.Text = "Atualizar";
            this.btnAtualizar.UseVisualStyleBackColor = false;
            this.btnAtualizar.Click += new System.EventHandler(this.BtnAtualizar_Click);
            // 
            // lblAtualizadoEm
            // 
            this.lblAtualizadoEm.AutoSize = true;
            this.lblAtualizadoEm.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Italic);
            this.lblAtualizadoEm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblAtualizadoEm.Location = new System.Drawing.Point(30, 380);
            this.lblAtualizadoEm.Name = "lblAtualizadoEm";
            this.lblAtualizadoEm.Size = new System.Drawing.Size(0, 15);
            this.lblAtualizadoEm.TabIndex = 7;
            // 
            // FrmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(920, 420);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.cardOsAbertas);
            this.Controls.Add(this.cardConcluidasMes);
            this.Controls.Add(this.cardFaturamentoMes);
            this.Controls.Add(this.cardDespesasMes);
            this.Controls.Add(this.cardSaldoMes);
            this.Controls.Add(this.btnAtualizar);
            this.Controls.Add(this.lblAtualizadoEm);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Painel de Controle — AltoLab";
            this.Shown += new System.EventHandler(this.FrmDashboard_Shown);
            this.cardOsAbertas.ResumeLayout(false);
            this.cardConcluidasMes.ResumeLayout(false);
            this.cardFaturamentoMes.ResumeLayout(false);
            this.cardDespesasMes.ResumeLayout(false);
            this.cardSaldoMes.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel cardOsAbertas;
        private System.Windows.Forms.Label lblOsAbertasValor;
        private System.Windows.Forms.Label lblOsAbertasRotulo;
        private System.Windows.Forms.Panel cardConcluidasMes;
        private System.Windows.Forms.Label lblConcluidasValor;
        private System.Windows.Forms.Label lblConcluidasRotulo;
        private System.Windows.Forms.Panel cardFaturamentoMes;
        private System.Windows.Forms.Label lblFaturamentoValor;
        private System.Windows.Forms.Label lblFaturamentoRotulo;
        private System.Windows.Forms.Panel cardDespesasMes;
        private System.Windows.Forms.Label lblDespesasValor;
        private System.Windows.Forms.Label lblDespesasRotulo;
        private System.Windows.Forms.Panel cardSaldoMes;
        private System.Windows.Forms.Label lblSaldoValor;
        private System.Windows.Forms.Label lblSaldoRotulo;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.Label lblAtualizadoEm;
    }
}
