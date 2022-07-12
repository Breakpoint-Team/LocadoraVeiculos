CREATE TABLE [dbo].[TBVeiculo] (
    [Id]                       UNIQUEIDENTIFIER NOT NULL,
    [Modelo]                   VARCHAR (300)    NOT NULL,
    [Marca]                    VARCHAR (300)    NOT NULL,
    [Ano]                      INT              NOT NULL,
    [Cor]                      VARCHAR (300)    NOT NULL,
    [Placa]                    VARCHAR (7)      NOT NULL,
    [Tipo_combustivel]         VARCHAR (300)    NOT NULL,
    [Quilometragem_percorrida] INT              NOT NULL,
    [Capacidade_tanque]        DECIMAL (18, 2)  NOT NULL,
    [Id_Grupo_veiculos]        UNIQUEIDENTIFIER NOT NULL,
    [Imagem]                   VARBINARY (MAX)  NOT NULL,
    CONSTRAINT [PK_TBVeiculo_1] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TBVeiculo_TBGrupoVeiculos] FOREIGN KEY ([Id_Grupo_veiculos]) REFERENCES [dbo].[TBGrupoVeiculos] ([Id])
);

