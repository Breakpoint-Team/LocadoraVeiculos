
using Locadora_Veiculos.Dominio.ModuloPlanoCobranca;
using Locadora_Veiculos.Infra.BancoDados.ORM.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

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
            planos.Add(novoRegistro);
        }

        public void Editar(PlanoCobranca registro)
        {
            planos.Update(registro);
        }

        public void Excluir(PlanoCobranca registro)
        {
            planos.Remove(registro);
        }

        public PlanoCobranca SelecionarPlanoPorIdDoGrupoVeiculos(Guid idGrupoVeiculo)
        {
            return planos.FirstOrDefault(x => x.GrupoVeiculosId == idGrupoVeiculo);
        }

        public PlanoCobranca SelecionarPorId(Guid id)
        {
            return planos.FirstOrDefault(x => x.Id == id);
        }

        public List<PlanoCobranca> SelecionarTodos()
        {
            return planos.Include(x => x.GrupoVeiculos).ToList();
        }

        public int QuantidadePlanosCadastrados()
        {
            return planos.ToList().Count;
        }
    }
}
