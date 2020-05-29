
CREATE DATABASE ControleAtuali
USE ControleAtuali
drop database ControleAtuali

-- CRIA TABELA TURMA
CREATE TABLE Turma(
   idTURMA INT NOT NULL IDENTITY(1,1),
   SÉRIE   varchar(5)
)
--drop table Turma

--CRIA CHAVE PRIMARIA IDTURMA
ALTER TABLE TURMA ADD CONSTRAINT PK_TURMA
 			PRIMARY KEY (idTurma) 

SELECT * FROM TURMA 

--CRIA TABELA ALUNO 
CREATE TABLE Aluno(
  idAluno INT NOT NULL IDENTITY(1,1),
  Nome   VARCHAR(255),
  --Endereco VARCHAR(255),
  --Cep VARCHAR(17),
  Telefone VARCHAR(17),
  --Celular VARCHAR(17),
  dataNascimento DATE,
  dataCadastro DATE DEFAULT GETDATE(),
  dataUltAtualizacao DATE DEFAULT GETDATE()
 )
--drop table aluno

--CRIA CHAVE PRIMARIA IDALUNO 
 ALTER TABLE Aluno ADD CONSTRAINT PK_ALUNO
 			 PRIMARY KEY (idAluno)  

  select * from aluno

--CRIA TABELA PROFESSOR
CREATE TABLE PROFESSOR(
  idProfessor INT NOT NULL IDENTITY(1,1),
  Nome   VARCHAR(255),
  Endereco VARCHAR(255),
  Cep VARCHAR(17),
  Telefone VARCHAR(17),
  Celular VARCHAR(17),
  dataNascimento DATE,
  dataCadastro DATE DEFAULT GETDATE(),
  dataUltAtualizacao DATE DEFAULT GETDATE(),
  IdTurma INT,
  IdAluno INT
 )

 drop table professor

--CRIA CHAVE PRIMARIA IDPROFESSOR
ALTER TABLE PROFESSOR ADD CONSTRAINT PK_PROFESSOR
			PRIMARY KEY (idPROFESSOR)

--CRIA CHAVE ESTRANGEIRA IDTURMA
ALTER TABLE PROFESSOR ADD CONSTRAINT FK_TURMA
			FOREIGN KEY (idTURMA) REFERENCES TURMA (idTURMA)

--CRIA CHAVE ESTRANGEIRA IDALUNO
ALTER TABLE PROFESSOR ADD CONSTRAINT FK_ALUNO
		    FOREIGN KEY (idALUNO) REFERENCES ALUNO (idALUNO)

select * from PROFESSOR


CREATE TABLE MATERIA(
IdMateria INT NOT NULL IDENTITY(1,1),
Nome_Materia varchar(50),
IdProfessor int,
)

drop table materia

--CRIA CHAVE PRIMARIA ID MATERIA
ALTER TABLE MATERIA ADD CONSTRAINT PK_Materia 
			PRIMARY KEY (IdMateria)

--cria chave estrangeira professor
ALTER TABLE MATERIA ADD CONSTRAINT FKKK_Professor
			FOREIGN KEY (IdProfessor) REFERENCES PROFESSOR (IdProfessor)

select * from MATERIA


Create table Administrador(
Cod_Administrador int identity (1,1),
Nome_Administrador varchar(50),
Email varchar(50),
Senha varchar(50),
)

--drop table administrador

ALTER TABLE ADMINISTRADOR ADD CONSTRAINT PK_ADM
			PRIMARY KEY (Cod_Administrador)

select * From Administrador


--INSERT ADM
insert into Administrador (Nome_Administrador,Email,Senha) values('Gabriel','gabriel21saltareli2002@gmail.com','administrador77242')


--INSERT ALUNO
insert into Aluno  (Nome,Telefone,dataNascimento,dataCadastro,dataUltAtualizacao) values ('Gabriel','11975155199','21/08/2002','21/05/2020','23/05/2020')
insert into  Aluno (Nome,Telefone,dataNascimento,dataCadastro,dataUltAtualizacao) values('JOAO','11975155199','21/08/2002','21/05/2020','22/05/2020')