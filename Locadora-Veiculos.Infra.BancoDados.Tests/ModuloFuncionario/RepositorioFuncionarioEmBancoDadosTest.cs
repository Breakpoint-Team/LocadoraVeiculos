using Locadora_Veiculos.Dominio.ModuloFuncionario;
using Locadora_Veiculos.Infra.BancoDados.Compartilhado;
using Locadora_Veiculos.Infra.BancoDados.ModuloFuncionario;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

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



        #region METODOS PRIVADOS
        private Funcionario NovoFuncionario()
        {
            var funcionario = new Funcionario("Alexandre Rech", "rech", "i?4I{'EY", System.DateTime.Today, 3000, false, true);

            return funcionario;
        }
        #endregion
    }
}
