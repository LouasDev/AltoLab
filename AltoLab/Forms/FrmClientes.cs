using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using AltoLab.DAO;
using AltoLab.Models;
using AltoLab.Utils;

namespace AltoLab.Forms
{
    public class FrmClientes : Form
    {
        private int clienteSelecionadoId;

        private readonly TextBox txtNome = new TextBox();
        private readonly TextBox txtTelefone = new TextBox();
        private readonly TextBox txtEmail = new TextBox();
        private readonly TextBox txtEndereco = new TextBox();
        private readonly TextBox txtBusca = new TextBox();
        private readonly DataGridView grid = new DataGridView();
        private readonly Button btnNovo = new Button();
        private readonly Button btnSalvar = new Button();
        private readonly Button btnExcluir = new Button();
        private readonly Button btnLimpar = new Button();

        public FrmClientes()
        {
            MontarTela();
            CarregarGrid();
            LimparCampos();
        }

        private void MontarTela()
        {
            EstiloUI.EstilizarForm(this);
            Text = "Cadastro de Clientes — AltoLab";
            Size = new Size(900, 560);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            Label lblTituloTela = new Label
            {
                Text = "Cadastro de Clientes",
                Font = new Font("Segoe UI", 15F, FontStyle.Bold),
                ForeColor = EstiloUI.CorNavyEscuro,
                AutoSize = true,
                Location = new Point(20, 15)
            };

            Label lblBusca = new Label { Text = "Buscar por nome:", AutoSize = true, Location = new Point(430, 55) };
            txtBusca.SetBounds(540, 51, 320, 26);
            txtBusca.TextChanged += (s, e) => CarregarGrid(txtBusca.Text);

            // --- Painel do formulário (esquerda) ---
            GroupBox grpForm = new GroupBox
            {
                Text = "Dados do Cliente",
                Location = new Point(20, 90),
                Size = new Size(360, 300)
            };

            Label lblNome = new Label { Text = "Nome (*):", AutoSize = true, Location = new Point(15, 30) };
            txtNome.SetBounds(15, 50, 325, 26);

            Label lblTelefone = new Label { Text = "Telefone:", AutoSize = true, Location = new Point(15, 85) };
            txtTelefone.SetBounds(15, 105, 325, 26);

            Label lblEmail = new Label { Text = "E-mail:", AutoSize = true, Location = new Point(15, 140) };
            txtEmail.SetBounds(15, 160, 325, 26);

            Label lblEndereco = new Label { Text = "Endereço:", AutoSize = true, Location = new Point(15, 195) };
            txtEndereco.SetBounds(15, 215, 325, 26);
            txtEndereco.Multiline = false;

            grpForm.Controls.AddRange(new Control[] { lblNome, txtNome, lblTelefone, txtTelefone, lblEmail, txtEmail, lblEndereco, txtEndereco });

            // --- Botões ---
            btnNovo.Text = "Novo";
            btnNovo.SetBounds(20, 410, 82, 38);
            EstiloUI.EstilizarBotaoSecundario(btnNovo);
            btnNovo.Click += (s, e) => LimparCampos();

            btnSalvar.Text = "Salvar";
            btnSalvar.SetBounds(112, 410, 82, 38);
            EstiloUI.EstilizarBotaoPrimario(btnSalvar);
            btnSalvar.Click += BtnSalvar_Click;

            btnExcluir.Text = "Excluir";
            btnExcluir.SetBounds(204, 410, 82, 38);
            EstiloUI.EstilizarBotaoPerigo(btnExcluir);
            btnExcluir.Click += BtnExcluir_Click;

            btnLimpar.Text = "Limpar";
            btnLimpar.SetBounds(296, 410, 84, 38);
            btnLimpar.FlatStyle = FlatStyle.Flat;
            btnLimpar.Click += (s, e) => LimparCampos();

            // --- Grid (direita) ---
            EstiloUI.EstilizarGrid(grid);
            grid.Location = new Point(400, 85);
            grid.Size = new Size(464, 363);
            grid.CellClick += Grid_CellClick;
            grid.ColumnHeaderMouseClick += (s, e) => { };

            Controls.Add(lblTituloTela);
            Controls.Add(lblBusca);
            Controls.Add(txtBusca);
            Controls.Add(grpForm);
            Controls.Add(btnNovo);
            Controls.Add(btnSalvar);
            Controls.Add(btnExcluir);
            Controls.Add(btnLimpar);
            Controls.Add(grid);
        }

        private void CarregarGrid(string filtro = "")
        {
            try
            {
                ClienteDAO dao = new ClienteDAO();
                System.Collections.Generic.List<Cliente> clientes = dao.ListarTodos(filtro);

                DataTable tabela = new DataTable();
                tabela.Columns.Add("Id", typeof(int));
                tabela.Columns.Add("Nome", typeof(string));
                tabela.Columns.Add("Telefone", typeof(string));
                tabela.Columns.Add("Email", typeof(string));

                foreach (Cliente c in clientes)
                {
                    tabela.Rows.Add(c.Id, c.Nome, c.Telefone, c.Email);
                }

                grid.DataSource = tabela;

                if (grid.Columns["Id"] != null)
                {
                    grid.Columns["Id"].Visible = false;
                    grid.Columns["Id"].HeaderText = "Código";
                }
                if (grid.Columns["Nome"] != null)
                {
                    grid.Columns["Nome"].Width = 170;
                    grid.Columns["Nome"].HeaderText = "Nome";
                }
                if (grid.Columns["Telefone"] != null)
                {
                    grid.Columns["Telefone"].Width = 110;
                    grid.Columns["Telefone"].HeaderText = "Telefone";
                }
                if (grid.Columns["Email"] != null)
                {
                    grid.Columns["Email"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    grid.Columns["Email"].HeaderText = "E-mail";
                }
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
                DataGridViewRow linha = grid.Rows[e.RowIndex];
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
