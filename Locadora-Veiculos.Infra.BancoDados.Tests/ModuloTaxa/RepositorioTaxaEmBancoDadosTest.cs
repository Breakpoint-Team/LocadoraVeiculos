using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Locadora_Veiculos.Infra.BancoDados.Tests.ModuloTaxa
{

    [TestClass]
    public class RepositorioTaxaEmBancoDadosTest
    {
        //private RepositorioTaxaEmBancoDados repositorioTaxa;
        //private ServicoTaxa servicoTaxa;
        //public RepositorioTaxaEmBancoDadosTest()
        //{
        //    Db.ExecutarSql("DELETE FROM TBTAXA");
        //    repositorioTaxa = new RepositorioTaxaEmBancoDados();
        //    servicoTaxa = new ServicoTaxa(repositorioTaxa);
        //}

        //[TestMethod]
        //public void Deve_inserir_registro()
        //{
        //    //arrange
        //    var taxa = NovaTaxa();

        //    //action
        //    var resultadoInsercao = servicoTaxa.Inserir(taxa);

        //    var resultadoSelecao = servicoTaxa.SelecionarPorId(taxa.Id);

        //    var registroEncontrado = resultadoSelecao.Value;

        //    //assert
        //    Assert.AreEqual(true, resultadoInsercao.IsSuccess);
        //    Assert.AreEqual(true, resultadoSelecao.IsSuccess);
        //    Assert.IsNotNull(registroEncontrado);
        //    Assert.AreEqual(taxa, registroEncontrado);
        //}

        //[TestMethod]
        //public void Deve_editar_registro()
        //{
        //    //arrange
        //    var taxa = NovaTaxa();

        //    servicoTaxa.Inserir(taxa);

        //    taxa.Descricao = "Gasolina";

        //    //action
        //    var resultadoEdicao = servicoTaxa.Editar(taxa);

        //    var resultadoSelecao = servicoTaxa.SelecionarPorId(taxa.Id);

        //    var registroEncontrado = resultadoSelecao.Value;

        //    //assert
        //    Assert.AreEqual(true, resultadoEdicao.IsSuccess);
        //    Assert.AreEqual(true, resultadoSelecao.IsSuccess);
        //    Assert.IsNotNull(registroEncontrado);
        //    Assert.AreEqual(taxa, registroEncontrado);
        //}

        //[TestMethod]
        //public void Deve_excluir_registro()
        //{
        //    //arrange
        //    var taxa = NovaTaxa();
        //    servicoTaxa.Inserir(taxa);

        //    //action
        //   var resultadoExclusao = servicoTaxa.Excluir(taxa);

        //    var resultadoSelecao = servicoTaxa.SelecionarPorId(taxa.Id);
        //    var registroEncontrado = resultadoSelecao.Value;


        //    //assert
        //    Assert.AreEqual(true, resultadoExclusao.IsSuccess);
        //    Assert.AreEqual(true, resultadoSelecao.IsSuccess);
        //    Assert.IsNull(registroEncontrado);
        //}

        //[TestMethod]
        //public void Deve_selecionar_um_registro()
        //{
        //    //arrange
        //    var taxa = NovaTaxa();

        //    servicoTaxa.Inserir(taxa);
        //    //action
        //    var resultadoSelecao = servicoTaxa.SelecionarPorId(taxa.Id);
        //    var registroEncontrado = resultadoSelecao.Value;

        //    //assert
        //    Assert.AreEqual(true, resultadoSelecao.IsSuccess);
        //    Assert.IsNotNull(registroEncontrado);
        //    Assert.AreEqual(taxa, registroEncontrado);
        //}

        //[TestMethod]
        //public void Deve_selecionar_todos_os_registros()
        //{
        //    //arrange
        //    var taxas = NovasTaxas();
        //    foreach (var t in taxas)
        //        servicoTaxa.Inserir(t);


        //    var resultadoSelecao = servicoTaxa.SelecionarTodos();
        //    var registrosEncontrados = resultadoSelecao.Value;

        //    //assert
        //    Assert.AreEqual(true, resultadoSelecao.IsSuccess);
        //    Assert.AreEqual(3, registrosEncontrados.Count);
        //    Assert.AreEqual(true, registrosEncontrados.Contains(taxas[0]));
        //    Assert.AreEqual(true, registrosEncontrados.Contains(taxas[1]));
        //    Assert.AreEqual(true, registrosEncontrados.Contains(taxas[2]));

        //}

        //[TestMethod]
        //public void Nao_deve_inserir_taxa_com_descricao_duplicada()
        //{
        //    //arrange
        //    var t1 = NovaTaxa();
        //    var resultadoInsercaoT1 = servicoTaxa.Inserir(t1);
        //    var t2 = new Taxa();
        //    t2.Descricao = "Lavação do Veículo";
        //    t2.Valor = 200;
        //    t2.TipoCalculo = TipoCalculo.Fixo;

        //    //action
        //    var resultadoInsercaoT2 = servicoTaxa.Inserir(t2);

        //    //assert
        //    Assert.AreEqual(true, resultadoInsercaoT1.IsSuccess);
        //   Assert.AreEqual(true, resultadoInsercaoT2.IsFailed);
        //  Assert.AreEqual("Descrição já está cadastrada!", resultadoInsercaoT2.Errors[0].Message);
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