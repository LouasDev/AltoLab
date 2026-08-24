using System;
using System.Windows.Forms;
using AltoLab.DAO;
using AltoLab.Models;
using AltoLab.Utils;

namespace AltoLab.Forms
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void BtnEntrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLogin.Text))
            {
                MessageBox.Show("Informe o usuário.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLogin.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtSenha.Text))
            {
                MessageBox.Show("Informe a senha.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSenha.Focus();
                return;
            }

            try
            {
                UsuarioDAO dao = new UsuarioDAO();
                Usuario usuario = dao.Autenticar(txtLogin.Text, txtSenha.Text);

                if (usuario == null)
                {
                    MessageBox.Show("Usuário ou senha inválidos!", "Acesso Negado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSenha.Clear();
                    txtSenha.Focus();
                    return;
                }

                SessaoUsuario.UsuarioLogado = usuario;

                FrmPrincipal principal = new FrmPrincipal();
                Hide();
                principal.ShowDialog();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
