using Locadora_Veiculos.Dominio.ModuloCliente;
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
                TipoCliente.PessoaFisica, "013.987.765-09", 2,
                "Rua das laranjeiras", "centro", "São Paulo", "SP");

            Cliente c2 = new Cliente(null, "(49) 9 8888-9999", "joao@gmail.com",
                TipoCliente.PessoaFisica, "013.987.765-09", 2,
                "Rua das laranjeiras", "centro", "São Paulo", "SP");

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
                TipoCliente.PessoaFisica, "013.987.765-09",  2,
                "Rua das laranjeiras", "centro", "São Paulo", "SP");

            Cliente c2 = new Cliente("Jo", "(49) 9 8888-9999", "joao@gmail.com",
                TipoCliente.PessoaFisica, "013.987.765-09",  2,
                 "Rua das laranjeiras", "centro", "São Paulo", "SP");

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
                TipoCliente.PessoaFisica, "013.987.765-09",  2,
                "Rua das laranjeiras", "centro", "São Paulo", "SP");

            Cliente c2 = new Cliente("João da Silva", null, "joao@gmail.com",
                TipoCliente.PessoaFisica, "013.987.765-09",  2,
                "Rua das laranjeiras", "centro", "São Paulo", "SP");

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
                TipoCliente.PessoaFisica, "013.987.765-09",  2,
                "Rua das laranjeiras", "centro", "São Paulo", "SP");

            Cliente c2 = new Cliente("João da Silva", null, "joao@gmail.com",
                TipoCliente.PessoaFisica, "013.987.765-09",  2,
                "Rua das laranjeiras", "centro", "São Paulo", "SP");

            var validador = new ValidadorCliente();

            var resultado1 = validador.Validate(c1);
            var resultado2 = validador.Validate(c2);

            Assert.AreEqual(0, resultado1.Errors.Count);
            //Assert.AreEqual("O campo 'Telefone' é obrigatório!", resultado2.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Email_Do_Cliente_Deve_ser_Obrigatorio()
        {
            Cliente c1 = new Cliente("João da Silva", "(49) 98888-9999", "",
                TipoCliente.PessoaFisica, "013.987.765-09",  2,
                "Rua das laranjeiras", "centro", "São Paulo", "SP");

            Cliente c2 = new Cliente("João da Silva", "(49) 98888-9999", null,
                TipoCliente.PessoaFisica, "013.987.765-09",  2,
                "Rua das laranjeiras", "centro", "São Paulo", "SP");

            var validador = new ValidadorCliente();

            var resultado1 = validador.Validate(c1);
            var resultado2 = validador.Validate(c2);

            Assert.AreEqual("O campo 'Email' é obrigatório!", resultado1.Errors[0].ErrorMessage);
            Assert.AreEqual("O campo 'Email' é obrigatório!", resultado2.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Rua_Do_Cliente_Deve_ser_obrigatorio()
        {
            Cliente c1 = new Cliente("João da Silva", "(49) 98888-9999", "joao@gmail.com",
                TipoCliente.PessoaFisica, "013.987.765-09",  2,
                "", "centro", "São Paulo", "SP");

            Cliente c2 = new Cliente("João da Silva", "(49) 98888-9999", "joao@gmail.com",
                TipoCliente.PessoaFisica, "013.987.765-09",  2,
                null, "centro", "São Paulo", "SP");

            var validador = new ValidadorCliente();

            var resultado1 = validador.Validate(c1);
            var resultado2 = validador.Validate(c2);

            Assert.AreEqual("O campo 'Rua' é obrigatório!", resultado1.Errors[0].ErrorMessage);
            Assert.AreEqual("O campo 'Rua' é obrigatório!", resultado2.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Rua_Do_Cliente_Deve_ter_no_minimo_cinco_caracteres()
        {
            Cliente c1 = new Cliente("João da Silva", "(49) 98888-9999", "joao@gmail.com",
                TipoCliente.PessoaFisica, "013.987.765-09",  2,
                "Rua das laranjeiras", "centro", "São Paulo", "SP");

            Cliente c2 = new Cliente("João da Silva", "(49) 98888-9999", "joao@gmail.com",
                TipoCliente.PessoaFisica, "013.987.765-09",  2,
                "R", "centro", "São Paulo", "SP");

            var validador = new ValidadorCliente();

            var resultado1 = validador.Validate(c1);
            var resultado2 = validador.Validate(c2);

            Assert.AreEqual(0, resultado1.Errors.Count);
            Assert.AreEqual("O campo 'Rua' deve ter no mínimo 5 (cinco) caracteres!", resultado2.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Bairro_Do_Cliente_Deve_ser_obrigatorio()
        {
            Cliente c1 = new Cliente("João da Silva", "(49) 98888-9999", "joao@gmail.com",
                TipoCliente.PessoaFisica, "013.987.765-09",  2,
                "Rua das laranjeiras", "", "São Paulo", "SP");

            Cliente c2 = new Cliente("João da Silva", "(49) 98888-9999", "joao@gmail.com",
                TipoCliente.PessoaFisica, "013.987.765-09",  2,
                "Rua das laranjeiras", null, "São Paulo", "SP");

            var validador = new ValidadorCliente();

            var resultado1 = validador.Validate(c1);
            var resultado2 = validador.Validate(c2);

            Assert.AreEqual("O campo 'Bairro' é obrigatório!", resultado1.Errors[0].ErrorMessage);
            Assert.AreEqual("O campo 'Bairro' é obrigatório!", resultado2.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Bairro_Do_Cliente_Deve_ter_no_minimo_cinco_caracteres()
        {
            Cliente c1 = new Cliente("João da Silva", "(49) 98888-9999", "joao@gmail.com",
                TipoCliente.PessoaFisica, "013.987.765-09",  2,
                "Rua das laranjeiras", "centro", "São Paulo", "SP");

            Cliente c2 = new Cliente("João da Silva", "(49) 98888-9999", "joao@gmail.com",
                TipoCliente.PessoaFisica, "013.987.765-09",  2,
                "Rua das laranjeiras", "ce", "São Paulo", "SP");

            var validador = new ValidadorCliente();

            var resultado1 = validador.Validate(c1);
            var resultado2 = validador.Validate(c2);

            Assert.AreEqual(0, resultado1.Errors.Count);
            Assert.AreEqual("O campo 'Bairro' deve ter no mínimo 5 (cinco) caracteres!", resultado2.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Cidade_Do_Cliente_Deve_ser_obrigatorio()
        {
            Cliente c1 = new Cliente("João da Silva", "(49) 98888-9999", "joao@gmail.com",
                TipoCliente.PessoaFisica, "013.987.765-09",  2,
                "Rua das laranjeiras", "centro", "", "SP");

            Cliente c2 = new Cliente("João da Silva", "(49) 98888-9999", "joao@gmail.com",
                TipoCliente.PessoaFisica, "013.987.765-09",  2,
                "Rua das laranjeiras", "centro", null, "SP");

            var validador = new ValidadorCliente();

            var resultado1 = validador.Validate(c1);
            var resultado2 = validador.Validate(c2);

            Assert.AreEqual("O campo 'Cidade' é obrigatório!", resultado1.Errors[0].ErrorMessage);
            Assert.AreEqual("O campo 'Cidade' é obrigatório!", resultado2.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Cidade_Do_Cliente_Deve_ter_no_minimo_cinco_caracteres()
        {
            Cliente c1 = new Cliente("João da Silva", "(49) 98888-9999", "joao@gmail.com",
                TipoCliente.PessoaFisica, "013.987.765-09",  2,
                "Rua das laranjeiras", "centro", "São Paulo", "SP");

            Cliente c2 = new Cliente("João da Silva", "(49) 98888-9999", "joao@gmail.com",
                TipoCliente.PessoaFisica, "013.987.765-09",  2,
                "Rua das laranjeiras", "centro", "São", "SP");

            var validador = new ValidadorCliente();

            var resultado1 = validador.Validate(c1);
            var resultado2 = validador.Validate(c2);

            Assert.AreEqual(0, resultado1.Errors.Count);
            Assert.AreEqual("O campo 'Cidade' deve ter no mínimo 5 (cinco) caracteres!", resultado2.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Estado_Do_Cliente_Deve_ser_obrigatorio()
        {
            Cliente c1 = new Cliente("João da Silva", "(49) 98888-9999", "joao@gmail.com",
                TipoCliente.PessoaFisica, "013.987.765-09",  2,
                "Rua das laranjeiras", "centro", "São Paulo", "");

            Cliente c2 = new Cliente("João da Silva", "(49) 98888-9999", "joao@gmail.com",
                TipoCliente.PessoaFisica, "013.987.765-09",  2,
                "Rua das laranjeiras", "centro", "São Paulo", null);

            var validador = new ValidadorCliente();

            var resultado1 = validador.Validate(c1);
            var resultado2 = validador.Validate(c2);

            Assert.AreEqual("O campo 'Estado' é obrigatório!", resultado1.Errors[0].ErrorMessage);
            Assert.AreEqual("O campo 'Estado' é obrigatório!", resultado2.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Estado_Do_Cliente_Deve_ter_somente_dois_caracteres()
        {
            Cliente c1 = new Cliente("João da Silva", "(49) 98888-9999", "joao@gmail.com",
                TipoCliente.PessoaFisica, "013.987.765-09",  2,
                "Rua das laranjeiras", "centro", "São Paulo", "SP");

            Cliente c2 = new Cliente("João da Silva", "(49) 98888-9999", "joao@gmail.com",
                TipoCliente.PessoaFisica, "013.987.765-09",  2,
                "Rua das laranjeiras", "centro", "São Paulo", "SPC");

            Cliente c3 = new Cliente("João da Silva", "(49) 98888-9999", "joao@gmail.com",
                TipoCliente.PessoaFisica, "013.987.765-09",  2,
                "Rua das laranjeiras", "centro", "São Paulo", "SPC");

            var validador = new ValidadorCliente();

            var resultado1 = validador.Validate(c1);
            var resultado2 = validador.Validate(c2);
            var resultado3 = validador.Validate(c3);

            Assert.AreEqual(0, resultado1.Errors.Count);
            Assert.AreEqual("O campo 'Estado' deve ter somente 2 caracteres!", resultado2.Errors[0].ErrorMessage);
            Assert.AreEqual("O campo 'Estado' deve ter somente 2 caracteres!", resultado3.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Documento_Do_Cliente_Pessoa_Fisica_Deve_ser_Obrigatorio()
        {
            Cliente c1 = new Cliente("João da Silva", "(49) 98888-9999", "joao@gmail.com",
                TipoCliente.PessoaFisica, "",  2,
                "Rua das laranjeiras", "centro", "São Paulo", "SP");

            Cliente c2 = new Cliente("João da Silva", "(49) 98888-9999", "joao@gmail.com",
                TipoCliente.PessoaFisica, null,  2,
                "Rua das laranjeiras", "centro", "São Paulo", "SP");

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
                TipoCliente.PessoaFisica, "0987",  2,
                "Rua das laranjeiras", "centro", "São Paulo", "SP");

            Cliente c2 = new Cliente("João da Silva", "(49) 98888-9999", "joao@gmail.com",
                TipoCliente.PessoaFisica, "gdfgsdf",  2,
                "Rua das laranjeiras", "centro", "São Paulo", "SP");

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
                TipoCliente.PessoaJuridica, null,  2,
                "Rua das laranjeiras", "centro", "São Paulo", "SP");

            Cliente c2 = new Cliente("João da Silva", "(49) 98888-9999", "joao@gmail.com",
                TipoCliente.PessoaJuridica, null,  2,
                "Rua das laranjeiras", "centro", "São Paulo", "SP");

            Cliente c3 = new Cliente("João da Silva", "(49) 98888-9999", "joao@gmail.com",
                TipoCliente.PessoaJuridica, "99.789.457/0001-88",  2,
                "Rua das laranjeiras", "centro", "São Paulo", "SP");

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
               TipoCliente.PessoaJuridica, "cc.jjj.nnn/oooi-pp",  2,
               "Rua das laranjeiras", "centro", "São Paulo", "SP");

            Cliente c2 = new Cliente("João da Silva", "(49) 98888-9999", "joao@gmail.com",
                TipoCliente.PessoaJuridica, "09.345",  2,
                "Rua das laranjeiras", "centro", "São Paulo", "SP");

            Cliente c3 = new Cliente("João da Silva", "(49) 98888-9999", "joao@gmail.com",
                TipoCliente.PessoaJuridica, "99.789.457/0001-88",  2,
                "Rua das laranjeiras", "centro", "São Paulo", "SP");

            var validador = new ValidadorCliente();

            var resultado1 = validador.Validate(c1);
            var resultado2 = validador.Validate(c2);
            var resultado3 = validador.Validate(c3);

            Assert.AreEqual("O campo 'CNPJ' deve ser válido!", resultado1.Errors[0].ErrorMessage);
            Assert.AreEqual("O campo 'CNPJ' deve ser válido!", resultado2.Errors[0].ErrorMessage);
            Assert.AreEqual(0, resultado3.Errors.Count);
        }
    }
}