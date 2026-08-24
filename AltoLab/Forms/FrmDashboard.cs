using System;
using System.Drawing;
using System.Windows.Forms;
using AltoLab.DAO;
using AltoLab.Models;

namespace AltoLab.Forms
{
    public partial class FrmDashboard : Form
    {
        public FrmDashboard()
        {
            InitializeComponent();
        }

        private void FrmDashboard_Shown(object sender, EventArgs e)
        {
            CarregarMetricas();
        }

        private void BtnAtualizar_Click(object sender, EventArgs e)
        {
            CarregarMetricas();
        }

        private void CarregarMetricas()
        {
            try
            {
                OrdemServicoDAO osDao = new OrdemServicoDAO();
                DespesaDAO despDao = new DespesaDAO();

                int osAbertas = osDao.ContarAbertas();
                int concluidasMes = osDao.ContarConcluidasMesAtual();
                decimal faturamentoMes = osDao.SomarFaturamentoMesAtual();
                decimal despesasMes = despDao.SomarDespesasMesAtual();
                decimal saldoMes = faturamentoMes - despesasMes;

                lblOsAbertasValor.Text = osAbertas.ToString();
                lblConcluidasValor.Text = concluidasMes.ToString();
                lblFaturamentoValor.Text = "R$ " + faturamentoMes.ToString("N2");
                lblDespesasValor.Text = "R$ " + despesasMes.ToString("N2");

                lblSaldoValor.Text = "R$ " + saldoMes.ToString("N2");
                lblSaldoValor.ForeColor = saldoMes >= 0
                    ? Color.FromArgb(16, 185, 129)
                    : Color.FromArgb(239, 68, 68);

                lblAtualizadoEm.Text = "Última atualização: " + DateTime.Now.ToString("HH:mm:ss");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao carregar métricas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
