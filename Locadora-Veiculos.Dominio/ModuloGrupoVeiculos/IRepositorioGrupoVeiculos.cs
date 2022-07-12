using Locadora_Veiculos.Dominio.Compartilhado;
using System;

namespace Locadora_Veiculos.Dominio.ModuloGrupoVeiculos
{
    public interface IRepositorioGrupoVeiculos : IRepositorio<GrupoVeiculos>
    {
        GrupoVeiculos SelecionarGrupoVeiculosPorNome(string nome);

        int QuantidadeGrupoVeiculosCadastrados();

        int QuantidadeVeiculosRelacionadosAoGrupo(Guid id);

        int QuantidadePlanosDeCobrancaRelacionadosAoGrupo(Guid id);
    }
}