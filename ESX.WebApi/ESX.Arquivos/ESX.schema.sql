CREATE DATABASE ESXWebApi
GO
USE ESXWebApi
GO

if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKCEEC56F637BF129D]') and parent_object_id = OBJECT_ID(N'Patrimonio')) alter table Patrimonio  drop constraint FKCEEC56F637BF129D

if exists (select * from dbo.sysobjects where id = object_id(N'Marca') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Marca

if exists (select * from dbo.sysobjects where id = object_id(N'Patrimonio') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Patrimonio

create table Marca (
    Id INT IDENTITY NOT NULL,
    Nome VARCHAR(255) not null,
    primary key (Id)
)

create table Patrimonio (
    Id INT IDENTITY NOT NULL,
    Nome VARCHAR(255) not null,
    Descricao VARCHAR(255) null,
    NumeroTombo INT null,
    IdMarca INT not null,
    primary key (Id)
)

alter table Patrimonio 
    add constraint FKCEEC56F637BF129D 
    foreign key (IdMarca) 
    references Marca
