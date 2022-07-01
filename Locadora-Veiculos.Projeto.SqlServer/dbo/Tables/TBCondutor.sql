CREATE TABLE [dbo].[TBCondutor] (
    [Id]                INT           IDENTITY (1, 1) NOT NULL,
    [Nome]              VARCHAR (300) NOT NULL,
    [Telefone]          VARCHAR (30)  NOT NULL,
    [Email]             VARCHAR (300) NOT NULL,
    [Numero]            INT           NOT NULL,
    [Rua]               VARCHAR (300) NOT NULL,
    [Bairro]            VARCHAR (300) NOT NULL,
    [Cidade]            VARCHAR (300) NOT NULL,
    [Estado]            VARCHAR (300) NOT NULL,
    [Cpf]               VARCHAR (30)  NOT NULL,
    [Cnh]               VARCHAR (30)  NOT NULL,
    [Data_validade_cnh] DATE          NOT NULL,
    [Id_cliente]        INT           NOT NULL,
    CONSTRAINT [PK_TBCondutor] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TBCondutor_TBCliente] FOREIGN KEY ([Id_cliente]) REFERENCES [dbo].[TBCliente] ([Id])
);

