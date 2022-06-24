using Locadora_Veiculos.Dominio.ModuloTaxa;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void Descricao_nao_deve_ter_caracteres_especiais()
        {
            //arrange
            var taxa = new Taxa();
            taxa.Descricao = "C@D&IRA DE BEBE";

            ValidadorTaxa validador = new();

            //action
            var resultado = validador.Validate(taxa);

            //assert
            Assert.AreEqual("Caracteres especiais não são permitidos!", resultado.Errors[0].ErrorMessage);
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

        //[TestMethod]
        //public void Tipo_de_calculo_deve_ser_obrigatorio()
        //{
        //    //arrange
        //    var taxa = new Taxa();
        //    taxa.Descricao = "Lavação do veículo";
        //    taxa.Valor = 100;
        //    taxa.TipoCalculo = null;

        //    ValidadorTaxa validador = new();

        //    //action
        //    var resultado = validador.Validate(taxa);

        //    //assert
        //    Assert.AreEqual("O campo 'Tipo de Cálculo' é obrigatório!", resultado.Errors[0].ErrorMessage);

        //}


    }
}
