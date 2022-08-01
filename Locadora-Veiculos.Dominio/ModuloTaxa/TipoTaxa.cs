using System.ComponentModel;

namespace Locadora_Veiculos.Dominio.ModuloTaxa
{
    public enum TipoTaxa
    {
        [Description("Taxa de locação")]
        TaxaLocacao,
        [Description("Taxa de devolução")]
        TaxaDevolucao
    }
}