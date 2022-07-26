using Locadora_Veiculos.Dominio.ModuloVeiculo;
using Locadora_Veiculos.Infra.BancoDados.ORM.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Locadora_Veiculos.Infra.BancoDados.ORM.ModuloVeiculo
{
    public class RepositorioVeiculoORM : IRepositorioVeiculo
    {
        private DbSet<Veiculo> veiculos;
        private readonly LocadoraVeiculosDbContext dbContext;

        public RepositorioVeiculoORM(LocadoraVeiculosDbContext dbContext)
        {
            veiculos = dbContext.Set<Veiculo>();
            this.dbContext = dbContext;
        }

        public void Inserir(Veiculo novoRegistro)
        {
            throw new NotImplementedException();
        }

        public void Editar(Veiculo registro)
        {
            throw new NotImplementedException();
        }

        public void Excluir(Veiculo registro)
        {
            throw new NotImplementedException();
        }

        public Veiculo SelecionarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Veiculo> SelecionarTodos()
        {
            throw new NotImplementedException();
        }

        public Veiculo SelecionarVeiculoPorPlaca(string placa)
        {
            throw new NotImplementedException();
        }
    }
}
