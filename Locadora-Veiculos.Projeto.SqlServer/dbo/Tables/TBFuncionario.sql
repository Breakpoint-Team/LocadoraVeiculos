CREATE TABLE [dbo].[TBFuncionario] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [Nome]         VARCHAR (300) NOT NULL,
    [Usuario]      VARCHAR (300) NOT NULL,
    [Senha]        VARCHAR (300) NOT NULL,
    [Data_entrada] DATE          NOT NULL,
    [Salario]      DECIMAL (18)  NOT NULL,
    [Is_Admin]     BIT           NOT NULL,
    [Esta_Ativo] BIT NOT NULL, 
    CONSTRAINT [PK_TBFuncionario] PRIMARY KEY CLUSTERED ([Id] ASC)
);

