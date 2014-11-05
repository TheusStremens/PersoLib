CREATE TABLE USR_Usuario (
USR_id_usuario INTEGER PRIMARY KEY,
USR_ds_nome VARCHAR(30),
USR_ds_email VARCHAR(20),
USR_pw_senha VARCHAR(20),
USR_ds_telefone VARCHAR(10)
)

CREATE TABLE LVR_Livro (
LVR_id_livro INTEGER PRIMARY KEY,
LVR_ds_nome VARCHAR(30),
LVR_qt_disponivel NUMERIC(10),
LVR_qt_emprestado NUMERIC(10),
LVR_id_usuario INTEGER,
FOREIGN KEY(LVR_id_usuario) REFERENCES USR_Usuario (USR_id_usuario)
)

CREATE TABLE EMP_Emprestimo (
EMP_dt_devolucao DATETIME,
EMP_id_emprestimo INTEGER PRIMARY KEY,
EMP_ds_email_emprestante VARCHAR(20),
EMP_ds_emprestante VARCHAR(30),
EMP_id_livro INTEGER,
EMP_id_usuario INTEGER,
FOREIGN KEY(EMP_id_livro) REFERENCES LVR_Livro (LVR_id_livro),
FOREIGN KEY(EMP_id_usuario) REFERENCES USR_Usuario (USR_id_usuario)
)

