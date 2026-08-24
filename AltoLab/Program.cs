using System;
using System.Windows.Forms;
using AltoLab.Database;
using AltoLab.Forms;

namespace AltoLab
{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Cria o banco SQLite (AltoLabDB.db) na primeira execucao, se nao existir
            try
            {
                ConexaoBD.GarantirBancoCriado();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro de Banco de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Application.Run(new FrmLogin());
        }
    }
}
