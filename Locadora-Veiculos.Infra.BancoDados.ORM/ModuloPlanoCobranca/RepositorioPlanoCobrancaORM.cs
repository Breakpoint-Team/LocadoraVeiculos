
using Locadora_Veiculos.Dominio.ModuloPlanoCobranca;
using Locadora_Veiculos.Infra.BancoDados.ORM.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Locadora_Veiculos.Infra.BancoDados.ORM.ModuloPlanoCobranca
{
    public class RepositorioPlanoCobrancaORM : IRepositorioPlanoCobranca
    {
        private DbSet<PlanoCobranca> planos;
        private readonly LocadoraVeiculosDbContext dbContext;

        public RepositorioPlanoCobrancaORM(LocadoraVeiculosDbContext dbContext)
        {
            planos = dbContext.Set<PlanoCobranca>();
            this.dbContext = dbContext;
        }

        public void Inserir(PlanoCobranca novoRegistro)
        {
            throw new NotImplementedException();
        }

        public void Editar(PlanoCobranca registro)
        {
            throw new NotImplementedException();
        }

        public void Excluir(PlanoCobranca registro)
        {
            throw new NotImplementedException();
        }

        public PlanoCobranca SelecionarPlanoPorIdDoGrupoVeiculos(Guid idGrupoVeiculo)
        {
            throw new NotImplementedException();
        }

        public PlanoCobranca SelecionarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<PlanoCobranca> SelecionarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
