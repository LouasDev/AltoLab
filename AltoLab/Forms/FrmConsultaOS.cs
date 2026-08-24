using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using AltoLab.DAO;
using AltoLab.Models;

namespace AltoLab.Forms
{
    public partial class FrmConsultaOS : Form
    {
        public FrmConsultaOS()
        {
            InitializeComponent();

            // Datas relativas não podem ser fixadas no Designer — definidas aqui
            dtpInicial.Value = DateTime.Today.AddMonths(-1);
            dtpFinal.Value = DateTime.Today;

            CarregarGrid();
        }

        private void CarregarGrid()
        {
            try
            {
                string statusSelecionado = cboStatus.SelectedIndex > 0 ? cboStatus.SelectedItem.ToString() : "";
                string filtroCliente = txtCliente.Text.Trim();

                DateTime? dataInicial = null;
                DateTime? dataFinal = null;
                if (chkPeriodo.Checked)
                {
                    dataInicial = dtpInicial.Value.Date;
                    dataFinal = dtpFinal.Value.Date;
                }

                OrdemServicoDAO dao = new OrdemServicoDAO();
                List<OrdemServico> ordens = dao.Consultar(statusSelecionado, filtroCliente, dataInicial, dataFinal);

                DataTable tabela = new DataTable();
                tabela.Columns.Add("Id", typeof(int));
                tabela.Columns.Add("ClienteNome", typeof(string));
                tabela.Columns.Add("Equipamento", typeof(string));
                tabela.Columns.Add("Status", typeof(string));
                tabela.Columns.Add("DataAbertura", typeof(DateTime));
                tabela.Columns.Add("ValorTotal", typeof(decimal));

                foreach (OrdemServico os in ordens)
                {
                    tabela.Rows.Add(os.Id, os.ClienteNome, os.Equipamento, os.Status, os.DataAbertura, os.ValorTotal);
                }

                dgvOrdensServico.DataSource = tabela;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao consultar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ChkPeriodo_CheckedChanged(object sender, EventArgs e)
        {
            dtpInicial.Enabled = chkPeriodo.Checked;
            dtpFinal.Enabled = chkPeriodo.Checked;
        }

        private void BtnFiltrar_Click(object sender, EventArgs e)
        {
            CarregarGrid();
        }

        private void BtnLimparFiltros_Click(object sender, EventArgs e)
        {
            cboStatus.SelectedIndex = 0;
            txtCliente.Clear();
            chkPeriodo.Checked = false;
            dtpInicial.Value = DateTime.Today.AddMonths(-1);
            dtpFinal.Value = DateTime.Today;
            CarregarGrid();
        }

        private int ObterOsSelecionada()
        {
            if (dgvOrdensServico.CurrentRow == null) return 0;

            object valorId = dgvOrdensServico.CurrentRow.Cells["Id"].Value;
            if (valorId == null || valorId == DBNull.Value) return 0;

            return Convert.ToInt32(valorId);
        }

        private void Grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                AbrirEdicaoOS();
            }
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            AbrirEdicaoOS();
        }

        private void AbrirEdicaoOS()
        {
            int id = ObterOsSelecionada();
            if (id <= 0)
            {
                MessageBox.Show("Selecione uma Ordem de Serviço no grid.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (FrmCadastroOS formEdicao = new FrmCadastroOS(id))
                {
                    formEdicao.ShowDialog(this);
                }
                CarregarGrid(); // Atualiza o grid refletindo as alterações
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao abrir a edição da OS: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
