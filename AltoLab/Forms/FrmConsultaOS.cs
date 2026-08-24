using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using AltoLab.DAO;
using AltoLab.Models;
using AltoLab.Utils;

namespace AltoLab.Forms
{
    public class FrmConsultaOS : Form
    {
        private readonly ComboBox cboStatus = new ComboBox();
        private readonly TextBox txtCliente = new TextBox();
        private readonly CheckBox chkPeriodo = new CheckBox();
        private readonly DateTimePicker dtpInicial = new DateTimePicker();
        private readonly DateTimePicker dtpFinal = new DateTimePicker();
        private readonly DataGridView grid = new DataGridView();
        private readonly Button btnFiltrar = new Button();
        private readonly Button btnEditar = new Button();
        private readonly Button btnLimparFiltros = new Button();

        public FrmConsultaOS()
        {
            MontarTela();
            CarregarGrid();
        }

        private void MontarTela()
        {
            EstiloUI.EstilizarForm(this);
            Text = "Consulta de Ordens de Serviço — AltoLab";
            Size = new Size(1000, 600);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            Label lblTituloTela = new Label
            {
                Text = "Consulta de Ordens de Serviço",
                Font = new Font("Segoe UI", 15F, FontStyle.Bold),
                ForeColor = EstiloUI.CorNavyEscuro,
                AutoSize = true,
                Location = new Point(20, 15)
            };

            Label lblStatus = new Label { Text = "Status:", AutoSize = true, Location = new Point(25, 62) };
            cboStatus.SetBounds(70, 58, 150, 26);
            cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cboStatus.Items.AddRange(new object[] { "Todos", "Aberta", "Em andamento", "Concluída", "Entregue" });
            cboStatus.SelectedIndex = 0;

            Label lblCliente = new Label { Text = "Cliente:", AutoSize = true, Location = new Point(240, 62) };
            txtCliente.SetBounds(290, 58, 180, 26);

            chkPeriodo.Text = "Período:";
            chkPeriodo.AutoSize = true;
            chkPeriodo.Location = new Point(490, 61);
            chkPeriodo.CheckedChanged += (s, e) =>
            {
                dtpInicial.Enabled = dtpFinal.Enabled = chkPeriodo.Checked;
            };

            dtpInicial.SetBounds(555, 58, 110, 26);
            dtpInicial.Format = DateTimePickerFormat.Short;
            dtpInicial.Enabled = false;
            dtpInicial.Value = DateTime.Today.AddMonths(-1);

            Label lblAte = new Label { Text = "até", AutoSize = true, Location = new Point(670, 62) };

            dtpFinal.SetBounds(700, 58, 110, 26);
            dtpFinal.Format = DateTimePickerFormat.Short;
            dtpFinal.Enabled = false;
            dtpFinal.Value = DateTime.Today;

            btnFiltrar.Text = "Filtrar";
            btnFiltrar.SetBounds(830, 53, 90, 34);
            EstiloUI.EstilizarBotaoPrimario(btnFiltrar);
            btnFiltrar.Click += (s, e) => CarregarGrid();

            btnLimparFiltros.Text = "Limpar Filtros";
            btnLimparFiltros.SetBounds(20, 95, 130, 32);
            btnLimparFiltros.FlatStyle = FlatStyle.Flat;
            btnLimparFiltros.Click += BtnLimparFiltros_Click;

            EstiloUI.EstilizarGrid(grid);
            grid.Location = new Point(20, 135);
            grid.Size = new Size(944, 330);
            grid.CellDoubleClick += Grid_CellDoubleClick;

            btnEditar.Text = "EDITAR OS SELECIONADA";
            btnEditar.SetBounds(740, 480, 224, 42);
            EstiloUI.EstilizarBotaoPrimario(btnEditar);
            btnEditar.Click += BtnEditar_Click;

            Controls.Add(lblTituloTela);
            Controls.Add(lblStatus);
            Controls.Add(cboStatus);
            Controls.Add(lblCliente);
            Controls.Add(txtCliente);
            Controls.Add(chkPeriodo);
            Controls.Add(dtpInicial);
            Controls.Add(lblAte);
            Controls.Add(dtpFinal);
            Controls.Add(btnFiltrar);
            Controls.Add(btnLimparFiltros);
            Controls.Add(grid);
            Controls.Add(btnEditar);
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
                System.Collections.Generic.List<OrdemServico> ordens = dao.Consultar(statusSelecionado, filtroCliente, dataInicial, dataFinal);

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

                grid.DataSource = tabela;

                if (grid.Columns["Id"] != null)
                {
                    grid.Columns["Id"].Width = 60;
                    grid.Columns["Id"].HeaderText = "Nº OS";
                }
                if (grid.Columns["ClienteNome"] != null)
                {
                    grid.Columns["ClienteNome"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    grid.Columns["ClienteNome"].HeaderText = "Cliente";
                }
                if (grid.Columns["Equipamento"] != null)
                {
                    grid.Columns["Equipamento"].Width = 200;
                    grid.Columns["Equipamento"].HeaderText = "Equipamento";
                }
                if (grid.Columns["Status"] != null)
                {
                    grid.Columns["Status"].Width = 120;
                    grid.Columns["Status"].HeaderText = "Status";
                }
                if (grid.Columns["DataAbertura"] != null)
                {
                    grid.Columns["DataAbertura"].Width = 110;
                    grid.Columns["DataAbertura"].HeaderText = "Abertura";
                    grid.Columns["DataAbertura"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                }
                if (grid.Columns["ValorTotal"] != null)
                {
                    grid.Columns["ValorTotal"].Width = 110;
                    grid.Columns["ValorTotal"].HeaderText = "Valor Total";
                    grid.Columns["ValorTotal"].DefaultCellStyle.Format = "C2";
                    grid.Columns["ValorTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao consultar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            if (grid.CurrentRow == null) return 0;

            object valorId = grid.CurrentRow.Cells["Id"].Value;
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
