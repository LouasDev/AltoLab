using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using AltoLab.DAO;
using AltoLab.Models;
using AltoLab.Utils;

namespace AltoLab.Forms
{
    public class FrmCadastroOS : Form
    {
        private readonly int osIdEdicao; // 0 = nova OS

        private readonly ComboBox cboCliente = new ComboBox();
        private readonly TextBox txtEquipamento = new TextBox();
        private readonly TextBox txtProblema = new TextBox();
        private readonly ComboBox cboStatus = new ComboBox();
        private readonly ComboBox cboServico = new ComboBox();
        private readonly TextBox txtValorServico = new TextBox();
        private readonly DataGridView gridItens = new DataGridView();
        private readonly DataTable tabelaItens = new DataTable();
        private readonly Label lblTotal = new Label();
        private readonly Button btnAdicionarItem = new Button();
        private readonly Button btnRemoverItem = new Button();
        private readonly Button btnSalvar = new Button();
        private readonly Button btnCancelar = new Button();

        public FrmCadastroOS() : this(0)
        {
        }

        public FrmCadastroOS(int idOrdemServicoParaEditar)
        {
            osIdEdicao = idOrdemServicoParaEditar;
            MontarTela();
            CarregarClientes();
            CarregarServicos();
            ConfigurarTabelaItens();

            if (osIdEdicao > 0)
            {
                CarregarOrdemServico(osIdEdicao);
            }
        }

        private void MontarTela()
        {
            EstiloUI.EstilizarForm(this);
            Text = (osIdEdicao > 0 ? "Editar OS nº " + osIdEdicao : "Nova Ordem de Serviço") + " — AltoLab";
            Size = new Size(920, 620);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            Label lblTituloTela = new Label
            {
                Text = osIdEdicao > 0 ? "Editar Ordem de Serviço nº " + osIdEdicao : "Nova Ordem de Serviço",
                Font = new Font("Segoe UI", 15F, FontStyle.Bold),
                ForeColor = EstiloUI.CorNavyEscuro,
                AutoSize = true,
                Location = new Point(20, 15)
            };

            // --- Coluna esquerda: dados da OS ---
            Label lblCliente = new Label { Text = "Cliente (*):", AutoSize = true, Location = new Point(25, 60) };
            cboCliente.SetBounds(25, 80, 400, 26);
            cboCliente.DropDownStyle = ComboBoxStyle.DropDownList;

            Label lblEquipamento = new Label { Text = "Equipamento (*):", AutoSize = true, Location = new Point(25, 120) };
            txtEquipamento.SetBounds(25, 140, 400, 26);

            Label lblProblema = new Label { Text = "Problema Relatado (*):", AutoSize = true, Location = new Point(25, 180) };
            txtProblema.SetBounds(25, 200, 400, 70);
            txtProblema.Multiline = true;

            Label lblStatus = new Label { Text = "Status:", AutoSize = true, Location = new Point(25, 285) };
            cboStatus.SetBounds(25, 305, 200, 26);
            cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cboStatus.Items.AddRange(new object[] { "Aberta", "Em andamento", "Concluída", "Entregue" });
            cboStatus.SelectedIndex = 0;
            cboStatus.SelectedIndexChanged += CboStatus_SelectedIndexChanged;

            // --- Coluna direita: serviços da OS ---
            GroupBox grpItens = new GroupBox
            {
                Text = "Serviços da OS",
                Location = new Point(450, 50),
                Size = new Size(440, 160)
            };

            Label lblServico = new Label { Text = "Serviço:", AutoSize = true, Location = new Point(15, 28) };
            cboServico.SetBounds(15, 48, 300, 26);
            cboServico.DropDownStyle = ComboBoxStyle.DropDownList;
            cboServico.SelectedIndexChanged += CboServico_SelectedIndexChanged;

            Label lblValorServico = new Label { Text = "Valor (R$):", AutoSize = true, Location = new Point(325, 32) };
            txtValorServico.SetBounds(325, 48, 95, 26);
            txtValorServico.TextAlign = HorizontalAlignment.Right;
            txtValorServico.KeyPress += TxtValorServico_KeyPress;

            btnAdicionarItem.Text = "+ Adicionar";
            btnAdicionarItem.SetBounds(15, 88, 130, 34);
            EstiloUI.EstilizarBotaoPrimario(btnAdicionarItem);
            btnAdicionarItem.Click += BtnAdicionarItem_Click;

            btnRemoverItem.Text = "- Remover Selecionado";
            btnRemoverItem.SetBounds(155, 88, 190, 34);
            EstiloUI.EstilizarBotaoPerigo(btnRemoverItem);
            btnRemoverItem.Click += BtnRemoverItem_Click;

            grpItens.Controls.AddRange(new Control[]
            {
                lblServico, cboServico, lblValorServico, txtValorServico, btnAdicionarItem, btnRemoverItem
            });

            // --- Grid de itens ---
            EstiloUI.EstilizarGrid(gridItens);
            gridItens.Location = new Point(450, 220);
            gridItens.Size = new Size(440, 170);

            // --- Rodapé: total e botões ---
            lblTotal.Text = "VALOR TOTAL: R$ 0,00";
            lblTotal.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTotal.ForeColor = EstiloUI.CorCyanAltoLab;
            lblTotal.SetBounds(450, 400, 440, 30);
            lblTotal.TextAlign = ContentAlignment.MiddleRight;

            btnSalvar.Text = "SALVAR ORDEM DE SERVIÇO";
            btnSalvar.SetBounds(450, 445, 440, 46);
            EstiloUI.EstilizarBotaoPrimario(btnSalvar);
            btnSalvar.Click += BtnSalvar_Click;

            btnCancelar.Text = "Cancelar";
            btnCancelar.SetBounds(25, 510, 200, 42);
            EstiloUI.EstilizarBotaoSecundario(btnCancelar);
            btnCancelar.Click += (s, e) => Close();

            Controls.Add(lblTituloTela);
            Controls.Add(lblCliente);
            Controls.Add(cboCliente);
            Controls.Add(lblEquipamento);
            Controls.Add(txtEquipamento);
            Controls.Add(lblProblema);
            Controls.Add(txtProblema);
            Controls.Add(lblStatus);
            Controls.Add(cboStatus);
            Controls.Add(grpItens);
            Controls.Add(gridItens);
            Controls.Add(lblTotal);
            Controls.Add(btnSalvar);
            Controls.Add(btnCancelar);
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

            gridItens.DataSource = tabelaItens;

            gridItens.Columns["ServicoId"].Visible = false;
            gridItens.Columns["Descricao"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            gridItens.Columns["Descricao"].HeaderText = "Serviço";
            gridItens.Columns["Valor"].Width = 120;
            gridItens.Columns["Valor"].HeaderText = "Valor";
            gridItens.Columns["Valor"].DefaultCellStyle.Format = "C2";
            gridItens.Columns["Valor"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
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
            if (gridItens.CurrentRow == null)
            {
                MessageBox.Show("Selecione um item no grid para remover.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow linha = gridItens.CurrentRow;
            gridItens.EndEdit();
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
    }
}
