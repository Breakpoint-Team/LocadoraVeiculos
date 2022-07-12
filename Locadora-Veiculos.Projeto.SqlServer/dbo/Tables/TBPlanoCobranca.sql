CREATE TABLE [dbo].[TBPlanoCobranca] (
    [Id]                      UNIQUEIDENTIFIER NOT NULL,
    [Diario_valor_dia]        DECIMAL (18, 2)  NOT NULL,
    [Diario_valor_km]         DECIMAL (18, 2)  NOT NULL,
    [Km_controlado_valor_dia] DECIMAL (18, 2)  NOT NULL,
    [Km_controlado_valor_km]  DECIMAL (18, 2)  NOT NULL,
    [Km_controlado_limite_km] DECIMAL (18, 2)  NOT NULL,
    [Km_livre_valor_dia]      DECIMAL (18, 2)  NOT NULL,
    [Id_grupo_veiculos]       UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_TBPlanoCobranca_1] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TBPlanoCobranca_TBGrupoVeiculos] FOREIGN KEY ([Id_grupo_veiculos]) REFERENCES [dbo].[TBGrupoVeiculos] ([Id])
);

