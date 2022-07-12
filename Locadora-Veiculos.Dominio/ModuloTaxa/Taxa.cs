using Locadora_Veiculos.Dominio.Compartilhado;
using System;

namespace Locadora_Veiculos.Dominio.ModuloTaxa
{
    public class Taxa : EntidadeBase<Taxa>
    {
        #region PROPS

        public string Descricao { get; set; }
        public Decimal Valor { get; set; }
        public TipoCalculo TipoCalculo { get; set; }
        
        #endregion

        #region CONSTRUTORES

        public Taxa()
        {

        }

        public Taxa(string descricao, decimal valor, TipoCalculo tipoCalculo)
        {
            Descricao = descricao;
            Valor = valor;
            TipoCalculo = tipoCalculo;
        }

        #endregion

        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}", Descricao, Valor, TipoCalculo.GetDescription());
        }

        public override bool Equals(object obj)
        {
            return obj is Taxa taxa &&
                   Id.Equals(taxa.Id) &&
                   Descricao == taxa.Descricao &&
                   Valor == taxa.Valor &&
                   TipoCalculo == taxa.TipoCalculo;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Descricao, Valor, TipoCalculo);
        }
    }
}