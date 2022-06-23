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

       
    }
}
