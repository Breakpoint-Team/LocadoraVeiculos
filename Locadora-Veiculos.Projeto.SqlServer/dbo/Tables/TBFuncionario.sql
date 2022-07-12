CREATE TABLE [dbo].[TBFuncionario] (
    [Id]           UNIQUEIDENTIFIER NOT NULL,
    [Nome]         VARCHAR (300)    NOT NULL,
    [Login]        VARCHAR (300)    NOT NULL,
    [Senha]        VARCHAR (300)    NOT NULL,
    [Data_entrada] DATE             NOT NULL,
    [Salario]      DECIMAL (18, 2)  NOT NULL,
    [Is_Admin]     BIT              NOT NULL,
    [Esta_Ativo]   BIT              NOT NULL,
    CONSTRAINT [PK_TBFuncionario_1] PRIMARY KEY CLUSTERED ([Id] ASC)
);

