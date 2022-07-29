using Locadora_Veiculos.Dominio.Compartilhado;
using Locadora_Veiculos.Dominio.ModuloCliente;
using Locadora_Veiculos.Dominio.ModuloCondutor;
using Locadora_Veiculos.Dominio.ModuloGrupoVeiculos;
using Locadora_Veiculos.Dominio.ModuloPlanoCobranca;
using Locadora_Veiculos.Dominio.ModuloTaxa;
using Locadora_Veiculos.Dominio.ModuloVeiculo;
using Locadora_Veiculos.Infra.BancoDados.ORM.ModuloCliente;
using Locadora_Veiculos.Infra.BancoDados.ORM.ModuloCondutor;
using Locadora_Veiculos.Infra.BancoDados.ORM.ModuloFuncionario;
using Locadora_Veiculos.Infra.BancoDados.ORM.ModuloGrupoVeiculos;
using Locadora_Veiculos.Infra.BancoDados.ORM.ModuloLocacao;
using Locadora_Veiculos.Infra.BancoDados.ORM.ModuloPlanoCobranca;
using Locadora_Veiculos.Infra.BancoDados.ORM.ModuloTaxa;
using Locadora_Veiculos.Infra.BancoDados.ORM.ModuloVeiculo;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Serilog;
using System.Linq;

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

        public void DesfazerAlteracoes()
        {
            var context = this;
            var changedEntries = context.ChangeTracker.Entries()
                .Where(x => x.State != EntityState.Unchanged).ToList();

            foreach (var entry in changedEntries)
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.CurrentValues.SetValues(entry.OriginalValues);
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Unchanged;
                        break;
                }
            }
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
            modelBuilder.ApplyConfiguration(new MapeadorClienteORM());
            modelBuilder.ApplyConfiguration(new MapeadorGrupoVeiculosORM());
            modelBuilder.ApplyConfiguration(new MapeadorTaxaORM());
            modelBuilder.ApplyConfiguration(new MapeadorPlanoCobrancaORM());
            modelBuilder.ApplyConfiguration(new MapeadorVeiculoORM());
            modelBuilder.ApplyConfiguration(new MapeadorCondutorORM());
            modelBuilder.ApplyConfiguration(new MapeadorLocacaoORM());


            //USAR DEPOIS QUE TODOS OS MAPEADORES ESTIVEREMPRONTOS

            //var dllComConfiguracoesOrm = typeof(LocadoraVeiculosDbContext).Assembly;

            //modelBuilder.ApplyConfigurationsFromAssembly(dllComConfiguracoesOrm);

            //var dllComConfiguracoesOrm = typeof(LocadoraVeiculosDbContext).Assembly;

            //modelBuilder.ApplyConfigurationsFromAssembly(dllComConfiguracoesOrm);

        }
    }
}
