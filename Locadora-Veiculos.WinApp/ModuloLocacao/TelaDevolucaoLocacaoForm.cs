using FluentResults;
using Locadora_Veiculos.Dominio.Compartilhado;
using Locadora_Veiculos.Dominio.ModuloLocacao;
using Locadora_Veiculos.Dominio.ModuloTaxa;
using Locadora_Veiculos.Infra.Configs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Locadora_Veiculos.WinApp.ModuloLocacao
{
    public partial class TelaDevolucaoLocacaoForm : Form
    {
        private Locacao locacao;
        private CalculadoraValoresLocacao calculadoraDevolucao;
        private List<Taxa> taxasDevolucaoSelecionadas = new List<Taxa>();
        private readonly ConfiguracaoAplicacao configuracao;
        public TelaDevolucaoLocacaoForm(List<Taxa> taxas)
        {
            InitializeComponent();
            CarregarTaxasDeDevolucao(taxas);
            this.configuracao = new ConfiguracaoAplicacao();
            calculadoraDevolucao = new CalculadoraValoresLocacao(configuracao);
        }

        public Locacao Locacao
        {
            get => locacao;
            set
            {
                locacao = value;
                PreencherDadosTela();
                comboBoxNivelTanque.SelectedIndex = -1;
            }
        }

        public Func<Locacao, Result<Locacao>> GravarRegistro { get; set; }

        #region EVENTOS

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            dateTimePickerDevolucaoEfetiva.Value = DateTime.Today;
            for (int i = 0; i < checkedListBoxTaxasDevolucao.Items.Count; i++)
            {
                checkedListBoxTaxasDevolucao.SetItemChecked(i, false);
            }

            comboBoxNivelTanque.SelectedIndex = -1;
            numericUpDownKmFinal.Value = numericUpDownKmFinal.Minimum;
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            ObterDadosTela();

            locacao.StatusLocacao = StatusLocacao.EmProcessoDeDevolucao;
            var resultadoValidacao = GravarRegistro(locacao);

            if (resultadoValidacao.IsFailed)
            {
                locacao.StatusLocacao = StatusLocacao.Aberta;

                string erro = resultadoValidacao.Errors[0].Message;

                if (erro.StartsWith("Falha no sistema"))
                {
                    MessageBox.Show(erro,
                        "Devolução de Locação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                    DialogResult = DialogResult.None;
                }
            }
            else
            {
                MessageBox.Show($"Valor efetivo: R$ {locacao.ValorTotalEfetivo}", "Devolução de locação",
                    MessageBoxButtons.OK);
            }
        }

        #endregion

        #region MÉTODOS PRIVADOS

        private void PreencherDadosTela()
        {
            labelClienteNome.Text = locacao.Condutor.Cliente.Nome;
            labelCondutorNome.Text = locacao.Condutor.Nome;
            labelGrupoVeiculosNome.Text = locacao.Veiculo.GrupoVeiculos.Nome;
            labelVeiculoModelo.Text = locacao.Veiculo.Modelo;
            labelPlanoCobrancaTipo.Text = locacao.TipoPlanoSelecionado.GetDescription();
            labelDataLocacao.Text = locacao.DataLocacao.ToShortDateString();
            labelDevolucaoPrevista.Text = locacao.DataDevolucaoPrevista.ToShortDateString();
            labelKmInicial.Text = locacao.QuilometragemInicialVeiculo + " Km";
            dateTimePickerDevolucaoEfetiva.MinDate = DateTime.Today;
            numericUpDownKmFinal.Minimum = locacao.QuilometragemInicialVeiculo;

            CarregarTaxasDeLocacao();

            comboBoxNivelTanque.DisplayMember = "Description";
            comboBoxNivelTanque.ValueMember = "Value";
            comboBoxNivelTanque.DataSource = Enum.GetValues(typeof(NivelTanque))
                .Cast<Enum>()
                .Select(value => new
                {
                    (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                    value
                })
                .OrderBy(item => item.value)
                .ToList();
        }

        private void CarregarTaxasDeDevolucao(List<Taxa> taxas)
        {
            if (taxas.Count > 0)
            {
                foreach (var item in taxas)
                {
                    if (item.TipoTaxa == TipoTaxa.TaxaDevolucao)
                        checkedListBoxTaxasDevolucao.Items.Add(item);
                }
            }
        }

        private void CarregarTaxasDeLocacao()
        {
            if (locacao.TaxasSelecionadas.Count > 0)
            {
                for (int i = 0; i < locacao.TaxasSelecionadas.Count; i++)
                {
                    checkedListBoxTaxasLocacao.Items.Add(locacao.TaxasSelecionadas[i]);
                    checkedListBoxTaxasLocacao.SetItemChecked(i, true);
                }
                checkedListBoxTaxasLocacao.Enabled = false;
            }
        }

        private void ObterDadosTela()
        {
            locacao.DataDevolucaoEfetiva = dateTimePickerDevolucaoEfetiva.Value.Date;
            locacao.QuilometragemFinalVeiculo = (int)numericUpDownKmFinal.Value;
            if (comboBoxNivelTanque.SelectedIndex != -1)
            {
                NivelTanque nivel = 0;

                switch (comboBoxNivelTanque.Text)
                {
                    case "Vazio":
                        nivel = NivelTanque.Vazio;
                        break;
                    case "Um quarto":
                        nivel = NivelTanque.UmQuarto;
                        break;
                    case "Meio":
                        nivel = NivelTanque.Meio;
                        break;
                    case "Três quartos":
                        nivel = NivelTanque.TresQuartos;
                        break;
                    case "Cheio":
                        nivel = NivelTanque.Cheio;
                        break;
                }

                locacao.NivelTanqueDevolucao = nivel;
            }

            ObterTaxasDevolucaoSelecionadas();
            foreach (var item in taxasDevolucaoSelecionadas)
            {
                locacao.TaxasSelecionadas.Add(item);
            }

            locacao.ValorTotalEfetivo = CalcularValorTotalEfetivo();
        }

        private decimal CalcularValorTotalEfetivo()
        {
            var valor = calculadoraDevolucao.CalcularValorTotalEfetivo(locacao);
            return valor;
        }

        private void ObterTaxasDevolucaoSelecionadas()
        {
            taxasDevolucaoSelecionadas.Clear();
            for (int i = 0; i < checkedListBoxTaxasDevolucao.CheckedItems.Count; i++)
            {
                var taxa = (Taxa)checkedListBoxTaxasDevolucao.CheckedItems[i];
                taxasDevolucaoSelecionadas.Add(taxa);
            }
        }

        #endregion
    }
}
