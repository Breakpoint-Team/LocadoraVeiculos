using System;

namespace Locadora_Veiculos.Dominio.Compartilhado
{
    public abstract class EntidadeBase<T>
    {
        public Guid Id { get; set; }

        public abstract bool DadosPopulados { get; }

        public EntidadeBase()
        {
            Id = Guid.NewGuid();
        }
    }
}