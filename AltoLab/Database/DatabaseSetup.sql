-- ============================================================
-- AltoLabDB — Script de criacao (dialeto SQLite)
-- ------------------------------------------------------------
-- ATENCAO: a aplicacao executa este script automaticamente na
-- primeira execucao, criando o arquivo "AltoLabDB.db" na pasta
-- do executavel. Este arquivo existe apenas como referencia
-- para inspecao manual (DB Browser for SQLite, por exemplo).
-- Nao ha dependencia de LocalDB nem caminhos de .mdf.
-- ============================================================

PRAGMA foreign_keys = ON;

CREATE TABLE IF NOT EXISTS Clientes (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Nome TEXT NOT NULL,
    Telefone TEXT,
    Email TEXT,
    Endereco TEXT,
    DataCadastro DATETIME DEFAULT (datetime('now','localtime'))
);

CREATE TABLE IF NOT EXISTS Servicos (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Descricao TEXT NOT NULL,
    ValorPadrao NUMERIC(10,2) NOT NULL DEFAULT 0
);

CREATE TABLE IF NOT EXISTS Usuarios (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Login TEXT NOT NULL UNIQUE,
    Senha TEXT NOT NULL,
    NomeCompleto TEXT
);

CREATE TABLE IF NOT EXISTS OrdensServico (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    ClienteId INTEGER NOT NULL REFERENCES Clientes(Id),
    Equipamento TEXT,
    ProblemaRelatado TEXT,
    Status TEXT DEFAULT 'Aberta',
    DataAbertura DATETIME DEFAULT (datetime('now','localtime')),
    DataConclusao DATETIME NULL,
    ValorTotal NUMERIC(10,2) DEFAULT 0
);

CREATE TABLE IF NOT EXISTS ItensOS (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    OrdemServicoId INTEGER NOT NULL REFERENCES OrdensServico(Id) ON DELETE CASCADE,
    ServicoId INTEGER NOT NULL REFERENCES Servicos(Id),
    Valor NUMERIC(10,2) NOT NULL DEFAULT 0
);

CREATE TABLE IF NOT EXISTS Despesas (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Descricao TEXT NOT NULL,
    Categoria TEXT,
    Valor NUMERIC(10,2) NOT NULL DEFAULT 0,
    DataDespesa DATETIME NOT NULL DEFAULT (datetime('now','localtime'))
);

-- Carga inicial de dados para testes
-- Senha do admin: admin123 (hash SHA256 abaixo)
INSERT INTO Usuarios (Login, Senha, NomeCompleto)
VALUES ('admin', '240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a9', 'Administrador AltoLab');

INSERT INTO Servicos (Descricao, ValorPadrao) VALUES
('Formatação e Instalação de S.O.', 150.00),
('Limpeza Interna e Troca de Pasta Térmica', 120.00),
('Troca de Tela / Display', 350.00),
('Diagnóstico / Avaliação Técnica', 80.00);

INSERT INTO Clientes (Nome, Telefone, Email, Endereco) VALUES
('João Silva', '(11) 98888-7777', 'joao@email.com', 'Rua das Flores, 123'),
('Maria Oliveira', '(11) 97777-6666', 'maria@email.com', 'Av. Paulista, 1000');

INSERT INTO Despesas (Descricao, Categoria, Valor) VALUES
('Aluguel do box', 'Fixa', 1200.00),
('Compra de HD 1TB', 'Compra de peças', 289.90);
