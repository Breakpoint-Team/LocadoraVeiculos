using Locadora_Veiculos.Dominio.ModuloTaxa;

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
        public decimal CalcularValorTotalEfetivo(Locacao locacao)
        {
            decimal valorEfetivoAtual = 0;

            valorEfetivoAtual += GetValorTaxasDevolucao(locacao);
            valorEfetivoAtual += GetTaxaCombustivel(locacao);
            valorEfetivoAtual += GetTaxaValorDataDevolucao(locacao, valorEfetivoAtual);
            if (locacao.DataDevolucaoEfetiva < locacao.DataDevolucaoPrevista)
                return valorEfetivoAtual;
            else
                valorEfetivoAtual += locacao.ValorTotalPrevisto;
            
            return valorEfetivoAtual;
        }

        private decimal GetTaxaValorDataDevolucao(Locacao locacao, decimal valorEfetivoAtual)
        {
            decimal resultado = 0;

            if (locacao.DataDevolucaoPrevista == locacao.DataDevolucaoEfetiva)
                return 0;

            if (locacao.DataDevolucaoEfetiva < locacao.DataDevolucaoPrevista)
            {
                int quantidadeDiasPrevistosLocacao = locacao.DataDevolucaoPrevista.DayOfYear - locacao.DataLocacao.DayOfYear;
                int quantidadeDiasRealLocacao = locacao.DataDevolucaoEfetiva.Value.DayOfYear - locacao.DataLocacao.DayOfYear;

                var valorPrevistoEmDias = locacao.ValorTotalPrevisto / quantidadeDiasPrevistosLocacao;

                resultado = valorPrevistoEmDias * quantidadeDiasRealLocacao;
            }

            else if (locacao.DataDevolucaoEfetiva > locacao.DataDevolucaoPrevista)
            {
                decimal dezPorCento = valorEfetivoAtual * 0.1m;
                resultado = resultado + dezPorCento;
            }
            
            return resultado;
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

        private decimal GetValorTaxasDevolucao(Locacao locacao)
        {
            decimal resultado = 0m;

            foreach (var item in locacao.TaxasSelecionadas)
            {
                //if (item.TipoTaxa == TipoTaxa.TaxaDevolucao)
                    resultado += item.Valor;
            }
            return resultado;
        }
    }
}
