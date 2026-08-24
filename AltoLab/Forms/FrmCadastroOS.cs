using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using AltoLab.DAO;
using AltoLab.Models;

namespace AltoLab.Forms
{
    public partial class FrmCadastroOS : Form
    {
        private readonly int osIdEdicao; // 0 = nova OS

        private readonly DataTable tabelaItens = new DataTable();

        public FrmCadastroOS() : this(0)
        {
        }

        public FrmCadastroOS(int idOrdemServicoParaEditar)
        {
            InitializeComponent();

            osIdEdicao = idOrdemServicoParaEditar;

            // Título depende do modo (novo x edição) — definido em runtime
            if (osIdEdicao > 0)
            {
                Text = "Editar OS nº " + osIdEdicao + " — AltoLab";
                lblTituloTela.Text = "Editar Ordem de Serviço nº " + osIdEdicao;
            }

            CarregarClientes();
            CarregarServicos();
            ConfigurarTabelaItens();

            if (osIdEdicao > 0)
            {
                CarregarOrdemServico(osIdEdicao);
            }
        }

        private void CarregarClientes()
        {
            try
            {
                ClienteDAO dao = new ClienteDAO();
                List<Cliente> clientes = dao.ListarTodos();

                cboCliente.DataSource = null;
                cboCliente.Items.Clear();
                List<object> fontes = new List<object>();
                foreach (Cliente c in clientes)
                {
                    fontes.Add(new ItemCombo(c.Id, c.Nome));
                }
                cboCliente.DisplayMember = "Texto";
                cboCliente.ValueMember = "Id";
                cboCliente.DataSource = fontes;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao carregar clientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarServicos()
        {
            try
            {
                ServicoDAO dao = new ServicoDAO();
                List<Servico> servicos = dao.ListarTodos();

                List<ItemCombo> fontes = new List<ItemCombo>();
                foreach (Servico sv in servicos)
                {
                    fontes.Add(new ItemCombo(sv.Id, sv.Descricao));
                }

                cboServico.DisplayMember = "Texto";
                cboServico.ValueMember = "Id";
                cboServico.DataSource = fontes;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao carregar serviços", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private class ItemCombo
        {
            public int Id { get; }
            public string Texto { get; }

            public ItemCombo(int id, string texto)
            {
                Id = id;
                Texto = texto;
            }

            public override string ToString()
            {
                return Texto;
            }
        }

        private void CboServico_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboServico.SelectedValue == null) return;
                if (!(cboServico.SelectedValue is int)) return;

                ServicoDAO dao = new ServicoDAO();
                Servico servico = dao.BuscarPorId((int)cboServico.SelectedValue);
                if (servico != null && string.IsNullOrWhiteSpace(txtValorServico.Text))
                {
                    txtValorServico.Text = servico.ValorPadrao.ToString("N2");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Preenche DataConclusao automaticamente quando a OS é concluída/entregue
            if (osIdEdicao == 0) return;
        }

        private void TxtValorServico_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool teclaValida = char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar) || e.KeyChar == ',' || e.KeyChar == '.';
            if (!teclaValida)
            {
                e.Handled = true;
                return;
            }
            if (e.KeyChar == '.') e.KeyChar = ',';
            if (e.KeyChar == ',' && txtValorServico.Text.Contains(","))
            {
                e.Handled = true;
            }
        }

        private void ConfigurarTabelaItens()
        {
            tabelaItens.Columns.Clear();
            tabelaItens.Rows.Clear();
            tabelaItens.Columns.Add("ServicoId", typeof(int));
            tabelaItens.Columns.Add("Descricao", typeof(string));
            tabelaItens.Columns.Add("Valor", typeof(decimal));

            dgvItensOS.DataSource = tabelaItens;
        }

        private void BtnAdicionarItem_Click(object sender, EventArgs e)
        {
            if (cboServico.SelectedItem == null)
            {
                MessageBox.Show("Selecione um serviço.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string valorTexto = txtValorServico.Text.Trim().Replace(".", ",");
            if (!decimal.TryParse(valorTexto, out decimal valor) || valor <= 0)
            {
                MessageBox.Show("Informe um valor válido para o serviço.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtValorServico.Focus();
                return;
            }

            int servicoId = ((ItemCombo)cboServico.SelectedItem).Id;
            string descricao = ((ItemCombo)cboServico.SelectedItem).Texto;

            foreach (DataRow linhaExistente in tabelaItens.Rows)
            {
                if (Convert.ToInt32(linhaExistente["ServicoId"]) == servicoId)
                {
                    MessageBox.Show("Este serviço já foi adicionado à OS.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            tabelaItens.Rows.Add(servicoId, descricao, valor);
            txtValorServico.Clear();
            AtualizarTotal();
        }

        private void BtnRemoverItem_Click(object sender, EventArgs e)
        {
            if (dgvItensOS.CurrentRow == null)
            {
                MessageBox.Show("Selecione um item no grid para remover.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow linha = dgvItensOS.CurrentRow;
            dgvItensOS.EndEdit();
            DataRowView drv = linha.DataBoundItem as DataRowView;
            if (drv != null)
            {
                tabelaItens.Rows.Remove(drv.Row);
                AtualizarTotal();
            }
        }

        private void AtualizarTotal()
        {
            decimal total = 0;
            foreach (DataRow linha in tabelaItens.Rows)
            {
                total += Convert.ToDecimal(linha["Valor"]);
            }
            lblTotal.Text = "VALOR TOTAL: R$ " + total.ToString("N2");
        }

        private bool ValidarCampos()
        {
            if (cboCliente.SelectedItem == null)
            {
                MessageBox.Show("Selecione um cliente para a OS.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtEquipamento.Text))
            {
                MessageBox.Show("Informe o equipamento.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEquipamento.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtProblema.Text))
            {
                MessageBox.Show("Informe o problema relatado.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtProblema.Focus();
                return false;
            }
            if (tabelaItens.Rows.Count == 0)
            {
                MessageBox.Show("Adicione pelo menos um serviço à OS.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void CarregarOrdemServico(int id)
        {
            try
            {
                OrdemServicoDAO dao = new OrdemServicoDAO();
                OrdemServico os = dao.BuscarPorId(id);

                if (os == null)
                {
                    MessageBox.Show("Ordem de Serviço não encontrada!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Close();
                    return;
                }

                cboCliente.SelectedValue = os.ClienteId;
                txtEquipamento.Text = os.Equipamento;
                txtProblema.Text = os.ProblemaRelatado;
                cboStatus.SelectedItem = os.Status;

                foreach (ItemOS item in os.Itens)
                {
                    tabelaItens.Rows.Add(item.ServicoId, item.ServicoDescricao, item.Valor);
                }

                AtualizarTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao carregar OS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            try
            {
                OrdemServico os = new OrdemServico
                {
                    Id = osIdEdicao,
                    ClienteId = (int)cboCliente.SelectedValue,
                    Equipamento = txtEquipamento.Text.Trim(),
                    ProblemaRelatado = txtProblema.Text.Trim(),
                    Status = cboStatus.SelectedItem.ToString()
                };

                if (os.Status == "Concluída" || os.Status == "Entregue")
                {
                    os.DataConclusao = DateTime.Now;
                }

                if (osIdEdicao > 0)
                {
                    // Preserva a data de abertura original em edições
                    os.DataAbertura = BuscarDataAberturaOriginal(osIdEdicao);
                }

                foreach (DataRow linha in tabelaItens.Rows)
                {
                    os.Itens.Add(new ItemOS
                    {
                        ServicoId = Convert.ToInt32(linha["ServicoId"]),
                        Valor = Convert.ToDecimal(linha["Valor"])
                    });
                }

                OrdemServicoDAO dao = new OrdemServicoDAO();
                dao.Salvar(os);

                MessageBox.Show(
                    osIdEdicao > 0 ? "Ordem de Serviço atualizada com sucesso!" : "Ordem de Serviço nº " + os.Id + " aberta com sucesso!",
                    "Sucesso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao salvar OS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DateTime BuscarDataAberturaOriginal(int id)
        {
            OrdemServicoDAO dao = new OrdemServicoDAO();
            OrdemServico original = dao.BuscarPorId(id);
            return original != null ? original.DataAbertura : DateTime.Now;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
