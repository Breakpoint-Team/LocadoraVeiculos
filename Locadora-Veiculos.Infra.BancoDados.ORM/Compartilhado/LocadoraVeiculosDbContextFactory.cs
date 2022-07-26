using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Locadora_Veiculos.Infra.BancoDados.ORM.Compartilhado
{
    public class LocadoraVeiculosDbContextFactory : IDesignTimeDbContextFactory<LocadoraVeiculosDbContext>
    {
        public LocadoraVeiculosDbContext CreateDbContext(string[] args)
        {
            var configuracao = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("ConfiguracaoAplicacao.json")
             .Build();

            var connectionString = configuracao.GetConnectionString("SqlServer");

            return new LocadoraVeiculosDbContext(connectionString);
        }
    }
}