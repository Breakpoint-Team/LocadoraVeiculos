using Locadora_Veiculos.Dominio.ModuloTaxa;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Locadora_Veiculos.Dominio.Tests.ModuloTaxa
{
    [TestClass]
    public class ValidadorTaxaTest
    {
        [TestMethod]
        public void Descricao_deve_ser_obrigatorio()
        {
            //arrange
            var taxa = new Taxa();
            taxa.Descricao = null;

            ValidadorTaxa validador = new();

            //action
            var resultado = validador.Validate(taxa);

            //assert
            Assert.AreEqual("O campo 'Descrição' é obrigatório!", resultado.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Descricao_nao_deve_ter_caracteres_especiais_e_numeros()
        {
            //arrange
            var taxa = new Taxa();
            taxa.Descricao = "C@D&IRA DE BEBE";

            ValidadorTaxa validador = new();

            //action
            var resultado = validador.Validate(taxa);

            //assert
            Assert.AreEqual("O campo 'Descrição' não aceita caracteres especiais e números!", resultado.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Descricao_deve_ter_no_minimo_dois_caracteres()
        {
            //arrange
            var taxa = new Taxa();
            taxa.Descricao = "A";

            ValidadorTaxa validador = new();

            //action
            var resultado = validador.Validate(taxa);

            //assert
            Assert.AreEqual("O campo 'Descrição' deve ter no mínimo 2 (dois) caracteres!", resultado.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Valor_deve_ser_obrigatorio()
        {
            //arrange
            var taxa = new Taxa();
            taxa.Descricao = "Lavação do veículo";
            taxa.Valor = 0;

            ValidadorTaxa validador = new();

            //action
            var resultado = validador.Validate(taxa);

            //assert
            Assert.AreEqual("O campo 'Valor' é obrigatório!", resultado.Errors[0].ErrorMessage);

        }


    }
}