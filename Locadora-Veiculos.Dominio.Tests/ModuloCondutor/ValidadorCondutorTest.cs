using Locadora_Veiculos.Dominio.ModuloCliente;
using Locadora_Veiculos.Dominio.ModuloCondutor;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Locadora_Veiculos.Dominio.Tests.ModuloCondutor
{
    [TestClass]
    public class ValidadorCondutorTest
    {
        [TestMethod]
        public void Nome_Do_Condutor_Deve_ser_Obrigatorio()
        {
            Cliente cliente = GetClienteFisico();

            Condutor cond1 = new Condutor("", "(49) 98888-9999", "joao@gmail.com", "013.987.765-09", "123456789",
                new DateTime(2025, 12, 28), 2, " rua das laranjeiras",
                "centro", "cidade fantasma", "SC", cliente);
            
            Condutor cond2 = new Condutor(null, "(49) 98888-9999", "joao@gmail.com", "013.987.765-09", "123456789",
                new DateTime(2025, 12, 28), 2, " rua das laranjeiras",
                "centro", "cidade fantasma", "SC", cliente);
            
            Condutor cond3 = new Condutor("João da Silva", "(49) 98888-9999", "joao@gmail.com", "013.987.765-09", "123456789",
                new DateTime(2025, 12, 28), 2, " rua das laranjeiras",
                "centro", "cidade fantasma", "SC", cliente);

            var validador = new ValidadorCondutor();

            var resultado1 = validador.Validate(cond1);
            var resultado2 = validador.Validate(cond2);
            var resultado3 = validador.Validate(cond3);

            Assert.AreEqual("O campo 'Nome' é obrigatório!", resultado1.Errors[0].ErrorMessage);
            Assert.AreEqual("O campo 'Nome' é obrigatório!", resultado2.Errors[0].ErrorMessage);
            Assert.AreEqual(0, resultado3.Errors.Count);
        }

        [TestMethod]
        public void Nome_Do_Condutor_Deve_ter_no_minimo_tres_caracteres()
        {
            Cliente cliente = GetClienteFisico();

            Condutor cond1 = new Condutor("j", "(49) 98888-9999", "joao@gmail.com", "013.987.765-09", "123456789",
                new DateTime(2025, 12, 28), 2, " rua das laranjeiras",
                "centro", "cidade fantasma", "SC", cliente);

            Condutor cond2 = new Condutor("jh", "(49) 98888-9999", "joao@gmail.com", "013.987.765-09", "123456789",
                new DateTime(2025, 12, 28), 2, " rua das laranjeiras",
                "centro", "cidade fantasma", "SC", cliente);

            Condutor cond3 = new Condutor("João da Silva", "(49) 98888-9999", "joao@gmail.com", "013.987.765-09", "123456789",
                new DateTime(2025, 12, 28), 2, " rua das laranjeiras",
                "centro", "cidade fantasma", "SC", cliente);

            var validador = new ValidadorCondutor();

            var resultado1 = validador.Validate(cond1);
            var resultado2 = validador.Validate(cond2);
            var resultado3 = validador.Validate(cond3);

            Assert.AreEqual("O campo 'Nome' deve ter no mínimo 3 (três) caracteres!", resultado1.Errors[0].ErrorMessage);
            Assert.AreEqual("O campo 'Nome' deve ter no mínimo 3 (três) caracteres!", resultado2.Errors[0].ErrorMessage);
            Assert.AreEqual(0, resultado3.Errors.Count);
        }

        [TestMethod]
        public void Telefone_Do_Condutor_Deve_ser_Obrigatorio()
        {
            Cliente cliente = GetClienteFisico();

            Condutor cond1 = new Condutor("joão", "", "joao@gmail.com", "013.987.765-09", "123456789",
                new DateTime(2025, 12, 28), 2, " rua das laranjeiras",
                "centro", "cidade fantasma", "SC", cliente);

            Condutor cond2 = new Condutor("joão", null, "joao@gmail.com", "013.987.765-09", "123456789",
                new DateTime(2025, 12, 28), 2, " rua das laranjeiras",
                "centro", "cidade fantasma", "SC", cliente);

            var validador = new ValidadorCondutor();

            var resultado1 = validador.Validate(cond1);
            var resultado2 = validador.Validate(cond2);

            Assert.AreEqual("O campo 'Telefone' é obrigatório!", resultado1.Errors[0].ErrorMessage);
            Assert.AreEqual("O campo 'Telefone' é obrigatório!", resultado2.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Telefone_Do_Condutor_Deve_ser_Valido()
        {
            Cliente cliente = GetClienteFisico();

            Condutor cond1 = new Condutor("joão", "(49) 988-99", "joao@gmail.com", "013.987.765-09", "123456789",
                new DateTime(2025, 12, 28), 2, " rua das laranjeiras",
                "centro", "cidade fantasma", "SC", cliente);
           
            var validador = new ValidadorCondutor();

            var resultado1 = validador.Validate(cond1);

            Assert.AreEqual("O campo 'Telefone' deve ser válido!", resultado1.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Email_Do_Condutor_Deve_ser_Obrigatorio()
        {
            Cliente cliente = GetClienteFisico();

            Condutor cond1 = new Condutor("João da Silva", "(49) 98888-9999", "", "013.987.765-09", "123456789",
                new DateTime(2025, 12, 28), 2, " rua das laranjeiras",
                "centro", "cidade fantasma", "SC", cliente);

            Condutor cond2 = new Condutor("João da Silva", "(49) 98888-9999", null, "013.987.765-09", "123456789",
                new DateTime(2025, 12, 28), 2, " rua das laranjeiras",
                "centro", "cidade fantasma", "SC", cliente);

            var validador = new ValidadorCondutor();

            var resultado1 = validador.Validate(cond1);
            var resultado2 = validador.Validate(cond2);

            Assert.AreEqual("O campo 'Email' é obrigatório!", resultado1.Errors[0].ErrorMessage);
            Assert.AreEqual("O campo 'Email' é obrigatório!", resultado2.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Rua_Do_Condutor_Deve_ser_obrigatorio()
        {
            Cliente cliente = GetClienteFisico();

            Condutor cond1 = new Condutor("João da Silva", "(49) 98888-9999", "joao@gmail.com", "013.987.765-09", "123456789",
                new DateTime(2025, 12, 28), 2, "",
                "centro", "cidade fantasma", "SC", cliente);

            Condutor cond2 = new Condutor("João da Silva", "(49) 98888-9999", "joao@gmail.com", "013.987.765-09", "123456789",
                new DateTime(2025, 12, 28), 2, null,
                "centro", "cidade fantasma", "SC", cliente);

            var validador = new ValidadorCondutor();

            var resultado1 = validador.Validate(cond1);
            var resultado2 = validador.Validate(cond2);

            Assert.AreEqual("O campo 'Rua' é obrigatório!", resultado1.Errors[0].ErrorMessage);
            Assert.AreEqual("O campo 'Rua' é obrigatório!", resultado2.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Rua_Do_Condutor_Deve_ter_no_minimo_cinco_caracteres()
        {
            Cliente cliente = GetClienteFisico();

            Condutor cond1 = new Condutor("João da Silva", "(49) 98888-9999", "joao@gmail.com", "013.987.765-09", "123456789",
                new DateTime(2025, 12, 28), 2, "rua das laranjeiras",
                "centro", "cidade fantasma", "SC", cliente);

            Condutor cond2 = new Condutor("João da Silva", "(49) 98888-9999", "joao@gmail.com", "013.987.765-09", "123456789",
                new DateTime(2025, 12, 28), 2, "rua ",
                "centro", "cidade fantasma", "SC", cliente);

            var validador = new ValidadorCondutor();

            var resultado1 = validador.Validate(cond1);
            var resultado2 = validador.Validate(cond2);

            Assert.AreEqual(0, resultado1.Errors.Count);
            Assert.AreEqual("O campo 'Rua' deve ter no mínimo 5 (cinco) caracteres!", resultado2.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Bairro_Do_Condutor_Deve_ser_obrigatorio()
        {
            Cliente cliente = GetClienteFisico();

            Condutor cond1 = new Condutor("João da Silva", "(49) 98888-9999", "joao@gmail.com", "013.987.765-09", "123456789",
                new DateTime(2025, 12, 28), 2, "rua das laranjeiras",
                "", "cidade fantasma", "SC", cliente);

            Condutor cond2 = new Condutor("João da Silva", "(49) 98888-9999", "joao@gmail.com", "013.987.765-09", "123456789",
                new DateTime(2025, 12, 28), 2, "rua das laranjeiras",
                null, "cidade fantasma", "SC", cliente);

            var validador = new ValidadorCondutor();

            var resultado1 = validador.Validate(cond1);
            var resultado2 = validador.Validate(cond2);

            Assert.AreEqual("O campo 'Bairro' é obrigatório!", resultado1.Errors[0].ErrorMessage);
            Assert.AreEqual("O campo 'Bairro' é obrigatório!", resultado2.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Bairro_Do_Condutor_Deve_ter_no_minimo_cinco_caracteres()
        {
            Cliente cliente = GetClienteFisico();

            Condutor cond1 = new Condutor("João da Silva", "(49) 98888-9999", "joao@gmail.com", "013.987.765-09", "123456789",
                new DateTime(2025, 12, 28), 2, "rua das laranjeiras",
                "centro", "cidade fantasma", "SC", cliente);

            Condutor cond2 = new Condutor("João da Silva", "(49) 98888-9999", "joao@gmail.com", "013.987.765-09", "123456789",
                new DateTime(2025, 12, 28), 2, "rua das laranjeiras",
                "cent", "cidade fantasma", "SC", cliente);

            var validador = new ValidadorCondutor();

            var resultado1 = validador.Validate(cond1);
            var resultado2 = validador.Validate(cond2);

            Assert.AreEqual(0, resultado1.Errors.Count);
            Assert.AreEqual("O campo 'Bairro' deve ter no mínimo 5 (cinco) caracteres!", resultado2.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Cidade_Do_Condutor_Deve_ser_obrigatorio()
        {
            Cliente cliente = GetClienteFisico();

            Condutor cond1 = new Condutor("João da Silva", "(49) 98888-9999", "joao@gmail.com", "013.987.765-09", "123456789",
                new DateTime(2025, 12, 28), 2, "rua das laranjeiras",
                "centro", "", "SC", cliente);

            Condutor cond2 = new Condutor("João da Silva", "(49) 98888-9999", "joao@gmail.com", "013.987.765-09", "123456789",
                new DateTime(2025, 12, 28), 2, "rua das laranjeiras",
                "centro", null, "SC", cliente);

            var validador = new ValidadorCondutor();

            var resultado1 = validador.Validate(cond1);
            var resultado2 = validador.Validate(cond2);

            Assert.AreEqual("O campo 'Cidade' é obrigatório!", resultado1.Errors[0].ErrorMessage);
            Assert.AreEqual("O campo 'Cidade' é obrigatório!", resultado2.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Cidade_Do_Condutor_Deve_ter_no_minimo_cinco_caracteres()
        {
            Cliente cliente = GetClienteFisico();

            Condutor cond1 = new Condutor("João da Silva", "(49) 98888-9999", "joao@gmail.com", "013.987.765-09", "123456789",
                new DateTime(2025, 12, 28), 2, "rua das laranjeiras",
                "centro", "cidade fantasma", "SC", cliente);

            Condutor cond2 = new Condutor("João da Silva", "(49) 98888-9999", "joao@gmail.com", "013.987.765-09", "123456789",
                new DateTime(2025, 12, 28), 2, "rua das laranjeiras",
                "centro", "cida", "SC", cliente);

            var validador = new ValidadorCondutor();

            var resultado1 = validador.Validate(cond1);
            var resultado2 = validador.Validate(cond2);

            Assert.AreEqual(0, resultado1.Errors.Count);
            Assert.AreEqual("O campo 'Cidade' deve ter no mínimo 5 (cinco) caracteres!", resultado2.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Estado_Do_Condutor_Deve_ser_obrigatorio()
        {
            Cliente cliente = GetClienteFisico();

            Condutor cond1 = new Condutor("João da Silva", "(49) 98888-9999", "joao@gmail.com", "013.987.765-09", "123456789",
                new DateTime(2025, 12, 28), 2, "rua das laranjeiras",
                "centro", "cidade fantasma", "", cliente);

            Condutor cond2 = new Condutor("João da Silva", "(49) 98888-9999", "joao@gmail.com", "013.987.765-09", "123456789",
                new DateTime(2025, 12, 28), 2, "rua das laranjeiras",
                "centro", "cidade fantasma", null, cliente);

            var validador = new ValidadorCondutor();

            var resultado1 = validador.Validate(cond1);
            var resultado2 = validador.Validate(cond2);

            Assert.AreEqual("O campo 'Estado' é obrigatório!", resultado1.Errors[0].ErrorMessage);
            Assert.AreEqual("O campo 'Estado' é obrigatório!", resultado2.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Estado_Do_Condutor_Deve_ter_somente_dois_caracteres()
        {
            Cliente cliente = GetClienteFisico();

            Condutor cond1 = new Condutor("João da Silva", "(49) 98888-9999", "joao@gmail.com", "013.987.765-09", "123456789",
                new DateTime(2025, 12, 28), 2, "rua das laranjeiras",
                "centro", "cidade fantasma", "SC", cliente);

            Condutor cond2 = new Condutor("João da Silva", "(49) 98888-9999", "joao@gmail.com", "013.987.765-09", "123456789",
                new DateTime(2025, 12, 28), 2, "rua das laranjeiras",
                "centro", "cidade fantasma", "S", cliente);
            
            Condutor cond3 = new Condutor("João da Silva", "(49) 98888-9999", "joao@gmail.com", "013.987.765-09", "123456789",
                new DateTime(2025, 12, 28), 2, "rua das laranjeiras",
                "centro", "cidade fantasma", "SCJ", cliente);

            var validador = new ValidadorCondutor();

            var resultado1 = validador.Validate(cond1);
            var resultado2 = validador.Validate(cond2);
            var resultado3 = validador.Validate(cond3);

            Assert.AreEqual(0, resultado1.Errors.Count);
            Assert.AreEqual("O campo 'Estado' deve ter somente 2 (dois) caracteres!", resultado2.Errors[0].ErrorMessage);
            Assert.AreEqual("O campo 'Estado' deve ter somente 2 (dois) caracteres!", resultado3.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void CPF_Do_Condutor_Deve_ser_Obrigatorio()
        {
            Cliente cliente = GetClienteJuridico();

            Condutor cond1 = new Condutor("João da Silva", "(49) 98888-9999", "joao@gmail.com", "", "123456789",
                new DateTime(2025, 12, 28), 2, "rua das laranjeiras",
                "centro", "cidade fantasma", "SC", cliente);

            Condutor cond2 = new Condutor("João da Silva", "(49) 98888-9999", "joao@gmail.com", null, "123456789",
                new DateTime(2025, 12, 28), 2, "rua das laranjeiras",
                "centro", "cidade fantasma", "SC", cliente);

            var validador = new ValidadorCondutor();

            var resultado1 = validador.Validate(cond1);
            var resultado2 = validador.Validate(cond2);

            Assert.AreEqual("O campo 'CPF' é obrigatório!", resultado1.Errors[0].ErrorMessage);
            Assert.AreEqual("O campo 'CPF' é obrigatório!", resultado2.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void CPF_Do_Condutor_Deve_ser_Valido()
        {
            Cliente cliente = GetClienteJuridico();

            Condutor cond1 = new Condutor("João da Silva", "(49) 98888-9999", "joao@gmail.com", "0987", "123456789",
                new DateTime(2025, 12, 28), 2, "rua das laranjeiras",
                "centro", "cidade fantasma", "SC", cliente);

            Condutor cond2 = new Condutor("João da Silva", "(49) 98888-9999", "joao@gmail.com", "gdfgsdf", "123456789",
                new DateTime(2025, 12, 28), 2, "rua das laranjeiras",
                "centro", "cidade fantasma", "SC", cliente);

            var validador = new ValidadorCondutor();

            var resultado1 = validador.Validate(cond1);
            var resultado2 = validador.Validate(cond2);

            Assert.AreEqual("O campo 'CPF' deve ser válido!", resultado1.Errors[0].ErrorMessage);
            Assert.AreEqual("O campo 'CPF' deve ser válido!", resultado2.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void CNH_Do_Condutor_Deve_ser_Obrigatorio()
        {
            Cliente cliente = GetClienteFisico();

            Condutor cond1 = new Condutor("João da Silva", "(49) 98888-9999", "joao@gmail.com", "013.987.765-09", "",
                new DateTime(2025, 12, 28), 2, "rua das laranjeiras",
                "centro", "cidade fantasma", "SC", cliente);

            Condutor cond2 = new Condutor("João da Silva", "(49) 98888-9999", "joao@gmail.com", "013.987.765-09", null,
                new DateTime(2025, 12, 28), 2, "rua das laranjeiras",
                "centro", "cidade fantasma", "SC", cliente);

            var validador = new ValidadorCondutor();

            var resultado1 = validador.Validate(cond1);
            var resultado2 = validador.Validate(cond2);

            Assert.AreEqual("O campo 'CNH' é obrigatório!", resultado1.Errors[0].ErrorMessage);
            Assert.AreEqual("O campo 'CNH' é obrigatório!", resultado2.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void CNH_Do_Condutor_Deve_ser_Valida()
        {
            Cliente cliente = GetClienteJuridico();

            Condutor cond1 = new Condutor("João da Silva", "(49) 98888-9999", "joao@gmail.com", "013.987.765-09", "1234",
                new DateTime(2025, 12, 28), 2, "rua das laranjeiras",
                "centro", "cidade fantasma", "SC", cliente);

            Condutor cond2 = new Condutor("João da Silva", "(49) 98888-9999", "joao@gmail.com", "013.987.765-09", "xmnjh8",
                new DateTime(2025, 12, 28), 2, "rua das laranjeiras",
                "centro", "cidade fantasma", "SC", cliente);

            var validador = new ValidadorCondutor();

            var resultado1 = validador.Validate(cond1);
            var resultado2 = validador.Validate(cond2);

            Assert.AreEqual("O campo 'CNH' deve ser válido!", resultado1.Errors[0].ErrorMessage);
            Assert.AreEqual("O campo 'CNH' deve ser válido!", resultado2.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Condutor_Deve_ter_um_cliente()
        {
            Cliente cliente = null;

            Condutor cond1 = new Condutor("João da Silva", "(49) 98888-9999", "joao@gmail.com", "013.987.765-09", "123456789",
                new DateTime(2025, 12, 28), 2, "rua das laranjeiras",
                "centro", "cidade fantasma", "SC", cliente);

            var validador = new ValidadorCondutor();

            var resultado1 = validador.Validate(cond1);

            Assert.AreEqual("O campo 'Cliente' é obrigatório!", resultado1.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Data_De_Validade_Da_CNH_Do_Condutor_Deve_ser_maior_que_a_data_atual()
        {
            Cliente cliente = GetClienteFisico();

            Condutor cond1 = new Condutor("João da Silva", "(49) 98888-9999", "joao@gmail.com", "013.987.765-09", "123456789",
                DateTime.Today, 2, "rua das laranjeiras",
                "centro", "cidade fantasma", "SC", cliente);
            
            Condutor cond2 = new Condutor("João da Silva", "(49) 98888-9999", "joao@gmail.com", "013.987.765-09", "123456789",
                new DateTime(2020, 12, 28), 2, "rua das laranjeiras",
                "centro", "cidade fantasma", "SC", cliente);
            
            Condutor cond3 = new Condutor("João da Silva", "(49) 98888-9999", "joao@gmail.com", "013.987.765-09", "123456789",
                new DateTime(2030, 12, 28), 2, "rua das laranjeiras",
                "centro", "cidade fantasma", "SC", cliente);

            var validador = new ValidadorCondutor();

            var resultado1 = validador.Validate(cond1);
            var resultado2 = validador.Validate(cond2);
            var resultado3 = validador.Validate(cond3);

            Assert.AreEqual("O campo 'Data de validade da CNH' deve ser maior que a data atual!", resultado1.Errors[0].ErrorMessage);
            Assert.AreEqual("O campo 'Data de validade da CNH' deve ser maior que a data atual!", resultado2.Errors[0].ErrorMessage);
            Assert.AreEqual(0, resultado3.Errors.Count);
        }

        private Cliente GetClienteFisico()
        {
            return new Cliente("Paulo Roberto Pereira", "(49) 98855-0076", "paulo@gmail.com",
                TipoCliente.PessoaFisica, "015.932.598-04", 2,
                "Rua do abacaxi", "centro", "São Paulo", "SP");
        }
        
        private Cliente GetClienteJuridico()
        {
            return new Cliente("Paulo Roberto Pereira", "(49) 98855-0076", "paulo@gmail.com",
                TipoCliente.PessoaJuridica, "99.789.457/0001-88", 2,
                "Rua do abacaxi", "centro", "São Paulo", "SP");
        }
    }
}