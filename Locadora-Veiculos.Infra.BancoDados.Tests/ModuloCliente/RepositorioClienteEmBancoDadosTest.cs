using Locadora_Veiculos.Dominio.ModuloCliente;
using Locadora_Veiculos.Infra.BancoDados.Compartilhado;
using Locadora_Veiculos.Infra.BancoDados.ModuloCliente;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Locadora_Veiculos.Infra.BancoDados.Tests.ModuloCliente
{
    [TestClass]
    public class RepositorioClienteEmBancoDadosTest
    {
        private RepositorioClienteEmBancoDados repositorioCliente;

        public RepositorioClienteEmBancoDadosTest()
        {
            Db.ExecutarSql("DELETE FROM TBCLIENTE; DBCC CHECKIDENT (TBCLIENTE, RESEED, 0)");
            repositorioCliente = new RepositorioClienteEmBancoDados();
        }

        //[TestMethod]
        //public void Deve_inserir_registro()
        //{
        //    //Arrange
        //    var cliente = NovoCliente();

        //    //action
        //    repositorioCliente.Inserir(cliente);

        //    var registroEncontrado = repositorioCliente.SelecionarPorId(cliente.Id);

        //    //assert
        //    Assert.IsNotNull(registroEncontrado);
        //    Assert.AreEqual(cliente, registroEncontrado);
        //}

        //[TestMethod]
        //public void Deve_editar_registro()
        //{
        //    //arrange
        //    var cliente = NovoCliente();

        //    repositorioCliente.Inserir(cliente);

        //    cliente.Nome = "Alexandre Rech";

        //    //action
        //    repositorioCliente.Editar(cliente);

        //    var registroEncontrado = repositorioCliente.SelecionarPorId(cliente.Id);

        //    //assert
        //    Assert.IsNotNull(registroEncontrado);
        //    Assert.AreEqual(cliente, registroEncontrado);
        //}

        //[TestMethod]
        //public void Deve_excluir_registro()
        //{
        //    //arrange
        //    var cliente = NovoCliente();
        //    repositorioCliente.Inserir(cliente);

        //    //action
        //    repositorioCliente.Excluir(cliente);

        //    var registroEncontrado = repositorioCliente.SelecionarPorId(cliente.Id);

        //    //assert
        //    Assert.IsNull(registroEncontrado);
        //}

        //[TestMethod]
        //public void Deve_selecionar_um_registro()
        //{
        //    //arrange
        //    var cliente = NovoCliente();

        //    repositorioCliente.Inserir(cliente);

        //    //action
        //    var registroEncontrado = repositorioCliente.SelecionarPorId(cliente.Id);

        //    //assert
        //    Assert.IsNotNull(registroEncontrado);
        //    Assert.AreEqual(cliente, registroEncontrado);
        //}

        //[TestMethod]
        //public void Deve_selecionar_todos_os_registros()
        //{
        //    //arrange
        //    var clientes = NovosClientesFisicos();
        //    foreach (var cliente in clientes)
        //        repositorioCliente.Inserir(cliente);

        //    //action
        //    var registrosEncontrados = repositorioCliente.SelecionarTodos();

        //    //assert
        //    Assert.AreEqual(3, registrosEncontrados.Count);

        //    int posicao = 0;
        //    foreach (var g in clientes)
        //    {
        //        Assert.AreEqual(registrosEncontrados[posicao].Id, g.Id);
        //        posicao++;
        //    }

        //}

        //[TestMethod]
        //public void Nao_Deve_inserir_Pessoa_Fisica_Com_CPF_Ja_Cadastrado()
        //{
        //    //Arrange
        //    var cliente1 = NovoCliente();
        //    repositorioCliente.Inserir(cliente1);

        //    var cliente2 = new Cliente("Sérgio Ramos", "(49) 99943-9554", "sergio@gmail.com",
        //        TipoCliente.PessoaFisica, "013.987.765-09", 507,
        //        "Rua do abacaxi", "centro", "Lages", "SC");

        //    //action
        //    var resultado = repositorioCliente.Inserir(cliente2);

        //    //assert
        //    Assert.AreEqual("CPF já está cadastrado", resultado.Errors[0].ErrorMessage);
        //}

        //[TestMethod]
        //public void Nao_Deve_inserir_Pessoa_Juridica_Com_CNPJ_Ja_Cadastrado()
        //{
        //    //Arrange
        //    var cliente1 = new Cliente("Coca cola", "(49) 99943-9554", "cocacola@gmail.com",
        //        TipoCliente.PessoaJuridica, "01.987.765/0001-09", 507,
        //        "Rua do abacaxi", "centro", "Lages", "SC");
        //    repositorioCliente.Inserir(cliente1);

        //    var cliente2 = new Cliente("Itaú", "(49) 99943-9554", "itau@gmail.com",
        //        TipoCliente.PessoaJuridica, "01.987.765/0001-09", 507,
        //        "Rua do abacaxi", "centro", "Lages", "SC");

        //    //action
        //    var resultado = repositorioCliente.Inserir(cliente2);

        //    //assert
        //    Assert.AreEqual("CNPJ já está cadastrado", resultado.Errors[0].ErrorMessage);
        //}

        //#region MÉTODOS PRIVADOS

        //private Cliente NovoCliente()
        //{
        //    Cliente c = new Cliente("João da Silva", "(49) 98888-9999", "joao@gmail.com",
        //        TipoCliente.PessoaFisica, "013.987.765-09", 2,
        //        "Rua das laranjeiras", "centro", "São Paulo", "SP");

        //    return c;
        //}

        //private List<Cliente> NovosClientesFisicos()
        //{
        //    Cliente c1 = new Cliente("João da Silva", "(49) 98888-9999", "joao@gmail.com",
        //        TipoCliente.PessoaFisica, "063.987.765-09", 2,
        //        "Rua das laranjeiras", "centro", "São Paulo", "SP");

        //    Cliente c2 = new Cliente("Alexandre Rech", "(49) 98888-9555", "alexandre@gmail.com",
        //        TipoCliente.PessoaFisica, "047.967.762-08",  2,
        //        "Rua das bananeirass", "centro", "São Paulo", "SP");

        //    Cliente c3 = new Cliente("Tiago Santini", "(49) 98655-9002", "tiago@gmail.com",
        //        TipoCliente.PessoaFisica, "013.987.763-07", 2,
        //        "Rua das macieiras", "centro", "São Paulo", "SP");

        //    var lista = new List<Cliente>();
        //    lista.Add(c1);
        //    lista.Add(c2);
        //    lista.Add(c3);

        //    return lista;
        //}

        //#endregion
    }
}