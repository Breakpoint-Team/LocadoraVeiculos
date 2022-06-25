using Locadora_Veiculos.Dominio.ModuloFuncionario;
using Locadora_Veiculos.Infra.BancoDados.Compartilhado;
using Locadora_Veiculos.Infra.BancoDados.ModuloFuncionario;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Locadora_Veiculos.Infra.BancoDados.Tests.ModuloFuncionario
{
    [TestClass]
    public class RepositorioFuncionarioEmBancoDadosTest
    {
        private RepositorioFuncionarioEmBancoDados repositorioFuncionario;

        public RepositorioFuncionarioEmBancoDadosTest()
        {
            Db.ExecutarSql("DELETE FROM TBFUNCIONARIO; DBCC CHECKIDENT (TBFUNCIONARIO, RESEED, 0)");
            repositorioFuncionario = new RepositorioFuncionarioEmBancoDados();
        }

        [TestMethod]
        public void Deve_inserir_registro()
        {
            //arrange
            var funcionario = NovoFuncionario();

            //action
            repositorioFuncionario.Inserir(funcionario);

            //assert
            var registroEncontrado = repositorioFuncionario.SelecionarPorId(funcionario.Id);

            Assert.IsNotNull(registroEncontrado);
            Assert.AreEqual(funcionario, registroEncontrado);
        }

        [TestMethod]
        public void Deve_editar_registro()
        {
            //arrange
            var funcionario = NovoFuncionario();

            //action
            repositorioFuncionario.Inserir(funcionario);

            funcionario.Nome = "Tiago Santini";

            //action
            repositorioFuncionario.Editar(funcionario);

            //assert
            var registroEncontrado = repositorioFuncionario.SelecionarPorId(funcionario.Id);

            Assert.IsNotNull(registroEncontrado);
            Assert.AreEqual(funcionario, registroEncontrado);
        }

        [TestMethod]
        public void Deve_excluir_registro()
        {
            //arrange
            var funcionario = NovoFuncionario();
            repositorioFuncionario.Inserir(funcionario);

            //action
            repositorioFuncionario.Excluir(funcionario);

            //assert
            var registroEncontrado = repositorioFuncionario.SelecionarPorId(funcionario.Id);
            Assert.IsNull(registroEncontrado);
        }

        [TestMethod]
        public void Deve_selecionar_todos_os_registros()
        {
            //arrange
            var funcionarios = NovosFuncionarios();
            foreach (var f in funcionarios)
            {
                repositorioFuncionario.Inserir(f);
            }

            //action
            var registrosEncontrados = repositorioFuncionario.SelecionarTodos();

            //assert
            Assert.AreEqual(3, registrosEncontrados.Count);

            int posicao = 0;
            foreach (var f in funcionarios)
            {
                Assert.AreEqual(registrosEncontrados[posicao].Id, f.Id);
                posicao++;
            }
        }

        [TestMethod]
        public void Deve_selecionar_um_registro()
        {
            //arrange
            var funcionario = NovoFuncionario();
            repositorioFuncionario.Inserir(funcionario);

            //action
            var registroEncontrado = repositorioFuncionario.SelecionarPorId(funcionario.Id);

            //assert
            Assert.IsNotNull(registroEncontrado);
            Assert.AreEqual(funcionario, registroEncontrado);
        }


        #region METODOS PRIVADOS
        private Funcionario NovoFuncionario()
        {
            var funcionario = new Funcionario("Alexandre Rech", "rech", "i?4I{'EY", System.DateTime.Today, 3000, false, true);

            return funcionario;
        }

        private List<Funcionario> NovosFuncionarios()
        {
            var f1 = new Funcionario("Matheus de Medeiros", "matheus", "i?4I{'PY", System.DateTime.Today, 3000, false, true);
            var f2 = new Funcionario("João Gabriel Santos", "joaogabriel", "i?8563Y4", System.DateTime.Today, 3000, false, true);
            var f3 = new Funcionario("Camila Candido", "camilavcandido", "85`$vxvb", System.DateTime.Today, 3000, false, true);

            var lista = new List<Funcionario>();
            lista.Add(f1);
            lista.Add(f2);
            lista.Add(f3);

            return lista;

        }

        #endregion
    }
}
