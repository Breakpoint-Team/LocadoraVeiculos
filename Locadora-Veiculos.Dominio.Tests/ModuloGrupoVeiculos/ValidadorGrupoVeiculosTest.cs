using Locadora_Veiculos.Dominio.ModuloGrupoVeiculos;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Locadora_Veiculos.Dominio.Tests.ModuloGrupoVeiculos
{
    [TestClass]
    public class ValidadorGrupoVeiculosTest
    {
        [TestMethod]
        public void Nome_deve_ser_obrigatorio()
        {
            //arrange
            var grupoVeiculos = new GrupoVeiculos();
            grupoVeiculos.Nome = null;

            ValidadorGrupoVeiculos validador = new();

            //action
            var resultado = validador.Validate(grupoVeiculos);

            //assert
            Assert.AreEqual("O campo 'Nome' é obrigatório!", resultado.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Nome_nao_deve_ter_caracteres_especiais_e_numeros()
        {
            //arrange
            var grupoVeiculos = new GrupoVeiculos();
            grupoVeiculos.Nome = "Ub3r#@";

            ValidadorGrupoVeiculos validador = new();

            //action
            var resultado = validador.Validate(grupoVeiculos);

            //assert
            Assert.AreEqual("O campo 'Nome' não aceita caracteres especiais e números!", resultado.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Nome_de_ter_no_minimo_dois_caracteres()
        {
            //arrange
            var grupoVeiculos = new GrupoVeiculos();
            grupoVeiculos.Nome = "A";

            ValidadorGrupoVeiculos validador = new();

            //action
            var resultado = validador.Validate(grupoVeiculos);

            //assert
            Assert.AreEqual("O campo 'Nome' deve ter no mínimo 2 caracteres!", resultado.Errors[0].ErrorMessage);
        }
    }
}