using Locadora_Veiculos.Dominio.Compartilhado;
using Locadora_Veiculos.Dominio.ModuloGrupoVeiculos;
using Locadora_Veiculos.Infra.BancoDados.ORM.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Locadora_Veiculos.Infra.BancoDados.ORM.ModuloGrupoVeiculos
{
    public class RepositorioGrupoVeiculosORM : IRepositorioGrupoVeiculos
    {
        private DbSet<GrupoVeiculos> grupos;

        private readonly LocadoraVeiculosDbContext dbContext;

        public RepositorioGrupoVeiculosORM(IContextoPersistencia contextoPersitencia)
        {
            this.dbContext = (LocadoraVeiculosDbContext)contextoPersitencia;
            grupos = dbContext.Set<GrupoVeiculos>();
        }

        public void Inserir(GrupoVeiculos novoRegistro)
        {
            grupos.Add(novoRegistro);
        }

        public void Editar(GrupoVeiculos registro)
        {
            grupos.Update(registro);
        }

        public void Excluir(GrupoVeiculos registro)
        {
            grupos.Remove(registro);
        }

        public int QuantidadeGrupoVeiculosCadastrados()
        {
            return grupos.Count();
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
            return grupos.FirstOrDefault(x => x.Nome == nome);

        }

        public GrupoVeiculos SelecionarPorId(Guid id)
        {
            return grupos.FirstOrDefault(x => x.Id == id);
        }

        public List<GrupoVeiculos> SelecionarTodos()
        {
            return grupos.ToList();
        }
    }
}
