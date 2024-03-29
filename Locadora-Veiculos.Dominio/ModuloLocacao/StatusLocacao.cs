﻿using System.ComponentModel;

namespace Locadora_Veiculos.Dominio.ModuloLocacao
{
    public enum StatusLocacao
    {
        [Description("Aberta")]
        Aberta,

        [Description("Fechada")]
        Fechada,

        [Description("Em processo de devolução")]
        EmProcessoDeDevolucao,

        [Description("Inativa")]
        Inativa
    }
}