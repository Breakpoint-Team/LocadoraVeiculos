using Locadora_Veiculos.Infra.Configs;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Locadora_Veiculos.Infra.BancoDados.ORM.Compartilhado
{
    public class MigradorBancoDadosLocadoraVeiculos
    {
        public static void AtualizarBancoDados()
        {
            var config = new ConfiguracaoAplicacao();

            var db = new LocadoraVeiculosDbContext(config.ConnectionStrings);

            var migracoesPendentes = db.Database.GetPendingMigrations();

            if (migracoesPendentes.Count() > 0)
                db.Database.Migrate();
        }
    }
}