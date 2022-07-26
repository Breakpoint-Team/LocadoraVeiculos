using Locadora_Veiculos.Dominio.Compartilhado;
using Locadora_Veiculos.Dominio.ModuloCliente;
using Locadora_Veiculos.Dominio.ModuloCondutor;
using Locadora_Veiculos.Dominio.ModuloGrupoVeiculos;
using Locadora_Veiculos.Dominio.ModuloPlanoCobranca;
using Locadora_Veiculos.Dominio.ModuloTaxa;
using Locadora_Veiculos.Dominio.ModuloVeiculo;
using Locadora_Veiculos.Infra.BancoDados.ORM.ModuloFuncionario;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Locadora_Veiculos.Infra.BancoDados.ORM.Compartilhado
{
    public class LocadoraVeiculosDbContext : DbContext, IContextoPersistencia
    {
        private string connectionString;

        public LocadoraVeiculosDbContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void GravarDados()
        {
            SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);

            ILoggerFactory loggerFactory = LoggerFactory.Create((x) =>
            {
                x.AddSerilog(Log.Logger);
            });

            optionsBuilder.UseLoggerFactory(loggerFactory);

            optionsBuilder.EnableSensitiveDataLogging();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MapeadorFuncionarioORM());
 
            
            //USAR DEPOIS QUE TODOS OS MAPEADORES ESTIVEREMPRONTOS

            //var dllComConfiguracoesOrm = typeof(LocadoraVeiculosDbContext).Assembly;

            //modelBuilder.ApplyConfigurationsFromAssembly(dllComConfiguracoesOrm);

            modelBuilder.Ignore<Cliente>();
            modelBuilder.Ignore<Condutor>();
            modelBuilder.Ignore<Taxa>();
            modelBuilder.Ignore<PlanoCobranca>();
            modelBuilder.Ignore<GrupoVeiculos>();
            modelBuilder.Ignore<Veiculo>();

        }
    }
}
