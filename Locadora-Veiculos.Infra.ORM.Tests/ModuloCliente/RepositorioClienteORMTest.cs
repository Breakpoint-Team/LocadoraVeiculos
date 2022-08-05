using Locadora_Veiculos.Dominio.ModuloCliente;
using Locadora_Veiculos.Dominio.ModuloCondutor;
using Locadora_Veiculos.Dominio.ModuloEndereco;
using Locadora_Veiculos.Infra.BancoDados.Compartilhado;
using Locadora_Veiculos.Infra.BancoDados.ORM.Compartilhado;
using Locadora_Veiculos.Infra.BancoDados.ORM.ModuloCliente;
using Locadora_Veiculos.Infra.BancoDados.ORM.ModuloCondutor;
using Locadora_Veiculos.Infra.ORM.Tests.Compartilhado;
using LocadoraVeiculos.Aplicacao.ModuloCliente;
using LocadoraVeiculos.Aplicacao.ModuloCondutor;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Locadora_Veiculos.Infra.ORM.Tests.ModuloCliente
{
    [TestClass]
    public class RepositorioClienteORMTest : RepositorioORMTestBase
    {
        private LocadoraVeiculosDbContext dbContext;
        private RepositorioClienteORM repositorioCliente;
        private RepositorioCondutorORM repositorioCondutor;
        private ServicoCliente servicoCliente;
        private ServicoCondutor servicoCondutor;

        public RepositorioClienteORMTest()
        {
            LimparTabelas();

            dbContext = new LocadoraVeiculosDbContext(Db.enderecoBanco);
            repositorioCliente = new RepositorioClienteORM(dbContext);
            repositorioCondutor = new RepositorioCondutorORM(dbContext);
            servicoCliente = new ServicoCliente(repositorioCliente, dbContext);
            servicoCondutor = new ServicoCondutor(repositorioCondutor, dbContext);
        }

        [TestMethod]
        public void Deve_inserir_registro()
        {
            //Arrange
            var cliente = NovoCliente();

            //Action
            var resultadoInsercao = servicoCliente.Inserir(cliente);

            var resultadoSelecao = servicoCliente.SelecionarPorId(cliente.Id);

            var registroEncontrado = resultadoSelecao.Value;

            //Assert
            Assert.AreEqual(true, resultadoInsercao.IsSuccess);
            Assert.AreEqual(true, resultadoSelecao.IsSuccess);
            Assert.IsNotNull(registroEncontrado);
            Assert.AreEqual(cliente, registroEncontrado);
        }

        [TestMethod]
        public void Deve_editar_registro()
        {
            //Arrange
            var cliente = NovoCliente();

            servicoCliente.Inserir(cliente);

            cliente.Nome = "Alexandre Rech";
            cliente.Email = "rech@academia.com";

            //Action
            var resultadoEdicao = servicoCliente.Editar(cliente);

            var resultadoSelecao = servicoCliente.SelecionarPorId(cliente.Id);

            var registroEncontrado = resultadoSelecao.Value;

            //Assert
            Assert.AreEqual(true, resultadoEdicao.IsSuccess);
            Assert.AreEqual(true, resultadoSelecao.IsSuccess);
            Assert.IsNotNull(registroEncontrado);
            Assert.AreEqual(cliente, registroEncontrado);
        }

        [TestMethod]
        public void Deve_excluir_registro()
        {
            //Arrange
            var cliente = NovoCliente();

            servicoCliente.Inserir(cliente);

            //Action
            var resultadoExclusao = servicoCliente.Excluir(cliente);

            var resultadoSelecao = servicoCliente.SelecionarPorId(cliente.Id);

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
            var cliente = NovoCliente();

            var resultadoInsercao = servicoCliente.Inserir(cliente);

            //Action
            var resultadoSelecao = servicoCliente.SelecionarPorId(cliente.Id);

            var registroEncontrado = resultadoSelecao.Value;

            //Assert
            Assert.AreEqual(true, resultadoInsercao.IsSuccess);
            Assert.AreEqual(true, resultadoSelecao.IsSuccess);
            Assert.IsNotNull(registroEncontrado);
            Assert.AreEqual(cliente, registroEncontrado);
        }

        [TestMethod]
        public void Deve_selecionar_todos_os_registros()
        {
            //Arrange
            var clientes = NovosClientesFisicos();
            foreach (var cliente in clientes)
                servicoCliente.Inserir(cliente);

            //Action
            var resultadoSelecao = servicoCliente.SelecionarTodos();
            var registrosEncontrados = resultadoSelecao.Value;

            //Assert
            Assert.AreEqual(true, resultadoSelecao.IsSuccess);
            Assert.AreEqual(3, registrosEncontrados.Count);
            Assert.AreEqual(true, registrosEncontrados.Contains(clientes[0]));
            Assert.AreEqual(true, registrosEncontrados.Contains(clientes[1]));
            Assert.AreEqual(true, registrosEncontrados.Contains(clientes[2]));
        }

        [TestMethod]
        public void Nao_Deve_inserir_Pessoa_Fisica_Com_CPF_Ja_Cadastrado()
        {
            //Arrange
            var cliente1 = NovoCliente();
            var resultadoInsercao1 = servicoCliente.Inserir(cliente1);

            var cliente2 = new Cliente("Sérgio Ramos", "(49) 99943-9554", "sergio@gmail.com",
                TipoCliente.PessoaFisica, "013.987.765-09", GetEndereco());

            ////Action
            var resultadoInsercao2 = servicoCliente.Inserir(cliente2);

            //Assert
            Assert.AreEqual(true, resultadoInsercao1.IsSuccess);
            Assert.AreEqual(true, resultadoInsercao2.IsFailed);
            Assert.AreEqual("CPF já está cadastrado!", resultadoInsercao2.Errors[0].Message);
        }

        [TestMethod]
        public void Nao_Deve_inserir_Pessoa_Juridica_Com_CNPJ_Ja_Cadastrado()
        {
            //Arrange
            var cliente1 = new Cliente("Coca cola", "(49) 99943-9554", "cocacola@gmail.com",
                TipoCliente.PessoaJuridica, "01.987.765/0001-09", GetEndereco());

            var resultadoInsercao1 = servicoCliente.Inserir(cliente1);

            var cliente2 = new Cliente("Itaú", "(49) 99943-9554", "itau@gmail.com",
                TipoCliente.PessoaJuridica, "01.987.765/0001-09", GetEndereco());

            ////Action
            var resultadoInsercao2 = servicoCliente.Inserir(cliente2);

            //Assert
            Assert.AreEqual(true, resultadoInsercao1.IsSuccess);
            Assert.AreEqual(true, resultadoInsercao2.IsFailed);
            Assert.AreEqual("CNPJ já está cadastrado!", resultadoInsercao2.Errors[0].Message);
        }

        [TestMethod]
        public void Nao_Deve_excluir_cliente_Com_Condutor_relacionado()
        {
            //Arrange
            var cliente = new Cliente("Coca cola", "(49) 99943-9554", "cocacola@gmail.com",
                TipoCliente.PessoaJuridica, "01.987.765/0001-09", GetEndereco());

            var resultadoInsercaoCliente = servicoCliente.Inserir(cliente);

            Condutor condutor = new Condutor("João dos Santos", "(49) 98888-9999", "joao@gmail.com", "018.987.765-09", "123456789",
               new DateTime(2025, 12, 28), GetEndereco(), cliente);

            var resultadoInsercaoCondutor = servicoCondutor.Inserir(condutor);

            //Action
            var resultadoExclusaoCliente = servicoCliente.Excluir(cliente);

            //Assert
            Assert.AreEqual(true, resultadoInsercaoCliente.IsSuccess);
            Assert.AreEqual(true, resultadoInsercaoCondutor.IsSuccess);
            Assert.AreEqual(true, resultadoExclusaoCliente.IsFailed);
            Assert.AreEqual("O cliente Coca cola está relacionado com um condutor e não pode ser excluído", resultadoExclusaoCliente.Errors[0].Message);
        }

        #region MÉTODOS PRIVADOS

        private Endereco GetEndereco()
        {
            return new Endereco("SP", "São Paulo", "centro", "Rua das laranjeiras", 87); throw new NotImplementedException();
        }

        private Cliente NovoCliente()
        {
            Cliente c = new Cliente("João da Silva", "(49) 98888-9999", "joao@gmail.com",
                TipoCliente.PessoaFisica, "013.987.765-09", GetEndereco());

            return c;
        }

        private List<Cliente> NovosClientesFisicos()
        {
            Endereco endereco = new Endereco("SP", "São Paulo", "centro", "Rua das laranjeiras", 87);

            Cliente c1 = new Cliente("João da Silva", "(49) 98888-9999", "joao@gmail.com",
                TipoCliente.PessoaFisica, "063.987.765-09", GetEndereco());

            Cliente c2 = new Cliente("Alexandre Rech", "(49) 98888-9555", "alexandre@gmail.com",
                TipoCliente.PessoaFisica, "047.967.762-08", GetEndereco());

            Cliente c3 = new Cliente("Tiago Santini", "(49) 98655-9002", "tiago@gmail.com",
                TipoCliente.PessoaFisica, "013.987.763-07", GetEndereco());

            var lista = new List<Cliente>();
            lista.Add(c1);
            lista.Add(c2);
            lista.Add(c3);

            return lista;
        }

        #endregion
    }
}