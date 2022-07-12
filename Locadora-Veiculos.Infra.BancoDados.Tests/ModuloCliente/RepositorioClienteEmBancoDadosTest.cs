using Locadora_Veiculos.Dominio.ModuloCliente;
using Locadora_Veiculos.Dominio.ModuloCondutor;
using Locadora_Veiculos.Dominio.ModuloEndereco;
using Locadora_Veiculos.Infra.BancoDados.Compartilhado;
using Locadora_Veiculos.Infra.BancoDados.ModuloCliente;
using Locadora_Veiculos.Infra.BancoDados.ModuloCondutor;
using LocadoraVeiculos.Aplicacao.ModuloCliente;
using LocadoraVeiculos.Aplicacao.ModuloCondutor;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Locadora_Veiculos.Infra.BancoDados.Tests.ModuloCliente
{
    [TestClass]
    public class RepositorioClienteEmBancoDadosTest
    {
        private RepositorioClienteEmBancoDados repositorioCliente;
        private RepositorioCondutorEmBancoDados repositorioCondutor;
        private ServicoCliente servicoCliente;
        private ServicoCondutor servicoCondutor;

        public RepositorioClienteEmBancoDadosTest()
        {
            Db.ExecutarSql("DELETE FROM TBCONDUTOR;");
            Db.ExecutarSql("DELETE FROM TBCLIENTE;");
            repositorioCliente = new RepositorioClienteEmBancoDados();
            repositorioCondutor = new RepositorioCondutorEmBancoDados();
            servicoCliente = new ServicoCliente(repositorioCliente);
            servicoCondutor = new ServicoCondutor(repositorioCondutor);
        }

        [TestMethod]
        public void Deve_inserir_registro()
        {
            //Arrange
            var cliente = NovoCliente();

            //action
            var resultado = servicoCliente.Inserir(cliente);

            var registroEncontrado = repositorioCliente.SelecionarPorId(cliente.Id);

            //assert
            Assert.AreEqual(0, resultado.Errors.Count);
            Assert.IsNotNull(registroEncontrado);
            Assert.AreEqual(cliente, registroEncontrado);
        }

        [TestMethod]
        public void Deve_editar_registro()
        {
            //arrange
            var cliente = NovoCliente();

            servicoCliente.Inserir(cliente);

            cliente.Nome = "Alexandre Rech";
            cliente.Email = "rech@academia.com";

            //action
            var resultado = servicoCliente.Editar(cliente);

            var registroEncontrado = repositorioCliente.SelecionarPorId(cliente.Id);

            //assert
            Assert.AreEqual(0, resultado.Errors.Count);
            Assert.IsNotNull(registroEncontrado);
            Assert.AreEqual(cliente, registroEncontrado);
        }

        [TestMethod]
        public void Deve_excluir_registro()
        {
            //arrange
            var cliente = NovoCliente();
            servicoCliente.Inserir(cliente);

            //action
            servicoCliente.Excluir(cliente);

            var registroEncontrado = repositorioCliente.SelecionarPorId(cliente.Id);

            //assert
            Assert.IsNull(registroEncontrado);
        }

        [TestMethod]
        public void Deve_selecionar_um_registro()
        {
            //arrange
            var cliente = NovoCliente();

            servicoCliente.Inserir(cliente);

            //action
            var registroEncontrado = repositorioCliente.SelecionarPorId(cliente.Id);

            //assert
            Assert.IsNotNull(registroEncontrado);
            Assert.AreEqual(cliente, registroEncontrado);
        }

        [TestMethod]
        public void Deve_selecionar_todos_os_registros()
        {
            //arrange
            var clientes = NovosClientesFisicos();
            foreach (var cliente in clientes)
                servicoCliente.Inserir(cliente);

            //action
            var registrosEncontrados = repositorioCliente.SelecionarTodos();

            //assert
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
            servicoCliente.Inserir(cliente1);

            var cliente2 = new Cliente("Sérgio Ramos", "(49) 99943-9554", "sergio@gmail.com",
                TipoCliente.PessoaFisica, "013.987.765-09", GetEndereco());

            //action
            var resultado = servicoCliente.Inserir(cliente2);

            //assert
            Assert.AreEqual("CPF já está cadastrado!", resultado.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Nao_Deve_inserir_Pessoa_Juridica_Com_CNPJ_Ja_Cadastrado()
        {
            //Arrange
            var cliente1 = new Cliente("Coca cola", "(49) 99943-9554", "cocacola@gmail.com",
                TipoCliente.PessoaJuridica, "01.987.765/0001-09", GetEndereco());
            servicoCliente.Inserir(cliente1);

            var cliente2 = new Cliente("Itaú", "(49) 99943-9554", "itau@gmail.com",
                TipoCliente.PessoaJuridica, "01.987.765/0001-09", GetEndereco());

            //action
            var resultado = servicoCliente.Inserir(cliente2);

            //assert
            Assert.AreEqual("CNPJ já está cadastrado!", resultado.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Nao_Deve_excluir_cliente_Com_Condutor_relacionado()
        {
            //Arrange
            var cliente = new Cliente("Coca cola", "(49) 99943-9554", "cocacola@gmail.com",
                TipoCliente.PessoaJuridica, "01.987.765/0001-09", GetEndereco());
            servicoCliente.Inserir(cliente);

            Condutor condutor = new Condutor("João dos Santos", "(49) 98888-9999", "joao@gmail.com", "018.987.765-09", "123456789",
               new DateTime(2025, 12, 28), GetEndereco(), cliente);
            
            servicoCondutor.Inserir(condutor);

            //Action
            var resultado = servicoCliente.Excluir(cliente);

            //Assert
            Assert.AreEqual("Não é possível excluir um Cliente que possui Condutores relacionados!", resultado.Errors[0].ErrorMessage);
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