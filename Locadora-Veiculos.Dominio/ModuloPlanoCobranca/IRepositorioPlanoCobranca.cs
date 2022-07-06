using Locadora_Veiculos.Dominio.Compartilhado;

namespace Locadora_Veiculos.Dominio.ModuloPlanoCobranca
{
    public interface IRepositorioPlanoCobranca : IRepositorio<PlanoCobranca>
    {
        PlanoCobranca SelecionarGrupoVeiculosPorNome(string nome);
        int QuantidadeGrupoVeiculosCadastrados();

        int QuantidadeVeiculosRelacionadosAoGrupo(int id);
    }
}
