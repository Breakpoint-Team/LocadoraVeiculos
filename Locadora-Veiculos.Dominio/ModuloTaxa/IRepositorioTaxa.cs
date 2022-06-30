using Locadora_Veiculos.Dominio.Compartilhado;

namespace Locadora_Veiculos.Dominio.ModuloTaxa
{
    public interface IRepositorioTaxa : IRepositorio<Taxa>
    {
        Taxa SelecionarTaxaPorDescricao(string descricao);
    }
}