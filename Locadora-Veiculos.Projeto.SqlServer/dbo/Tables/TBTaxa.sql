CREATE TABLE [dbo].[TBTaxa] (
    [Id]          UNIQUEIDENTIFIER NOT NULL,
    [Descricao]   VARCHAR (300)    NOT NULL,
    [Valor]       DECIMAL (18, 2)  NOT NULL,
    [TipoCalculo] INT              NOT NULL,
    CONSTRAINT [PK_TBTaxa_1] PRIMARY KEY CLUSTERED ([Id] ASC)
);

