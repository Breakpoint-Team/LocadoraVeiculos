using Locadora_Veiculos.Dominio.ModuloCliente;
using Locadora_Veiculos.Dominio.ModuloEndereco;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Locadora_Veiculos.Dominio.Tests.ModuloCliente
{
    [TestClass]
    public class ValidadorClienteTest
    {
        [TestMethod]
        public void Nome_Do_Cliente_Deve_ser_Obrigatorio()
        {
            Cliente c1 = new Cliente("", "(49) 9 8888-9999", "joao@gmail.com",
                TipoCliente.PessoaFisica, "013.987.765-09", GetEndereco());

            Cliente c2 = new Cliente(null, "(49) 9 8888-9999", "joao@gmail.com",
                TipoCliente.PessoaFisica, "013.987.765-09", GetEndereco());

            var validador = new ValidadorCliente();

            var resultado1 = validador.Validate(c1);
            var resultado2 = validador.Validate(c2);

            Assert.AreEqual("O campo 'Nome' é obrigatório!", resultado1.Errors[0].ErrorMessage);
            Assert.AreEqual("O campo 'Nome' é obrigatório!", resultado2.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Nome_Do_Cliente_Deve_ter_no_minimo_tres_caracteres()
        {
            Cliente c1 = new Cliente("João da Silva", "(49) 98888-9999", "joao@gmail.com",
                TipoCliente.PessoaFisica, "013.987.765-09", GetEndereco());

            Cliente c2 = new Cliente("Jo", "(49) 9 8888-9999", "joao@gmail.com",
                TipoCliente.PessoaFisica, "013.987.765-09", GetEndereco());

            var validador = new ValidadorCliente();

            var resultado1 = validador.Validate(c1);
            var resultado2 = validador.Validate(c2);

            Assert.AreEqual(0, resultado1.Errors.Count);
            Assert.AreEqual("O campo 'Nome' deve ter no mínimo 3 (três) caracteres!", resultado2.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Telefone_Do_Cliente_Deve_ser_Obrigatorio()
        {
            Cliente c1 = new Cliente("João da Silva", "", "joao@gmail.com",
                TipoCliente.PessoaFisica, "013.987.765-09", GetEndereco());

            Cliente c2 = new Cliente("João da Silva", null, "joao@gmail.com",
                TipoCliente.PessoaFisica, "013.987.765-09", GetEndereco());

            var validador = new ValidadorCliente();

            var resultado1 = validador.Validate(c1);
            var resultado2 = validador.Validate(c2);

            Assert.AreEqual("O campo 'Telefone' é obrigatório!", resultado1.Errors[0].ErrorMessage);
            Assert.AreEqual("O campo 'Telefone' é obrigatório!", resultado2.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Telefone_Do_Cliente_Deve_ser_Valido()
        {
            Cliente c1 = new Cliente("João da Silva", "(49) 98888-9999", "joao@gmail.com",
                TipoCliente.PessoaFisica, "013.987.765-09", GetEndereco());

            Cliente c2 = new Cliente("João da Silva", "897", "joao@gmail.com",
                TipoCliente.PessoaFisica, "013.987.765-09", GetEndereco());

            var validador = new ValidadorCliente();

            var resultado1 = validador.Validate(c1);
            var resultado2 = validador.Validate(c2);

            Assert.AreEqual(0, resultado1.Errors.Count);
            Assert.AreEqual("O campo 'Telefone' deve ser válido!", resultado2.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Email_Do_Cliente_Deve_ser_Obrigatorio()
        {
            Cliente c1 = new Cliente("João da Silva", "(49) 98888-9999", "",
                TipoCliente.PessoaFisica, "013.987.765-09", GetEndereco());

            Cliente c2 = new Cliente("João da Silva", "(49) 98888-9999", null,
                TipoCliente.PessoaFisica, "013.987.765-09", GetEndereco());

            var validador = new ValidadorCliente();

            var resultado1 = validador.Validate(c1);
            var resultado2 = validador.Validate(c2);

            Assert.AreEqual("O campo 'Email' é obrigatório!", resultado1.Errors[0].ErrorMessage);
            Assert.AreEqual("O campo 'Email' é obrigatório!", resultado2.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Documento_Do_Cliente_Pessoa_Fisica_Deve_ser_Obrigatorio()
        {
            Cliente c1 = new Cliente("João da Silva", "(49) 98888-9999", "joao@gmail.com",
                TipoCliente.PessoaFisica, "", GetEndereco());

            Cliente c2 = new Cliente("João da Silva", "(49) 98888-9999", "joao@gmail.com",
                TipoCliente.PessoaFisica, null, GetEndereco());

            var validador = new ValidadorCliente();

            var resultado1 = validador.Validate(c1);
            var resultado2 = validador.Validate(c2);

            Assert.AreEqual("O campo 'CPF' é obrigatório!", resultado1.Errors[0].ErrorMessage);
            Assert.AreEqual("O campo 'CPF' é obrigatório!", resultado2.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Documento_Do_Cliente_Pessoa_Fisica_Deve_ser_Valido()
        {
            Cliente c1 = new Cliente("João da Silva", "(49) 98888-9999", "joao@gmail.com",
                TipoCliente.PessoaFisica, "0987", GetEndereco());

            Cliente c2 = new Cliente("João da Silva", "(49) 98888-9999", "joao@gmail.com",
                TipoCliente.PessoaFisica, "gdfgsdf", GetEndereco());

            var validador = new ValidadorCliente();

            var resultado1 = validador.Validate(c1);
            var resultado2 = validador.Validate(c2);

            Assert.AreEqual("O campo 'CPF' deve ser válido!", resultado1.Errors[0].ErrorMessage);
            Assert.AreEqual("O campo 'CPF' deve ser válido!", resultado2.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Documento_Do_Cliente_Pessoa_Juridica_Deve_ser_Obrigatorio()
        {
            Cliente c1 = new Cliente("João da Silva", "(49) 98888-9999", "joao@gmail.com",
                TipoCliente.PessoaJuridica, null, GetEndereco());

            Cliente c2 = new Cliente("João da Silva", "(49) 98888-9999", "joao@gmail.com",
                TipoCliente.PessoaJuridica, null, GetEndereco());

            Cliente c3 = new Cliente("João da Silva", "(49) 98888-9999", "joao@gmail.com",
                TipoCliente.PessoaJuridica, "99.789.457/0001-88", GetEndereco());

            var validador = new ValidadorCliente();

            var resultado1 = validador.Validate(c1);
            var resultado2 = validador.Validate(c2);
            var resultado3 = validador.Validate(c3);

            Assert.AreEqual("O campo 'CNPJ' é obrigatório!", resultado1.Errors[0].ErrorMessage);
            Assert.AreEqual("O campo 'CNPJ' é obrigatório!", resultado2.Errors[0].ErrorMessage);
            Assert.AreEqual(0, resultado3.Errors.Count);
        }

        [TestMethod]
        public void Documento_Do_Cliente_Pessoa_junridica_Deve_ser_Valido()
        {
            Cliente c1 = new Cliente("João da Silva", "(49) 98888-9999", "joao@gmail.com",
               TipoCliente.PessoaJuridica, "cc.jjj.nnn/oooi-pp", GetEndereco());

            Cliente c2 = new Cliente("João da Silva", "(49) 98888-9999", "joao@gmail.com",
                TipoCliente.PessoaJuridica, "09.345", GetEndereco());

            Cliente c3 = new Cliente("João da Silva", "(49) 98888-9999", "joao@gmail.com",
                TipoCliente.PessoaJuridica, "99.789.457/0001-88", GetEndereco());

            var validador = new ValidadorCliente();

            var resultado1 = validador.Validate(c1);
            var resultado2 = validador.Validate(c2);
            var resultado3 = validador.Validate(c3);

            Assert.AreEqual("O campo 'CNPJ' deve ser válido!", resultado1.Errors[0].ErrorMessage);
            Assert.AreEqual("O campo 'CNPJ' deve ser válido!", resultado2.Errors[0].ErrorMessage);
            Assert.AreEqual(0, resultado3.Errors.Count);
        }

        private Endereco GetEndereco()
        {
            return new Endereco("SP", "São Paulo", "centro", "Rua das laranjeiras", 2);
        }
    }
}