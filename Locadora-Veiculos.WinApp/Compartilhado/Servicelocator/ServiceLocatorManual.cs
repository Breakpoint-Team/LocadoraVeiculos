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
using System.Collections.Generic;

namespace Locadora_Veiculos.WinApp.Compartilhado.Servicelocator
{
    public class ServiceLocatorManual : IServiceLocator
    {
        private Dictionary<string, ControladorBase> controladores;

        public ServiceLocatorManual()
        {
            InicializarControladores();
        }

        public T Get<T>() where T : ControladorBase
        {
            var tipo = typeof(T);

            var nomeControlador = tipo.Name;

            return (T)controladores[nomeControlador];
        }

        private void InicializarControladores()
        {
            controladores = new Dictionary<string, ControladorBase>();

            //var configuracao = new ConfigurationBuilder()
            //   .SetBasePath(Directory.GetCurrentDirectory())
            //   .AddJsonFile("ConfiguracaoAplicacao.json")
            //   .Build();
            //var config = new ConfiguracaoAplicacao();

            //var connectionString = configuracao.GetConnectionString("SqlServer");

            var config = new ConfiguracaoAplicacao();

            var contextoDadosOrm = new LocadoraVeiculosDbContext(config.ConnectionStrings);

            var repositorioFuncionario = new RepositorioFuncionarioORM(contextoDadosOrm);
            var servicoFuncionario = new ServicoFuncionario(repositorioFuncionario, contextoDadosOrm);
            controladores.Add("ControladorFuncionario", new ControladorFuncionario(servicoFuncionario));

            var repositorioTaxa = new RepositorioTaxaORM(contextoDadosOrm);
            var servicoTaxa = new ServicoTaxa(repositorioTaxa, contextoDadosOrm);
            controladores.Add("ControladorTaxa", new ControladorTaxa(servicoTaxa));

            var repositorioCliente = new RepositorioClienteORM(contextoDadosOrm);
            var servicoCliente = new ServicoCliente(repositorioCliente, contextoDadosOrm);
            controladores.Add("ControladorCliente", new ControladorCliente(servicoCliente));

            var repositorioCondutor = new RepositorioCondutorORM(contextoDadosOrm);
            var servicoCondutor = new ServicoCondutor(repositorioCondutor, contextoDadosOrm);
            controladores.Add("ControladorCondutor", new ControladorCondutor(servicoCliente, servicoCondutor));

            var repositorioGrupoVeiculos = new RepositorioGrupoVeiculosORM(contextoDadosOrm);
            var servicoGrupoVeiculo = new ServicoGrupoVeiculos(repositorioGrupoVeiculos, contextoDadosOrm);
            controladores.Add("ControladorGrupoVeiculos", new ControladorGrupoVeiculos(servicoGrupoVeiculo));

            var repositorioVeiculo = new RepositorioVeiculoORM(contextoDadosOrm);
            var servicoVeiculo = new ServicoVeiculo(repositorioVeiculo, contextoDadosOrm);
            controladores.Add("ControladorVeiculo", new ControladorVeiculo(servicoVeiculo, servicoGrupoVeiculo));

            var repositorioPlanoCobranca = new RepositorioPlanoCobrancaORM(contextoDadosOrm);
            var servicoPlanoCobranca = new ServicoPlanoCobranca(repositorioPlanoCobranca, contextoDadosOrm);
            controladores.Add("ControladorPlanoCobranca", new ControladorPlanoCobranca(servicoPlanoCobranca, servicoGrupoVeiculo));

            var geradorRelatorio = new GeradorRelatorioITextSharp();
            var repositorioLocacao = new RepositorioLocacaoORM(contextoDadosOrm);
            var servicoLocacao = new ServicoLocacao(repositorioLocacao, contextoDadosOrm, geradorRelatorio);
            controladores.Add("ControladorLocacao", new ControladorLocacao(servicoCondutor, servicoCliente,
                servicoGrupoVeiculo, servicoVeiculo, servicoTaxa, servicoPlanoCobranca, servicoLocacao));

            controladores.Add("ControladorConfiguracao", new ControladorConfiguracao(config));
        }
    }
}