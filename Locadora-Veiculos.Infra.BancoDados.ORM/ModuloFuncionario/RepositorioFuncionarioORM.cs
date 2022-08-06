using Locadora_Veiculos.Dominio.Compartilhado;
using Locadora_Veiculos.Dominio.ModuloFuncionario;
using Locadora_Veiculos.Infra.BancoDados.ORM.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Locadora_Veiculos.Infra.BancoDados.ORM.ModuloFuncionario
{
    public class RepositorioFuncionarioORM : IRepositorioFuncionario
    {
        private DbSet<Funcionario> funcionarios;
        private readonly LocadoraVeiculosDbContext dbContext;

        public RepositorioFuncionarioORM(IContextoPersistencia contextoPersitencia)
        {
            this.dbContext = (LocadoraVeiculosDbContext)contextoPersitencia;
            funcionarios = dbContext.Set<Funcionario>();
        }

        public void Inserir(Funcionario novoRegistro)
        {
            funcionarios.Add(novoRegistro);
        }

        public void Editar(Funcionario registro)
        {
            funcionarios.Update(registro);
        }

        public void Excluir(Funcionario registro)
        {
            funcionarios.Remove(registro);
        }

        public Funcionario SelecionarFuncionarioPorLogin(string login)
        {
            return funcionarios.FirstOrDefault(x => x.Login == login);
        }

        public Funcionario SelecionarPorId(Guid id)
        {
            return funcionarios.FirstOrDefault(x => x.Id == id);
        }

        public List<Funcionario> SelecionarTodos()
        {
            return funcionarios.ToList();
        }
    }
}
