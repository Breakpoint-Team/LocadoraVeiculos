CREATE TABLE [dbo].[TBGrupoVeiculos] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Nome] VARCHAR (300) NOT NULL,
    CONSTRAINT [PK_TBGrupoVeiculos] PRIMARY KEY CLUSTERED ([Id] ASC)
);

