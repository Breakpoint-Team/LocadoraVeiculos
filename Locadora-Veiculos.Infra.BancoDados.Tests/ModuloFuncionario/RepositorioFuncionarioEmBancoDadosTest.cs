using Locadora_Veiculos.Infra.BancoDados.Compartilhado;
using Locadora_Veiculos.Infra.BancoDados.ModuloFuncionario;
using LocadoraVeiculos.Aplicacao.ModuloFuncionario;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Locadora_Veiculos.Dominio.ModuloFuncionario;
using System.Collections.Generic;
using System;

namespace Locadora_Veiculos.Infra.BancoDados.Tests.ModuloFuncionario
{
    [TestClass]
    public class RepositorioFuncionarioEmBancoDadosTest
    {
        private RepositorioFuncionarioEmBancoDados repositorioFuncionario;
        private ServicoFuncionario servicoFuncionario;

        public RepositorioFuncionarioEmBancoDadosTest()
        {
            Db.ExecutarSql("DELETE FROM TBFUNCIONARIO; DBCC CHECKIDENT (TBFUNCIONARIO, RESEED, 0)");
            repositorioFuncionario = new RepositorioFuncionarioEmBancoDados();
        }


        /* Login = login;
            Senha = senha;
            DataAdmissao = dataAdmissao;
            Salario = salario;
            EhAdmin = ehAdmin;
            EstaAtivo = estaAtivo;*/

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


        /*  Nome = nome
             Login = login;
             Senha = senha;
             DataAdmissao = dataAdmissao;
             Salario = salario;
             EhAdmin = ehAdmin;
             EstaAtivo = estaAtivo;*/
        private Funcionario NovoFuncionario()
        {
            
            Funcionario f = new Funcionario("Alexandre Rech", "rech", "12345678",
                new DateTime(2019,2,5) ,1200, true, true );
            return f;
        }

        private List<Funcionario> NovosFuncionarios()
        {
            Funcionario f1 = new Funcionario("Matheus Medeiros","math", "12345678",new DateTime(2020, 07, 14), 800,true,
                 true );

            Funcionario f2 = new Funcionario("Camila Candido","cami", "87654321",new DateTime(2020, 07, 14), 700,true,
                 true);

            Funcionario f3 = new Funcionario("João Santos","joao", "12378945", new DateTime(2020, 07, 14), 600,true  ,
                 true);

            var lista = new List<Funcionario>();
            lista.Add(f1);
            lista.Add(f2);
            lista.Add(f3);

            return lista;
        }


        
        



        #endregion


        //[TestMethod]
        //public void Deve_inserir_registro()
        //{
        //    //arrange
        //    var funcionario = NovoFuncionario();

        //    //action
        //    repositorioFuncionario.Inserir(funcionario);

        //    //assert
        //    var registroEncontrado = repositorioFuncionario.SelecionarPorId(funcionario.Id);

        //    Assert.IsNotNull(registroEncontrado);
        //    Assert.AreEqual(funcionario, registroEncontrado);
        //}

        //[TestMethod]
        //public void Deve_editar_registro()
        //{
        //    //arrange
        //    var funcionario = NovoFuncionario();

        //    //action
        //    repositorioFuncionario.Inserir(funcionario);

        //    funcionario.Nome = "Tiago Santini";

        //    //action
        //    repositorioFuncionario.Editar(funcionario);

        //    //assert
        //    var registroEncontrado = repositorioFuncionario.SelecionarPorId(funcionario.Id);

        //    Assert.IsNotNull(registroEncontrado);
        //    Assert.AreEqual(funcionario, registroEncontrado);
        //}

        //[TestMethod]
        //public void Deve_excluir_registro()
        //{
        //    //arrange
        //    var funcionario = NovoFuncionario();
        //    repositorioFuncionario.Inserir(funcionario);

        //    //action
        //    repositorioFuncionario.Excluir(funcionario);

        //    //assert
        //    var registroEncontrado = repositorioFuncionario.SelecionarPorId(funcionario.Id);
        //    Assert.IsNull(registroEncontrado);
        //}

        //[TestMethod]
        //public void Deve_selecionar_todos_os_registros()
        //{
        //    //arrange
        //    var funcionarios = NovosFuncionarios();
        //    foreach (var f in funcionarios)
        //    {
        //        repositorioFuncionario.Inserir(f);
        //    }

        //    //action
        //    var registrosEncontrados = repositorioFuncionario.SelecionarTodos();

        //    //assert
        //    Assert.AreEqual(3, registrosEncontrados.Count);

        //    int posicao = 0;
        //    foreach (var f in funcionarios)
        //    {
        //        Assert.AreEqual(registrosEncontrados[posicao].Id, f.Id);
        //        posicao++;
        //    }
        //}

        //[TestMethod]
        //public void Deve_selecionar_um_registro()
        //{
        //    //arrange
        //    var funcionario = NovoFuncionario();
        //    repositorioFuncionario.Inserir(funcionario);

        //    //action
        //    var registroEncontrado = repositorioFuncionario.SelecionarPorId(funcionario.Id);

        //    //assert
        //    Assert.IsNotNull(registroEncontrado);
        //    Assert.AreEqual(funcionario, registroEncontrado);
        //}


        //#region METODOS PRIVADOS
        //private Funcionario NovoFuncionario()
        //{
        //    var funcionario = new Funcionario("Alexandre Rech", "rech", "i?4I{'EY", System.DateTime.Today, 3000, false, true);

        //    return funcionario;
        //}

        //private List<Funcionario> NovosFuncionarios()
        //{
        //    var f1 = new Funcionario("Matheus de Medeiros", "matheus", "i?4I{'PY", System.DateTime.Today, 3000, false, true);
        //    var f2 = new Funcionario("João Gabriel Santos", "joaogabriel", "i?8563Y4", System.DateTime.Today, 3000, false, true);
        //    var f3 = new Funcionario("Camila Candido", "camilavcandido", "85`$vxvb", System.DateTime.Today, 3000, false, true);

        //    var lista = new List<Funcionario>();
        //    lista.Add(f1);
        //    lista.Add(f2);
        //    lista.Add(f3);

        //    return lista;

        //}

        //#endregion
    }
}
