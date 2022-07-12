CREATE TABLE [dbo].[TBCondutor] (
    [Id]                UNIQUEIDENTIFIER NOT NULL,
    [Nome]              VARCHAR (300)    NOT NULL,
    [Telefone]          VARCHAR (30)     NOT NULL,
    [Email]             VARCHAR (300)    NOT NULL,
    [Numero]            INT              NOT NULL,
    [Rua]               VARCHAR (300)    NOT NULL,
    [Bairro]            VARCHAR (300)    NOT NULL,
    [Cidade]            VARCHAR (300)    NOT NULL,
    [Estado]            VARCHAR (300)    NOT NULL,
    [Cpf]               VARCHAR (30)     NOT NULL,
    [Cnh]               VARCHAR (30)     NOT NULL,
    [Data_validade_cnh] DATE             NOT NULL,
    [Id_Cliente]        UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_TBCondutor_1] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TBCondutor_TBCliente] FOREIGN KEY ([Id_Cliente]) REFERENCES [dbo].[TBCliente] ([Id])
);

