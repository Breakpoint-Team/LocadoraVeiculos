using Locadora_Veiculos.Infra.Configs;
using Microsoft.EntityFrameworkCore.Design;

namespace Locadora_Veiculos.Infra.BancoDados.ORM.Compartilhado
{
    public class LocadoraVeiculosDbContextFactory : IDesignTimeDbContextFactory<LocadoraVeiculosDbContext>
    {
        public LocadoraVeiculosDbContext CreateDbContext(string[] args)
        {
            var config = new ConfiguracaoAplicacao();

            return new LocadoraVeiculosDbContext(config.ConnectionStrings);
        }
    }
}