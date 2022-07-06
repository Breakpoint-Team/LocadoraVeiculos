using Locadora_Veiculos.Dominio.ModuloEndereco;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Locadora_Veiculos.Dominio.Tests.ModuloEndereco
{
    [TestClass]
    public class ValidadorEnderecoTest
    {
        [TestMethod]
        public void Estado_Deve_ser_obrigatorio()
        {
            Endereco e1 = new Endereco("", "São Paulo","centro","Rua das laranjeiras",2);
            Endereco e2 = new Endereco(null, "São Paulo","centro","Rua das laranjeiras",2);

            var validador = new ValidadorEndereco();

            var resultado1 = validador.Validate(e1);
            var resultado2 = validador.Validate(e2);

            Assert.AreEqual("O campo 'Estado' é obrigatório!", resultado1.Errors[0].ErrorMessage);
            Assert.AreEqual("O campo 'Estado' é obrigatório!", resultado2.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Estado_Deve_ter_somente_dois_caracteres()
        {
            Endereco e1 = new Endereco("SP", "São Paulo", "centro", "Rua das laranjeiras", 2);
            Endereco e2 = new Endereco("SPC", "São Paulo", "centro", "Rua das laranjeiras", 2);
            Endereco e3 = new Endereco("S", "São Paulo", "centro", "Rua das laranjeiras", 2);

            var validador = new ValidadorEndereco();

            var resultado1 = validador.Validate(e1);
            var resultado2 = validador.Validate(e2);
            var resultado3 = validador.Validate(e3);

            Assert.AreEqual(0, resultado1.Errors.Count);
            Assert.AreEqual("O campo 'Estado' deve ter somente 2 (dois) caracteres!", resultado2.Errors[0].ErrorMessage);
            Assert.AreEqual("O campo 'Estado' deve ter somente 2 (dois) caracteres!", resultado3.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Cidade_Deve_ser_obrigatorio()
        {
            Endereco e1 = new Endereco("SP", "", "centro", "Rua das laranjeiras", 2);
            Endereco e2 = new Endereco("SP", null, "centro", "Rua das laranjeiras", 2);

            var validador = new ValidadorEndereco();

            var resultado1 = validador.Validate(e1);
            var resultado2 = validador.Validate(e2);

            Assert.AreEqual("O campo 'Cidade' é obrigatório!", resultado1.Errors[0].ErrorMessage);
            Assert.AreEqual("O campo 'Cidade' é obrigatório!", resultado2.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Cidade_Deve_ter_no_minimo_tres_caracteres()
        {
            Endereco e1 = new Endereco("SP", "São Paulo", "centro", "Rua das laranjeiras", 2);
            Endereco e2 = new Endereco("SP", "Sã", "centro", "Rua das laranjeiras", 2);

            var validador = new ValidadorEndereco();

            var resultado1 = validador.Validate(e1);
            var resultado2 = validador.Validate(e2);

            Assert.AreEqual(0, resultado1.Errors.Count);
            Assert.AreEqual("O campo 'Cidade' deve ter no mínimo 3 (três) caracteres!", resultado2.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Bairro_Deve_ser_obrigatorio()
        {
            Endereco e1 = new Endereco("SP", "São Paulo", "", "Rua das laranjeiras", 2);
            Endereco e2 = new Endereco("SP", "São Paulo", null, "Rua das laranjeiras", 2);

            var validador = new ValidadorEndereco();

            var resultado1 = validador.Validate(e1);
            var resultado2 = validador.Validate(e2);

            Assert.AreEqual("O campo 'Bairro' é obrigatório!", resultado1.Errors[0].ErrorMessage);
            Assert.AreEqual("O campo 'Bairro' é obrigatório!", resultado2.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Bairro_Deve_ter_no_minimo_tres_caracteres()
        {
            Endereco e1 = new Endereco("SP", "São Paulo", "centro", "Rua das laranjeiras", 2);
            Endereco e2 = new Endereco("SP", "São Paulo", "ce", "Rua das laranjeiras", 2);

            var validador = new ValidadorEndereco();

            var resultado1 = validador.Validate(e1);
            var resultado2 = validador.Validate(e2);

            Assert.AreEqual(0, resultado1.Errors.Count);
            Assert.AreEqual("O campo 'Bairro' deve ter no mínimo 3 (três) caracteres!", resultado2.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Logradouro_Deve_ser_obrigatorio()
        {
            Endereco e1 = new Endereco("SP", "São Paulo", "centro", "", 2);
            Endereco e2 = new Endereco("SP", "São Paulo", "centro", null, 2);

            var validador = new ValidadorEndereco();

            var resultado1 = validador.Validate(e1);
            var resultado2 = validador.Validate(e2);

            Assert.AreEqual("O campo 'Logradouro' é obrigatório!", resultado1.Errors[0].ErrorMessage);
            Assert.AreEqual("O campo 'Logradouro' é obrigatório!", resultado2.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Logradouro_Deve_ter_no_minimo_tres_caracteres()
        {
            Endereco e1 = new Endereco("SP", "São Paulo", "centro", "Rua das laranjeiras", 2);
            Endereco e2 = new Endereco("SP", "São Paulo", "centro", "Av", 2);

            var validador = new ValidadorEndereco();

            var resultado1 = validador.Validate(e1);
            var resultado2 = validador.Validate(e2);

            Assert.AreEqual(0, resultado1.Errors.Count);
            Assert.AreEqual("O campo 'Logradouro' deve ter no mínimo 3 (três) caracteres!", resultado2.Errors[0].ErrorMessage);
        }
    }
}