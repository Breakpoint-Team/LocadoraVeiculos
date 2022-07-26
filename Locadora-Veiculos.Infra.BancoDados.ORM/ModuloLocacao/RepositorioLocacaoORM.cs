using Locadora_Veiculos.Dominio.ModuloLocacao;
using Locadora_Veiculos.Infra.BancoDados.ORM.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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
            throw new NotImplementedException();
        }
        
        public void Editar(Locacao registro)
        {
            throw new NotImplementedException();
        }

        public void Excluir(Locacao registro)
        {
            throw new NotImplementedException();
        }
        
        public Locacao SelecionarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Locacao> SelecionarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
