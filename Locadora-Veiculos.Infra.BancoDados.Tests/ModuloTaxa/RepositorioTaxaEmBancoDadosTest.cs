using Locadora_Veiculos.Infra.BancoDados.Compartilhado;
using Locadora_Veiculos.Infra.BancoDados.ModuloTaxa;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Locadora_Veiculos.Infra.BancoDados.Tests.ModuloTaxa
{

    [TestClass]
    public class RepositorioTaxaEmBancoDadosTest
    {
        private RepositorioTaxaEmBancoDados repositorioTaxa;

        public RepositorioTaxaEmBancoDadosTest()
        {
            Db.ExecutarSql("DELETE FROM TBTAXA; DBCC CHECKIDENT (TBTAXA, RESEED, 0)");
            repositorioTaxa = new RepositorioTaxaEmBancoDados();
        }

        //[TestMethod]
        //public void Deve_inserir_registro()
        //{
        //    //arrange
        //    var taxa = NovaTaxa();

        //    //action
        //    repositorioTaxa.Inserir(taxa);

        //    //assert
        //    var registroEncontrado = repositorioTaxa.SelecionarPorId(taxa.Id);

        //    Assert.IsNotNull(registroEncontrado);
        //    Assert.AreEqual(taxa, registroEncontrado);
        //}

        //[TestMethod]
        //public void Deve_editar_registro()
        //{
        //    //arrange
        //    var taxa = NovaTaxa();

        //    repositorioTaxa.Inserir(taxa);

        //    taxa.Descricao = "Gasolina";

        //    //action
        //    repositorioTaxa.Editar(taxa);

        //    //assert
        //    var registroEncontrado = repositorioTaxa.SelecionarPorId(taxa.Id);

        //    Assert.IsNotNull(registroEncontrado);
        //    Assert.AreEqual(taxa, registroEncontrado);
        //}

        //[TestMethod]
        //public void Deve_excluir_registro()
        //{
        //    //arrange
        //    var taxa = NovaTaxa();
        //    repositorioTaxa.Inserir(taxa);

        //    //action
        //    repositorioTaxa.Excluir(taxa);

        //    var registroEncontrado = repositorioTaxa.SelecionarPorId(taxa.Id);

        //    //assert
        //    Assert.IsNull(registroEncontrado);
        //}

        //[TestMethod]
        //public void Deve_selecionar_um_registro()
        //{
        //    //arrange
        //    var taxa = NovaTaxa();

        //    repositorioTaxa.Inserir(taxa);

        //    //action
        //    var registroEncontrado = repositorioTaxa.SelecionarPorId(taxa.Id);

        //    //assert
        //    Assert.IsNotNull(registroEncontrado);
        //    Assert.AreEqual(taxa, registroEncontrado);
        //}

        //[TestMethod]
        //public void Deve_selecionar_todos_os_registros()
        //{
        //    //arrange
        //    var taxas = NovasTaxas();
        //    foreach (var t in taxas)
        //    {
        //        repositorioTaxa.Inserir(t);
        //    }

        //    //action
        //    var registrosEncontrados = repositorioTaxa.SelecionarTodos();

        //    //assert
        //    Assert.AreEqual(3, registrosEncontrados.Count);

        //    int posicao = 0;
        //    foreach (var t in taxas)
        //    {
        //        Assert.AreEqual(registrosEncontrados[posicao].Id, t.Id);
        //        posicao++;
        //    }
        //}

        //#region MÉTODOS PRIVADOS

        //private Taxa NovaTaxa()
        //{
        //    var t = new Taxa();
        //    t.Descricao = "Lavação do Veículo";
        //    t.Valor = 100;
        //    t.TipoCalculo = TipoCalculo.Fixo;

        //    return t;
        //}

        //private List<Taxa> NovasTaxas()
        //{
        //    var t1 = new Taxa("Lavação do Veículo", 100, TipoCalculo.Fixo);
        //    var t2 = new Taxa("Cadeira de Bebê", 90, TipoCalculo.Diario);
        //    var t3 = new Taxa("Frigobar", 50, TipoCalculo.Diario);

        //    var lista = new List<Taxa>();
        //    lista.Add(t1);
        //    lista.Add(t2);
        //    lista.Add(t3);

        //    return lista;
        //}

        //#endregion
    }
}