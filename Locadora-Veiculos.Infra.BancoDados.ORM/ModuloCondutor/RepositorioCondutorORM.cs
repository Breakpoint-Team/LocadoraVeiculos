using Locadora_Veiculos.Dominio.ModuloCondutor;
using Locadora_Veiculos.Infra.BancoDados.ORM.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

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
            condutores.Add(novoRegistro);
        }
        
        public void Editar(Condutor registro)
        {
            condutores.Update(registro);
        }

        public void Excluir(Condutor registro)
        {
            condutores.Remove(registro);
        }

        public Condutor SelecionarCondutorPorCNH(string cnh)
        {
            return condutores.SingleOrDefault(x => x.Cnh == cnh);
        }

        public Condutor SelecionarCondutorPorCPF(string cpf)
        {
            return condutores.SingleOrDefault(x => x.Cpf == cpf);
        }

        public Condutor SelecionarPorId(Guid id)
        {
            return condutores.SingleOrDefault(x => x.Id == id);
        }

        public List<Condutor> SelecionarTodos()
        {
            return condutores.Include(x =>x.Cliente).ToList();
        }
    }
}
