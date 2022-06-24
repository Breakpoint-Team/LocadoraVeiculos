using Locadora_Veiculos.Dominio.ModuloFuncionario;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora_Veiculos.Dominio.Tests.ModuloFuncionario
{
    [TestClass]
    public class ValidadorFuncionarioTest
    {
        [TestMethod]
        public void Nome_deve_ser_obrigatorio()
        {
            //arrange
            var funcionario = new Funcionario();
            funcionario.Nome = null;

            ValidadorFuncionario validador = new();

            //action
            var resultado = validador.Validate(funcionario);

            //assert
            Assert.AreEqual("O campo 'Nome' é obrigatório!", resultado.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Nome_nao_deve_ter_caracteres_especiais()
        {
            //arrange
            var funcionario = new Funcionario();
            funcionario.Nome = "R&ch#@";

            ValidadorFuncionario validador = new();

            //action
            var resultado = validador.Validate(funcionario);

            //assert
            Assert.AreEqual("Caracteres especiais não são permitidos!", resultado.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Login_deve_ser_obrigatorio()
        {
            //arrange
            var funcionario = new Funcionario();
            funcionario.Nome = "Alexandre Rech";
            funcionario.Login = null;

            ValidadorFuncionario validador = new();

            //action
            var resultado = validador.Validate(funcionario);

            //assert
            Assert.AreEqual("O campo 'Login' é obrigatório!", resultado.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Senha_deve_ser_obrigatorio()
        {
            //arrange
            var funcionario = new Funcionario();
            funcionario.Nome = "Alexandre Rech";
            funcionario.Login = "rech";
            funcionario.Senha = null;

            ValidadorFuncionario validador = new();

            //action
            var resultado = validador.Validate(funcionario);

            //assert
            Assert.AreEqual("O campo 'Senha' é obrigatório!", resultado.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Senha_deve_ter_no_minino_oito_caracteres()
        {
            //arrange
            var funcionario = new Funcionario();
            funcionario.Nome = "Alexandre Rech";
            funcionario.Login = "rech";
            funcionario.Senha = "Dt3T&N";

            ValidadorFuncionario validador = new();

            //action
            var resultado = validador.Validate(funcionario);

            //assert
            Assert.AreEqual("'Senha' deve ter no mínimo 8 (oito) caracteres!", resultado.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Data_de_Admissao_deve_ser_obrigatorio()
        {
            //arrange
            var funcionario = new Funcionario();
            funcionario.Nome = "Alexandre Rech";
            funcionario.Login = "rech";
            funcionario.Senha = "i?4I{'EY";
            funcionario.DataAdmissao = DateTime.MinValue;

            ValidadorFuncionario validador = new();

            //action
            var resultado = validador.Validate(funcionario);

            //assert
            Assert.AreEqual("O campo 'Data de Admissão' é obrigatório!", resultado.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Salario_deve_ser_obrigatorio()
        {
            //arrange
            var funcionario = new Funcionario();
            funcionario.Nome = "Alexandre Rech";
            funcionario.Login = "rech";
            funcionario.Senha = "i?4I{'EY";
            funcionario.DataAdmissao = new DateTime(2019,2,5);
            funcionario.Salario = 0;

            ValidadorFuncionario validador = new();

            //action
            var resultado = validador.Validate(funcionario);

            //assert
            Assert.AreEqual("O campo 'Salário' é obrigatório!", resultado.Errors[0].ErrorMessage);
        }

    }
}
