using Locadora_Veiculos.Dominio.ModuloGrupoVeiculos;
using Locadora_Veiculos.Infra.BancoDados.ORM.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Locadora_Veiculos.Infra.BancoDados.ORM.ModuloGrupoVeiculos
{
    public class RepositorioGrupoVeiculosORM : IRepositorioGrupoVeiculos
    {
        private DbSet<GrupoVeiculos> grupos;
        private readonly LocadoraVeiculosDbContext dbContext;

        public RepositorioGrupoVeiculosORM(LocadoraVeiculosDbContext dbContext)
        {
            grupos = dbContext.Set<GrupoVeiculos>();
            this.dbContext = dbContext;
        }

        public void Inserir(GrupoVeiculos novoRegistro)
        {
            throw new NotImplementedException();
        }
        
        public void Editar(GrupoVeiculos registro)
        {
            throw new NotImplementedException();
        }

        public void Excluir(GrupoVeiculos registro)
        {
            throw new NotImplementedException();
        }
        
        public int QuantidadeGrupoVeiculosCadastrados()
        {
            throw new NotImplementedException();
        }

        public int QuantidadePlanosDeCobrancaRelacionadosAoGrupo(Guid id)
        {
            throw new NotImplementedException();
        }

        public int QuantidadeVeiculosRelacionadosAoGrupo(Guid id)
        {
            throw new NotImplementedException();
        }

        public GrupoVeiculos SelecionarGrupoVeiculosPorNome(string nome)
        {
            throw new NotImplementedException();
        }

        public GrupoVeiculos SelecionarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<GrupoVeiculos> SelecionarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
