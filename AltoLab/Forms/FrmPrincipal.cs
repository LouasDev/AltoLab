using System;
using System.Drawing;
using System.Windows.Forms;
using AltoLab.Utils;

namespace AltoLab.Forms
{
    public class FrmPrincipal : Form
    {
        private readonly Label lblTitulo = new Label();
        private readonly Label lblUsuario = new Label();
        private readonly Button btnClientes = new Button();
        private readonly Button btnServicos = new Button();
        private readonly Button btnNovaOS = new Button();
        private readonly Button btnConsultaOS = new Button();
        private readonly Button btnLogout = new Button();

        public FrmPrincipal()
        {
            MontarTela();
        }

        private void MontarTela()
        {
            EstiloUI.EstilizarForm(this);
            Text = "AltoLab — Menu Principal";
            Size = new Size(560, 560);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            BackColor = EstiloUI.CorNavyEscuro;

            lblTitulo.Text = "AltoLab";
            lblTitulo.Font = new Font("Segoe UI", 26F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.SetBounds(40, 30, 480, 50);
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;

            lblUsuario.Font = new Font("Segoe UI", 9.5F, FontStyle.Italic);
            lblUsuario.ForeColor = Color.FromArgb(148, 163, 184);
            lblUsuario.SetBounds(40, 82, 480, 22);
            lblUsuario.TextAlign = ContentAlignment.MiddleCenter;
            lblUsuario.Text = SessaoUsuario.UsuarioLogado != null
                ? "Bem-vindo, " + SessaoUsuario.UsuarioLogado.NomeCompleto
                : "Usuário";

            btnClientes.Text = "👥  CADASTRO DE CLIENTES";
            btnClientes.SetBounds(80, 140, 400, 52);

            btnServicos.Text = "🛠  CADASTRO DE SERVIÇOS";
            btnServicos.SetBounds(80, 204, 400, 52);

            btnNovaOS.Text = "📄  NOVA ORDEM DE SERVIÇO";
            btnNovaOS.SetBounds(80, 268, 400, 52);

            btnConsultaOS.Text = "🔍  CONSULTAR ORDENS DE SERVIÇO";
            btnConsultaOS.SetBounds(80, 332, 400, 52);

            btnLogout.Text = "SAIR (LOGOUT)";
            btnLogout.SetBounds(80, 410, 400, 46);
            EstiloUI.EstilizarBotaoPerigo(btnLogout);
            btnLogout.Click += BtnLogout_Click;

            foreach (Button b in new[] { btnClientes, btnServicos, btnNovaOS, btnConsultaOS })
            {
                EstiloUI.EstilizarBotaoPrimario(b);
            }

            btnClientes.Click += (s, e) => AbrirFormulario<FrmClientes>("Cadastro de Clientes");
            btnServicos.Click += (s, e) => AbrirFormulario<FrmServicos>("Cadastro de Serviços");
            btnNovaOS.Click += (s, e) => AbrirFormulario<FrmCadastroOS>("Nova Ordem de Serviço");
            btnConsultaOS.Click += (s, e) => AbrirFormulario<FrmConsultaOS>("Consulta de Ordens de Serviço");

            Controls.Add(lblTitulo);
            Controls.Add(lblUsuario);
            Controls.Add(btnClientes);
            Controls.Add(btnServicos);
            Controls.Add(btnNovaOS);
            Controls.Add(btnConsultaOS);
            Controls.Add(btnLogout);
        }

        private void AbrirFormulario<T>(string titulo) where T : Form, new()
        {
            try
            {
                using (Form form = new T())
                {
                    form.Text = titulo + " — AltoLab";
                    form.ShowDialog(this);
                }
                AtualizarSaudacao();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao abrir a tela \"" + titulo + "\": " + ex.Message,
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AtualizarSaudacao()
        {
            if (IsDisposed || Disposing) return;
            lblUsuario.Text = SessaoUsuario.UsuarioLogado != null
                ? "Bem-vindo, " + SessaoUsuario.UsuarioLogado.NomeCompleto
                : "Usuário";
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            DialogResult confirmacao = MessageBox.Show(
                "Deseja realmente sair do sistema?",
                "Confirmar Saída",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmacao == DialogResult.Yes)
            {
                SessaoUsuario.EncerrarSessao();
                Close();
            }
        }
    }
}
