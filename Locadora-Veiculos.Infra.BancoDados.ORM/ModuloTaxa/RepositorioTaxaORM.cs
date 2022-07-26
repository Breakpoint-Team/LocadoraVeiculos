
using Locadora_Veiculos.Dominio.ModuloTaxa;
using Locadora_Veiculos.Infra.BancoDados.ORM.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Locadora_Veiculos.Infra.BancoDados.ORM.ModuloTaxa
{
    public class RepositorioTaxaORM : IRepositorioTaxa
    {
        private DbSet<Taxa> taxas;
        private readonly LocadoraVeiculosDbContext dbContext;

        public RepositorioTaxaORM(LocadoraVeiculosDbContext dbContext)
        {
            taxas = dbContext.Set<Taxa>();
            this.dbContext = dbContext;
        }

        public void Inserir(Taxa novoRegistro)
        {
            throw new NotImplementedException();
        }

        public void Editar(Taxa registro)
        {
            throw new NotImplementedException();
        }

        public void Excluir(Taxa registro)
        {
            throw new NotImplementedException();
        }

        public Taxa SelecionarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Taxa SelecionarTaxaPorDescricao(string descricao)
        {
            throw new NotImplementedException();
        }

        public List<Taxa> SelecionarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
