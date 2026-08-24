using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using AltoLab.DAO;
using AltoLab.Models;
using AltoLab.Utils;

namespace AltoLab.Forms
{
    public class FrmServicos : Form
    {
        private int servicoSelecionadoId;

        private readonly TextBox txtDescricao = new TextBox();
        private readonly TextBox txtValor = new TextBox();
        private readonly TextBox txtBusca = new TextBox();
        private readonly DataGridView grid = new DataGridView();
        private readonly Button btnNovo = new Button();
        private readonly Button btnSalvar = new Button();
        private readonly Button btnExcluir = new Button();
        private readonly Button btnLimpar = new Button();

        public FrmServicos()
        {
            MontarTela();
            CarregarGrid();
            LimparCampos();
        }

        private void MontarTela()
        {
            EstiloUI.EstilizarForm(this);
            Text = "Cadastro de Serviços — AltoLab";
            Size = new Size(900, 560);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            Label lblTituloTela = new Label
            {
                Text = "Cadastro de Serviços",
                Font = new Font("Segoe UI", 15F, FontStyle.Bold),
                ForeColor = EstiloUI.CorNavyEscuro,
                AutoSize = true,
                Location = new Point(20, 15)
            };

            Label lblBusca = new Label { Text = "Buscar por descrição:", AutoSize = true, Location = new Point(430, 55) };
            txtBusca.SetBounds(565, 51, 299, 26);
            txtBusca.TextChanged += (s, e) => CarregarGrid(txtBusca.Text);

            GroupBox grpForm = new GroupBox
            {
                Text = "Dados do Serviço",
                Location = new Point(20, 90),
                Size = new Size(360, 220)
            };

            Label lblDescricao = new Label { Text = "Descrição (*):", AutoSize = true, Location = new Point(15, 35) };
            txtDescricao.SetBounds(15, 55, 325, 26);

            Label lblValor = new Label { Text = "Valor Padrão (R$) (*):", AutoSize = true, Location = new Point(15, 95) };
            txtValor.SetBounds(15, 115, 160, 26);
            txtValor.TextAlign = HorizontalAlignment.Right;
            txtValor.KeyPress += TxtValor_KeyPress;

            grpForm.Controls.AddRange(new Control[] { lblDescricao, txtDescricao, lblValor, txtValor });

            btnNovo.Text = "Novo";
            btnNovo.SetBounds(20, 340, 82, 38);
            EstiloUI.EstilizarBotaoSecundario(btnNovo);
            btnNovo.Click += (s, e) => LimparCampos();

            btnSalvar.Text = "Salvar";
            btnSalvar.SetBounds(112, 340, 82, 38);
            EstiloUI.EstilizarBotaoPrimario(btnSalvar);
            btnSalvar.Click += BtnSalvar_Click;

            btnExcluir.Text = "Excluir";
            btnExcluir.SetBounds(204, 340, 82, 38);
            EstiloUI.EstilizarBotaoPerigo(btnExcluir);
            btnExcluir.Click += BtnExcluir_Click;

            btnLimpar.Text = "Limpar";
            btnLimpar.SetBounds(296, 340, 84, 38);
            btnLimpar.FlatStyle = FlatStyle.Flat;
            btnLimpar.Click += (s, e) => LimparCampos();

            EstiloUI.EstilizarGrid(grid);
            grid.Location = new Point(400, 85);
            grid.Size = new Size(464, 363);
            grid.CellClick += Grid_CellClick;

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

        private void TxtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite apenas dígitos, vírgula e ponto (converte depois para decimal)
            bool teclaValida = char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar) || e.KeyChar == ',' || e.KeyChar == '.';
            if (!teclaValida)
            {
                e.Handled = true;
                return;
            }
            // Converte ponto digitado em vírgula
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
            // Impede mais de uma vírgula
            if (e.KeyChar == ',' && txtValor.Text.Contains(","))
            {
                e.Handled = true;
            }
        }

        private void CarregarGrid(string filtro = "")
        {
            try
            {
                ServicoDAO dao = new ServicoDAO();
                System.Collections.Generic.List<Servico> servicos = dao.ListarTodos(filtro);

                DataTable tabela = new DataTable();
                tabela.Columns.Add("Id", typeof(int));
                tabela.Columns.Add("Descricao", typeof(string));
                tabela.Columns.Add("ValorPadrao", typeof(decimal));

                foreach (Servico sv in servicos)
                {
                    tabela.Rows.Add(sv.Id, sv.Descricao, sv.ValorPadrao);
                }

                grid.DataSource = tabela;

                if (grid.Columns["Id"] != null)
                {
                    grid.Columns["Id"].Visible = false;
                    grid.Columns["Id"].HeaderText = "Código";
                }
                if (grid.Columns["Descricao"] != null)
                {
                    grid.Columns["Descricao"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    grid.Columns["Descricao"].HeaderText = "Descrição";
                }
                if (grid.Columns["ValorPadrao"] != null)
                {
                    grid.Columns["ValorPadrao"].Width = 120;
                    grid.Columns["ValorPadrao"].HeaderText = "Valor Padrão";
                    grid.Columns["ValorPadrao"].DefaultCellStyle.Format = "C2";
                    grid.Columns["ValorPadrao"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimparCampos()
        {
            servicoSelecionadoId = 0;
            txtDescricao.Clear();
            txtValor.Clear();
            txtDescricao.Focus();
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtDescricao.Text))
            {
                MessageBox.Show("O campo Descrição é obrigatório.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescricao.Focus();
                return false;
            }

            string valorTexto = txtValor.Text.Trim().Replace(".", ",");
            if (!decimal.TryParse(valorTexto, out decimal valor) || valor < 0)
            {
                MessageBox.Show("Informe um Valor Padrão válido (ex: 150,00).", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtValor.Focus();
                return false;
            }

            return true;
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            try
            {
                ServicoDAO dao = new ServicoDAO();
                decimal valor = decimal.Parse(txtValor.Text.Trim().Replace(".", ","));

                if (servicoSelecionadoId == 0)
                {
                    Servico novo = new Servico
                    {
                        Descricao = txtDescricao.Text.Trim(),
                        ValorPadrao = valor
                    };
                    dao.Inserir(novo);
                    MessageBox.Show("Serviço cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Servico existente = new Servico
                    {
                        Id = servicoSelecionadoId,
                        Descricao = txtDescricao.Text.Trim(),
                        ValorPadrao = valor
                    };
                    dao.Atualizar(existente);
                    MessageBox.Show("Serviço atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (servicoSelecionadoId == 0)
            {
                MessageBox.Show("Selecione um serviço no grid para excluir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirmacao = MessageBox.Show(
                "Deseja realmente excluir o serviço \"" + txtDescricao.Text + "\"?",
                "Confirmar Exclusão",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmacao != DialogResult.Yes) return;

            try
            {
                ServicoDAO dao = new ServicoDAO();
                dao.Excluir(servicoSelecionadoId);
                MessageBox.Show("Serviço excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                ServicoDAO dao = new ServicoDAO();
                Servico servico = dao.BuscarPorId(id);

                if (servico == null)
                {
                    MessageBox.Show("Serviço não encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                servicoSelecionadoId = servico.Id;
                txtDescricao.Text = servico.Descricao;
                txtValor.Text = servico.ValorPadrao.ToString("N2");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
