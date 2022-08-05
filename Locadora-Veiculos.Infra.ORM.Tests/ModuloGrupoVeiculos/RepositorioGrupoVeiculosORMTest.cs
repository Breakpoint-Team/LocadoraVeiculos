using Locadora_Veiculos.Dominio.ModuloGrupoVeiculos;
using Locadora_Veiculos.Dominio.ModuloPlanoCobranca;
using Locadora_Veiculos.Dominio.ModuloVeiculo;
using Locadora_Veiculos.Infra.BancoDados.ORM.ModuloGrupoVeiculos;
using Locadora_Veiculos.Infra.BancoDados.ORM.ModuloPlanoCobranca;
using Locadora_Veiculos.Infra.BancoDados.ORM.ModuloVeiculo;
using Locadora_Veiculos.Infra.ORM.Tests.Compartilhado;
using LocadoraVeiculos.Aplicacao.ModuloGrupoVeiculos;
using LocadoraVeiculos.Aplicacao.ModuloPlanoCobranca;
using LocadoraVeiculos.Aplicacao.ModuloVeiculo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Locadora_Veiculos.Infra.ORM.Tests.ModuloGrupoVeiculos
{
    [TestClass]
    public class RepositorioGrupoVeiculosORMTest : RepositorioORMTestBase
    {
        private RepositorioGrupoVeiculosORM repositorioGrupoVeiculos;
        private ServicoGrupoVeiculos servicoGrupoVeiculos;
        private RepositorioVeiculoORM repositorioVeiculo;
        private ServicoVeiculo servicoVeiculo;
        private RepositorioPlanoCobrancaORM repositorioPlanoCobranca;
        private ServicoPlanoCobranca servicoPlanoCobranca;

        public RepositorioGrupoVeiculosORMTest()
        {
            LimparTabelas();
            repositorioGrupoVeiculos = new RepositorioGrupoVeiculosORM(dbContext);
            servicoGrupoVeiculos = new ServicoGrupoVeiculos(repositorioGrupoVeiculos, dbContext);

            repositorioVeiculo = new RepositorioVeiculoORM(dbContext);
            servicoVeiculo = new ServicoVeiculo(repositorioVeiculo, dbContext);

            repositorioPlanoCobranca = new RepositorioPlanoCobrancaORM(dbContext);
            servicoPlanoCobranca = new ServicoPlanoCobranca(repositorioPlanoCobranca, dbContext);
        }

        [TestMethod]
        public void Deve_inserir_registro()
        {
            //arrange
            var grupoVeiculos = NovoGrupoVeiculos();

            //action
            var resultadoInsercao = servicoGrupoVeiculos.Inserir(grupoVeiculos);

            //assert
            var resultadoSelecao = servicoGrupoVeiculos.SelecionarPorId(grupoVeiculos.Id);
            var registroEncontrado = resultadoSelecao.Value;

            Assert.AreEqual(true, resultadoInsercao.IsSuccess);
            Assert.AreEqual(true, resultadoSelecao.IsSuccess);
            Assert.IsNotNull(registroEncontrado);
            Assert.AreEqual(grupoVeiculos, registroEncontrado);
        }

        [TestMethod]
        public void Deve_editar_registro()
        {
            //arrange
            var grupoVeiculos = NovoGrupoVeiculos();

            servicoGrupoVeiculos.Inserir(grupoVeiculos);

            grupoVeiculos.Nome = "Uber";

            //action
            var resultadoEdicao = servicoGrupoVeiculos.Editar(grupoVeiculos);

            //assert
            var resultadoSelecao = servicoGrupoVeiculos.SelecionarPorId(grupoVeiculos.Id);
            var registroEncontrado = resultadoSelecao.Value;

            Assert.AreEqual(true, resultadoEdicao.IsSuccess);
            Assert.AreEqual(true, resultadoSelecao.IsSuccess);
            Assert.IsNotNull(registroEncontrado);
            Assert.AreEqual(grupoVeiculos, registroEncontrado);
        }

        [TestMethod]
        public void Deve_excluir_registro()
        {
            //arrange
            var grupoVeiculos = NovoGrupoVeiculos();
            servicoGrupoVeiculos.Inserir(grupoVeiculos);

            //action
            var resultadoExclusao = servicoGrupoVeiculos.Excluir(grupoVeiculos);
            var resultadoSelecao = servicoGrupoVeiculos.SelecionarPorId(grupoVeiculos.Id);
            var registroEncontrado = resultadoSelecao.Value;

            //assert
            Assert.AreEqual(true, resultadoExclusao.IsSuccess);
            Assert.AreEqual(true, resultadoSelecao.IsSuccess);
            Assert.IsNull(registroEncontrado);
        }

        [TestMethod]
        public void Deve_selecionar_um_registro()
        {
            //arrange
            var grupoVeiculos = NovoGrupoVeiculos();

            servicoGrupoVeiculos.Inserir(grupoVeiculos);

            //action
            var resultadoSelecao = servicoGrupoVeiculos.SelecionarPorId(grupoVeiculos.Id);

            var registroEncontrado = resultadoSelecao.Value;

            //assert
            Assert.AreEqual(true, resultadoSelecao.IsSuccess);
            Assert.IsNotNull(registroEncontrado);
            Assert.AreEqual(grupoVeiculos, registroEncontrado);
        }

        [TestMethod]
        public void Deve_selecionar_todos_os_registros()
        {
            //arrange
            var grupos = NovosGruposVeiculos();
            foreach (var g in grupos)
                servicoGrupoVeiculos.Inserir(g);

            //action
            var resultadoSelecao = servicoGrupoVeiculos.SelecionarTodos();

            var registrosEncontrados = resultadoSelecao.Value;

            //assert
            Assert.AreEqual(true, resultadoSelecao.IsSuccess);
            Assert.AreEqual(3, registrosEncontrados.Count);
            Assert.AreEqual(true, registrosEncontrados.Contains(grupos[0]));
            Assert.AreEqual(true, registrosEncontrados.Contains(grupos[1]));
            Assert.AreEqual(true, registrosEncontrados.Contains(grupos[2]));

        }

        [TestMethod]
        public void Nao_deve_inserir_grupo_de_veiculos_com_nome_duplicado()
        {
            //arrange
            var g1 = NovoGrupoVeiculos();
            var resultadoInsercaoG1 = servicoGrupoVeiculos.Inserir(g1);

            var g2 = new GrupoVeiculos();
            g2.Nome = "SUV";

            //action
            var resultadoInsercaoG2 = servicoGrupoVeiculos.Inserir(g2);

            //assert
            Assert.AreEqual(true, resultadoInsercaoG1.IsSuccess);

            Assert.AreEqual(true, resultadoInsercaoG2.IsFailed);

            Assert.AreEqual("Nome já está cadastrado!", resultadoInsercaoG2.Errors[0].Message);
        }

        [TestMethod]
        public void Nao_deve_excluir_grupo_de_veiculos_que_possui_veiculo_relacionado()
        {
            //arrange
            var grupoVeiculos = NovoGrupoVeiculos();
            servicoGrupoVeiculos.Inserir(grupoVeiculos);

            var veiculo = NovoVeiculo();
            veiculo.GrupoVeiculos = grupoVeiculos;
            servicoVeiculo.Inserir(veiculo);

            //action
            var resultadoExclusao = servicoGrupoVeiculos.Excluir(grupoVeiculos);

            //assert
            Assert.AreEqual(true, resultadoExclusao.IsFailed);
            Assert.AreEqual("O grupo de veículos SUV está relacionado com um veículo ou plano de cobrança e não pode ser excluído", resultadoExclusao.Errors[0].Message);

        }

        [TestMethod]
        public void Nao_deve_excluir_grupo_de_veiculos_que_possui_plano_de_cobranca_relacionado()
        {

            //arrange
            var grupoVeiculos = NovoGrupoVeiculos();
            servicoGrupoVeiculos.Inserir(grupoVeiculos);

            var planoCobranca = NovoPlanoCobranca();
            planoCobranca.GrupoVeiculos = grupoVeiculos;
            servicoPlanoCobranca.Inserir(planoCobranca);

            //action
            var resultadoExclusao = servicoGrupoVeiculos.Excluir(grupoVeiculos);

            //assert
            Assert.AreEqual(true, resultadoExclusao.IsFailed);
            Assert.AreEqual("O grupo de veículos SUV está relacionado com um veículo ou plano de cobrança e não pode ser excluído", resultadoExclusao.Errors[0].Message);

        }

        #region MÉTODOS PRIVADOS

        private GrupoVeiculos NovoGrupoVeiculos()
        {
            var g = new GrupoVeiculos();
            g.Nome = "SUV";

            return g;
        }

        private List<GrupoVeiculos> NovosGruposVeiculos()
        {
            var g1 = new GrupoVeiculos("SUV");
            var g2 = new GrupoVeiculos("Esportivo");
            var g3 = new GrupoVeiculos("PCD");

            var lista = new List<GrupoVeiculos>();
            lista.Add(g1);
            lista.Add(g2);
            lista.Add(g3);

            return lista;
        }

        private Veiculo NovoVeiculo()
        {
            var veiculo = new Veiculo();
            veiculo.Modelo = "Tracker 2022";
            veiculo.Marca = "Chevrolet";
            veiculo.Ano = 2022;
            veiculo.Cor = "Cinza";
            veiculo.Placa = "ABC0J97";
            veiculo.QuilometragemPercorrida = 200;
            veiculo.CapacidadeTanque = 13;
            veiculo.TipoCombustivel = "Gasolina";
            veiculo.Imagem = new byte[3] { 1, 2, 3 };
            return veiculo;
        }
        private PlanoCobranca NovoPlanoCobranca()
        {
            var p = new PlanoCobranca();
            p.DiarioValorDia = 100;
            p.DiarioValorKm = 100;
            p.KmControladoValorDia = 150;
            p.KmControladoValorKm = 200;
            p.KmControladoLimiteKm = 300;
            p.KmLivreValorDia = 1000;

            return p;
        }

        #endregion
    }
}