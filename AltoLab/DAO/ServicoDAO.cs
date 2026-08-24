using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using AltoLab.Database;
using AltoLab.Models;

namespace AltoLab.DAO
{
    public class ServicoDAO
    {
        public List<Servico> ListarTodos(string filtroDescricao = "")
        {
            List<Servico> lista = new List<Servico>();
            string sql = "SELECT Id, Descricao, ValorPadrao FROM Servicos";
            if (!string.IsNullOrWhiteSpace(filtroDescricao))
            {
                sql += " WHERE Descricao LIKE @Filtro";
            }
            sql += " ORDER BY Descricao ASC";

            try
            {
                using (SQLiteConnection con = ConexaoBD.ObterConexao())
                using (SQLiteCommand cmd = new SQLiteCommand(sql, con))
                {
                    if (!string.IsNullOrWhiteSpace(filtroDescricao))
                    {
                        cmd.Parameters.Add("@Filtro", DbType.String).Value = "%" + filtroDescricao.Trim() + "%";
                    }

                    con.Open();
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Servico
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Descricao = reader["Descricao"].ToString(),
                                ValorPadrao = Convert.ToDecimal(reader["ValorPadrao"])
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar serviços: " + ex.Message, ex);
            }

            return lista;
        }

        public Servico BuscarPorId(int id)
        {
            const string sql = "SELECT Id, Descricao, ValorPadrao FROM Servicos WHERE Id = @Id";

            try
            {
                using (SQLiteConnection con = ConexaoBD.ObterConexao())
                using (SQLiteCommand cmd = new SQLiteCommand(sql, con))
                {
                    cmd.Parameters.Add("@Id", DbType.Int32).Value = id;

                    con.Open();
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Servico
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Descricao = reader["Descricao"].ToString(),
                                ValorPadrao = Convert.ToDecimal(reader["ValorPadrao"])
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar serviço por ID: " + ex.Message, ex);
            }

            return null;
        }

        public void Inserir(Servico servico)
        {
            const string sql = @"INSERT INTO Servicos (Descricao, ValorPadrao)
                                 VALUES (@Descricao, @ValorPadrao);";

            try
            {
                using (SQLiteConnection con = ConexaoBD.ObterConexao())
                {
                    con.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, con))
                    {
                        cmd.Parameters.Add("@Descricao", DbType.String).Value = servico.Descricao.Trim();
                        cmd.Parameters.Add("@ValorPadrao", DbType.Decimal).Value = servico.ValorPadrao;

                        cmd.ExecuteNonQuery();
                    }

                    using (SQLiteCommand cmdId = new SQLiteCommand("SELECT last_insert_rowid();", con))
                    {
                        servico.Id = Convert.ToInt32(cmdId.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar serviço: " + ex.Message, ex);
            }
        }

        public void Atualizar(Servico servico)
        {
            const string sql = @"UPDATE Servicos
                                 SET Descricao = @Descricao, ValorPadrao = @ValorPadrao
                                 WHERE Id = @Id";

            try
            {
                using (SQLiteConnection con = ConexaoBD.ObterConexao())
                using (SQLiteCommand cmd = new SQLiteCommand(sql, con))
                {
                    cmd.Parameters.Add("@Id", DbType.Int32).Value = servico.Id;
                    cmd.Parameters.Add("@Descricao", DbType.String).Value = servico.Descricao.Trim();
                    cmd.Parameters.Add("@ValorPadrao", DbType.Decimal).Value = servico.ValorPadrao;

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar serviço: " + ex.Message, ex);
            }
        }

        public void Excluir(int id)
        {
            const string sql = "DELETE FROM Servicos WHERE Id = @Id";

            try
            {
                using (SQLiteConnection con = ConexaoBD.ObterConexao())
                using (SQLiteCommand cmd = new SQLiteCommand(sql, con))
                {
                    cmd.Parameters.Add("@Id", DbType.Int32).Value = id;

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SQLiteException ex)
            {
                // No SQLite a violacao de FK chega como SQLITE_CONSTRAINT com essa mensagem
                if (ex.Message.IndexOf("FOREIGN KEY constraint failed", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    throw new Exception("Não é possível excluir este serviço pois ele está vinculado a itens de Ordens de Serviço.");
                }
                throw new Exception("Erro no banco de dados ao excluir serviço: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao excluir serviço: " + ex.Message, ex);
            }
        }
    }
}
