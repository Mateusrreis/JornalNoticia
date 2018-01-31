

CREATE TABLE Revisores_Adm (
usuarioRev VARCHAR(90) not null unique,
senha VARCHAR(90) not null unique,
idRevisores int PRIMARY KEY Identity (1,1),
Situacao VARCHAR(60),
idArea int
)

CREATE TABLE Area (
NomeArea VARCHAR(60) not null unique,
idArea int PRIMARY KEY Identity (1,1),
Situacao VARCHAR(60)
)

CREATE TABLE imagens (
tipoimg VARCHAR(60),
idImagem int PRIMARY KEY Identity (1,1),
caminhoimg VARCHAR(60),
Situacao VARCHAR(60),
idPublicacao INT
)

CREATE TABLE Publicação (
Titulo VARCHAR(90) not null,
CorpoNoticia varchar(MAX) not null,--Texto grande 
idPublicacao int PRIMARY KEY Identity (1,1),
revisado varchar(60),
Situacao VARCHAR(60),
DtaPublicacao DateTime,
idCategoria int not null,
idArea int not null,
FOREIGN KEY(idArea) REFERENCES Area (idArea)
)

CREATE TABLE Categoria (
idCategoria int PRIMARY KEY Identity (1,1),
tipCategoria VARCHAR(60) unique not null,
Situacao VARCHAR(60)
)

ALTER TABLE Revisores_Adm ADD FOREIGN KEY(idArea) REFERENCES Area (idArea)
ALTER TABLE imagens ADD FOREIGN KEY(idPublicacao) REFERENCES Publicação (idPublicacao)
ALTER TABLE Publicação ADD FOREIGN KEY(idCategoria) REFERENCES Categoria (idCategoria)

select * from Publicação
SELECT DATE_FORMAT(Now(),' %d %M %Y %H:%i')
select GETDATE ()
SELECT SYSDATETIME()
Select DAY(GETDATE()), MONTH(GETDATE()), YEAR(GETDATE()),CONVERT (time, SYSDATETIME())

select * from Publicação

insert into Categoria(tipCategoria) values('Empresarial')
insert into Categoria(tipCategoria) values('Negócios')

Select * from Categoria 