using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using AltoLab.Database;
using AltoLab.Models;

namespace AltoLab.DAO
{
    public class ClienteDAO
    {
        public List<Cliente> ListarTodos(string filtroNome = "")
        {
            List<Cliente> lista = new List<Cliente>();
            string sql = "SELECT Id, Nome, Telefone, Email, Endereco, DataCadastro FROM Clientes";
            if (!string.IsNullOrWhiteSpace(filtroNome))
            {
                sql += " WHERE Nome LIKE @Filtro";
            }
            sql += " ORDER BY Nome ASC";

            try
            {
                using (SQLiteConnection con = ConexaoBD.ObterConexao())
                using (SQLiteCommand cmd = new SQLiteCommand(sql, con))
                {
                    if (!string.IsNullOrWhiteSpace(filtroNome))
                    {
                        cmd.Parameters.Add("@Filtro", DbType.String).Value = "%" + filtroNome.Trim() + "%";
                    }

                    con.Open();
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Cliente
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Nome = reader["Nome"].ToString(),
                                Telefone = reader["Telefone"] != DBNull.Value ? reader["Telefone"].ToString() : string.Empty,
                                Email = reader["Email"] != DBNull.Value ? reader["Email"].ToString() : string.Empty,
                                Endereco = reader["Endereco"] != DBNull.Value ? reader["Endereco"].ToString() : string.Empty,
                                DataCadastro = Convert.ToDateTime(reader["DataCadastro"])
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar clientes: " + ex.Message, ex);
            }

            return lista;
        }

        public Cliente BuscarPorId(int id)
        {
            const string sql = "SELECT Id, Nome, Telefone, Email, Endereco, DataCadastro FROM Clientes WHERE Id = @Id";

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
                            return new Cliente
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Nome = reader["Nome"].ToString(),
                                Telefone = reader["Telefone"] != DBNull.Value ? reader["Telefone"].ToString() : string.Empty,
                                Email = reader["Email"] != DBNull.Value ? reader["Email"].ToString() : string.Empty,
                                Endereco = reader["Endereco"] != DBNull.Value ? reader["Endereco"].ToString() : string.Empty,
                                DataCadastro = Convert.ToDateTime(reader["DataCadastro"])
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar cliente por ID: " + ex.Message, ex);
            }

            return null;
        }

        public void Inserir(Cliente cliente)
        {
            const string sql = @"INSERT INTO Clientes (Nome, Telefone, Email, Endereco)
                                 VALUES (@Nome, @Telefone, @Email, @Endereco);";

            try
            {
                using (SQLiteConnection con = ConexaoBD.ObterConexao())
                {
                    con.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, con))
                    {
                        cmd.Parameters.Add("@Nome", DbType.String).Value = cliente.Nome.Trim();
                        cmd.Parameters.Add("@Telefone", DbType.String).Value = (object)cliente.Telefone ?? DBNull.Value;
                        cmd.Parameters.Add("@Email", DbType.String).Value = (object)cliente.Email ?? DBNull.Value;
                        cmd.Parameters.Add("@Endereco", DbType.String).Value = (object)cliente.Endereco ?? DBNull.Value;

                        cmd.ExecuteNonQuery();
                    }

                    using (SQLiteCommand cmdId = new SQLiteCommand("SELECT last_insert_rowid();", con))
                    {
                        cliente.Id = Convert.ToInt32(cmdId.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar cliente: " + ex.Message, ex);
            }
        }

        public void Atualizar(Cliente cliente)
        {
            const string sql = @"UPDATE Clientes
                                 SET Nome = @Nome, Telefone = @Telefone, Email = @Email, Endereco = @Endereco
                                 WHERE Id = @Id";

            try
            {
                using (SQLiteConnection con = ConexaoBD.ObterConexao())
                using (SQLiteCommand cmd = new SQLiteCommand(sql, con))
                {
                    cmd.Parameters.Add("@Id", DbType.Int32).Value = cliente.Id;
                    cmd.Parameters.Add("@Nome", DbType.String).Value = cliente.Nome.Trim();
                    cmd.Parameters.Add("@Telefone", DbType.String).Value = (object)cliente.Telefone ?? DBNull.Value;
                    cmd.Parameters.Add("@Email", DbType.String).Value = (object)cliente.Email ?? DBNull.Value;
                    cmd.Parameters.Add("@Endereco", DbType.String).Value = (object)cliente.Endereco ?? DBNull.Value;

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar cliente: " + ex.Message, ex);
            }
        }

        public void Excluir(int id)
        {
            const string sql = "DELETE FROM Clientes WHERE Id = @Id";

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
                    throw new Exception("Não é possível excluir este cliente pois existem Ordens de Serviço vinculadas a ele.");
                }
                throw new Exception("Erro no banco de dados ao excluir cliente: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao excluir cliente: " + ex.Message, ex);
            }
        }
    }
}
