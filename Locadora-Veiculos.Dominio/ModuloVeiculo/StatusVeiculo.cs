using System.ComponentModel;

namespace Locadora_Veiculos.Dominio.ModuloVeiculo
{
    public enum StatusVeiculo
    {
        [Description("Locado")]
        Locado,

        [Description("Disponível")]
        Disponivel
    }
}