-- Geração de Modelo físico
-- Sql ANSI 2003 - brModelo.



CREATE TABLE USR_Usuario (
USR_ds_email VARCHAR(20),
USR_ds_nome VARCHAR(30),
USR_pw_senha VARCHAR(20),
USR_id_usuario INTEGER PRIMARY KEY
)

CREATE TABLE EMP_Emprestimo (
EMP_dt_devolucao DATETIME,
EMP_id_emprestimo INTEGER PRIMARY KEY,
USR_id_usuario INTEGER,
LVR_id_livro INTEGER,
FOREIGN KEY(USR_id_usuario) REFERENCES USR_Usuario (USR_id_usuario)
)

CREATE TABLE LVR_Livro (
LVR_qt_quantidade NUMERIC(10),
LVR_ds_nome VARCHAR(10),
LVR_id_livro INTEGER PRIMARY KEY,
USR_id_usuario INTEGER,
FOREIGN KEY(USR_id_usuario) REFERENCES USR_Usuario (USR_id_usuario)
)

ALTER TABLE EMP_Emprestimo ADD FOREIGN KEY(LVR_id_livro) REFERENCES LVR_Livro (LVR_id_livro)
