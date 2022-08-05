
using Locadora_Veiculos.Dominio.Compartilhado;
using Locadora_Veiculos.Dominio.ModuloTaxa;
using Locadora_Veiculos.Infra.BancoDados.ORM.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Locadora_Veiculos.Infra.BancoDados.ORM.ModuloTaxa
{
    public class RepositorioTaxaORM : IRepositorioTaxa
    {
        private DbSet<Taxa> taxas;
        private readonly LocadoraVeiculosDbContext dbContext;

        public RepositorioTaxaORM(IContextoPersistencia contextoPersitencia)
        {
            this.dbContext = (LocadoraVeiculosDbContext)contextoPersitencia;
            taxas = dbContext.Set<Taxa>();
        }

        public void Inserir(Taxa novoRegistro)
        {
            taxas.Add(novoRegistro);
        }

        public void Editar(Taxa registro)
        {
            taxas.Update(registro);
        }

        public void Excluir(Taxa registro)
        {
            taxas.Remove(registro);
        }

        public Taxa SelecionarPorId(Guid id)
        {
            return taxas.FirstOrDefault(x => x.Id == id);
        }

        public Taxa SelecionarTaxaPorDescricao(string descricao)
        {
            return taxas.FirstOrDefault(x => x.Descricao == descricao);
        }

        public List<Taxa> SelecionarTodos()
        {
            return taxas.ToList();
        }

        public int QuantidadeTaxasCadastradas()
        {
            return taxas.ToList().Count;
        }
    }
}
