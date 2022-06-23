using FluentValidation.Results;
using Locadora_Veiculos.Dominio.Compartilhado;
using Locadora_Veiculos.Dominio.ModuloGrupoVeiculos;
using Locadora_Veiculos.Infra.BancoDados.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora_Veiculos.Infra.BancoDados.ModuloGrupoVeiculos
{
    public class RepositorioGrupoVeiculosEmBancoDados : RepositorioBase<GrupoVeiculos, ValidadorGrupoVeiculos, MapeadorGrupoVeiculos>
    {
        protected override string sqlInserir => throw new NotImplementedException();

        protected override string sqlEditar => throw new NotImplementedException();

        protected override string sqlExcluir => throw new NotImplementedException();

        protected override string sqlSelecionarPorId => throw new NotImplementedException();

        protected override string sqlSelecionarTodos => throw new NotImplementedException();

    }
}
