using Locadora_Veiculos.Dominio.ModuloCliente;
using Locadora_Veiculos.Dominio.ModuloCondutor;
using Locadora_Veiculos.Dominio.ModuloEndereco;
using Locadora_Veiculos.Dominio.ModuloGrupoVeiculos;
using Locadora_Veiculos.Dominio.ModuloLocacao;
using Locadora_Veiculos.Dominio.ModuloPlanoCobranca;
using Locadora_Veiculos.Dominio.ModuloTaxa;
using Locadora_Veiculos.Dominio.ModuloVeiculo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Locadora_Veiculos.Dominio.Tests.ModuloLocacao
{
    [TestClass]
    public class ValidadorLocacaoTest
    {
        [TestMethod]
        public void Locacao_Deve_ter_um_condutor()
        {
            Locacao locacao1 = new(null, GetVeiculo(),
            GetGrupoVeiculos(), GetPlanoCobranca(), TipoPlano.Diario, new List<Taxa>(), DateTime.Today, 2000,
            new DateTime(2025, 8, 13), GetVeiculo().QuilometragemPercorrida);

            Locacao locacao2 = new(GetCondutor(), GetVeiculo(),
            GetGrupoVeiculos(), GetPlanoCobranca(), TipoPlano.Diario, new List<Taxa>(), DateTime.Today, 2000,
            new DateTime(2025, 8, 13), GetVeiculo().QuilometragemPercorrida);

            var validador = new Dominio.ModuloLocacao.ValidadorLocacao();

            var resultado1 = validador.Validate(locacao1);
            var resultado2 = validador.Validate(locacao2);

            Assert.AreEqual("O campo 'Condutor' é obrigatório!", resultado1.Errors[0].ErrorMessage);
            Assert.AreEqual(0, resultado2.Errors.Count);
        }

        [TestMethod]
        public void Locacao_Deve_ter_um_veiculo()
        {
            Locacao locacao1 = new(GetCondutor(), null,
            GetGrupoVeiculos(), GetPlanoCobranca(), TipoPlano.Diario, new List<Taxa>(), DateTime.Today, 2000,
            new DateTime(2025, 8, 13), GetVeiculo().QuilometragemPercorrida);

            var validador = new Dominio.ModuloLocacao.ValidadorLocacao();

            var resultado1 = validador.Validate(locacao1);

            Assert.AreEqual("O campo 'Veículo' é obrigatório!", resultado1.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Locacao_Deve_ter_um_grupo_de_veiculos()
        {
            Locacao locacao1 = new(GetCondutor(), GetVeiculo(),
            null, GetPlanoCobranca(), TipoPlano.Diario, new List<Taxa>(), DateTime.Today, 2000,
            new DateTime(2025, 8, 13), GetVeiculo().QuilometragemPercorrida);

            var validador = new Dominio.ModuloLocacao.ValidadorLocacao();

            var resultado1 = validador.Validate(locacao1);

            Assert.AreEqual("O campo 'Grupo de Veículos' é obrigatório!", resultado1.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Locacao_Deve_ter_um_plano_de_cobranca()
        {
            Locacao locacao1 = new(GetCondutor(), GetVeiculo(),
            GetGrupoVeiculos(), null, TipoPlano.Diario, new List<Taxa>(), DateTime.Today, 2000,
            new DateTime(2025, 8, 13), GetVeiculo().QuilometragemPercorrida);

            var validador = new Dominio.ModuloLocacao.ValidadorLocacao();

            var resultado1 = validador.Validate(locacao1);

            Assert.AreEqual("O campo 'Plano de Cobrança' é obrigatório!", resultado1.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Data_da_Locacao_deve_ser_obrigatorio()
        {
            Locacao locacao1 = new(GetCondutor(), GetVeiculo(),
            GetGrupoVeiculos(), GetPlanoCobranca(), TipoPlano.Diario, new List<Taxa>(), DateTime.MinValue, 2000,
            new DateTime(2025, 8, 13), GetVeiculo().QuilometragemPercorrida);

            var validador = new Dominio.ModuloLocacao.ValidadorLocacao();

            var resultado1 = validador.Validate(locacao1);

            Assert.AreEqual("O campo 'Data de Locação' é obrigatório!", resultado1.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Valor_total_previsto_da_Locacao_deve_ser_maior_que_zero()
        {
            Locacao locacao1 = new(GetCondutor(), GetVeiculo(),
            GetGrupoVeiculos(), GetPlanoCobranca(), TipoPlano.Diario, new List<Taxa>(), DateTime.Today, 0,
            new DateTime(2025, 8, 13), GetVeiculo().QuilometragemPercorrida);

            var validador = new Dominio.ModuloLocacao.ValidadorLocacao();

            var resultado1 = validador.Validate(locacao1);

            Assert.AreEqual("O campo 'Valor Total Previsto' deve ser maior que 0 (zero)!", resultado1.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Data_de_devolucao_prevista_deve_ser_obrigatorio()
        {
            Locacao locacao1 = new(GetCondutor(), GetVeiculo(),
            GetGrupoVeiculos(), GetPlanoCobranca(), TipoPlano.Diario, new List<Taxa>(), DateTime.Today, 2000,
            DateTime.MinValue, GetVeiculo().QuilometragemPercorrida);

            var validador = new Dominio.ModuloLocacao.ValidadorLocacao();

            var resultado1 = validador.Validate(locacao1);

            Assert.AreEqual("O campo 'Data de Devolução Prevista' é obrigatório!", resultado1.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Data_de_devolucao_prevista_deve_ser_maior_que_a_data_da_locacao()
        {
            Locacao locacao1 = new(GetCondutor(), GetVeiculo(),
            GetGrupoVeiculos(), GetPlanoCobranca(), TipoPlano.Diario, new List<Taxa>(), DateTime.Today, 2000,
            DateTime.Today.AddDays(-1), GetVeiculo().QuilometragemPercorrida);

            var validador = new Dominio.ModuloLocacao.ValidadorLocacao();

            var resultado1 = validador.Validate(locacao1);

            Assert.AreEqual("O campo 'Data de Devolução Prevista' deve ser maior ou igual a data da locação!", resultado1.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Validade_ad_CNH_do_condutor_deve_ser_maior_que_a_data_de_devolucao_prevista()
        {
            var dataPrevistaDevolucao = DateTime.Today.AddDays(30);

            var condutorComCNHInvalida = GetCondutor().Clone();
            condutorComCNHInvalida.DataValidadeCnh = dataPrevistaDevolucao.AddDays(-1);

            Locacao locacao1 = new(condutorComCNHInvalida, GetVeiculo(),
            GetGrupoVeiculos(), GetPlanoCobranca(), TipoPlano.Diario, new List<Taxa>(), DateTime.Today, 2000,
            dataPrevistaDevolucao, GetVeiculo().QuilometragemPercorrida);

            Locacao locacao2 = new(GetCondutor(), GetVeiculo(),
            GetGrupoVeiculos(), GetPlanoCobranca(), TipoPlano.Diario, new List<Taxa>(), DateTime.Today, 2000,
            dataPrevistaDevolucao, GetVeiculo().QuilometragemPercorrida);

            var validador = new Dominio.ModuloLocacao.ValidadorLocacao();

            var resultado1 = validador.Validate(locacao1);
            var resultado2 = validador.Validate(locacao2);

            Assert.AreEqual("A data de validade da CNH do condutor selecionado não deve ser menor que a data de devolução prevista!", resultado1.Errors[0].ErrorMessage);
            Assert.AreEqual(0, resultado2.Errors.Count);
        }

        [TestMethod]
        public void Ao_fechar_uma_locacao_a_quilometragem_final_nao_deve_ser_menor_que_a_inicial()
        {
            var dataPrevistaDevolucao = DateTime.Today.AddDays(30);

            Locacao locacao1 = new(GetCondutor(), GetVeiculo(),
            GetGrupoVeiculos(), GetPlanoCobranca(), TipoPlano.Diario, new List<Taxa>(), DateTime.Today, 2000,
            dataPrevistaDevolucao, GetVeiculo().QuilometragemPercorrida);

            locacao1.StatusLocacao = StatusLocacao.Fechada;

            locacao1.QuilometragemFinalVeiculo = locacao1.QuilometragemInicialVeiculo - 1;

            var validador = new Dominio.ModuloLocacao.ValidadorLocacao();

            var resultado1 = validador.Validate(locacao1);

            Assert.AreEqual("O campo 'Quilometragem Final' deve ser maior ou igual à quilometragem inicial!", resultado1.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Ao_fechar_uma_locacao_a_data_de_devolucao_efetiva_deve_ser_obrigatorio()
        {
            var dataPrevistaDevolucao = DateTime.Today.AddDays(30);

            Locacao locacao1 = new(GetCondutor(), GetVeiculo(),
            GetGrupoVeiculos(), GetPlanoCobranca(), TipoPlano.Diario, new List<Taxa>(), DateTime.Today, 2000,
            dataPrevistaDevolucao, GetVeiculo().QuilometragemPercorrida);

            locacao1.StatusLocacao = StatusLocacao.Fechada;

            locacao1.QuilometragemFinalVeiculo = locacao1.QuilometragemInicialVeiculo + 50;

            var validador = new Dominio.ModuloLocacao.ValidadorLocacao();

            var resultado1 = validador.Validate(locacao1);

            Assert.AreEqual("O campo 'Data de Devolução Efetiva' é obrigatório!", resultado1.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Ao_fechar_uma_locacao_a_data_de_devolucao_efetiva_nao_deve_ser_menor_que_a_data_da_locacao()
        {
            var dataPrevistaDevolucao = DateTime.Today.AddDays(30);

            Locacao locacao1 = new(GetCondutor(), GetVeiculo(),
            GetGrupoVeiculos(), GetPlanoCobranca(), TipoPlano.Diario, new List<Taxa>(), DateTime.Today, 2000,
            dataPrevistaDevolucao, GetVeiculo().QuilometragemPercorrida);

            locacao1.StatusLocacao = StatusLocacao.Fechada;

            locacao1.QuilometragemFinalVeiculo = locacao1.QuilometragemInicialVeiculo + 50;

            locacao1.DataDevolucaoEfetiva = locacao1.DataLocacao.AddDays(-1);

            var validador = new Dominio.ModuloLocacao.ValidadorLocacao();

            var resultado1 = validador.Validate(locacao1);

            Assert.AreEqual("O campo 'Data de Devolução Efetiva' deve ser maior ou igual a data da locação!", resultado1.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Ao_fechar_uma_locacao_o_nivel_do_tanque_deve_ser_obrigatorio()
        {
            var dataPrevistaDevolucao = DateTime.Today.AddDays(30);

            Locacao locacao1 = new(GetCondutor(), GetVeiculo(),
            GetGrupoVeiculos(), GetPlanoCobranca(), TipoPlano.Diario, new List<Taxa>(), DateTime.Today, 2000,
            dataPrevistaDevolucao, GetVeiculo().QuilometragemPercorrida);

            locacao1.StatusLocacao = StatusLocacao.Fechada;

            locacao1.QuilometragemFinalVeiculo = locacao1.QuilometragemInicialVeiculo + 50;

            locacao1.DataDevolucaoEfetiva = dataPrevistaDevolucao;

            var validador = new Dominio.ModuloLocacao.ValidadorLocacao();

            var resultado1 = validador.Validate(locacao1);

            Assert.AreEqual("O campo 'Nível do Tanque' é obrigatório!", resultado1.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Ao_fechar_uma_locacao_o_valor_total_efetivo_deve_ser_obrigatorio()
        {
            var dataPrevistaDevolucao = DateTime.Today.AddDays(30);

            Locacao locacao1 = new(GetCondutor(), GetVeiculo(),
            GetGrupoVeiculos(), GetPlanoCobranca(), TipoPlano.Diario, new List<Taxa>(), DateTime.Today, 2000,
            dataPrevistaDevolucao, GetVeiculo().QuilometragemPercorrida);

            locacao1.StatusLocacao = StatusLocacao.Fechada;

            locacao1.QuilometragemFinalVeiculo = locacao1.QuilometragemInicialVeiculo + 50;

            locacao1.DataDevolucaoEfetiva = dataPrevistaDevolucao;

            locacao1.NivelTanqueDevolucao = NivelTanque.Meio;

            var validador = new Dominio.ModuloLocacao.ValidadorLocacao();

            var resultado1 = validador.Validate(locacao1);

            Assert.AreEqual("O campo 'Valor Total Efetivo' é obrigatório!", resultado1.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Ao_fechar_uma_locacao_o_valor_total_efetivo_deve_ser_maior_que_zero()
        {
            var dataPrevistaDevolucao = DateTime.Today.AddDays(30);

            Locacao locacao1 = new(GetCondutor(), GetVeiculo(),
            GetGrupoVeiculos(), GetPlanoCobranca(), TipoPlano.Diario, new List<Taxa>(), DateTime.Today, 2000,
            dataPrevistaDevolucao, GetVeiculo().QuilometragemPercorrida);

            locacao1.StatusLocacao = StatusLocacao.Fechada;

            locacao1.QuilometragemFinalVeiculo = locacao1.QuilometragemInicialVeiculo + 50;

            locacao1.DataDevolucaoEfetiva = dataPrevistaDevolucao;

            locacao1.NivelTanqueDevolucao = NivelTanque.Meio;

            locacao1.ValorTotalEfetivo = 0;

            var validador = new Dominio.ModuloLocacao.ValidadorLocacao();

            var resultado1 = validador.Validate(locacao1);

            Assert.AreEqual("O campo 'Valor Total Efetivo' deve ser maior que 0 (zero)!", resultado1.Errors[0].ErrorMessage);
        }


        #region MÉTODOS PRIVADOS

        private Veiculo GetVeiculo()
        {
            var imagem = new byte[10];
            for (int i = 0; i < imagem.Length; i++)
                imagem[i] = (byte)i;

            var veiculo = new Veiculo("Kicks", "Nissan", 2019, "Vermelho", "ABC-1234",
           "Gasolina", 10000, 40.0m, GetGrupoVeiculos(), imagem);

            return veiculo;
        }

        private GrupoVeiculos GetGrupoVeiculos()
        {
            return new GrupoVeiculos("Uber");
        }

        private PlanoCobranca GetPlanoCobranca()
        {
            return new PlanoCobranca(100, 20, 200, 30, 50, 300, GetGrupoVeiculos());
        }

        private Cliente GetClienteFisico()
        {
            return new Cliente("Paulo Roberto Pereira", "(49) 98855-0076", "paulo@gmail.com",
                TipoCliente.PessoaFisica, "015.932.598-04", GetEndereco());
        }

        private Condutor GetCondutor()
        {
            return new Condutor("João da Silva", "(49) 98888-9999", "joao@gmail.com", "013.987.765-09", "123456789",
                new DateTime(2028, 12, 28), GetEndereco(), GetClienteFisico());
        }

        private Endereco GetEndereco()
        {
            return new Endereco("SP", "São Paulo", "centro", "Rua das laranjeiras", 2);
        }

        #endregion
    }
}