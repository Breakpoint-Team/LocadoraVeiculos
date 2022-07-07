using Locadora_Veiculos.Dominio.ModuloFuncionario;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

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
        public void Nome_nao_deve_ter_caracteres_especiais_e_numeros()
        {
            //arrange
            var funcionario = new Funcionario();
            funcionario.Nome = "R&ch#@";

            ValidadorFuncionario validador = new();

            //action
            var resultado = validador.Validate(funcionario);

            //assert
            Assert.AreEqual("O campo 'Nome' não aceita caracteres especiais e números!", resultado.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Nome_deve_ter_no_minimo_dois_caracteres()
        {
            //arrange
            var funcionario = new Funcionario();
            funcionario.Nome = "A";

            ValidadorFuncionario validador = new();

            //action
            var resultado = validador.Validate(funcionario);

            //assert
            Assert.AreEqual("O campo 'Nome' deve ter no mínimo 2 (dois) caracteres!", resultado.Errors[0].ErrorMessage);
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
        public void Login_deve_ter_no_minino_quatro_caracteres()
        {
            //arrange
            var funcionario = new Funcionario();
            funcionario.Nome = "Alexandre Rech";
            funcionario.Login = "AAA";

            ValidadorFuncionario validador = new();

            //action
            var resultado = validador.Validate(funcionario);

            //assert
            Assert.AreEqual("O campo 'Login' deve ter no mínimo 4 (quatro) caracteres!", resultado.Errors[0].ErrorMessage);
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
            funcionario.DataAdmissao = new DateTime(2019, 2, 5);
            funcionario.Salario = 0;

            ValidadorFuncionario validador = new();

            //action
            var resultado = validador.Validate(funcionario);

            //assert
            Assert.AreEqual("O campo 'Salário' é obrigatório!", resultado.Errors[0].ErrorMessage);
        }

    }
}
