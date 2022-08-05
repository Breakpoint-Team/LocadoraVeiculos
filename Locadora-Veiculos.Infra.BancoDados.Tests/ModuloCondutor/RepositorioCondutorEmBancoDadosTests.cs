using Locadora_Veiculos.Infra.BancoDados.ModuloCliente;
using Locadora_Veiculos.Infra.BancoDados.ModuloCondutor;
using LocadoraVeiculos.Aplicacao.ModuloCliente;
using LocadoraVeiculos.Aplicacao.ModuloCondutor;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Locadora_Veiculos.Infra.BancoDados.Tests.ModuloCondutor
{
    [TestClass]
    public class RepositorioCondutorEmBancoDadosTests
    {
        private RepositorioClienteEmBancoDados repositorioCliente;
        private RepositorioCondutorEmBancoDados repositorioCondutor;
        private ServicoCliente servicoCliente;
        private ServicoCondutor servicoCondutor;

        //public RepositorioCondutorEmBancoDadosTests()
        //{
        //    Db.ExecutarSql("DELETE FROM TBCONDUTOR;");
        //    Db.ExecutarSql("DELETE FROM TBCLIENTE;");
        //    repositorioCliente = new RepositorioClienteEmBancoDados();
        //    repositorioCondutor = new RepositorioCondutorEmBancoDados();
        //    servicoCliente = new ServicoCliente(repositorioCliente);
        //    servicoCondutor = new ServicoCondutor(repositorioCondutor);
        //}

        //[TestMethod]
        //public void Deve_inserir_registro()
        //{
        //    //Arrange
        //    var condutor = NovoCondutor();

        //    //Action
        //    var resultadoInsercao = servicoCondutor.Inserir(condutor);

        //    var resultadoSelecao = servicoCondutor.SelecionarPorId(condutor.Id);

        //    var registroEncontrado = resultadoSelecao.Value;

        //    //assert
        //    Assert.AreEqual(true, resultadoInsercao.IsSuccess);
        //    Assert.AreEqual(true, resultadoSelecao.IsSuccess);
        //    Assert.IsNotNull(registroEncontrado);
        //    Assert.AreEqual(condutor, registroEncontrado);
        //}

        //[TestMethod]
        //public void Deve_editar_registro()
        //{
        //    //Arrange
        //    var condutor = NovoCondutor();

        //    servicoCondutor.Inserir(condutor);

        //    condutor.Nome = "Alexandre Rech";
        //    condutor.Email = "rech@academia.com";

        //    //Action
        //    var resultadoEdicao = servicoCondutor.Editar(condutor);

        //    var resultadoSelecao = servicoCondutor.SelecionarPorId(condutor.Id);

        //    var registroEncontrado = resultadoSelecao.Value;

        //    //Assert
        //    Assert.AreEqual(true, resultadoEdicao.IsSuccess);
        //    Assert.AreEqual(true, resultadoSelecao.IsSuccess);
        //    Assert.IsNotNull(registroEncontrado);
        //    Assert.AreEqual(condutor, registroEncontrado);
        //}

        //[TestMethod]
        //public void Deve_excluir_registro()
        //{
        //    //Arrange
        //    var condutor = NovoCondutor();
        //    servicoCondutor.Inserir(condutor);

        //    //Action
        //    var resultadoExclusao = servicoCondutor.Excluir(condutor);

        //    var resultadoSelecao = servicoCondutor.SelecionarPorId(condutor.Id);

        //    var registroEncontrado = resultadoSelecao.Value;

        //    //Assert
        //    Assert.AreEqual(true, resultadoExclusao.IsSuccess);
        //    Assert.AreEqual(true, resultadoSelecao.IsSuccess);
        //    Assert.IsNull(registroEncontrado);
        //}

        //[TestMethod]
        //public void Deve_selecionar_um_registro()
        //{
        //    //Arrange
        //    var condutor = NovoCondutor();

        //    var resultadoInsercao = servicoCondutor.Inserir(condutor);

        //    //Action
        //    var resultadoSelecao = servicoCondutor.SelecionarPorId(condutor.Id);

        //    var registroEncontrado = resultadoSelecao.Value;

        //    //Assert
        //    Assert.AreEqual(true, resultadoInsercao.IsSuccess);
        //    Assert.AreEqual(true, resultadoSelecao.IsSuccess);
        //    Assert.IsNotNull(registroEncontrado);
        //    Assert.AreEqual(condutor, registroEncontrado);
        //}

        //[TestMethod]
        //public void Deve_selecionar_todos_os_registros()
        //{
        //    //arrange
        //    var condutores = NovosCondutores();
        //    foreach (var condutor in condutores)
        //        servicoCondutor.Inserir(condutor);

        //    //Action
        //    var resultadoSelecao = servicoCondutor.SelecionarTodos();
        //    var registrosEncontrados = resultadoSelecao.Value;

        //    //Assert
        //    Assert.AreEqual(true, resultadoSelecao.IsSuccess);
        //    Assert.AreEqual(3, registrosEncontrados.Count);
        //    Assert.AreEqual(true, registrosEncontrados.Contains(condutores[0]));
        //    Assert.AreEqual(true, registrosEncontrados.Contains(condutores[1]));
        //    Assert.AreEqual(true, registrosEncontrados.Contains(condutores[2]));
        //}

        //[TestMethod]
        //public void Nao_Deve_inserir_condutor_Com_CPF_Ja_Cadastrado()
        //{
        //    //Arrange
        //    var condutor1 = NovoCondutor();
        //    var resultadoInsercao1 = servicoCondutor.Inserir(condutor1);

        //    var cliente2 = new Cliente("Carlos Pereira", "(49) 98842-9922", "carlos@gmail.com",
        //         TipoCliente.PessoaFisica, "583.127.545-96", GetEndereco());

        //    servicoCliente.Inserir(cliente2);

        //    var condutor2 = new Condutor("Paulo Pereira", "(49) 95588-9564", "paulo@gmail.com", "018.987.765-09", "288677554",
        //       new DateTime(2025, 12, 28), GetEndereco(), cliente2);

        //    //Action
        //    var resultadoInsercao2 = servicoCondutor.Inserir(condutor2);

        //    //Assert
        //    Assert.AreEqual(true, resultadoInsercao1.IsSuccess);
        //    Assert.AreEqual(true, resultadoInsercao2.IsFailed);
        //    Assert.AreEqual("CPF já está cadastrado como condutor!", resultadoInsercao2.Errors[0].Message);
        //}

        //[TestMethod]
        //public void Nao_Deve_inserir_condutor_Com_CNH_Ja_Cadastrada()
        //{
        //    //Arrange
        //    var condutor1 = NovoCondutor();
        //    var resultadoInsercao1 = servicoCondutor.Inserir(condutor1);

        //    var cliente2 = new Cliente("Carlos Pereira", "(49) 98842-9922", "carlos@gmail.com",
        //         TipoCliente.PessoaFisica, "583.127.545-96", GetEndereco());

        //    servicoCliente.Inserir(cliente2);

        //    var condutor2 = new Condutor("Paulo Pereira", "(49) 95588-9564", "paulo@gmail.com", "045.456.742-26", "123456789",
        //       new DateTime(2025, 12, 28), GetEndereco(), cliente2);

        //    //Action
        //    var resultadoInsercao2 = servicoCondutor.Inserir(condutor2);

        //    //Assert
        //    Assert.AreEqual(true, resultadoInsercao1.IsSuccess);
        //    Assert.AreEqual(true, resultadoInsercao2.IsFailed);
        //    Assert.AreEqual("CNH já está cadastrada como condutor!", resultadoInsercao2.Errors[0].Message);
        //}

        //#region MÉTODOS PRIVADOS

        //private Endereco GetEndereco()
        //{
        //    return new Endereco("SP", "São Paulo", "centro", "Rua das laranjeiras", 87);
        //}

        //private Condutor NovoCondutor()
        //{
        //    return new Condutor("João dos Santos", "(49) 98888-9999", "joao@gmail.com", "018.987.765-09", "123456789",
        //       new DateTime(2025, 12, 28), GetEndereco(), GetCliente());
        //}

        //private Cliente GetCliente()
        //{
        //    var cliente = new Cliente("João da Silva", "(49) 98888-9999", "joao@gmail.com",
        //         TipoCliente.PessoaFisica, "013.987.765-09", GetEndereco());

        //    servicoCliente.Inserir(cliente);

        //    var resultado = servicoCliente.SelecionarPorId(cliente.Id);

        //    return resultado.Value;
        //}

        //private List<Condutor> NovosCondutores()
        //{
        //    var cliente1 = new Cliente("Mario Barros", "(49) 98844-9923", "mario@gmail.com",
        //         TipoCliente.PessoaFisica, "021.749.743-02", GetEndereco());

        //    var cliente2 = new Cliente("Carlos Pereira", "(49) 98842-9922", "carlos@gmail.com",
        //         TipoCliente.PessoaFisica, "583.127.545-96", GetEndereco());

        //    var cliente3 = new Cliente("Claudio Ramos", "(49) 94444-9909", "claudio@gmail.com",
        //         TipoCliente.PessoaFisica, "016.941.763-09", GetEndereco());

        //    servicoCliente.Inserir(cliente1);
        //    servicoCliente.Inserir(cliente2);
        //    servicoCliente.Inserir(cliente3);

        //    Condutor c1 = new Condutor("João da Silva", "(49) 98888-9999", "joao@gmail.com",
        //         "063.987.765-89", "123456789", new DateTime(2030, 10, 20), GetEndereco(), cliente1);
        //    Condutor c2 = new Condutor("Alexandre Rech", "(49) 98888-9555", "alexandre@gmail.com",
        //         "043.967.762-05", "987654321", new DateTime(2028, 8, 14), GetEndereco(), cliente2);

        //    Condutor c3 = new Condutor("Tiago Santini", "(49) 98655-9002", "tiago@gmail.com",
        //         "015.367.763-07", "554433227", new DateTime(2025, 12, 25), GetEndereco(), cliente3);

        //    var lista = new List<Condutor>();
        //    lista.Add(c1);
        //    lista.Add(c2);
        //    lista.Add(c3);

        //    return lista;
        //}

        //#endregion
    }
}