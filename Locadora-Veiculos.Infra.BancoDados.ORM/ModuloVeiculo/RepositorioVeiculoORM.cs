using Locadora_Veiculos.Dominio.ModuloVeiculo;
using Locadora_Veiculos.Infra.BancoDados.ORM.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

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
            veiculos.Add(novoRegistro);
        }

        public void Editar(Veiculo registro)
        {
            veiculos.Update(registro);
        }

        public void Excluir(Veiculo registro)
        {
            veiculos.Remove(registro);
        }

        public Veiculo SelecionarPorId(Guid id)
        {
            return veiculos.SingleOrDefault(x => x.Id == id);
        }

        public List<Veiculo> SelecionarTodos()
        {
            return veiculos.Include(x => x.GrupoVeiculos).ToList();
        }

        public Veiculo SelecionarVeiculoPorPlaca(string placa)
        {
            return veiculos.SingleOrDefault(x => x.Placa == placa);
        }

        public int QuantidadeVeiculosCadastrados()
        {
            return veiculos.ToList().Count;
        }
    }
}
