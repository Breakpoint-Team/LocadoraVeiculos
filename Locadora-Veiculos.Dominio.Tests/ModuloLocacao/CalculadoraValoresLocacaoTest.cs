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
    public class CalculadoraValoresLocacaoTest
    {
        [TestMethod]
        public void Deve_calcular_o_total_previsto_da_locacao_sem_taxas()
        {
            var dataLocacao = DateTime.Today;
            var dataDevolucaoPrevista = dataLocacao.AddDays(10);

            Locacao locacao = new(GetCondutor(), GetVeiculo(),
            GetGrupoVeiculos(), GetPlanoCobranca(), TipoPlano.Diario, new List<Taxa>(), DateTime.Today, 2000,
            dataDevolucaoPrevista, GetVeiculo().QuilometragemPercorrida);

            var qtdDiasLocacao = Convert.ToDecimal((dataDevolucaoPrevista - dataLocacao).TotalDays);

            var resultadoEsperado = GetPlanoCobranca().DiarioValorDia * qtdDiasLocacao;

            CalculadoraValoresLocacao calculadora = new CalculadoraValoresLocacao();

            var resultadoObtido = calculadora.CalcularValorTotalPrevisto(locacao);

            Assert.AreEqual(resultadoEsperado, resultadoObtido);
        }

        [TestMethod]
        public void Deve_calcular_o_total_previsto_da_locacao_com_taxas()
        {
            var dataLocacao = DateTime.Today;
            var dataDevolucaoPrevista = dataLocacao.AddDays(10);

            Locacao locacao = new(GetCondutor(), GetVeiculo(),
            GetGrupoVeiculos(), GetPlanoCobranca(), TipoPlano.Diario, NovasTaxas(), DateTime.Today, 2000,
            dataDevolucaoPrevista, GetVeiculo().QuilometragemPercorrida);

            var qtdDiasLocacao = Convert.ToDecimal((dataDevolucaoPrevista - dataLocacao).TotalDays);

            var resultadoEsperado = GetPlanoCobranca().DiarioValorDia * qtdDiasLocacao;

            decimal totalTaxas = 0;
            foreach (var item in NovasTaxas())
            {
                if (item.TipoCalculo == TipoCalculo.Diario)
                    totalTaxas += item.Valor * qtdDiasLocacao;
                else
                    totalTaxas += item.Valor;
            }
            resultadoEsperado += totalTaxas;

            CalculadoraValoresLocacao calculadora = new CalculadoraValoresLocacao();

            var resultadoObtido = calculadora.CalcularValorTotalPrevisto(locacao);

            Assert.AreEqual(resultadoEsperado, resultadoObtido);
        }

        [TestMethod]
        public void Deve_calcular_o_total_efetivo_da_locacao_com_entrega_na_data()
        {
            CalculadoraValoresLocacao calculadora = new CalculadoraValoresLocacao();
            
            var dataLocacao = DateTime.Today;
            var dataDevolucaoPrevista = dataLocacao.AddDays(10);

            Locacao locacao = new(GetCondutor(), GetVeiculo(),
            GetGrupoVeiculos(), GetPlanoCobranca(), TipoPlano.Diario, NovasTaxas(), DateTime.Today, 2000,
            dataDevolucaoPrevista, GetVeiculo().QuilometragemPercorrida);

            var qtdDiasLocacao = Convert.ToDecimal((dataDevolucaoPrevista - dataLocacao).TotalDays);

            var valorPrevisto = GetPlanoCobranca().DiarioValorDia * qtdDiasLocacao;

            locacao.ValorTotalPrevisto = calculadora.CalcularValorTotalPrevisto(locacao);

            locacao.DataDevolucaoEfetiva = dataDevolucaoPrevista;
            locacao.QuilometragemFinalVeiculo = locacao.Veiculo.QuilometragemPercorrida + 10;
            locacao.NivelTanqueDevolucao = NivelTanque.Cheio;

            var resultadoObtido = calculadora.CalcularValorTotalEfetivo(locacao);

            Assert.AreEqual(1340, resultadoObtido);
        }

        [TestMethod]
        public void Deve_calcular_o_total_efetivo_da_locacao_com_entrega_antes_da_data()
        {
            CalculadoraValoresLocacao calculadora = new CalculadoraValoresLocacao();

            var dataLocacao = DateTime.Today;
            var dataDevolucaoPrevista = dataLocacao.AddDays(10);

            Locacao locacao = new(GetCondutor(), GetVeiculo(),
            GetGrupoVeiculos(), GetPlanoCobranca(), TipoPlano.Diario, NovasTaxas(), DateTime.Today, 2000,
            dataDevolucaoPrevista, GetVeiculo().QuilometragemPercorrida);

            var qtdDiasLocacao = Convert.ToDecimal((dataDevolucaoPrevista - dataLocacao).TotalDays);

            locacao.ValorTotalPrevisto = calculadora.CalcularValorTotalPrevisto(locacao);

            locacao.DataDevolucaoEfetiva = dataLocacao.AddDays(5);
            locacao.QuilometragemFinalVeiculo = locacao.Veiculo.QuilometragemPercorrida + 10;
            locacao.NivelTanqueDevolucao = NivelTanque.Cheio;

            var resultadoObtido = calculadora.CalcularValorTotalEfetivo(locacao);

            Assert.AreEqual(1200, resultadoObtido);
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

        private List<Taxa> NovasTaxas()
        {
            var t1 = new Taxa("Cadeira de Bebê", 90, TipoCalculo.Diario);
            var t2 = new Taxa("Frigobar", 50, TipoCalculo.Diario);

            var lista = new List<Taxa>();
            lista.Add(t1);
            lista.Add(t2);
            return lista;
        }

        #endregion
    }
}