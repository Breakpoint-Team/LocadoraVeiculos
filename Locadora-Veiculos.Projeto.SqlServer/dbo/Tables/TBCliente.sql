﻿CREATE TABLE [dbo].[TBCliente] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [Nome]         VARCHAR (300) NOT NULL,
    [Documento]    VARCHAR (300) NOT NULL,
    [Email]        VARCHAR (300) NOT NULL,
    [Telefone]     VARCHAR (300) NOT NULL,
    [Endereco]     VARCHAR (300) NOT NULL,
    [Tipo_cliente] VARCHAR (300) NOT NULL,
    [Cnh]          VARCHAR (300) NOT NULL,
    CONSTRAINT [PK_TBCliente] PRIMARY KEY CLUSTERED ([Id] ASC)
);

