using Locadora_Veiculos.Dominio.Compartilhado;
using Locadora_Veiculos.Infra.BancoDados.ORM.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace Locadora_Veiculos.Infra.BancoDados.ORM.ModuloPrecoCombustiveis
{
    public class RepositorioPrecoCombustivelORM
    {
        private DbSet<PrecoCombustivel> precoCombustivel;
        private readonly LocadoraVeiculosDbContext dbContext;

        public RepositorioPrecoCombustivelORM(LocadoraVeiculosDbContext dbContext)
        {
            precoCombustivel = dbContext.Set<PrecoCombustivel>();
            this.dbContext = dbContext;
        }

        public void Atualizar(PrecoCombustivel registro)
        {
            precoCombustivel.Update(registro);
        }

    }
}
