using Locadora_Veiculos.Dominio.ModuloCliente;
using Locadora_Veiculos.Infra.BancoDados.ORM.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Locadora_Veiculos.Infra.BancoDados.ORM.ModuloCliente
{
    public class RepositorioClienteORM : IRepositorioCliente
    {
        private DbSet<Cliente> clientes;
        private readonly LocadoraVeiculosDbContext dbContext;

        public RepositorioClienteORM(LocadoraVeiculosDbContext dbContext)
        {
            clientes = dbContext.Set<Cliente>();
            this.dbContext = dbContext;
        }

        public void Inserir(Cliente novoRegistro)
        {
            clientes.Add(novoRegistro);
        }

        public void Editar(Cliente registro)
        {
            clientes.Update(registro);
        }

        public void Excluir(Cliente registro)
        {
            clientes.Remove(registro);
        }

        public int QuantidadeClientesCadastrados()
        {
            return clientes.ToList().Count();
        }

        public int QuantidadeCondutoresRelacionadosAoCliente(Guid id)
        {
            var qtd = clientes.FirstOrDefault(x => x.Id == id).Condutores.Count;
            return qtd;
        }

        public Cliente SelecionarClientePorDocumento(string documento)
        {
            return clientes.FirstOrDefault(x => x.Documento == documento);
        }

        public Cliente SelecionarPorId(Guid id)
        {
            return clientes.FirstOrDefault(x => x.Id == id);
        }

        public List<Cliente> SelecionarTodos()
        {
            return clientes.ToList();
        }
    }
}
