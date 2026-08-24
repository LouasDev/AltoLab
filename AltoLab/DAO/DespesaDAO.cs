using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using AltoLab.Database;
using AltoLab.Models;

namespace AltoLab.DAO
{
    public class DespesaDAO
    {
        public List<Despesa> ListarTodos(string filtro = "")
        {
            List<Despesa> lista = new List<Despesa>();
            string sql = "SELECT Id, Descricao, Categoria, Valor, DataDespesa FROM Despesas";
            if (!string.IsNullOrWhiteSpace(filtro))
            {
                sql += " WHERE Descricao LIKE @Filtro OR Categoria LIKE @Filtro";
            }
            sql += " ORDER BY DataDespesa DESC, Id DESC";

            try
            {
                using (SQLiteConnection con = ConexaoBD.ObterConexao())
                using (SQLiteCommand cmd = new SQLiteCommand(sql, con))
                {
                    if (!string.IsNullOrWhiteSpace(filtro))
                    {
                        cmd.Parameters.Add("@Filtro", DbType.String).Value = "%" + filtro.Trim() + "%";
                    }

                    con.Open();
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Despesa
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Descricao = reader["Descricao"].ToString(),
                                Categoria = reader["Categoria"] == DBNull.Value ? "" : reader["Categoria"].ToString(),
                                Valor = Convert.ToDecimal(reader["Valor"]),
                                DataDespesa = Convert.ToDateTime(reader["DataDespesa"])
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar despesas: " + ex.Message, ex);
            }

            return lista;
        }

        public Despesa BuscarPorId(int id)
        {
            const string sql = "SELECT Id, Descricao, Categoria, Valor, DataDespesa FROM Despesas WHERE Id = @Id";

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
                            return new Despesa
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Descricao = reader["Descricao"].ToString(),
                                Categoria = reader["Categoria"] == DBNull.Value ? "" : reader["Categoria"].ToString(),
                                Valor = Convert.ToDecimal(reader["Valor"]),
                                DataDespesa = Convert.ToDateTime(reader["DataDespesa"])
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar despesa por ID: " + ex.Message, ex);
            }

            return null;
        }

        public void Inserir(Despesa despesa)
        {
            const string sql = @"INSERT INTO Despesas (Descricao, Categoria, Valor, DataDespesa)
                                 VALUES (@Descricao, @Categoria, @Valor, @DataDespesa);";

            try
            {
                using (SQLiteConnection con = ConexaoBD.ObterConexao())
                {
                    con.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, con))
                    {
                        cmd.Parameters.Add("@Descricao", DbType.String).Value = despesa.Descricao.Trim();
                        cmd.Parameters.Add("@Categoria", DbType.String).Value = (object)despesa.Categoria ?? DBNull.Value;
                        cmd.Parameters.Add("@Valor", DbType.Decimal).Value = despesa.Valor;
                        cmd.Parameters.Add("@DataDespesa", DbType.DateTime).Value = despesa.DataDespesa;

                        cmd.ExecuteNonQuery();
                    }

                    using (SQLiteCommand cmdId = new SQLiteCommand("SELECT last_insert_rowid();", con))
                    {
                        despesa.Id = Convert.ToInt32(cmdId.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar despesa: " + ex.Message, ex);
            }
        }

        public void Atualizar(Despesa despesa)
        {
            const string sql = @"UPDATE Despesas
                                 SET Descricao = @Descricao, Categoria = @Categoria,
                                     Valor = @Valor, DataDespesa = @DataDespesa
                                 WHERE Id = @Id";

            try
            {
                using (SQLiteConnection con = ConexaoBD.ObterConexao())
                using (SQLiteCommand cmd = new SQLiteCommand(sql, con))
                {
                    cmd.Parameters.Add("@Id", DbType.Int32).Value = despesa.Id;
                    cmd.Parameters.Add("@Descricao", DbType.String).Value = despesa.Descricao.Trim();
                    cmd.Parameters.Add("@Categoria", DbType.String).Value = (object)despesa.Categoria ?? DBNull.Value;
                    cmd.Parameters.Add("@Valor", DbType.Decimal).Value = despesa.Valor;
                    cmd.Parameters.Add("@DataDespesa", DbType.DateTime).Value = despesa.DataDespesa;

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar despesa: " + ex.Message, ex);
            }
        }

        public void Excluir(int id)
        {
            const string sql = "DELETE FROM Despesas WHERE Id = @Id";

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
            catch (Exception ex)
            {
                throw new Exception("Erro ao excluir despesa: " + ex.Message, ex);
            }
        }

        public decimal SomarDespesasMesAtual()
        {
            const string sql = @"SELECT COALESCE(SUM(Valor), 0)
                                 FROM Despesas
                                 WHERE DataDespesa >= date('now', 'start of month')
                                   AND DataDespesa < date('now', 'start of month', '+1 month')";

            try
            {
                using (SQLiteConnection con = ConexaoBD.ObterConexao())
                using (SQLiteCommand cmd = new SQLiteCommand(sql, con))
                {
                    con.Open();
                    return Convert.ToDecimal(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao calcular despesas do mês: " + ex.Message, ex);
            }
        }
    }
}
