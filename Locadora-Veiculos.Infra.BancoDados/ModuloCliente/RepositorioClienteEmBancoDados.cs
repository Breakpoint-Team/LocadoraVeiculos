using FluentValidation.Results;
using Locadora_Veiculos.Dominio.Compartilhado;
using Locadora_Veiculos.Dominio.ModuloCliente;
using System;
using System.Collections.Generic;

namespace Locadora_Veiculos.Infra.BancoDados.ModuloCliente
{
    public class RepositorioClienteEmBancoDados : IRepositioCliente
    {
        public ValidationResult Editar(Cliente registro)
        {
            throw new NotImplementedException();
        }

        public ValidationResult Excluir(Cliente registro)
        {
            throw new NotImplementedException();
        }

        public ValidationResult Inserir(Cliente novoRegistro)
        {
            throw new NotImplementedException();
        }

        public Cliente SelecionarPorId(int id)
        {
            throw new NotImplementedException();
        }

    }
}
