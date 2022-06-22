CREATE TABLE [dbo].[TBTaxa] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [Descricao] VARCHAR (300) NOT NULL,
    [Valor]     DECIMAL (18)  NOT NULL,
    CONSTRAINT [PK_TBTaxa] PRIMARY KEY CLUSTERED ([Id] ASC)
);

