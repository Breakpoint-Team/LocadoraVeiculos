using Locadora_Veiculos.Dominio.Compartilhado;

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

        public string Nome {get; set;}

        #endregion

        public override string ToString()
        {
            return Nome;
        }

        public override bool Equals(object obj)
        {
            GrupoVeiculos g = obj as GrupoVeiculos;

            if (g == null)
                return false;

            return
                g.Id.Equals(Id) &&
                g.Nome.Equals(Nome);
        }
    }
}