using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using AltoLab.DAO;
using AltoLab.Models;

namespace AltoLab.Forms
{
    public partial class FrmClientes : Form
    {
        private int clienteSelecionadoId;

        public FrmClientes()
        {
            InitializeComponent();
            CarregarGrid();
            LimparCampos();
        }

        private void CarregarGrid(string filtro = "")
        {
            try
            {
                ClienteDAO dao = new ClienteDAO();
                List<Cliente> clientes = dao.ListarTodos(filtro);

                DataTable tabela = new DataTable();
                tabela.Columns.Add("Id", typeof(int));
                tabela.Columns.Add("Nome", typeof(string));
                tabela.Columns.Add("Telefone", typeof(string));
                tabela.Columns.Add("Email", typeof(string));

                foreach (Cliente c in clientes)
                {
                    tabela.Rows.Add(c.Id, c.Nome, c.Telefone, c.Email);
                }

                dgvClientes.DataSource = tabela;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimparCampos()
        {
            clienteSelecionadoId = 0;
            txtNome.Clear();
            txtTelefone.Clear();
            txtEmail.Clear();
            txtEndereco.Clear();
            txtNome.Focus();
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("O campo Nome é obrigatório.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNome.Focus();
                return false;
            }
            return true;
        }

        private void TxtBusca_TextChanged(object sender, EventArgs e)
        {
            CarregarGrid(txtBusca.Text);
        }

        private void BtnNovo_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void BtnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            try
            {
                ClienteDAO dao = new ClienteDAO();

                if (clienteSelecionadoId == 0)
                {
                    Cliente novo = new Cliente
                    {
                        Nome = txtNome.Text.Trim(),
                        Telefone = txtTelefone.Text.Trim(),
                        Email = txtEmail.Text.Trim(),
                        Endereco = txtEndereco.Text.Trim()
                    };
                    dao.Inserir(novo);
                    MessageBox.Show("Cliente cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Cliente existente = new Cliente
                    {
                        Id = clienteSelecionadoId,
                        Nome = txtNome.Text.Trim(),
                        Telefone = txtTelefone.Text.Trim(),
                        Email = txtEmail.Text.Trim(),
                        Endereco = txtEndereco.Text.Trim()
                    };
                    dao.Atualizar(existente);
                    MessageBox.Show("Cliente atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                CarregarGrid(txtBusca.Text);
                LimparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao salvar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            if (clienteSelecionadoId == 0)
            {
                MessageBox.Show("Selecione um cliente no grid para excluir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirmacao = MessageBox.Show(
                "Deseja realmente excluir o cliente \"" + txtNome.Text + "\"?",
                "Confirmar Exclusão",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmacao != DialogResult.Yes) return;

            try
            {
                ClienteDAO dao = new ClienteDAO();
                dao.Excluir(clienteSelecionadoId);
                MessageBox.Show("Cliente excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CarregarGrid(txtBusca.Text);
                LimparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao excluir", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            try
            {
                DataGridViewRow linha = dgvClientes.Rows[e.RowIndex];
                object valorId = linha.Cells["Id"].Value;
                if (valorId == null || valorId == DBNull.Value) return;

                int id = Convert.ToInt32(valorId);
                ClienteDAO dao = new ClienteDAO();
                Cliente cliente = dao.BuscarPorId(id);

                if (cliente == null)
                {
                    MessageBox.Show("Cliente não encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                clienteSelecionadoId = cliente.Id;
                txtNome.Text = cliente.Nome;
                txtTelefone.Text = cliente.Telefone;
                txtEmail.Text = cliente.Email;
                txtEndereco.Text = cliente.Endereco;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
