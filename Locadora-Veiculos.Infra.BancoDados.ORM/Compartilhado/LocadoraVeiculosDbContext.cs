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
using Locadora_Veiculos.Infra.BancoDados.ORM.ModuloPlanoCobranca;
using Locadora_Veiculos.Infra.BancoDados.ORM.ModuloPrecoCombustiveis;
using Locadora_Veiculos.Infra.BancoDados.ORM.ModuloTaxa;
using Locadora_Veiculos.Infra.BancoDados.ORM.ModuloVeiculo;
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
            modelBuilder.ApplyConfiguration(new MapeadorClienteORM());
            modelBuilder.ApplyConfiguration(new MapeadorGrupoVeiculosORM());
            modelBuilder.ApplyConfiguration(new MapeadorTaxaORM());
            modelBuilder.ApplyConfiguration(new MapeadorPlanoCobrancaORM());
            modelBuilder.ApplyConfiguration(new MapeadorVeiculoORM());
            modelBuilder.ApplyConfiguration(new MapeadorCondutorORM());
            modelBuilder.ApplyConfiguration(new MapeadorPrecoCombustivelORM());


            //USAR DEPOIS QUE TODOS OS MAPEADORES ESTIVEREMPRONTOS

            //var dllComConfiguracoesOrm = typeof(LocadoraVeiculosDbContext).Assembly;

            //modelBuilder.ApplyConfigurationsFromAssembly(dllComConfiguracoesOrm);

            //var dllComConfiguracoesOrm = typeof(LocadoraVeiculosDbContext).Assembly;

            //modelBuilder.ApplyConfigurationsFromAssembly(dllComConfiguracoesOrm);

        }
    }
}
