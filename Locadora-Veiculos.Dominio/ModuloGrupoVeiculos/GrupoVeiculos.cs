using Locadora_Veiculos.Dominio.Compartilhado;
using System;

namespace Locadora_Veiculos.Dominio.ModuloGrupoVeiculos
{
    public class GrupoVeiculos : EntidadeBase<GrupoVeiculos>
    {
        #region CONSTRUTORES

        public GrupoVeiculos()
        {

        }

        public GrupoVeiculos(string nome)
        {
            Nome = nome;
        }

        #endregion

        #region PROPS

        public string Nome { get; set; }

        public override bool DadosPopulados
        {
            get
            {
                if (string.IsNullOrEmpty(Nome))
                    return false;
                return true;
            }
        }

        #endregion

        public override bool Equals(object obj)
        {
            return obj is GrupoVeiculos veiculos &&
                   Id.Equals(veiculos.Id) &&
                   Nome == veiculos.Nome;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Nome);
        }

        public override string ToString()
        {
            return Nome;
        }
    }
}