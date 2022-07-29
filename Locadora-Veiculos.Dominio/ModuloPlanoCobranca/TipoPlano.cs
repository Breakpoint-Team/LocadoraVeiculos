
using System.ComponentModel;

namespace Locadora_Veiculos.Dominio.ModuloPlanoCobranca
{
    public enum TipoPlano
    {
        [Description("Plano diário")]
        Diario,
        
        [Description("Km controlado")]
        Controlado,
 
        [Description("Km livre")]
        Livre
    }
}