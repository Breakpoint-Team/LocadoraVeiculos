using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora_Veiculos.Dominio.Compartilhado
{
    public class PrecoCombustivel
    {
        public int Id { get; set; }
        public decimal PrecoGasolina { get; set; }
        public decimal PrecoDiesel { get; set; }
        public decimal PrecoAlcool { get; set; }
        public decimal PrecoGNV { get; set; }

        public PrecoCombustivel()
        {

        }

    }
}
