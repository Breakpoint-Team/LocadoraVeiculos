using Locadora_Veiculos.Infra.BancoDados.Compartilhado;
using Locadora_Veiculos.Infra.BancoDados.ModuloGrupoVeiculos;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Locadora_Veiculos.Infra.BancoDados.Tests.ModuloGrupoVeiculos
{
    [TestClass]
    public class RepositorioGrupoVeiculosEmBancoDadosTest
    {
        private RepositorioGrupoVeiculosEmBancoDados repositorioGrupoVeiculos;

        public RepositorioGrupoVeiculosEmBancoDadosTest()
        {
            Db.ExecutarSql("DELETE FROM TBGRUPOVEICULOS; DBCC CHECKIDENT (TBGRUPOVEICULOS, RESEED, 0)");
            repositorioGrupoVeiculos = new RepositorioGrupoVeiculosEmBancoDados();
        }

        //[TestMethod]
        //public void Deve_inserir_registro()
        //{
        //    //ararnge
        //    var grupoVeiculos = NovoGrupoVeiculos();

        //    //action
        //    repositorioGrupoVeiculos.Inserir(grupoVeiculos);

        //    //assert
        //    var registroEncontrado = repositorioGrupoVeiculos.SelecionarPorId(grupoVeiculos.Id);
        //    Assert.IsNotNull(registroEncontrado);
        //    Assert.AreEqual(grupoVeiculos, registroEncontrado);
        //}

        //[TestMethod]
        //public void Deve_editar_registro()
        //{
        //    //arrange
        //    var grupoVeiculos = NovoGrupoVeiculos();

        //    repositorioGrupoVeiculos.Inserir(grupoVeiculos);

        //    grupoVeiculos.Nome = "Uber";

        //    //action
        //    repositorioGrupoVeiculos.Editar(grupoVeiculos);

        //    //assert
        //    var registroEncontrado = repositorioGrupoVeiculos.SelecionarPorId(grupoVeiculos.Id);

        //    Assert.IsNotNull(registroEncontrado);
        //    Assert.AreEqual(grupoVeiculos, registroEncontrado);
        //}

        //[TestMethod]
        //public void Deve_excluir_registro()
        //{
        //    //arrange
        //    var grupoVeiculos = NovoGrupoVeiculos();
        //    repositorioGrupoVeiculos.Inserir(grupoVeiculos);

        //    //action
        //    repositorioGrupoVeiculos.Excluir(grupoVeiculos);

        //    //assert
        //    var registroEncontrado = repositorioGrupoVeiculos.SelecionarPorId(grupoVeiculos.Id);
        //    Assert.IsNull(registroEncontrado);
        //}

        //[TestMethod]
        //public void Deve_selecionar_um_registro()
        //{
        //    //arrange
        //    var grupoVeiculos = NovoGrupoVeiculos();

        //    repositorioGrupoVeiculos.Inserir(grupoVeiculos);

        //    //action
        //    var registroEncontrado = repositorioGrupoVeiculos.SelecionarPorId(grupoVeiculos.Id);

        //    //assert
        //    Assert.IsNotNull(registroEncontrado);
        //    Assert.AreEqual(grupoVeiculos, registroEncontrado);
        //}

        //[TestMethod]
        //public void Deve_selecionar_todos_os_registros()
        //{
        //    //arrange
        //    var grupos = NovosGruposVeiculos();
        //    foreach (var g in grupos)
        //    {
        //        repositorioGrupoVeiculos.Inserir(g);
        //    }

        //    //action
        //    var registrosEncontrados = repositorioGrupoVeiculos.SelecionarTodos();

        //    //assert
        //    Assert.AreEqual(3, registrosEncontrados.Count);

        //    int posicao = 0;
        //    foreach (var g in grupos)
        //    {
        //        Assert.AreEqual(registrosEncontrados[posicao].Id, g.Id);
        //        posicao++;
        //    }
        //}

        //#region MÉTODOS PRIVADOS

        //private GrupoVeiculos NovoGrupoVeiculos()
        //{
        //    var g = new GrupoVeiculos();
        //    g.Nome = "SUV";

        //    return g;
        //}

        //private List<GrupoVeiculos> NovosGruposVeiculos()
        //{
        //    var g1 = new GrupoVeiculos("SUV");
        //    var g2 = new GrupoVeiculos("Esportivo");
        //    var g3 = new GrupoVeiculos("PCD");

        //    var lista = new List<GrupoVeiculos>();
        //    lista.Add(g1);
        //    lista.Add(g2);
        //    lista.Add(g3);

        //    return lista;
        //}

        //#endregion
    }
}