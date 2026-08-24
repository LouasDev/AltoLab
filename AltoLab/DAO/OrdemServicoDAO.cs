using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using AltoLab.Database;
using AltoLab.Models;

namespace AltoLab.DAO
{
    public class OrdemServicoDAO
    {
        public void Salvar(OrdemServico os)
        {
            try
            {
                using (SQLiteConnection con = ConexaoBD.ObterConexao())
                {
                    con.Open();
                    using (SQLiteTransaction trans = con.BeginTransaction())
                    {
                        try
                        {
                            int osId;

                            if (os.Id == 0)
                            {
                                const string sqlInsert = @"INSERT INTO OrdensServico
                                    (ClienteId, Equipamento, ProblemaRelatado, Status, DataAbertura, DataConclusao, ValorTotal)
                                    VALUES (@ClienteId, @Equipamento, @ProblemaRelatado, @Status, @DataAbertura, @DataConclusao, @ValorTotal);";

                                using (SQLiteCommand cmd = new SQLiteCommand(sqlInsert, con, trans))
                                {
                                    PreencherParametros(cmd, os);
                                    cmd.ExecuteNonQuery();
                                }

                                // Equivalente ao SCOPE_IDENTITY() do SQL Server
                                using (SQLiteCommand cmdId = new SQLiteCommand("SELECT last_insert_rowid();", con, trans))
                                {
                                    osId = Convert.ToInt32(cmdId.ExecuteScalar());
                                }
                                os.Id = osId;
                            }
                            else
                            {
                                const string sqlUpdate = @"UPDATE OrdensServico
                                    SET ClienteId = @ClienteId, Equipamento = @Equipamento,
                                        ProblemaRelatado = @ProblemaRelatado, Status = @Status,
                                        DataConclusao = @DataConclusao, ValorTotal = @ValorTotal
                                    WHERE Id = @Id";

                                using (SQLiteCommand cmd = new SQLiteCommand(sqlUpdate, con, trans))
                                {
                                    PreencherParametros(cmd, os);
                                    cmd.Parameters.Add("@Id", DbType.Int32).Value = os.Id;
                                    cmd.ExecuteNonQuery();
                                }

                                // Remove itens antigos para reinsercao
                                const string sqlDeleteItens = "DELETE FROM ItensOS WHERE OrdemServicoId = @OrdemServicoId";
                                using (SQLiteCommand cmdDel = new SQLiteCommand(sqlDeleteItens, con, trans))
                                {
                                    cmdDel.Parameters.Add("@OrdemServicoId", DbType.Int32).Value = os.Id;
                                    cmdDel.ExecuteNonQuery();
                                }

                                osId = os.Id;
                            }

                            foreach (ItemOS item in os.Itens)
                            {
                                const string sqlItem = @"INSERT INTO ItensOS (OrdemServicoId, ServicoId, Valor)
                                    VALUES (@OrdemServicoId, @ServicoId, @Valor);";

                                using (SQLiteCommand cmdItem = new SQLiteCommand(sqlItem, con, trans))
                                {
                                    cmdItem.Parameters.Add("@OrdemServicoId", DbType.Int32).Value = osId;
                                    cmdItem.Parameters.Add("@ServicoId", DbType.Int32).Value = item.ServicoId;
                                    cmdItem.Parameters.Add("@Valor", DbType.Decimal).Value = item.Valor;
                                    cmdItem.ExecuteNonQuery();
                                }
                            }

                            trans.Commit();
                        }
                        catch (Exception)
                        {
                            try
                            {
                                trans.Rollback();
                            }
                            catch (Exception exRollback)
                            {
                                throw new Exception("Erro ao reverter a operação (Rollback): " + exRollback.Message);
                            }
                            throw; // Repassa a exceção original para o Form exibir
                        }
                    }
                }
            }
            catch (SQLiteException ex)
            {
                // No SQLite a violacao de FK chega como SQLITE_CONSTRAINT com essa mensagem
                if (ex.Message.IndexOf("FOREIGN KEY constraint failed", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    throw new Exception("Verifique o cliente e os serviços selecionados. Não foi possível salvar a Ordem de Serviço.");
                }
                throw new Exception("Erro no banco de dados ao salvar a Ordem de Serviço: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao salvar a Ordem de Serviço: " + ex.Message, ex);
            }
        }

        private static void PreencherParametros(SQLiteCommand cmd, OrdemServico os)
        {
            cmd.Parameters.Add("@ClienteId", DbType.Int32).Value = os.ClienteId;
            cmd.Parameters.Add("@Equipamento", DbType.String).Value = (object)os.Equipamento ?? DBNull.Value;
            cmd.Parameters.Add("@ProblemaRelatado", DbType.String).Value = (object)os.ProblemaRelatado ?? DBNull.Value;
            cmd.Parameters.Add("@Status", DbType.String).Value = os.Status;
            cmd.Parameters.Add("@DataAbertura", DbType.DateTime).Value = os.DataAbertura;
            cmd.Parameters.Add("@DataConclusao", DbType.DateTime).Value = (object)os.DataConclusao ?? DBNull.Value;
            cmd.Parameters.Add("@ValorTotal", DbType.Decimal).Value = os.ValorTotal;
        }

        public List<OrdemServico> Consultar(string status, string filtroCliente, DateTime? dataInicial, DateTime? dataFinal)
        {
            List<OrdemServico> lista = new List<OrdemServico>();

            string sql = @"SELECT OS.Id, OS.ClienteId, C.Nome AS ClienteNome, OS.Equipamento,
                                  OS.ProblemaRelatado, OS.Status, OS.DataAbertura, OS.DataConclusao, OS.ValorTotal
                           FROM OrdensServico OS
                           INNER JOIN Clientes C ON C.Id = OS.ClienteId
                           WHERE 1 = 1";

            if (!string.IsNullOrWhiteSpace(status))
            {
                sql += " AND OS.Status = @Status";
            }
            if (!string.IsNullOrWhiteSpace(filtroCliente))
            {
                sql += " AND C.Nome LIKE @FiltroCliente";
            }
            if (dataInicial.HasValue)
            {
                sql += " AND OS.DataAbertura >= @DataInicial";
            }
            if (dataFinal.HasValue)
            {
                sql += " AND OS.DataAbertura <= @DataFinal";
            }
            sql += " ORDER BY OS.DataAbertura DESC";

            try
            {
                using (SQLiteConnection con = ConexaoBD.ObterConexao())
                using (SQLiteCommand cmd = new SQLiteCommand(sql, con))
                {
                    if (!string.IsNullOrWhiteSpace(status))
                    {
                        cmd.Parameters.Add("@Status", DbType.String).Value = status.Trim();
                    }
                    if (!string.IsNullOrWhiteSpace(filtroCliente))
                    {
                        cmd.Parameters.Add("@FiltroCliente", DbType.String).Value = "%" + filtroCliente.Trim() + "%";
                    }
                    if (dataInicial.HasValue)
                    {
                        cmd.Parameters.Add("@DataInicial", DbType.DateTime).Value = dataInicial.Value.Date;
                    }
                    if (dataFinal.HasValue)
                    {
                        cmd.Parameters.Add("@DataFinal", DbType.DateTime).Value = dataFinal.Value.Date.AddDays(1).AddSeconds(-1);
                    }

                    con.Open();
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new OrdemServico
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                ClienteId = Convert.ToInt32(reader["ClienteId"]),
                                ClienteNome = reader["ClienteNome"].ToString(),
                                Equipamento = reader["Equipamento"] != DBNull.Value ? reader["Equipamento"].ToString() : string.Empty,
                                ProblemaRelatado = reader["ProblemaRelatado"] != DBNull.Value ? reader["ProblemaRelatado"].ToString() : string.Empty,
                                Status = reader["Status"].ToString(),
                                DataAbertura = Convert.ToDateTime(reader["DataAbertura"]),
                                DataConclusao = reader["DataConclusao"] != DBNull.Value ? Convert.ToDateTime(reader["DataConclusao"]) : (DateTime?)null,
                                ValorTotal = Convert.ToDecimal(reader["ValorTotal"])
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao consultar Ordens de Serviço: " + ex.Message, ex);
            }

            return lista;
        }

        public OrdemServico BuscarPorId(int id)
        {
            const string sqlOs = @"SELECT OS.Id, OS.ClienteId, C.Nome AS ClienteNome, OS.Equipamento,
                                          OS.ProblemaRelatado, OS.Status, OS.DataAbertura, OS.DataConclusao, OS.ValorTotal
                                   FROM OrdensServico OS
                                   INNER JOIN Clientes C ON C.Id = OS.ClienteId
                                   WHERE OS.Id = @Id";

            try
            {
                using (SQLiteConnection con = ConexaoBD.ObterConexao())
                {
                    OrdemServico os = null;

                    using (SQLiteCommand cmd = new SQLiteCommand(sqlOs, con))
                    {
                        cmd.Parameters.Add("@Id", DbType.Int32).Value = id;

                        con.Open();
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                os = new OrdemServico
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    ClienteId = Convert.ToInt32(reader["ClienteId"]),
                                    ClienteNome = reader["ClienteNome"].ToString(),
                                    Equipamento = reader["Equipamento"] != DBNull.Value ? reader["Equipamento"].ToString() : string.Empty,
                                    ProblemaRelatado = reader["ProblemaRelatado"] != DBNull.Value ? reader["ProblemaRelatado"].ToString() : string.Empty,
                                    Status = reader["Status"].ToString(),
                                    DataAbertura = Convert.ToDateTime(reader["DataAbertura"]),
                                    DataConclusao = reader["DataConclusao"] != DBNull.Value ? Convert.ToDateTime(reader["DataConclusao"]) : (DateTime?)null,
                                    ValorTotal = Convert.ToDecimal(reader["ValorTotal"])
                                };
                            }
                        }
                    }

                    if (os != null)
                    {
                        os.Itens = ListarItens(con, os.Id);
                    }

                    return os;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao carregar a Ordem de Serviço nº " + id + ": " + ex.Message, ex);
            }
        }

        private static List<ItemOS> ListarItens(SQLiteConnection con, int ordemServicoId)
        {
            List<ItemOS> itens = new List<ItemOS>();
            const string sqlItens = @"SELECT I.Id, I.ServicoId, S.Descricao AS ServicoDescricao, I.Valor
                                      FROM ItensOS I
                                      INNER JOIN Servicos S ON S.Id = I.ServicoId
                                      WHERE I.OrdemServicoId = @OrdemServicoId";

            try
            {
                using (SQLiteCommand cmd = new SQLiteCommand(sqlItens, con))
                {
                    cmd.Parameters.Add("@OrdemServicoId", DbType.Int32).Value = ordemServicoId;

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            itens.Add(new ItemOS
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                OrdemServicoId = ordemServicoId,
                                ServicoId = Convert.ToInt32(reader["ServicoId"]),
                                ServicoDescricao = reader["ServicoDescricao"].ToString(),
                                Valor = Convert.ToDecimal(reader["Valor"])
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao carregar os serviços da OS: " + ex.Message, ex);
            }

            return itens;
        }

        public decimal SomarFaturamentoMesAtual()
        {
            const string sql = @"SELECT COALESCE(SUM(ValorTotal), 0)
                                 FROM OrdensServico
                                 WHERE Status IN ('Concluída', 'Entregue')
                                   AND DataConclusao >= date('now', 'start of month')
                                   AND DataConclusao < date('now', 'start of month', '+1 month')";

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
                throw new Exception("Erro ao calcular faturamento do mês: " + ex.Message, ex);
            }
        }

        public int ContarAbertas()
        {
            const string sql = @"SELECT COUNT(*) FROM OrdensServico
                                 WHERE Status IN ('Aberta', 'Em andamento')";

            try
            {
                using (SQLiteConnection con = ConexaoBD.ObterConexao())
                using (SQLiteCommand cmd = new SQLiteCommand(sql, con))
                {
                    con.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao contar OS abertas: " + ex.Message, ex);
            }
        }

        public int ContarConcluidasMesAtual()
        {
            const string sql = @"SELECT COUNT(*) FROM OrdensServico
                                 WHERE Status IN ('Concluída', 'Entregue')
                                   AND DataConclusao >= date('now', 'start of month')
                                   AND DataConclusao < date('now', 'start of month', '+1 month')";

            try
            {
                using (SQLiteConnection con = ConexaoBD.ObterConexao())
                using (SQLiteCommand cmd = new SQLiteCommand(sql, con))
                {
                    con.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao contar OS concluídas do mês: " + ex.Message, ex);
            }
        }
    }
}
