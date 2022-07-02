using Locadora_Veiculos.Dominio.ModuloVeiculo;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Locadora_Veiculos.Dominio.Tests.ModuloVeiculo
{
    [TestClass]
    public class ValidadorVeiculoTest 
    {
        #region MODELO
        [TestMethod]
        public void Modelo_deve_ser_obrigatorio()
        {
            //arrange
            var veiculo = new Veiculo();
            veiculo.Modelo = null;

            ValidadorVeiculo validador = new();

            //action
            var resultado = validador.Validate(veiculo);

            //assert
            Assert.AreEqual("O campo 'Modelo' é obrigatório!", resultado.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Modelo_deve_ter_no_minimo_tres_caracteres()
        {
            //arrange
            var veiculo = new Veiculo();
            veiculo.Modelo = "AA";

            ValidadorVeiculo validador = new();

            //action
            var resultado = validador.Validate(veiculo);

            //assert
            Assert.AreEqual("O campo 'Modelo' deve ter no mínimo 3 (três) caracteres!", resultado.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Modelo_nao_deve_ter_caracteres_especiais()
        {
            //arrange
            var veiculo = new Veiculo();
            veiculo.Modelo = "AAA$";

            ValidadorVeiculo validador = new();

            //action
            var resultado = validador.Validate(veiculo);

            //assert
            Assert.AreEqual("Caracteres especiais não são permitidos!", resultado.Errors[0].ErrorMessage);
        }

        #endregion

        #region MARCA
        [TestMethod]
        public void Marca_deve_ser_obrigatorio()
        {
            //arrange
            var veiculo = new Veiculo();
            veiculo.Modelo = "Tracker 2023";
            veiculo.Marca = null;

            ValidadorVeiculo validador = new();

            //action
            var resultado = validador.Validate(veiculo);

            //assert
            Assert.AreEqual("O campo 'Marca' é obrigatório!", resultado.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Marca_deve_ter_no_minimo_tres_caracteres()
        {
            //arrange
            var veiculo = new Veiculo();
            veiculo.Modelo = "Tracker 2023";
            veiculo.Marca = "AA";

            ValidadorVeiculo validador = new();

            //action
            var resultado = validador.Validate(veiculo);

            //assert
            Assert.AreEqual("O campo 'Marca' deve ter no mínimo 3 (três) caracteres!", resultado.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Marca_nao_deve_ter_caracteres_especiais()
        {
            //arrange
            var veiculo = new Veiculo();
            veiculo.Modelo = "Tracker 2023";
            veiculo.Marca = "1$23";

            ValidadorVeiculo validador = new();

            //action
            var resultado = validador.Validate(veiculo);

            //assert
            Assert.AreEqual("Caracteres especiais não são permitidos!", resultado.Errors[0].ErrorMessage);
        }

        #endregion

        #region ANO

        [TestMethod]
        public void Ano_deve_ser_obrigatorio()
        {
            //arrange
            var veiculo = new Veiculo();
            veiculo.Modelo = "Tracker 2022";
            veiculo.Marca = "Chevrolet";
            veiculo.Ano = 0;

            ValidadorVeiculo validador = new();

            //action
            var resultado = validador.Validate(veiculo);

            //assert
            Assert.AreEqual("O campo 'Ano' é obrigatório!", resultado.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Ano_deve_ser_maior_que_1919()
        {
            //arrange
            var veiculo = new Veiculo();
            veiculo.Modelo = "Tracker 2023";
            veiculo.Marca = "Chevrolet";
            veiculo.Ano = 1919;

            ValidadorVeiculo validador = new();

            //action
            var resultado = validador.Validate(veiculo);

            //assert
            Assert.AreEqual("O 'Ano' deve ser maior que 1919!", resultado.Errors[0].ErrorMessage);
        }

        #endregion

        #region COR
        [TestMethod]
        public void Cor_deve_ser_obrigatorio()
        {
            //arrange
            var veiculo = new Veiculo();
            veiculo.Modelo = "Tracker 2022";
            veiculo.Marca = "Chevrolet";
            veiculo.Ano = 2022;
            veiculo.Cor = null;

            ValidadorVeiculo validador = new();

            //action
            var resultado = validador.Validate(veiculo);

            //assert
            Assert.AreEqual("O campo 'Cor' é obrigatório!", resultado.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Cor_deve_ter_no_minimo_tres_caracteres()
        {
            //arrange
            var veiculo = new Veiculo();
            veiculo.Modelo = "Tracker 2022";
            veiculo.Marca = "Chevrolet";
            veiculo.Ano = 2022;
            veiculo.Cor = "aa";

            ValidadorVeiculo validador = new();

            //action
            var resultado = validador.Validate(veiculo);

            //assert
            Assert.AreEqual("O campo 'Cor' deve ter no mínimo 3 (três) caracteres!", resultado.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Cor_nao_deve_ter_caracteres_especiais()
        {
            //arrange
            var veiculo = new Veiculo();
            veiculo.Modelo = "Tracker 2022";
            veiculo.Marca = "Chevrolet";
            veiculo.Ano = 2022;
            veiculo.Cor = "aa%$1";

            ValidadorVeiculo validador = new();

            //action
            var resultado = validador.Validate(veiculo);

            //assert
            Assert.AreEqual("Caracteres especiais não são permitidos!", resultado.Errors[0].ErrorMessage);
        }

        #endregion

        #region PLACA
        [TestMethod]
        public void Placa_deve_ser_obrigatorio()
        {
            //arrange
            var veiculo = new Veiculo();
            veiculo.Modelo = "Tracker 2022";
            veiculo.Marca = "Chevrolet";
            veiculo.Ano = 2022;
            veiculo.Cor = "Cinza";
            veiculo.Placa = null;

            ValidadorVeiculo validador = new();

            //action
            var resultado = validador.Validate(veiculo);

            //assert
            Assert.AreEqual("O campo 'Placa' é obrigatório!", resultado.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Placa_deve_ter_sete_caracteres()
        {
            //arrange
            var veiculo = new Veiculo();
            veiculo.Modelo = "Tracker 2022";
            veiculo.Marca = "Chevrolet";
            veiculo.Ano = 2022;
            veiculo.Cor = "Cinza";
            veiculo.Placa = "A";

            ValidadorVeiculo validador = new();

            //action
            var resultado = validador.Validate(veiculo);

            //assert
            Assert.AreEqual("O campo 'Placa' deve ter 7 (sete) caracteres!", resultado.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Placa_nao_deve_ter_caracteres_especiais()
        {
            //arrange
            var veiculo = new Veiculo();
            veiculo.Modelo = "Tracker 2022";
            veiculo.Marca = "Chevrolet";
            veiculo.Ano = 2022;
            veiculo.Cor = "Cinza";
            veiculo.Placa = "ABCD1@7";

            ValidadorVeiculo validador = new();

            //action
            var resultado = validador.Validate(veiculo);

            //assert
            Assert.AreEqual("Caracteres especiais não são permitidos!", resultado.Errors[0].ErrorMessage);
        }


        #endregion

        #region QUILOMETRAGEM_PERCORRIDA

        [TestMethod]
        public void Quilometragem_percorrida__deve_ser_obrigatorio()
        {
            //arrange
            var veiculo = new Veiculo();
            veiculo.Modelo = "Tracker 2022";
            veiculo.Marca = "Chevrolet";
            veiculo.Ano = 2022;
            veiculo.Cor = "Cinza";
            veiculo.Placa = "ABCD597";
            veiculo.QuilometragemPercorrida = 0;

            ValidadorVeiculo validador = new();

            //action
            var resultado = validador.Validate(veiculo);

            //assert
            Assert.AreEqual("O campo 'Quilometragem Percorrida' é obrigatório!", resultado.Errors[0].ErrorMessage);
        }

        #endregion

        #region CAPACIDADE_TANQUE
        [TestMethod]
        public void Capacidade_do_tanque_deve_ser_obrigatorio()
        {
            //arrange
            var veiculo = new Veiculo();
            veiculo.Modelo = "Tracker 2022";
            veiculo.Marca = "Chevrolet";
            veiculo.Ano = 2022;
            veiculo.Cor = "Cinza";
            veiculo.Placa = "ABCD597";
            veiculo.QuilometragemPercorrida = 200;
            veiculo.CapacidadeTanque = 0;
            veiculo.CapacidadeTanque = 0;
            veiculo.TipoCombustivel = "Gasolina";

            ValidadorVeiculo validador = new();

            //action
            var resultado = validador.Validate(veiculo);

            //assert
            Assert.AreEqual("O campo 'Capacidade do Tanque' é obrigatório!", resultado.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Capacidade_do_tanque_deve_ser_no_minimo_dez()
        {
            //arrange
            var veiculo = new Veiculo();
            veiculo.Modelo = "Tracker 2022";
            veiculo.Marca = "Chevrolet";
            veiculo.Ano = 2022;
            veiculo.Cor = "Cinza";
            veiculo.Placa = "ABCD597";
            veiculo.QuilometragemPercorrida = 200;
            veiculo.TipoCombustivel = "Gasolina";
            veiculo.CapacidadeTanque = 9;

            ValidadorVeiculo validador = new();

            //action
            var resultado = validador.Validate(veiculo);

            //assert
            Assert.AreEqual("A 'Capacidade do Tanque' deve ser no mínimo 10!", resultado.Errors[0].ErrorMessage);
        }

        #endregion

        #region GRUPO_VEICULOS
        [TestMethod]
        public void Grupo_de_veiculos_deve_ser_obrigatorio()
        {
            //arrange
            var veiculo = new Veiculo();
            veiculo.Modelo = "Tracker 2022";
            veiculo.Marca = "Chevrolet";
            veiculo.Ano = 2022;
            veiculo.Cor = "Cinza";
            veiculo.Placa = "ABCD597";
            veiculo.QuilometragemPercorrida = 200;
            veiculo.CapacidadeTanque = 13;
            veiculo.GrupoVeiculos = null;
            veiculo.TipoCombustivel = "Gasolina";

            ValidadorVeiculo validador = new();

            //action
            var resultado = validador.Validate(veiculo);

            //assert
            Assert.AreEqual("O campo 'Grupo de Veículos' é obrigatório!", resultado.Errors[0].ErrorMessage);
        }
        #endregion
    }
}
