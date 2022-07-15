using Locadora_Veiculos.Dominio.ModuloGrupoVeiculos;
using Locadora_Veiculos.Dominio.ModuloPlanoCobranca;
using Locadora_Veiculos.Dominio.ModuloVeiculo;
using Locadora_Veiculos.Infra.BancoDados.Compartilhado;
using Locadora_Veiculos.Infra.BancoDados.ModuloGrupoVeiculos;
using Locadora_Veiculos.Infra.BancoDados.ModuloPlanoCobranca;
using Locadora_Veiculos.Infra.BancoDados.ModuloVeiculo;
using LocadoraVeiculos.Aplicacao.ModuloGrupoVeiculos;
using LocadoraVeiculos.Aplicacao.ModuloPlanoCobranca;
using LocadoraVeiculos.Aplicacao.ModuloVeiculo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Locadora_Veiculos.Infra.BancoDados.Tests.ModuloGrupoVeiculos
{
    [TestClass]
    public class RepositorioGrupoVeiculosEmBancoDadosTest
    {
        private RepositorioGrupoVeiculosEmBancoDados repositorioGrupoVeiculos;
        private ServicoGrupoVeiculos servicoGrupoVeiculos;

        private RepositorioVeiculoEmBancoDados repositorioVeiculo;
        private ServicoVeiculo servicoVeiculo;

        private RepositorioPlanoCobrancaEmBancoDados repositorioPlanoCobranca;
        private ServicoPlanoCobranca servicoPlanoCobranca;

        public RepositorioGrupoVeiculosEmBancoDadosTest()
        {
            Db.ExecutarSql("DELETE FROM TBPLANOCOBRANCA");
            Db.ExecutarSql("DELETE FROM TBVEICULO");
            Db.ExecutarSql("DELETE FROM TBGRUPOVEICULOS");

            repositorioGrupoVeiculos = new RepositorioGrupoVeiculosEmBancoDados();
            servicoGrupoVeiculos = new ServicoGrupoVeiculos(repositorioGrupoVeiculos);

            repositorioVeiculo = new RepositorioVeiculoEmBancoDados();
            servicoVeiculo = new ServicoVeiculo(repositorioVeiculo);

            repositorioPlanoCobranca = new RepositorioPlanoCobrancaEmBancoDados();
            servicoPlanoCobranca = new ServicoPlanoCobranca(repositorioPlanoCobranca);
        }

        [TestMethod]
        public void Deve_inserir_registro()
        {
            //arrange
            var grupoVeiculos = NovoGrupoVeiculos();

            //action
            servicoGrupoVeiculos.Inserir(grupoVeiculos);

            //assert
            var registroEncontrado = repositorioGrupoVeiculos.SelecionarPorId(grupoVeiculos.Id);
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
            servicoGrupoVeiculos.Editar(grupoVeiculos);

            //assert
            var registroEncontrado = repositorioGrupoVeiculos.SelecionarPorId(grupoVeiculos.Id);

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
            servicoGrupoVeiculos.Excluir(grupoVeiculos);

            //assert
            var registroEncontrado = repositorioGrupoVeiculos.SelecionarPorId(grupoVeiculos.Id);
            Assert.IsNull(registroEncontrado);
        }

        [TestMethod]
        public void Deve_selecionar_um_registro()
        {
            //arrange
            var grupoVeiculos = NovoGrupoVeiculos();

            servicoGrupoVeiculos.Inserir(grupoVeiculos);

            //action
            var registroEncontrado = repositorioGrupoVeiculos.SelecionarPorId(grupoVeiculos.Id);

            //assert
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
            var registrosEncontrados = repositorioGrupoVeiculos.SelecionarTodos();

            //assert
            Assert.AreEqual(3, registrosEncontrados.Count);
            Assert.AreEqual(true, registrosEncontrados.Contains(grupos[0]));
            Assert.AreEqual(true, registrosEncontrados.Contains(grupos[1]));
            Assert.AreEqual(true, registrosEncontrados.Contains(grupos[2]));

        }

        //[TestMethod]
        //public void Nao_deve_inserir_grupo_de_veiculos_com_nome_duplicado()
        //{
        //    //arrange
        //    var g1 = NovoGrupoVeiculos();
        //    servicoGrupoVeiculos.Inserir(g1);
        //    var g2 = NovoGrupoVeiculos();

        //    //action
        //    var resultado = servicoGrupoVeiculos.Inserir(g2);

        //    //assert
        //    Assert.AreEqual("Falha ao tentar inserir o Grupo de Veículos", resultado.Errors[0].Message);
        //}

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
            var resultado = servicoGrupoVeiculos.Excluir(grupoVeiculos);

            //assert
            Assert.AreEqual("Falha no sistema ao tentar excluir o Grupo de Veículos", resultado.Errors[0].Message);

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
            var resultado = servicoGrupoVeiculos.Excluir(grupoVeiculos);

            //assert
            Assert.AreEqual("Falha no sistema ao tentar excluir o Grupo de Veículos", resultado.Errors[0].Message);

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