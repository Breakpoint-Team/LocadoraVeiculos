using Locadora_Veiculos.Dominio.Compartilhado;
using System;

namespace Locadora_Veiculos.Dominio.ModuloPlanoCobranca
{
    public interface IRepositorioPlanoCobranca : IRepositorio<PlanoCobranca>
    {
        PlanoCobranca SelecionarPlanoPorIdDoGrupoVeiculos(Guid idGrupoVeiculo);

        int QuantidadePlanosCadastrados();
    }
}