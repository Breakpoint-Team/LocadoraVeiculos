using Locadora_Veiculos.Dominio.Compartilhado;
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

        public RepositorioLocacaoORM(IContextoPersistencia contextoPersitencia)
        {
            this.dbContext = (LocadoraVeiculosDbContext)contextoPersitencia;
            locacoes = dbContext.Set<Locacao>();
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
            var locacao = locacoes.Include(x => x.Veiculo)
                .Include(x => x.Veiculo.GrupoVeiculos)
                .Include(x => x.PlanoCobranca)
                .Include(x => x.TaxasSelecionadas)
                .SingleOrDefault(x => x.Id == id);

            return locacao;
        }

        public List<Locacao> SelecionarTodos()
        {
            var retorno = locacoes
                .Include(x => x.Condutor)
                .Include(x => x.Condutor.Cliente)
                .Include(x => x.PlanoCobranca)
                .Include(x => x.TaxasSelecionadas)
                .Include(x => x.Veiculo)
                .Include(x => x.Veiculo.GrupoVeiculos)
                .ToList();

            return retorno;
        }
    }
}
