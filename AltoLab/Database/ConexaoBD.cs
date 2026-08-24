using System;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace AltoLab.Database
{
    public static class ConexaoBD
    {
        private const string NomeConexao = "AltoLabConnection";
        public const string NomeArquivoBanco = "AltoLabDB.db";

        private static bool _bancoVerificado;

        // Caminho completo do arquivo de banco, sempre na pasta do executavel
        public static string CaminhoBanco
        {
            get { return Path.Combine(Application.StartupPath, NomeArquivoBanco); }
        }

        public static string StringConexao
        {
            get
            {
                try
                {
                    ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[NomeConexao];
                    if (settings != null && !string.IsNullOrWhiteSpace(settings.ConnectionString))
                    {
                        SQLiteConnectionStringBuilder builder = new SQLiteConnectionStringBuilder(settings.ConnectionString);

                        // Resolve caminho relativo em relacao a pasta do executavel
                        if (!Path.IsPathRooted(builder.DataSource))
                        {
                            builder.DataSource = Path.Combine(Application.StartupPath, builder.DataSource);
                        }

                        // Equivalente a executar "PRAGMA foreign_keys = ON" em toda conexao
                        builder.ForeignKeys = true;

                        return builder.ConnectionString;
                    }
                }
                catch
                {
                    // Configuracao invalida no App.config: cai no padrao abaixo
                }

                SQLiteConnectionStringBuilder padrao = new SQLiteConnectionStringBuilder();
                padrao.DataSource = CaminhoBanco;
                padrao.Version = 3;
                padrao.ForeignKeys = true;
                return padrao.ConnectionString;
            }
        }

        // Cria o arquivo AltoLabDB.db com estrutura e dados iniciais caso nao exista.
        // Executado automaticamente na primeira operacao de banco da aplicacao.
        public static void GarantirBancoCriado()
        {
            if (_bancoVerificado && File.Exists(CaminhoBanco))
            {
                return;
            }

            try
            {
                bool precisaCriar = !File.Exists(CaminhoBanco);

                using (SQLiteConnection con = new SQLiteConnection(StringConexao))
                {
                    con.Open();

                    if (!precisaCriar)
                    {
                        // Arquivo existe: confere se as tabelas essenciais estao presentes
                        using (SQLiteCommand cmd = new SQLiteCommand(
                            "SELECT COUNT(*) FROM sqlite_master WHERE type = 'table' AND name = 'Usuarios'", con))
                        {
                            long totalTabelas = Convert.ToInt64(cmd.ExecuteScalar());
                            precisaCriar = totalTabelas == 0;
                        }
                    }

                    if (precisaCriar)
                    {
                        ExecutarScriptCriacao(con);
                    }
                }

                _bancoVerificado = true;
            }
            catch (Exception ex)
            {
                throw new Exception(
                    "N\u00e3o foi poss\u00edvel conectar ao banco de dados.\n" +
                    "Verifique se h\u00e1 permiss\u00e3o de escrita na pasta do sistema e se nenhum antiv\u00edrus est\u00e1 bloqueando o arquivo \"" +
                    NomeArquivoBanco + "\".\n\nDetalhe t\u00e9cnico: " + ex.Message, ex);
            }
        }

        private static void ExecutarScriptCriacao(SQLiteConnection con)
        {
            try
            {
                using (SQLiteTransaction trans = con.BeginTransaction())
                {
                    try
                    {
                        foreach (string blocoSql in ScriptCriacaoBanco())
                        {
                            using (SQLiteCommand cmd = new SQLiteCommand(blocoSql, con, trans))
                            {
                                cmd.ExecuteNonQuery();
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
                            throw new Exception("Erro ao reverter a cria\u00e7\u00e3o do banco de dados: " + exRollback.Message);
                        }
                        throw; // Repassa a excecao original
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao criar a estrutura do banco de dados: " + ex.Message, ex);
            }
        }

        // Retorna conexao ABERTA nao — apenas o objeto; quem chama deve abrir.
        public static SQLiteConnection ObterConexao()
        {
            GarantirBancoCriado();
            return new SQLiteConnection(StringConexao);
        }

        // Script de criacao das tabelas + carga inicial (mesmo conteudo de Database/DatabaseSetup.sql)
        private static string[] ScriptCriacaoBanco()
        {
            return new string[]
            {
                @"CREATE TABLE IF NOT EXISTS Clientes (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Nome TEXT NOT NULL,
                    Telefone TEXT,
                    Email TEXT,
                    Endereco TEXT,
                    DataCadastro DATETIME DEFAULT (datetime('now','localtime'))
                );",
                @"CREATE TABLE IF NOT EXISTS Servicos (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Descricao TEXT NOT NULL,
                    ValorPadrao NUMERIC(10,2) NOT NULL DEFAULT 0
                );",
                @"CREATE TABLE IF NOT EXISTS Usuarios (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Login TEXT NOT NULL UNIQUE,
                    Senha TEXT NOT NULL,
                    NomeCompleto TEXT
                );",
                @"CREATE TABLE IF NOT EXISTS OrdensServico (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    ClienteId INTEGER NOT NULL REFERENCES Clientes(Id),
                    Equipamento TEXT,
                    ProblemaRelatado TEXT,
                    Status TEXT DEFAULT 'Aberta',
                    DataAbertura DATETIME DEFAULT (datetime('now','localtime')),
                    DataConclusao DATETIME NULL,
                    ValorTotal NUMERIC(10,2) DEFAULT 0
                );",
                @"CREATE TABLE IF NOT EXISTS ItensOS (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    OrdemServicoId INTEGER NOT NULL REFERENCES OrdensServico(Id) ON DELETE CASCADE,
                    ServicoId INTEGER NOT NULL REFERENCES Servicos(Id),
                    Valor NUMERIC(10,2) NOT NULL DEFAULT 0
                );",
                @"INSERT INTO Usuarios (Login, Senha, NomeCompleto)
                  VALUES ('admin', '240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a9', 'Administrador AltoLab');",
                @"INSERT INTO Servicos (Descricao, ValorPadrao) VALUES
                  ('Formatação e Instalação de S.O.', 150.00),
                  ('Limpeza Interna e Troca de Pasta Térmica', 120.00),
                  ('Troca de Tela / Display', 350.00),
                  ('Diagnóstico / Avaliação Técnica', 80.00);",
                @"INSERT INTO Clientes (Nome, Telefone, Email, Endereco) VALUES
                  ('João Silva', '(11) 98888-7777', 'joao@email.com', 'Rua das Flores, 123'),
                  ('Maria Oliveira', '(11) 97777-6666', 'maria@email.com', 'Av. Paulista, 1000');"
            };
        }
    }
}
