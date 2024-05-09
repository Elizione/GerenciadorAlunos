Olá!

Caso não tenhas dados para as tabelas irei disponibilizar aqui.
Uma lista de estados com suas respectivas cidades, além de uma lista de instituições de ensino.

A base de dados é feita via entity framework, então será necessário rodar o Update-database 
para que seja criada o banco juntamente com as tabelas e relacionamentos.



SQL
use GerenciaAlunoDB

INSERT INTO Estados (UF, Nome) VALUES ('BA', 'Bahia');
INSERT INTO Estados (UF, Nome) VALUES ('RJ', 'Rio de Janeiro');
INSERT INTO Estados (UF, Nome) VALUES ('SP', 'São Paulo');


-- Cidades da Bahia
INSERT INTO Cidades (Nome, EstadoId) VALUES ('Salvador', 1); -- 1 é o ID do estado da Bahia
INSERT INTO Cidades (Nome, EstadoId) VALUES ('Feira de Santana', 1);
INSERT INTO Cidades (Nome, EstadoId) VALUES ('Vitória da Conquista', 1);


-- Cidades do Rio de Janeiro
INSERT INTO Cidades (Nome, EstadoId) VALUES ('Rio de Janeiro', 2); -- 2 é o ID do estado do Rio de Janeiro
INSERT INTO Cidades (Nome, EstadoId) VALUES ('Niterói', 2);
INSERT INTO Cidades (Nome, EstadoId) VALUES ('Campos dos Goytacazes', 2);


-- Cidades de São Paulo
INSERT INTO Cidades (Nome, EstadoId) VALUES ('São Paulo', 3); -- 3 é o ID do estado de São Paulo
INSERT INTO Cidades (Nome, EstadoId) VALUES ('Campinas', 3);
INSERT INTO Cidades (Nome, EstadoId) VALUES ('Santos', 3);

--Instituições
INSERT INTO InstituicoesEnsino(Nome) VALUES ('Unijorge');
INSERT INTO InstituicoesEnsino(Nome) VALUES ('UFBA');
INSERT INTO InstituicoesEnsino(Nome) VALUES ('Unifacs');

