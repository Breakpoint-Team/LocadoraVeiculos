using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora_Veiculos.Dominio.Compartilhado
{
    public abstract class EntidadeBase<T>
    {
        public int Id { get; set; }
    }
}
