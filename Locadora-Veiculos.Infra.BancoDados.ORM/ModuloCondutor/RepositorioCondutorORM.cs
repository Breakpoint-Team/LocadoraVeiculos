using Locadora_Veiculos.Dominio.ModuloCondutor;
using Locadora_Veiculos.Infra.BancoDados.ORM.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Locadora_Veiculos.Infra.BancoDados.ORM.ModuloCondutor
{
    public class RepositorioCondutorORM : IRepositorioCondutor
    {

        private DbSet<Condutor> condutores;
        private readonly LocadoraVeiculosDbContext dbContext;

        public RepositorioCondutorORM(LocadoraVeiculosDbContext dbContext)
        {
            condutores = dbContext.Set<Condutor>();
            this.dbContext = dbContext;
        }

        public void Inserir(Condutor novoRegistro)
        {
            throw new NotImplementedException();
        }
        
        public void Editar(Condutor registro)
        {
            throw new NotImplementedException();
        }

        public void Excluir(Condutor registro)
        {
            throw new NotImplementedException();
        }

        public Condutor SelecionarCondutorPorCNH(string cnh)
        {
            throw new NotImplementedException();
        }

        public Condutor SelecionarCondutorPorCPF(string cpf)
        {
            throw new NotImplementedException();
        }

        public Condutor SelecionarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Condutor> SelecionarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
