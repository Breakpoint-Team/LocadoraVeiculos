using System.ComponentModel;

namespace Locadora_Veiculos.Dominio.ModuloLocacao
{
    public enum NivelTanque
    {
        [Description("Vazio")]
        Vazio,

        [Description("Um quarto")]
        UmQuarto,

        [Description("Meio")]
        Meio,

        [Description("Três quartos")]
        TresQuartos,

        [Description("Cheio")]
        Cheio
    }
}