using Locadora_Veiculos.Dominio.ModuloGrupoVeiculos;
using Locadora_Veiculos.Dominio.ModuloPlanoCobranca;
using Locadora_Veiculos.Infra.BancoDados.ORM.ModuloGrupoVeiculos;
using Locadora_Veiculos.Infra.BancoDados.ORM.ModuloPlanoCobranca;
using Locadora_Veiculos.Infra.ORM.Tests.Compartilhado;
using LocadoraVeiculos.Aplicacao.ModuloGrupoVeiculos;
using LocadoraVeiculos.Aplicacao.ModuloPlanoCobranca;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;


namespace Locadora_Veiculos.Infra.ORM.Tests.ModuloPlanoCobranca
{
    [TestClass]

    public class RepositorioPlanoCobrancaORMTest : RepositorioORMTestBase
    {
        private RepositorioPlanoCobrancaORM repositorioPlanoCobranca;
        private RepositorioGrupoVeiculosORM repositorioGrupoVeiculos;
        private ServicoPlanoCobranca servicoPlanoCobranca;
        private ServicoGrupoVeiculos servicoGrupoVeiculos;

        public RepositorioPlanoCobrancaORMTest()
        {
            LimparTabelas();

            repositorioPlanoCobranca = new RepositorioPlanoCobrancaORM(dbContext);
            repositorioGrupoVeiculos = new RepositorioGrupoVeiculosORM(dbContext);
            servicoPlanoCobranca = new ServicoPlanoCobranca(repositorioPlanoCobranca, dbContext);
            servicoGrupoVeiculos = new ServicoGrupoVeiculos(repositorioGrupoVeiculos, dbContext);
        }

        [TestMethod]
        public void Deve_inserir_registro()
        {
            //Arrange
            var planoCobranca = NovoPlanoCobranca();

            //Action
            var resultadoInsercao = servicoPlanoCobranca.Inserir(planoCobranca);

            var resultadoSelecao = servicoPlanoCobranca.SelecionarPorId(planoCobranca.Id);

            var registroEncontrado = resultadoSelecao.Value;

            //Assert
            Assert.AreEqual(true, resultadoInsercao.IsSuccess);
            Assert.AreEqual(true, resultadoSelecao.IsSuccess);
            Assert.IsNotNull(registroEncontrado);
            Assert.AreEqual(planoCobranca, registroEncontrado);
        }

        [TestMethod]
        public void Deve_editar_registro()
        {
            //Arrange
            var planoCobranca = NovoPlanoCobranca();

            servicoPlanoCobranca.Inserir(planoCobranca);

            planoCobranca.DiarioValorDia = 100;
            planoCobranca.DiarioValorKm = 20;
            planoCobranca.KmControladoValorDia = 200;
            planoCobranca.KmControladoValorKm = 30;
            planoCobranca.KmControladoLimiteKm = 50;
            planoCobranca.KmLivreValorDia = 300;
            new GrupoVeiculos("Uber");



            //Action
            var resultadoEdicao = servicoPlanoCobranca.Editar(planoCobranca);

            var resultadoSelecao = servicoPlanoCobranca.SelecionarPorId(planoCobranca.Id);

            var registroEncontrado = resultadoSelecao.Value;

            //Assert
            Assert.AreEqual(true, resultadoEdicao.IsSuccess);
            Assert.AreEqual(true, resultadoSelecao.IsSuccess);
            Assert.IsNotNull(registroEncontrado);
            Assert.AreEqual(planoCobranca, registroEncontrado);

        }

        [TestMethod]
        public void Deve_excluir_registro()
        {
            //Arrange
            var planoCobranca = NovoPlanoCobranca();

            servicoPlanoCobranca.Inserir(planoCobranca);

            //Action
            var resultadoExclusao = servicoPlanoCobranca.Excluir(planoCobranca);

            var resultadoSelecao = servicoPlanoCobranca.SelecionarPorId(planoCobranca.Id);

            var registroEncontrado = resultadoSelecao.Value;

            //Assert
            Assert.AreEqual(true, resultadoExclusao.IsSuccess);
            Assert.AreEqual(true, resultadoSelecao.IsSuccess);
            Assert.IsNull(registroEncontrado);
        }

        [TestMethod]
        public void Deve_selecionar_um_registro()
        {
            //Arrange
            var planoCobranca = NovoPlanoCobranca();

            var resultadoInsercao = servicoPlanoCobranca.Inserir(planoCobranca);

            //Action
            var resultadoSelecao = servicoPlanoCobranca.SelecionarPorId(planoCobranca.Id);

            var registroEncontrado = resultadoSelecao.Value;

            //Assert
            Assert.AreEqual(true, resultadoInsercao.IsSuccess);
            Assert.AreEqual(true, resultadoSelecao.IsSuccess);
            Assert.IsNotNull(registroEncontrado);
            Assert.AreEqual(planoCobranca, registroEncontrado);
        }

        [TestMethod]
        public void Deve_selecionar_todos_os_registros()
        {
            //Arrange
            var planoCobrancas = NovosPlanos();
            foreach (var planoCobranca in planoCobrancas)
                servicoPlanoCobranca.Inserir(planoCobranca);

            //Action
            var resultadoSelecao = servicoPlanoCobranca.SelecionarTodos();
            var registrosEncontrados = resultadoSelecao.Value;

            //Assert
            Assert.AreEqual(true, resultadoSelecao.IsSuccess);
            Assert.AreEqual(3, registrosEncontrados.Count);
            Assert.AreEqual(true, registrosEncontrados.Contains(planoCobrancas[0]));
            Assert.AreEqual(true, registrosEncontrados.Contains(planoCobrancas[1]));
            Assert.AreEqual(true, registrosEncontrados.Contains(planoCobrancas[2]));
        }

        #region MÉTODOS PRIVADOS

        private GrupoVeiculos GetGrupoVeiculos()
        {
            var grupo = new GrupoVeiculos("Uber");

            servicoGrupoVeiculos.Inserir(grupo);

            var resultado = servicoGrupoVeiculos.SelecionarPorId(grupo.Id);

            return resultado.Value;
        }

        private PlanoCobranca NovoPlanoCobranca()
        {
            PlanoCobranca p = new PlanoCobranca(100, 20, 200, 30, 50, 300, GetGrupoVeiculos());

            return p;
        }

        private List<PlanoCobranca> NovosPlanos()
        {
            GrupoVeiculos g1 = new GrupoVeiculos("Popular");
            GrupoVeiculos g2 = new GrupoVeiculos("Esportivo");
            GrupoVeiculos g3 = new GrupoVeiculos("PCD");

            servicoGrupoVeiculos.Inserir(g1);
            servicoGrupoVeiculos.Inserir(g2);
            servicoGrupoVeiculos.Inserir(g3);

            PlanoCobranca p1 = new PlanoCobranca(100, 20, 200, 30, 50, 300, g1);

            PlanoCobranca p2 = new PlanoCobranca(100, 20, 200, 30, 50, 300, g2);

            PlanoCobranca p3 = new PlanoCobranca(100, 20, 200, 30, 50, 300, g3);

            var lista = new List<PlanoCobranca>();
            lista.Add(p1);
            lista.Add(p2);
            lista.Add(p3);

            return lista;
        }

        #endregion
    }
}