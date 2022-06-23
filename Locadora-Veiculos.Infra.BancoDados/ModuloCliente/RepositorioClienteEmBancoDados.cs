using FluentValidation.Results;
using Locadora_Veiculos.Dominio.ModuloCliente;
using Locadora_Veiculos.Infra.BancoDados.Compartilhado;
using System;
using System.Collections.Generic;

namespace Locadora_Veiculos.Infra.BancoDados.ModuloCliente
{
    public class RepositorioClienteEmBancoDados : RepositorioBase<Cliente, ValidadorCliente, MapeadorCliente>, IRepositorioCliente
    {
        protected override string sqlInserir => throw new NotImplementedException();

        protected override string sqlEditar => throw new NotImplementedException();

        protected override string sqlExcluir => throw new NotImplementedException();

        protected override string sqlSelecionarPorId => throw new NotImplementedException();

        protected override string sqlSelecionarTodos => throw new NotImplementedException();


    }
}
