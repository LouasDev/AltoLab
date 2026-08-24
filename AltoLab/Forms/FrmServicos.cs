using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using AltoLab.DAO;
using AltoLab.Models;

namespace AltoLab.Forms
{
    public partial class FrmServicos : Form
    {
        private int servicoSelecionadoId;

        public FrmServicos()
        {
            InitializeComponent();
            CarregarGrid();
            LimparCampos();
        }

        private void CarregarGrid(string filtro = "")
        {
            try
            {
                ServicoDAO dao = new ServicoDAO();
                List<Servico> servicos = dao.ListarTodos(filtro);

                DataTable tabela = new DataTable();
                tabela.Columns.Add("Id", typeof(int));
                tabela.Columns.Add("Descricao", typeof(string));
                tabela.Columns.Add("ValorPadrao", typeof(decimal));

                foreach (Servico sv in servicos)
                {
                    tabela.Rows.Add(sv.Id, sv.Descricao, sv.ValorPadrao);
                }

                dgvServicos.DataSource = tabela;
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
                DataGridViewRow linha = dgvServicos.Rows[e.RowIndex];
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
