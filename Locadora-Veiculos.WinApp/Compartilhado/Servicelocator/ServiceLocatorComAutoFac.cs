using Autofac;
using Locadora_Veiculos.Dominio.Compartilhado;
using Locadora_Veiculos.Dominio.ModuloCliente;
using Locadora_Veiculos.Dominio.ModuloCondutor;
using Locadora_Veiculos.Dominio.ModuloFuncionario;
using Locadora_Veiculos.Dominio.ModuloGrupoVeiculos;
using Locadora_Veiculos.Dominio.ModuloLocacao;
using Locadora_Veiculos.Dominio.ModuloPlanoCobranca;
using Locadora_Veiculos.Dominio.ModuloTaxa;
using Locadora_Veiculos.Dominio.ModuloVeiculo;
using Locadora_Veiculos.Infra.BancoDados.ORM.Compartilhado;
using Locadora_Veiculos.Infra.BancoDados.ORM.ModuloCliente;
using Locadora_Veiculos.Infra.BancoDados.ORM.ModuloCondutor;
using Locadora_Veiculos.Infra.BancoDados.ORM.ModuloFuncionario;
using Locadora_Veiculos.Infra.BancoDados.ORM.ModuloGrupoVeiculos;
using Locadora_Veiculos.Infra.BancoDados.ORM.ModuloLocacao;
using Locadora_Veiculos.Infra.BancoDados.ORM.ModuloPlanoCobranca;
using Locadora_Veiculos.Infra.BancoDados.ORM.ModuloTaxa;
using Locadora_Veiculos.Infra.BancoDados.ORM.ModuloVeiculo;
using Locadora_Veiculos.Infra.Configs;
using Locadora_Veiculos.Infra.PDF;
using Locadora_Veiculos.WinApp.ModuloCliente;
using Locadora_Veiculos.WinApp.ModuloCondutor;
using Locadora_Veiculos.WinApp.ModuloConfiguracao;
using Locadora_Veiculos.WinApp.ModuloFuncionario;
using Locadora_Veiculos.WinApp.ModuloGrupoVeiculos;
using Locadora_Veiculos.WinApp.ModuloLocacao;
using Locadora_Veiculos.WinApp.ModuloPlanoCobrança;
using Locadora_Veiculos.WinApp.ModuloTaxas;
using Locadora_Veiculos.WinApp.ModuloVeiculo;
using LocadoraVeiculos.Aplicacao.ModuloCliente;
using LocadoraVeiculos.Aplicacao.ModuloCondutor;
using LocadoraVeiculos.Aplicacao.ModuloFuncionario;
using LocadoraVeiculos.Aplicacao.ModuloGrupoVeiculos;
using LocadoraVeiculos.Aplicacao.ModuloLocacao;
using LocadoraVeiculos.Aplicacao.ModuloPlanoCobranca;
using LocadoraVeiculos.Aplicacao.ModuloTaxa;
using LocadoraVeiculos.Aplicacao.ModuloVeiculo;

namespace Locadora_Veiculos.WinApp.Compartilhado.Servicelocator
{
    public class ServiceLocatorComAutoFac : IServiceLocator
    {
        private readonly IContainer container;

        public ServiceLocatorComAutoFac()
        {
            var builder = new ContainerBuilder();

            builder.Register((x) => new ConfiguracaoAplicacao().ConnectionStrings)
                .As<ConnectionStrings>()
                .SingleInstance(); //Singleton

            builder.RegisterType<ConfiguracaoAplicacao>()
                .SingleInstance(); //Singleton

            builder.RegisterType<LocadoraVeiculosDbContext>().As<IContextoPersistencia>()
                .InstancePerLifetimeScope(); //Scoped

            builder.RegisterType<RepositorioClienteORM>().As<IRepositorioCliente>();
            builder.RegisterType<ServicoCliente>().AsSelf();
            builder.RegisterType<ControladorCliente>().AsSelf();

            builder.RegisterType<RepositorioGrupoVeiculosORM>().As<IRepositorioGrupoVeiculos>();
            builder.RegisterType<ServicoGrupoVeiculos>().AsSelf();
            builder.RegisterType<ControladorGrupoVeiculos>().AsSelf();

            builder.RegisterType<RepositorioFuncionarioORM>().As<IRepositorioFuncionario>();
            builder.RegisterType<ServicoFuncionario>().AsSelf();
            builder.RegisterType<ControladorFuncionario>().AsSelf();

            builder.RegisterType<RepositorioCondutorORM>().As<IRepositorioCondutor>();
            builder.RegisterType<ServicoCondutor>().AsSelf();
            builder.RegisterType<ControladorCondutor>().AsSelf();

            builder.RegisterType<RepositorioTaxaORM>().As<IRepositorioTaxa>();
            builder.RegisterType<ServicoTaxa>().AsSelf();
            builder.RegisterType<ControladorTaxa>().AsSelf();

            builder.RegisterType<RepositorioVeiculoORM>().As<IRepositorioVeiculo>();
            builder.RegisterType<ServicoVeiculo>().AsSelf();
            builder.RegisterType<ControladorVeiculo>().AsSelf();

            builder.RegisterType<RepositorioPlanoCobrancaORM>().As<IRepositorioPlanoCobranca>();
            builder.RegisterType<ServicoPlanoCobranca>().AsSelf();
            builder.RegisterType<ControladorPlanoCobranca>().AsSelf();

            builder.RegisterType<GeradorRelatorioITextSharp>().As<IGeradorRelatorio>();

            builder.RegisterType<RepositorioLocacaoORM>().As<IRepositorioLocacao>();
            builder.RegisterType<ServicoLocacao>().AsSelf();
            builder.RegisterType<ControladorLocacao>().AsSelf();

            builder.RegisterType<ControladorConfiguracao>();

            container = builder.Build();
        }

        public T Get<T>() where T : ControladorBase
        {
            return container.Resolve<T>();
        }
    }
}
