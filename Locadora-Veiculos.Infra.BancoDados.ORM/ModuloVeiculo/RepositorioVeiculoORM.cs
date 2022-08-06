using Locadora_Veiculos.Dominio.Compartilhado;
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

        public RepositorioVeiculoORM(IContextoPersistencia contextoPersitencia)
        {
            this.dbContext = (LocadoraVeiculosDbContext)contextoPersitencia;
            veiculos = dbContext.Set<Veiculo>();
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
