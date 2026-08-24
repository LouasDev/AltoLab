using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using AltoLab.DAO;
using AltoLab.Models;

namespace AltoLab.Forms
{
    public partial class FrmDespesas : Form
    {
        private int despesaSelecionadaId;
        private static readonly string[] CategoriasFixas = { "Fixa", "Variável", "Compra de peças" };

        public FrmDespesas()
        {
            InitializeComponent();
            dtpData.Value = DateTime.Today;
            CarregarGrid();
            LimparCampos();
        }

        private void FrmDespesas_Shown(object sender, EventArgs e)
        {
            RecalcularResumo();
        }

        private string ObterCategoriaSelecionada()
        {
            if (cboCategoria.SelectedItem == null) return "";
            string selecionado = cboCategoria.SelectedItem.ToString();
            if (selecionado == "Outra")
            {
                string textoLivre = txtCategoriaOutra.Text.Trim();
                return string.IsNullOrWhiteSpace(textoLivre) ? "Outra" : textoLivre;
            }
            return selecionado;
        }

        private bool EhCategoriaFixa(string categoria)
        {
            if (string.IsNullOrWhiteSpace(categoria)) return false;
            foreach (string fixa in CategoriasFixas)
            {
                if (string.Equals(fixa, categoria, StringComparison.OrdinalIgnoreCase))
                    return true;
            }
            return false;
        }

        private void CarregarGrid(string filtro = "")
        {
            try
            {
                DespesaDAO dao = new DespesaDAO();
                List<Despesa> despesas = dao.ListarTodos(filtro);

                DataTable tabela = new DataTable();
                tabela.Columns.Add("Id", typeof(int));
                tabela.Columns.Add("Descricao", typeof(string));
                tabela.Columns.Add("Categoria", typeof(string));
                tabela.Columns.Add("Valor", typeof(decimal));
                tabela.Columns.Add("DataDespesa", typeof(DateTime));

                foreach (Despesa d in despesas)
                {
                    tabela.Rows.Add(d.Id, d.Descricao, d.Categoria, d.Valor, d.DataDespesa);
                }

                dgvDespesas.DataSource = tabela;
                RecalcularResumo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RecalcularResumo()
        {
            // Total Gasto: soma do que está visível no grid (respeita filtro)
            decimal totalGasto = 0;
            if (dgvDespesas.DataSource is DataTable tabela)
            {
                foreach (DataRow linha in tabela.Rows)
                {
                    totalGasto += Convert.ToDecimal(linha["Valor"]);
                }
            }
            lblResumoGasto.Text = "Total Gasto: R$ " + totalGasto.ToString("N2");

            // Total Ganho (mês): faturamento do mês corrente via DAO
            decimal totalGanho = 0;
            try
            {
                OrdemServicoDAO osDao = new OrdemServicoDAO();
                totalGanho = osDao.SomarFaturamentoMesAtual();
            }
            catch { }
            lblResumoGanho.Text = "Total Ganho (mês): R$ " + totalGanho.ToString("N2");

            // Saldo
            decimal saldo = totalGanho - totalGasto;
            lblResumoSaldo.Text = "Saldo: R$ " + saldo.ToString("N2");
            lblResumoSaldo.ForeColor = saldo >= 0
                ? Color.FromArgb(16, 185, 129)
                : Color.FromArgb(239, 68, 68);
        }

        private void LimparCampos()
        {
            despesaSelecionadaId = 0;
            txtDescricao.Clear();
            cboCategoria.SelectedIndex = -1;
            txtCategoriaOutra.Clear();
            txtCategoriaOutra.Visible = false;
            txtValor.Clear();
            dtpData.Value = DateTime.Today;
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
            if (!decimal.TryParse(valorTexto, out decimal valor) || valor <= 0)
            {
                MessageBox.Show("Informe um Valor válido (ex: 150,00).", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void CboCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool selecionouOutra = cboCategoria.SelectedItem != null
                && cboCategoria.SelectedItem.ToString() == "Outra";
            txtCategoriaOutra.Visible = selecionouOutra;
            if (!selecionouOutra)
                txtCategoriaOutra.Clear();
        }

        private void TxtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool teclaValida = char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar) || e.KeyChar == ',' || e.KeyChar == '.';
            if (!teclaValida)
            {
                e.Handled = true;
                return;
            }
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
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
                DespesaDAO dao = new DespesaDAO();
                decimal valor = decimal.Parse(txtValor.Text.Trim().Replace(".", ","));
                string categoria = ObterCategoriaSelecionada();

                if (despesaSelecionadaId == 0)
                {
                    Despesa nova = new Despesa
                    {
                        Descricao = txtDescricao.Text.Trim(),
                        Categoria = categoria,
                        Valor = valor,
                        DataDespesa = dtpData.Value.Date
                    };
                    dao.Inserir(nova);
                    MessageBox.Show("Despesa cadastrada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Despesa existente = new Despesa
                    {
                        Id = despesaSelecionadaId,
                        Descricao = txtDescricao.Text.Trim(),
                        Categoria = categoria,
                        Valor = valor,
                        DataDespesa = dtpData.Value.Date
                    };
                    dao.Atualizar(existente);
                    MessageBox.Show("Despesa atualizada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (despesaSelecionadaId == 0)
            {
                MessageBox.Show("Selecione uma despesa no grid para excluir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirmacao = MessageBox.Show(
                "Deseja realmente excluir a despesa \"" + txtDescricao.Text + "\"?",
                "Confirmar Exclusão",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmacao != DialogResult.Yes) return;

            try
            {
                DespesaDAO dao = new DespesaDAO();
                dao.Excluir(despesaSelecionadaId);
                MessageBox.Show("Despesa excluída com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                DataGridViewRow linha = dgvDespesas.Rows[e.RowIndex];
                object valorId = linha.Cells["Id"].Value;
                if (valorId == null || valorId == DBNull.Value) return;

                int id = Convert.ToInt32(valorId);
                DespesaDAO dao = new DespesaDAO();
                Despesa despesa = dao.BuscarPorId(id);

                if (despesa == null)
                {
                    MessageBox.Show("Despesa não encontrada.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                despesaSelecionadaId = despesa.Id;
                txtDescricao.Text = despesa.Descricao;

                if (EhCategoriaFixa(despesa.Categoria))
                {
                    cboCategoria.SelectedItem = despesa.Categoria;
                    txtCategoriaOutra.Visible = false;
                    txtCategoriaOutra.Clear();
                }
                else
                {
                    cboCategoria.SelectedItem = "Outra";
                    txtCategoriaOutra.Visible = true;
                    txtCategoriaOutra.Text = despesa.Categoria ?? "";
                }

                txtValor.Text = despesa.Valor.ToString("N2");
                dtpData.Value = despesa.DataDespesa.Date > DateTimePicker.MinimumDateTime
                    ? despesa.DataDespesa.Date
                    : DateTime.Today;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
