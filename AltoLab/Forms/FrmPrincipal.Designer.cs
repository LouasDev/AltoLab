namespace AltoLab.Forms
{
    partial class FrmPrincipal
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.btnClientes = new System.Windows.Forms.Button();
            this.btnServicos = new System.Windows.Forms.Button();
            this.btnNovaOS = new System.Windows.Forms.Button();
            this.btnConsultaOS = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(40, 30);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(480, 50);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "AltoLab";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUsuario
            // 
            this.lblUsuario.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Italic);
            this.lblUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblUsuario.Location = new System.Drawing.Point(40, 82);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(480, 22);
            this.lblUsuario.TabIndex = 1;
            this.lblUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClientes
            // 
            this.btnClientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(165)))), ((int)(((byte)(233)))));
            this.btnClientes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClientes.FlatAppearance.BorderSize = 0;
            this.btnClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClientes.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnClientes.ForeColor = System.Drawing.Color.White;
            this.btnClientes.Location = new System.Drawing.Point(80, 140);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(400, 52);
            this.btnClientes.TabIndex = 2;
            this.btnClientes.Text = "👥  CADASTRO DE CLIENTES";
            this.btnClientes.UseVisualStyleBackColor = false;
            this.btnClientes.Click += new System.EventHandler(this.BtnClientes_Click);
            // 
            // btnServicos
            // 
            this.btnServicos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(165)))), ((int)(((byte)(233)))));
            this.btnServicos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnServicos.FlatAppearance.BorderSize = 0;
            this.btnServicos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnServicos.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnServicos.ForeColor = System.Drawing.Color.White;
            this.btnServicos.Location = new System.Drawing.Point(80, 204);
            this.btnServicos.Name = "btnServicos";
            this.btnServicos.Size = new System.Drawing.Size(400, 52);
            this.btnServicos.TabIndex = 3;
            this.btnServicos.Text = "🛠  CADASTRO DE SERVIÇOS";
            this.btnServicos.UseVisualStyleBackColor = false;
            this.btnServicos.Click += new System.EventHandler(this.BtnServicos_Click);
            // 
            // btnNovaOS
            // 
            this.btnNovaOS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(165)))), ((int)(((byte)(233)))));
            this.btnNovaOS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNovaOS.FlatAppearance.BorderSize = 0;
            this.btnNovaOS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNovaOS.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnNovaOS.ForeColor = System.Drawing.Color.White;
            this.btnNovaOS.Location = new System.Drawing.Point(80, 268);
            this.btnNovaOS.Name = "btnNovaOS";
            this.btnNovaOS.Size = new System.Drawing.Size(400, 52);
            this.btnNovaOS.TabIndex = 4;
            this.btnNovaOS.Text = "📄  NOVA ORDEM DE SERVIÇO";
            this.btnNovaOS.UseVisualStyleBackColor = false;
            this.btnNovaOS.Click += new System.EventHandler(this.BtnNovaOS_Click);
            // 
            // btnConsultaOS
            // 
            this.btnConsultaOS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(165)))), ((int)(((byte)(233)))));
            this.btnConsultaOS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConsultaOS.FlatAppearance.BorderSize = 0;
            this.btnConsultaOS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsultaOS.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnConsultaOS.ForeColor = System.Drawing.Color.White;
            this.btnConsultaOS.Location = new System.Drawing.Point(80, 332);
            this.btnConsultaOS.Name = "btnConsultaOS";
            this.btnConsultaOS.Size = new System.Drawing.Size(400, 52);
            this.btnConsultaOS.TabIndex = 5;
            this.btnConsultaOS.Text = "🔍  CONSULTAR ORDENS DE SERVIÇO";
            this.btnConsultaOS.UseVisualStyleBackColor = false;
            this.btnConsultaOS.Click += new System.EventHandler(this.BtnConsultaOS_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(80, 410);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(400, 46);
            this.btnLogout.TabIndex = 6;
            this.btnLogout.Text = "SAIR (LOGOUT)";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.BtnLogout_Click);
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.ClientSize = new System.Drawing.Size(560, 560);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.btnClientes);
            this.Controls.Add(this.btnServicos);
            this.Controls.Add(this.btnNovaOS);
            this.Controls.Add(this.btnConsultaOS);
            this.Controls.Add(this.btnLogout);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AltoLab — Menu Principal";
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Button btnClientes;
        private System.Windows.Forms.Button btnServicos;
        private System.Windows.Forms.Button btnNovaOS;
        private System.Windows.Forms.Button btnConsultaOS;
        private System.Windows.Forms.Button btnLogout;
    }
}
