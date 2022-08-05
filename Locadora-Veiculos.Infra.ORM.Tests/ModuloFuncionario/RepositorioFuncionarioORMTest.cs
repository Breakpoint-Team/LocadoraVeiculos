using Locadora_Veiculos.Dominio.ModuloFuncionario;
using Locadora_Veiculos.Infra.BancoDados.Compartilhado;
using Locadora_Veiculos.Infra.BancoDados.ORM.Compartilhado;
using Locadora_Veiculos.Infra.BancoDados.ORM.ModuloFuncionario;
using Locadora_Veiculos.Infra.ORM.Tests.Compartilhado;
using LocadoraVeiculos.Aplicacao.ModuloFuncionario;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Locadora_Veiculos.Infra.ORM.Tests.ModuloFuncionario
{
    [TestClass]
            
    public class RepositorioFuncionarioORMTest : RepositorioORMTestBase
    {
        private RepositorioFuncionarioORM repositorioFuncionario;
        private ServicoFuncionario servicoFuncionario;
        private LocadoraVeiculosDbContext dbContext;

        public RepositorioFuncionarioORMTest()
        {
            LimparTabelas();
            dbContext = new LocadoraVeiculosDbContext(Db.enderecoBanco);
            repositorioFuncionario = new RepositorioFuncionarioORM(dbContext);
            servicoFuncionario = new ServicoFuncionario(repositorioFuncionario, dbContext);
        }

        [TestMethod]
        public void Deve_inserir_registro()
        {
            //arrange
            var funcionario = NovoFuncionario();

            //action
            var resultadoInsercao = servicoFuncionario.Inserir(funcionario);

            var resultadoSelecao = servicoFuncionario.SelecionarPorId(funcionario.Id);

            var registroEncontrado = resultadoSelecao.Value;

            //assert
            Assert.AreEqual(true, resultadoInsercao.IsSuccess);
            Assert.AreEqual(true, resultadoSelecao.IsSuccess);
            Assert.IsNotNull(registroEncontrado);
            Assert.AreEqual(funcionario, registroEncontrado);
        }

        [TestMethod]
        public void Deve_editar_registro()
        {
            //arrange
            var funcionario = NovoFuncionario();

            servicoFuncionario.Inserir(funcionario);

            funcionario.Nome = "Joao Gabriel";
            funcionario.Senha = "12345679";

            //action
            var resultadoEdicao = servicoFuncionario.Editar(funcionario);

            var resultadoSelecao = servicoFuncionario.SelecionarPorId(funcionario.Id);

            var registroEncontrado = resultadoSelecao.Value;

            //assert
            Assert.AreEqual(true, resultadoEdicao.IsSuccess);
            Assert.AreEqual(true, resultadoSelecao.IsSuccess);

            Assert.IsNotNull(registroEncontrado);
            Assert.AreEqual(funcionario, registroEncontrado);
        }

        [TestMethod]
        public void Deve_excluir_registro()
        {
            //arrange
            var funcionario = NovoFuncionario();
            servicoFuncionario.Inserir(funcionario);

            //action
            var resultadoExclusao = servicoFuncionario.Excluir(funcionario);

            var resultadoSelecao = servicoFuncionario.SelecionarPorId(funcionario.Id);

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
            var funcionario = NovoFuncionario();

            var resultadoInsercao = servicoFuncionario.Inserir(funcionario);

            //action
            var resultadoSelecao = servicoFuncionario.SelecionarPorId(funcionario.Id);

            var registroEncontrado = resultadoSelecao.Value;

            //assert
            Assert.AreEqual(true, resultadoInsercao.IsSuccess);
            Assert.AreEqual(true, resultadoSelecao.IsSuccess);
            Assert.IsNotNull(registroEncontrado);
            Assert.AreEqual(funcionario, registroEncontrado);
        }

        [TestMethod]
        public void Deve_selecionar_todos_os_registros()
        {
            //arrange
            var funcionarios = NovosFuncionarios();
            foreach (var funcionario in funcionarios)
                servicoFuncionario.Inserir(funcionario);

            //action
            var resultadoSelecao = servicoFuncionario.SelecionarTodos();
            var registrosEncontrados = resultadoSelecao.Value;

            //assert
            Assert.AreEqual(true, resultadoSelecao.IsSuccess);
            Assert.AreEqual(3, registrosEncontrados.Count);
            Assert.AreEqual(true, registrosEncontrados.Contains(funcionarios[0]));
            Assert.AreEqual(true, registrosEncontrados.Contains(funcionarios[1]));
            Assert.AreEqual(true, registrosEncontrados.Contains(funcionarios[2]));

        }

        #region MÉTODOS PRIVADOS

        private Funcionario NovoFuncionario()
        {
            Funcionario f = new Funcionario("Alexandre Rech", "rech", "12345678",
                new DateTime(2019, 2, 5), 1200, true, true);
            return f;
        }

        private List<Funcionario> NovosFuncionarios()
        {
            Funcionario f1 = new Funcionario("Matheus Medeiros", "math", "12345678", new DateTime(2020, 07, 14), 800, true,
                 true);

            Funcionario f2 = new Funcionario("Camila Candido", "cami", "87654321", new DateTime(2020, 07, 14), 700, true,
                 true);

            Funcionario f3 = new Funcionario("João Santos", "joao", "12378945", new DateTime(2020, 07, 14), 600, true,
                 true);

            var lista = new List<Funcionario>();
            lista.Add(f1);
            lista.Add(f2);
            lista.Add(f3);

            return lista;
        }

        #endregion
    }
}