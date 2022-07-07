using Locadora_Veiculos.Dominio.Compartilhado;

namespace Locadora_Veiculos.Dominio.ModuloPlanoCobranca
{
    public interface IRepositorioPlanoCobranca : IRepositorio<PlanoCobranca>
    {
        PlanoCobranca SelecionarPlanoPorIdDoGrupoVeiculos(int idGrupoVeiculo);
    }
}