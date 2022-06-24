using System.ComponentModel;

namespace Locadora_Veiculos.Dominio.ModuloCliente
{
    public enum TipoCliente
    {
        [Description("Pessoa física")]
        PessoaFisica,
        
        [Description("Pessoa jurídica")]
        PessoaJuridica,
    }
}
