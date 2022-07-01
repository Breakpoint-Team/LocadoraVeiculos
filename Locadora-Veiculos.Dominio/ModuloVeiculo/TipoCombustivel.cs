using System.ComponentModel;

namespace Locadora_Veiculos.Dominio.ModuloVeiculo
{
    public enum TipoCombustivel
    {
        [Description("Gasolina")]
        Gasolina,

        [Description("Diesel")]
        Diesel,

        [Description("GNV")]
        GNV,

        [Description("Álcool")]
        Alcool,

        [Description("Flex")]
        Flex


    }
}
