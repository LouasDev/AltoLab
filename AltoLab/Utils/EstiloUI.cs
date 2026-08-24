using System.Drawing;
using System.Windows.Forms;

namespace AltoLab.Utils
{
    public static class EstiloUI
    {
        // Cores da Marca AltoLab
        public static readonly Color CorNavyEscuro = Color.FromArgb(30, 41, 59);    // #1E293B
        public static readonly Color CorCyanAltoLab = Color.FromArgb(14, 165, 233);   // #0EA5E9
        public static readonly Color CorFundoForm = Color.FromArgb(241, 245, 249);   // #F1F5F9
        public static readonly Color CorTextoEscuro = Color.FromArgb(15, 23, 42);    // #0F172A
        public static readonly Color CorSucesso = Color.FromArgb(34, 197, 94);     // #22C55E
        public static readonly Color CorAlerta = Color.FromArgb(234, 179, 8);      // #EAB308
        public static readonly Color CorErro = Color.FromArgb(239, 68, 68);        // #EF4444

        public static void EstilizarForm(Form form)
        {
            form.BackColor = CorFundoForm;
            form.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            form.StartPosition = FormStartPosition.CenterScreen;
        }

        public static void EstilizarGrid(DataGridView grid)
        {
            grid.BackgroundColor = Color.White;
            grid.BorderStyle = BorderStyle.None;
            grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            grid.GridColor = Color.FromArgb(226, 232, 240);
            grid.RowHeadersVisible = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.MultiSelect = false;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.ReadOnly = true;

            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersDefaultCellStyle.BackColor = CorNavyEscuro;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            grid.ColumnHeadersHeight = 35;

            grid.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            grid.DefaultCellStyle.ForeColor = CorTextoEscuro;
            grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 242, 254);
            grid.DefaultCellStyle.SelectionForeColor = CorNavyEscuro;
            grid.RowTemplate.Height = 32;
        }

        public static void EstilizarBotaoPrimario(Button btn)
        {
            btn.BackColor = CorCyanAltoLab;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;
        }

        public static void EstilizarBotaoSecundario(Button btn)
        {
            btn.BackColor = CorNavyEscuro;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;
        }

        public static void EstilizarBotaoPerigo(Button btn)
        {
            btn.BackColor = CorErro;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;
        }
    }
}
