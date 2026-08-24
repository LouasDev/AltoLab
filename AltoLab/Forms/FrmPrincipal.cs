using System;
using System.Windows.Forms;
using AltoLab.Utils;

namespace AltoLab.Forms
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
            AtualizarSaudacao();
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

        private void BtnClientes_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FrmClientes>("Cadastro de Clientes");
        }

        private void BtnServicos_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FrmServicos>("Cadastro de Serviços");
        }

        private void BtnNovaOS_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FrmCadastroOS>("Nova Ordem de Serviço");
        }

        private void BtnConsultaOS_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FrmConsultaOS>("Consulta de Ordens de Serviço");
        }

        private void BtnDashboard_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FrmDashboard>("Painel de Controle");
        }

        private void BtnDespesas_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FrmDespesas>("Controle de Despesas");
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
