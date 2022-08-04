using Locadora_Veiculos.Dominio.ModuloPlanoCobranca;
using Locadora_Veiculos.Dominio.ModuloTaxa;
using System;

namespace Locadora_Veiculos.Dominio.ModuloLocacao
{
    public class CalculadoraValoresLocacao
    {
        private decimal precoGasolina = 5m;
        private decimal precoAlcool = 5m;
        private decimal precoDiesel = 5m;
        private decimal precoGNV = 5m;

        public CalculadoraValoresLocacao()
        {
        }

        public decimal CalcularValorTotalPrevisto(Locacao locacao)
        {
            var qtdDiasPrevistosLocacao = Convert.ToDecimal((locacao.DataDevolucaoPrevista - locacao.DataLocacao).TotalDays);
            decimal resultado = 0, totalPlanoDias = 0, totalTaxasDiarias = 0, totalTaxasFixas = 0;

            if (locacao.PlanoCobranca != null)
            {
                switch (locacao.TipoPlanoSelecionado)
                {
                    case TipoPlano.Diario:
                        totalPlanoDias = locacao.PlanoCobranca.DiarioValorDia * qtdDiasPrevistosLocacao;
                        break;
                    case TipoPlano.Controlado:
                        totalPlanoDias = locacao.PlanoCobranca.KmControladoValorDia * qtdDiasPrevistosLocacao;
                        break;
                    case TipoPlano.Livre:
                        totalPlanoDias = locacao.PlanoCobranca.KmLivreValorDia * qtdDiasPrevistosLocacao;
                        break;
                    default:
                        totalPlanoDias = 0;
                        break;
                }
            }

            foreach (var taxa in locacao.TaxasSelecionadas)
            {
                if (taxa.TipoCalculo == TipoCalculo.Fixo)
                    totalTaxasFixas += taxa.Valor;
                else if (taxa.TipoCalculo == TipoCalculo.Diario)
                {
                    totalTaxasDiarias += qtdDiasPrevistosLocacao * taxa.Valor;
                }

            }

            resultado = totalTaxasFixas + totalTaxasDiarias + totalPlanoDias;
         
            return resultado;
        }

        public decimal CalcularValorTotalEfetivo(Locacao locacao)
        {
            decimal valorEfetivoAtual = 0;

            valorEfetivoAtual += GetValorPlanoCobranca(locacao);
            valorEfetivoAtual += GetValorTaxas(locacao);
            valorEfetivoAtual += GetTaxaCombustivel(locacao);
            
            if (locacao.DataDevolucaoEfetiva < locacao.DataDevolucaoPrevista)
            {
                int qtdDiasPrevistaLocacao = Convert.ToInt32((locacao.DataDevolucaoPrevista - locacao.DataLocacao).TotalDays);
                var retorno = (locacao.ValorTotalPrevisto /qtdDiasPrevistaLocacao) * GetQuantidadeDiasRealLocacao(locacao);
                return retorno;
            }
            else if (locacao.DataDevolucaoEfetiva > locacao.DataDevolucaoPrevista)
                valorEfetivoAtual += valorEfetivoAtual * 0.1m;
            
            return valorEfetivoAtual;
        }

        private decimal GetTaxaCombustivel(Locacao locacao)
        {
            decimal resultado = 0m;
            var tipoCombustivel = locacao.Veiculo.TipoCombustivel;
            var capacidadeTanque = locacao.Veiculo.CapacidadeTanque;
            decimal diferencaPraCompletarTanque = 0;
            decimal tanqueEmQuatro = capacidadeTanque / 4;

            switch (locacao.NivelTanqueDevolucao)
            {
                case NivelTanque.Cheio:
                    return 0;
                case NivelTanque.TresQuartos:
                    diferencaPraCompletarTanque = tanqueEmQuatro;
                    break;
                case NivelTanque.Meio:
                    diferencaPraCompletarTanque = tanqueEmQuatro * 2;
                    break;
                case NivelTanque.UmQuarto:
                    diferencaPraCompletarTanque = tanqueEmQuatro * 3;
                    break;
                case NivelTanque.Vazio:
                    diferencaPraCompletarTanque = capacidadeTanque;
                    break;
            }

            switch (tipoCombustivel)
            {
                case "Gasolina":

                    resultado = diferencaPraCompletarTanque * precoGasolina;
                    break;
                case "Álcool":
                    resultado = diferencaPraCompletarTanque * precoAlcool;
                    break;
                case "Diesel":
                    resultado = diferencaPraCompletarTanque * precoDiesel;
                    break;
                case "GNV":
                    resultado = diferencaPraCompletarTanque * precoGNV;
                    break;
            }
            return resultado;
        }

        private decimal GetValorTaxas(Locacao locacao)
        {
            decimal resultado = 0m;

            foreach (var item in locacao.TaxasSelecionadas)
            {
                    resultado += item.Valor;
            }
            return resultado;
        }

        private decimal GetValorPlanoCobranca(Locacao locacao)
        {
            var total = 0m;

            int qtdDiasLocacao = GetQuantidadeDiasRealLocacao(locacao);

            var km = locacao.QuilometragemFinalVeiculo.Value - locacao.QuilometragemInicialVeiculo;
            if (locacao.TipoPlanoSelecionado == ModuloPlanoCobranca.TipoPlano.Diario)
            {
                total += locacao.PlanoCobranca.DiarioValorDia * qtdDiasLocacao;
                total += locacao.PlanoCobranca.DiarioValorKm * km;
            }
            else if (locacao.TipoPlanoSelecionado == ModuloPlanoCobranca.TipoPlano.Controlado)
            {
                total += locacao.PlanoCobranca.DiarioValorDia * qtdDiasLocacao;
                if (locacao.QuilometragemFinalVeiculo > locacao.PlanoCobranca.KmControladoLimiteKm)
                {
                    total += locacao.PlanoCobranca.KmControladoValorKm * km;
                }
            }
            else if (locacao.TipoPlanoSelecionado == ModuloPlanoCobranca.TipoPlano.Livre)
            {
                total += locacao.PlanoCobranca.DiarioValorDia * qtdDiasLocacao;
            }

            return total;
        }

        private static int GetQuantidadeDiasRealLocacao(Locacao locacao)
        {
            TimeSpan timeSpanDias = Convert.ToDateTime(locacao.DataDevolucaoEfetiva.Value) - Convert.ToDateTime(locacao.DataLocacao);
            var qtdDiasLocacao = timeSpanDias.Days;
            return qtdDiasLocacao;
        }
    }
}
