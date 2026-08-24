using System;
using System.Data;
using System.Data.SQLite;
using AltoLab.Database;
using AltoLab.Models;
using AltoLab.Utils;

namespace AltoLab.DAO
{
    public class UsuarioDAO
    {
        public Usuario Autenticar(string login, string senhaPura)
        {
            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(senhaPura))
                return null;

            string senhaHash = SecurityUtils.GerarHashSHA256(senhaPura);
            const string sql = "SELECT Id, Login, Senha, NomeCompleto FROM Usuarios WHERE Login = @Login AND Senha = @Senha";

            try
            {
                using (SQLiteConnection con = ConexaoBD.ObterConexao())
                using (SQLiteCommand cmd = new SQLiteCommand(sql, con))
                {
                    cmd.Parameters.Add("@Login", DbType.String).Value = login.Trim();
                    cmd.Parameters.Add("@Senha", DbType.String).Value = senhaHash;

                    con.Open();
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Usuario
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Login = reader["Login"].ToString(),
                                Senha = reader["Senha"].ToString(),
                                NomeCompleto = reader["NomeCompleto"].ToString()
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao autenticar usuário no banco de dados: " + ex.Message, ex);
            }

            return null;
        }
    }
}
