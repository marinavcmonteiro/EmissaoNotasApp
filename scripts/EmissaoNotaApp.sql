create database EmissaoNotaApp;

use EmissaoNotaApp;

CREATE TABLE Produto (
Id bigint NOT NULL AUTO_INCREMENT,
Codigo varchar(10),
Descricao varchar(200),
PRIMARY KEY (Id)
);
