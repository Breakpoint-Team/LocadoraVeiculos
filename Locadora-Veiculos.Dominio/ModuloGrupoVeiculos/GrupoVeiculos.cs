using Locadora_Veiculos.Dominio.Compartilhado;


namespace Locadora_Veiculos.Dominio.ModuloGrupoVeiculos
{
    public class GrupoVeiculos : EntidadeBase<GrupoVeiculos>
    {
        public string Nome {get; set;}
        public GrupoVeiculos()
        {

        }

        public override string ToString()
        {
            return Nome;
        }

    }
}
