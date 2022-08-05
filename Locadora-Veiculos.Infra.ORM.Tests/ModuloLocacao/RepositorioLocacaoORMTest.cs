using Locadora_Veiculos.Dominio.ModuloCliente;
using Locadora_Veiculos.Dominio.ModuloCondutor;
using Locadora_Veiculos.Dominio.ModuloEndereco;
using Locadora_Veiculos.Dominio.ModuloGrupoVeiculos;
using Locadora_Veiculos.Dominio.ModuloLocacao;
using Locadora_Veiculos.Dominio.ModuloPlanoCobranca;
using Locadora_Veiculos.Dominio.ModuloTaxa;
using Locadora_Veiculos.Dominio.ModuloVeiculo;
using Locadora_Veiculos.Infra.BancoDados.Compartilhado;
using Locadora_Veiculos.Infra.BancoDados.ORM.Compartilhado;
using Locadora_Veiculos.Infra.BancoDados.ORM.ModuloCliente;
using Locadora_Veiculos.Infra.BancoDados.ORM.ModuloCondutor;
using Locadora_Veiculos.Infra.BancoDados.ORM.ModuloGrupoVeiculos;
using Locadora_Veiculos.Infra.BancoDados.ORM.ModuloLocacao;
using Locadora_Veiculos.Infra.BancoDados.ORM.ModuloPlanoCobranca;
using Locadora_Veiculos.Infra.BancoDados.ORM.ModuloTaxa;
using Locadora_Veiculos.Infra.BancoDados.ORM.ModuloVeiculo;
using Locadora_Veiculos.Infra.ORM.Tests.Compartilhado;
using Locadora_Veiculos.Infra.PDF;
using LocadoraVeiculos.Aplicacao.ModuloCliente;
using LocadoraVeiculos.Aplicacao.ModuloCondutor;
using LocadoraVeiculos.Aplicacao.ModuloGrupoVeiculos;
using LocadoraVeiculos.Aplicacao.ModuloLocacao;
using LocadoraVeiculos.Aplicacao.ModuloPlanoCobranca;
using LocadoraVeiculos.Aplicacao.ModuloTaxa;
using LocadoraVeiculos.Aplicacao.ModuloVeiculo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Locadora_Veiculos.Infra.ORM.Tests.ModuloLocacao
{

    [TestClass]
    public class RepositorioLocacaoORMTest : RepositorioORMTestBase
    {
        private LocadoraVeiculosDbContext dbContext;
        private RepositorioClienteORM repositorioCliente;
        private RepositorioCondutorORM repositorioCondutor;
        private RepositorioVeiculoORM repositorioVeiculo;
        private RepositorioTaxaORM repositorioTaxa;
        private RepositorioPlanoCobrancaORM repositorioPlano;
        private RepositorioGrupoVeiculosORM repositorioGrupo;
        private RepositorioLocacaoORM repositorioLocacao;

        private ServicoCliente servicoCliente;
        private ServicoCondutor servicoCondutor;
        private ServicoTaxa servicoTaxa;
        private ServicoPlanoCobranca servicoPlano;
        private ServicoGrupoVeiculos servicoGrupoVeiculo;
        private ServicoVeiculo servicoVeiculo;
        private ServicoLocacao servicoLocacao;

        public RepositorioLocacaoORMTest()
        {
            LimparTabelas();

            dbContext = new LocadoraVeiculosDbContext(Db.enderecoBanco);

            repositorioCliente = new RepositorioClienteORM(dbContext);
            repositorioCondutor = new RepositorioCondutorORM(dbContext);
            repositorioVeiculo = new RepositorioVeiculoORM(dbContext);
            repositorioTaxa = new RepositorioTaxaORM(dbContext);
            repositorioPlano = new RepositorioPlanoCobrancaORM(dbContext);
            repositorioGrupo = new RepositorioGrupoVeiculosORM(dbContext);
            repositorioLocacao = new RepositorioLocacaoORM(dbContext);

            servicoCliente = new ServicoCliente(repositorioCliente, dbContext);
            servicoCondutor = new ServicoCondutor(repositorioCondutor, dbContext);

            servicoTaxa = new ServicoTaxa(repositorioTaxa, dbContext);
            servicoPlano = new ServicoPlanoCobranca(repositorioPlano, dbContext);
            servicoGrupoVeiculo = new ServicoGrupoVeiculos(repositorioGrupo, dbContext);
            servicoVeiculo = new ServicoVeiculo(repositorioVeiculo, dbContext);
            IGeradorRelatorio geradorRelatorio = new GeradorRelatorioITextSharp();
            servicoLocacao = new ServicoLocacao(repositorioLocacao, dbContext, geradorRelatorio);
            PopularDados();
        }

        [TestMethod]
        public void Deve_inserir_registro()
        {
            var condutor = GetCondutor();
            var grupo = GetGrupoVeiculos();
            var veiculo = GetVeiculo();
            var plano = GetPlanoCobranca();

            Locacao locacao = new(condutor, veiculo,
            grupo, plano, TipoPlano.Diario, GetTaxas(), DateTime.Today, 1,
            new DateTime(2025, 8, 13), veiculo.QuilometragemPercorrida);
            CalculadoraValoresLocacao calculadora = new CalculadoraValoresLocacao();
            locacao.ValorTotalPrevisto = calculadora.CalcularValorTotalPrevisto(locacao);

            servicoLocacao.Inserir(locacao);

            var resultadoSelecao = servicoLocacao.SelecionarPorId(locacao.Id);

            //Assert
            Assert.AreEqual(locacao, resultadoSelecao.Value);
        }

        [TestMethod]
        public void Deve_editar_registro()
        {
            var condutor = GetCondutor();
            var grupo = GetGrupoVeiculos();
            var veiculo = GetVeiculo();
            var plano = GetPlanoCobranca();

            Locacao locacao = new(condutor, veiculo,
            grupo, plano, TipoPlano.Diario, GetTaxas(), DateTime.Today, 1,
            new DateTime(2025, 8, 13), veiculo.QuilometragemPercorrida);
            CalculadoraValoresLocacao calculadora = new CalculadoraValoresLocacao();
            locacao.ValorTotalPrevisto = calculadora.CalcularValorTotalPrevisto(locacao);
            servicoLocacao.Inserir(locacao);

            locacao.DataDevolucaoPrevista = new DateTime(2025, 8, 14);

            servicoLocacao.Editar(locacao);

            var resultadoSelecao = servicoLocacao.SelecionarPorId(locacao.Id);

            //Assert
            Assert.AreEqual(locacao, resultadoSelecao.Value);
        }

        [TestMethod]
        public void Deve_excluir_registro()
        {
            var condutor = GetCondutor();
            var grupo = GetGrupoVeiculos();
            var veiculo = GetVeiculo();
            var plano = GetPlanoCobranca();

            Locacao locacao = new(condutor, veiculo,
            grupo, plano, TipoPlano.Diario, GetTaxas(), DateTime.Today, 1,
            new DateTime(2025, 8, 13), veiculo.QuilometragemPercorrida);
            CalculadoraValoresLocacao calculadora = new CalculadoraValoresLocacao();
            locacao.ValorTotalPrevisto = calculadora.CalcularValorTotalPrevisto(locacao);
            servicoLocacao.Inserir(locacao);
            locacao.StatusLocacao = StatusLocacao.Fechada;
            servicoLocacao.Excluir(locacao);

            var resultadoSelecao = servicoLocacao.SelecionarPorId(locacao.Id);

            //Assert
            Assert.AreEqual(null, resultadoSelecao.Value);
        }

        [TestMethod]
        public void Deve_selecionar_um_registro()
        {
            var condutor = GetCondutor();
            var grupo = GetGrupoVeiculos();
            var veiculo = GetVeiculo();
            var plano = GetPlanoCobranca();

            Locacao locacao = new(condutor, veiculo,
            grupo, plano, TipoPlano.Diario, GetTaxas(), DateTime.Today, 1,
            new DateTime(2025, 8, 13), veiculo.QuilometragemPercorrida);
            CalculadoraValoresLocacao calculadora = new CalculadoraValoresLocacao();
            locacao.ValorTotalPrevisto = calculadora.CalcularValorTotalPrevisto(locacao);

            servicoLocacao.Inserir(locacao);

            var resultadoSelecao = servicoLocacao.SelecionarPorId(locacao.Id);

            //Assert
            Assert.AreEqual(locacao, resultadoSelecao.Value);
        }

        #region MÉTODOS PRIVADOS

        private Veiculo GetVeiculo()
        {
            var imagem = new byte[10];
            for (int i = 0; i < imagem.Length; i++)
                imagem[i] = (byte)i;

            var veiculo = new Veiculo("Kicks", "Nissan", 2019, "Vermelho", "ABC1234",
           "Gasolina", 10000, 40.0m, GetGrupoVeiculos(), imagem);

            return veiculo;
        }

        private GrupoVeiculos GetGrupoVeiculos()
        {
            var grupo = new GrupoVeiculos("Uber");
            return grupo;
        }

        private PlanoCobranca GetPlanoCobranca()
        {
            var plano = new PlanoCobranca(100, 20, 200, 30, 50, 300, GetGrupoVeiculos());
            return plano;
        }

        private Cliente GetCliente()
        {
            var cliente = new Cliente("Paulo Roberto Pereira", "(49) 98855-0076", "paulo@gmail.com",
                 TipoCliente.PessoaFisica, "015.932.598-04", GetEndereco());
            return cliente;
        }

        private Condutor GetCondutor()
        {
            var condutor = new Condutor("João da Silva", "(49) 98888-9999", "joao@gmail.com", "013.987.765-09", "123456789",
                new DateTime(2028, 12, 28), GetEndereco(), GetCliente());
            return condutor;
        }

        private Endereco GetEndereco()
        {
            return new Endereco("SP", "São Paulo", "centro", "Rua das laranjeiras", 2);
        }

        private List<Taxa> GetTaxas()
        {
            var t1 = new Taxa("Cadeira de Bebê", 90, TipoCalculo.Diario);
            var t2 = new Taxa("Frigobar", 50, TipoCalculo.Diario);

            var lista = new List<Taxa>();
            lista.Add(t1);
            lista.Add(t2);

            return lista;
        }

        private void PopularDados()
        {
            servicoGrupoVeiculo.Inserir(GetGrupoVeiculos());
            servicoCliente.Inserir(GetCliente());
            servicoPlano.Inserir(GetPlanoCobranca());
            foreach (var item in GetTaxas())
                servicoTaxa.Inserir(item);
            servicoCondutor.Inserir(GetCondutor());
            servicoVeiculo.Inserir(GetVeiculo());
        }

        #endregion
    }
}