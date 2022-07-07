using Locadora_Veiculos.Dominio.ModuloGrupoVeiculos;
using Locadora_Veiculos.Dominio.ModuloPlanoCobranca;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Locadora_Veiculos.Dominio.Tests.ModuloPlanoCobranca
{
    [TestClass]
    public class ValidadorPlanoCobrancaTest
    {
        [TestMethod]
        public void Grupo_de_Veiculos_deve_ser_Obrigatorio()
        {
            PlanoCobranca p = new PlanoCobranca(100, 20, 200, 30, 50, 300, null);

            var validador = new ValidadorPlanoCobranca();

            var resultado1 = validador.Validate(p);

            Assert.AreEqual("O campo 'Grupo de Veículos' é obrigatório!", resultado1.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Valor_Por_Dia_Do_plano_diario_deve_ser_maior_que_zero()
        {
            PlanoCobranca p1 = new PlanoCobranca(-1, 20, 200, 30, 50, 300, GetGrupoVeiculos());
            PlanoCobranca p2 = new PlanoCobranca(0, 20, 200, 30, 50, 300, GetGrupoVeiculos());
            PlanoCobranca p3 = new PlanoCobranca(0.1m, 20, 200, 30, 50, 300, GetGrupoVeiculos());
            PlanoCobranca p4 = new PlanoCobranca(30, 20, 200, 30, 50, 300, GetGrupoVeiculos());

            var validador = new ValidadorPlanoCobranca();

            var resultado1 = validador.Validate(p1);
            var resultado2 = validador.Validate(p2);
            var resultado3 = validador.Validate(p3);
            var resultado4 = validador.Validate(p4);

            Assert.AreEqual("O campo 'Valor diário' do plano diário deve ser maior que 0 (zero)!", resultado1.Errors[0].ErrorMessage);
            Assert.AreEqual("O campo 'Valor diário' do plano diário deve ser maior que 0 (zero)!", resultado2.Errors[0].ErrorMessage);
            Assert.AreEqual(0, resultado3.Errors.Count);
            Assert.AreEqual(0, resultado4.Errors.Count);
        }

        [TestMethod]
        public void Valor_Por_KM_Do_plano_diario_deve_ser_maior_que_zero()
        {
            PlanoCobranca p1 = new PlanoCobranca(100, -1, 200, 30, 50, 300, GetGrupoVeiculos());
            PlanoCobranca p2 = new PlanoCobranca(100, 0, 200, 30, 50, 300, GetGrupoVeiculos());
            PlanoCobranca p3 = new PlanoCobranca(100, 0.1m, 200, 30, 50, 300, GetGrupoVeiculos());
            PlanoCobranca p4 = new PlanoCobranca(100, 20, 200, 30, 50, 300, GetGrupoVeiculos());

            var validador = new ValidadorPlanoCobranca();

            var resultado1 = validador.Validate(p1);
            var resultado2 = validador.Validate(p2);
            var resultado3 = validador.Validate(p3);
            var resultado4 = validador.Validate(p4);

            Assert.AreEqual("O campo 'Valor por KM' do plano diário deve ser maior que 0 (zero)!", resultado1.Errors[0].ErrorMessage);
            Assert.AreEqual("O campo 'Valor por KM' do plano diário deve ser maior que 0 (zero)!", resultado2.Errors[0].ErrorMessage);
            Assert.AreEqual(0, resultado3.Errors.Count);
            Assert.AreEqual(0, resultado4.Errors.Count);
        }

        [TestMethod]
        public void Valor_Por_Dia_Do_plano_KM_Controlado_deve_ser_maior_que_zero()
        {
            PlanoCobranca p1 = new PlanoCobranca(100, 20, -1, 30, 50, 300, GetGrupoVeiculos());
            PlanoCobranca p2 = new PlanoCobranca(100, 20, 0, 30, 50, 300, GetGrupoVeiculos());
            PlanoCobranca p3 = new PlanoCobranca(100, 20, 0.1m, 30, 50, 300, GetGrupoVeiculos());
            PlanoCobranca p4 = new PlanoCobranca(100, 20, 200, 30, 50, 300, GetGrupoVeiculos());

            var validador = new ValidadorPlanoCobranca();

            var resultado1 = validador.Validate(p1);
            var resultado2 = validador.Validate(p2);
            var resultado3 = validador.Validate(p3);
            var resultado4 = validador.Validate(p4);

            Assert.AreEqual("O campo 'Valor diário' do plano KM Controlado deve ser maior que 0 (zero)!", resultado1.Errors[0].ErrorMessage);
            Assert.AreEqual("O campo 'Valor diário' do plano KM Controlado deve ser maior que 0 (zero)!", resultado2.Errors[0].ErrorMessage);
            Assert.AreEqual(0, resultado3.Errors.Count);
            Assert.AreEqual(0, resultado4.Errors.Count);
        }

        [TestMethod]
        public void Valor_Por_Km_Do_plano_KM_Controlado_deve_ser_maior_que_zero()
        {
            PlanoCobranca p1 = new PlanoCobranca(100, 20, 200, -1, 50, 300, GetGrupoVeiculos());
            PlanoCobranca p2 = new PlanoCobranca(100, 20, 200, 0, 50, 300, GetGrupoVeiculos());
            PlanoCobranca p3 = new PlanoCobranca(100, 20, 200, 0.1m, 50, 300, GetGrupoVeiculos());
            PlanoCobranca p4 = new PlanoCobranca(100, 20, 200, 30, 50, 300, GetGrupoVeiculos());

            var validador = new ValidadorPlanoCobranca();

            var resultado1 = validador.Validate(p1);
            var resultado2 = validador.Validate(p2);
            var resultado3 = validador.Validate(p3);
            var resultado4 = validador.Validate(p4);

            Assert.AreEqual("O campo 'Valor por KM' do plano KM Controlado deve ser maior que 0 (zero)!", resultado1.Errors[0].ErrorMessage);
            Assert.AreEqual("O campo 'Valor por KM' do plano KM Controlado deve ser maior que 0 (zero)!", resultado2.Errors[0].ErrorMessage);
            Assert.AreEqual(0, resultado3.Errors.Count);
            Assert.AreEqual(0, resultado4.Errors.Count);
        }

        [TestMethod]
        public void Limite_de_Km_Do_plano_KM_Controlado_deve_ser_maior_que_zero()
        {
            PlanoCobranca p1 = new PlanoCobranca(100, 20, 200, 30, -1, 300, GetGrupoVeiculos());
            PlanoCobranca p2 = new PlanoCobranca(100, 20, 200, 30, 0, 300, GetGrupoVeiculos());
            PlanoCobranca p3 = new PlanoCobranca(100, 20, 200, 30, 0.1m, 300, GetGrupoVeiculos());
            PlanoCobranca p4 = new PlanoCobranca(100, 20, 200, 30, 50, 300, GetGrupoVeiculos());

            var validador = new ValidadorPlanoCobranca();

            var resultado1 = validador.Validate(p1);
            var resultado2 = validador.Validate(p2);
            var resultado3 = validador.Validate(p3);
            var resultado4 = validador.Validate(p4);

            Assert.AreEqual("O campo 'Limite de KM' do plano KM Controlado deve ser maior que 0 (zero)!", resultado1.Errors[0].ErrorMessage);
            Assert.AreEqual("O campo 'Limite de KM' do plano KM Controlado deve ser maior que 0 (zero)!", resultado2.Errors[0].ErrorMessage);
            Assert.AreEqual(0, resultado3.Errors.Count);
            Assert.AreEqual(0, resultado4.Errors.Count);
        }

        [TestMethod]
        public void Valor_diario__Do_plano_KM_livre_deve_ser_maior_que_zero()
        {
            PlanoCobranca p1 = new PlanoCobranca(100, 20, 200, 30, 50, -1, GetGrupoVeiculos());
            PlanoCobranca p2 = new PlanoCobranca(100, 20, 200, 30, 50, 0, GetGrupoVeiculos());
            PlanoCobranca p3 = new PlanoCobranca(100, 20, 200, 30, 50, 0.1m, GetGrupoVeiculos());
            PlanoCobranca p4 = new PlanoCobranca(100, 20, 200, 30, 50, 300, GetGrupoVeiculos());

            var validador = new ValidadorPlanoCobranca();

            var resultado1 = validador.Validate(p1);
            var resultado2 = validador.Validate(p2);
            var resultado3 = validador.Validate(p3);
            var resultado4 = validador.Validate(p4);

            Assert.AreEqual("O campo 'Valor diário' do plano KM Livre deve ser maior que 0 (zero)!", resultado1.Errors[0].ErrorMessage);
            Assert.AreEqual("O campo 'Valor diário' do plano KM Livre deve ser maior que 0 (zero)!", resultado2.Errors[0].ErrorMessage);
            Assert.AreEqual(0, resultado3.Errors.Count);
            Assert.AreEqual(0, resultado4.Errors.Count);
        }

        private GrupoVeiculos GetGrupoVeiculos()
        {
            return new GrupoVeiculos("Uber");
        }
    }
}