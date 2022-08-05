using System;

namespace Locadora_Veiculos.Dominio.ModuloConfiguracao
{
    public class PrecoCombustivel
    {
        public decimal PrecoGasolina { get; set; }
        public decimal PrecoDiesel { get; set; }
        public decimal PrecoAlcool { get; set; }
        public decimal PrecoGNV { get; set; }

        public DateTime DataAtualizacao { get; set; }

        public PrecoCombustivel()
        {

        }

    }
}
