using Locadora_Veiculos.Dominio.Compartilhado;
using Locadora_Veiculos.Dominio.ModuloCondutor;
using Locadora_Veiculos.Dominio.ModuloGrupoVeiculos;
using Locadora_Veiculos.Dominio.ModuloPlanoCobranca;
using Locadora_Veiculos.Dominio.ModuloTaxa;
using Locadora_Veiculos.Dominio.ModuloVeiculo;
using System;
using System.Collections.Generic;

namespace Locadora_Veiculos.Dominio.ModuloLocacao
{
    public class Locacao : EntidadeBase<Locacao>
    {
        #region CONSTRUTORES

        public Locacao()
        {
            this.StatusLocacao = StatusLocacao.Aberta;
            this.TaxasSelecionadas = new List<Taxa>();
            //this.DataLocacao = DateTime.Today;
        }

        public Locacao(Condutor condutor, Veiculo veiculo,
            GrupoVeiculos grupoVeiculos, PlanoCobranca planoCobranca, TipoPlano tipoPlanoSelecionado,
            List<Taxa> taxas,
            DateTime dataLocacao, decimal valorTotalPrevisto,
            DateTime dataDevolucaoPrevista, int quilometragemInicialVeiculo) : this()
        {
            Condutor = condutor;
            Veiculo = veiculo;
            GrupoVeiculos = grupoVeiculos;
            PlanoCobranca = planoCobranca;
            TipoPlanoSelecionado = tipoPlanoSelecionado;
            TaxasSelecionadas = taxas;
            DataLocacao = dataLocacao;
            ValorTotalPrevisto = valorTotalPrevisto;
            DataDevolucaoPrevista = dataDevolucaoPrevista;
            QuilometragemInicialVeiculo = quilometragemInicialVeiculo;
        }

        #endregion

        #region PROPS

        public Condutor Condutor { get; set; }

        public Guid CondutorId { get; set; }

        public Veiculo Veiculo { get; set; }

        public Guid VeiculoId { get; set; }

        public GrupoVeiculos GrupoVeiculos { get; set; }

        public Guid GrupoVeiculosId { get; set; }

        public PlanoCobranca PlanoCobranca { get; set; }

        public TipoPlano TipoPlanoSelecionado { get; set; }

        public Guid PlanoCobrancaId { get; set; }

        public List<Taxa> TaxasSelecionadas { get; set; }

        public DateTime DataLocacao { get; set; }

        public decimal ValorTotalPrevisto { get; set; }

        public DateTime DataDevolucaoPrevista { get; set; }

        public int QuilometragemInicialVeiculo
        {
            get
            {
                if (Veiculo != null)
                    return Veiculo.QuilometragemPercorrida;
                return -1;
            }
            set { }
        }

        public int? QuilometragemFinalVeiculo { get; set; }

        public DateTime? DataDevolucaoEfetiva { get; set; }

        public NivelTanque? NivelTanqueDevolucao { get; set; }

        public decimal? ValorTotalEfetivo { get; set; }

        public StatusLocacao StatusLocacao { get; set; }

        #endregion

        public void ConfigurarGrupoVeiculos(GrupoVeiculos grupo)
        {
            if (grupo == null)
                return;

            GrupoVeiculos = grupo;
            GrupoVeiculosId = grupo.Id;
        }

        public void ConfigurarPlanoCobranca(PlanoCobranca planoCobranca)
        {
            if (planoCobranca == null)
                return;

            PlanoCobranca = planoCobranca;
            PlanoCobrancaId = planoCobranca.Id;
        }

        public void ConfigurarCondutor(Condutor condutor)
        {
            if (condutor == null)
                return;

            Condutor = condutor;
            CondutorId = condutor.Id;
        }

        public void AdicionarTaxa(Taxa taxa)
        {
            TaxasSelecionadas.Add(taxa);
        }
    }
}