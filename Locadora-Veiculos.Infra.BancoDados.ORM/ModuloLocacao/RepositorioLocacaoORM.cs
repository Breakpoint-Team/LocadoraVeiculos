using Locadora_Veiculos.Dominio.ModuloLocacao;
using Locadora_Veiculos.Infra.BancoDados.ORM.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Locadora_Veiculos.Infra.BancoDados.ORM.ModuloLocacao
{
    public class RepositorioLocacaoORM : IRepositorioLocacao
    {
        private DbSet<Locacao> locacoes;
        private readonly LocadoraVeiculosDbContext dbContext;

        public RepositorioLocacaoORM(LocadoraVeiculosDbContext dbContext)
        {
            locacoes = dbContext.Set<Locacao>();
            this.dbContext = dbContext;
        }

        public void Inserir(Locacao novoRegistro)
        {
            locacoes.Add(novoRegistro);
        }

        public void Editar(Locacao registro)
        {
            locacoes.Update(registro);
        }

        public void Excluir(Locacao registro)
        {
            locacoes.Remove(registro);
        }

        public Locacao SelecionarPorId(Guid id)
        {
            var locacao = locacoes.Include(x => x.GrupoVeiculos)
                .Include(x => x.PlanoCobranca)
                .Include(x => x.TaxasSelecionadas)
                .SingleOrDefault(x => x.Id == id);

            return locacao;
        }

        public List<Locacao> SelecionarTodos()
        {
            var retorno = locacoes.Include(x => x.GrupoVeiculos)
                .Include(x => x.PlanoCobranca)
                .Include(x => x.TaxasSelecionadas)
                .ToList();

            return retorno;
        }
    }
}
