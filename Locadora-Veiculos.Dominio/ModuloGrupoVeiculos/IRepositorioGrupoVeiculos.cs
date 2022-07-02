using Locadora_Veiculos.Dominio.Compartilhado;

namespace Locadora_Veiculos.Dominio.ModuloGrupoVeiculos
{
    public interface IRepositorioGrupoVeiculos : IRepositorio<GrupoVeiculos>
    {
        GrupoVeiculos SelecionarGrupoVeiculosPorNome(string nome);
        int QuantidadeGrupoVeiculosCadastrados();

        int QuantidadeVeiculosRelacionadosAoGrupo(int id);
    }
}