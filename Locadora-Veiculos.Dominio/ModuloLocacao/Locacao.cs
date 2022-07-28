using Locadora_Veiculos.Dominio.Compartilhado;
using Locadora_Veiculos.Dominio.ModuloCliente;
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
            this.CondutoresAtivos = new List<Condutor>();
            this.Taxas = new List<Taxa>();
        }

        #endregion

        #region PROPS

        public Cliente Cliente { get; set; }

        public Guid ClienteId { get; set; }

        public List<Condutor> CondutoresAtivos { get; set; }

        public Veiculo Veiculo { get; set; }

        public Guid VeiculoId { get; set; }

        public GrupoVeiculos GrupoVeiculos { get; set; }

        public Guid GrupoVeiculosId { get; set; }

        public PlanoCobranca PlanoCobranca { get; set; }

        public Guid PlanoCobrancaId { get; set; }

        public List<Taxa> Taxas { get; set; }

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

        public void ConfigurarCliente(Cliente cliente)
        {
            if (cliente == null)
                return;

            Cliente = cliente;
            ClienteId = cliente.Id;
        }

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

        public void AdicionarCondutorAtivo(Condutor condutor)
        {
            CondutoresAtivos.Add(condutor);
        }

        public void AdicionarTaxa(Taxa taxa)
        {
            Taxas.Add(taxa);
        }

        public override bool Equals(object obj)
        {
            return obj is Locacao locacao &&
                   Id.Equals(locacao.Id) &&
                   EqualityComparer<Cliente>.Default.Equals(Cliente, locacao.Cliente) &&
                   ClienteId.Equals(locacao.ClienteId) &&
                   EqualityComparer<List<Condutor>>.Default.Equals(CondutoresAtivos, locacao.CondutoresAtivos) &&
                   EqualityComparer<Veiculo>.Default.Equals(Veiculo, locacao.Veiculo) &&
                   VeiculoId.Equals(locacao.VeiculoId) &&
                   EqualityComparer<GrupoVeiculos>.Default.Equals(GrupoVeiculos, locacao.GrupoVeiculos) &&
                   GrupoVeiculosId.Equals(locacao.GrupoVeiculosId) &&
                   EqualityComparer<PlanoCobranca>.Default.Equals(PlanoCobranca, locacao.PlanoCobranca) &&
                   PlanoCobrancaId.Equals(locacao.PlanoCobrancaId) &&
                   EqualityComparer<List<Taxa>>.Default.Equals(Taxas, locacao.Taxas) &&
                   DataLocacao == locacao.DataLocacao &&
                   ValorTotalPrevisto == locacao.ValorTotalPrevisto &&
                   DataDevolucaoPrevista == locacao.DataDevolucaoPrevista &&
                   QuilometragemInicialVeiculo == locacao.QuilometragemInicialVeiculo &&
                   QuilometragemFinalVeiculo == locacao.QuilometragemFinalVeiculo &&
                   DataDevolucaoEfetiva == locacao.DataDevolucaoEfetiva &&
                   NivelTanqueDevolucao == locacao.NivelTanqueDevolucao &&
                   ValorTotalEfetivo == locacao.ValorTotalEfetivo &&
                   StatusLocacao == locacao.StatusLocacao;
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(Id);
            hash.Add(Cliente);
            hash.Add(ClienteId);
            hash.Add(CondutoresAtivos);
            hash.Add(Veiculo);
            hash.Add(VeiculoId);
            hash.Add(GrupoVeiculos);
            hash.Add(GrupoVeiculosId);
            hash.Add(PlanoCobranca);
            hash.Add(PlanoCobrancaId);
            hash.Add(Taxas);
            hash.Add(DataLocacao);
            hash.Add(ValorTotalPrevisto);
            hash.Add(DataDevolucaoPrevista);
            hash.Add(QuilometragemInicialVeiculo);
            hash.Add(QuilometragemFinalVeiculo);
            hash.Add(DataDevolucaoEfetiva);
            hash.Add(NivelTanqueDevolucao);
            hash.Add(ValorTotalEfetivo);
            hash.Add(StatusLocacao);
            return hash.ToHashCode();
        }
    }
}