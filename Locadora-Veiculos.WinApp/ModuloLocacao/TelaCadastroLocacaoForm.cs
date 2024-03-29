﻿using FluentResults;
using Locadora_Veiculos.Dominio.ModuloCliente;
using Locadora_Veiculos.Dominio.ModuloCondutor;
using Locadora_Veiculos.Dominio.ModuloGrupoVeiculos;
using Locadora_Veiculos.Dominio.ModuloLocacao;
using Locadora_Veiculos.Dominio.ModuloPlanoCobranca;
using Locadora_Veiculos.Dominio.ModuloTaxa;
using Locadora_Veiculos.Dominio.ModuloVeiculo;
using Locadora_Veiculos.Infra.Configs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Locadora_Veiculos.WinApp.ModuloLocacao
{
    public partial class TelaCadastroLocacaoForm : Form
    {
        private Locacao locacao;
        private List<Cliente> clientes;
        private List<Condutor> condutores;
        private List<GrupoVeiculos> gruposDeVeiculo;
        private List<Veiculo> veiculos;
        private List<Taxa> taxas;
        private List<PlanoCobranca> planosDeCobranca;
        private PlanoCobranca planoTela;
        private GrupoVeiculos grupoTela;
        private CalculadoraValoresLocacao calculadora;
        private readonly ConfiguracaoAplicacao configuracao;
        public TelaCadastroLocacaoForm(List<Cliente> clientes, List<Condutor> condutores,
            List<GrupoVeiculos> gruposDeVeiculo, List<Veiculo> veiculos,
            List<Taxa> taxas, List<PlanoCobranca> planosDeCobranca)
        {
            InitializeComponent();

            this.clientes = clientes;
            this.condutores = condutores;
            this.gruposDeVeiculo = gruposDeVeiculo;
            this.veiculos = veiculos;
            this.taxas = taxas;
            this.planosDeCobranca = planosDeCobranca;
            this.configuracao = new ConfiguracaoAplicacao();
            calculadora = new CalculadoraValoresLocacao(configuracao);
            dateTimePickerDataDevolucaoPrevista.MinDate = DateTime.Today;
            dateTimePickerDataDevolucaoPrevista.MaxDate = DateTime.Today.AddDays(30);
            CarregarClientes();
            CarregarGrupos();
            CarregarTaxas();
        }

        public Locacao Locacao
        {
            get => locacao;
            set
            {
                locacao = value;
                PreencherDadosNaTela();
            }
        }

        public Func<Locacao, Result<Locacao>> GravarRegistro { get; set; }


        #region MÉTODOS PRIVADOS

        private void ObterDadosTela()
        {
            if (comboBoxCondutores.SelectedIndex != -1)
                locacao.ConfigurarCondutor((Condutor)comboBoxCondutores.SelectedItem);

            if (comboBoxVeiculos.SelectedIndex != -1)
            {
                locacao.ConfigurarVeiculo((Veiculo)comboBoxVeiculos.SelectedItem);
                locacao.QuilometragemInicialVeiculo = locacao.Veiculo.QuilometragemPercorrida;
            }

            if (comboBoxGrupoVeiculos.SelectedIndex != -1)
            {
                grupoTela = ((GrupoVeiculos)comboBoxGrupoVeiculos.SelectedItem);
                locacao.PlanoCobranca = planosDeCobranca.Find(x => x.GrupoVeiculos == grupoTela);
            }

            locacao.TipoPlanoSelecionado = ObterTipoPlanoSelecionado();
            locacao.TaxasSelecionadas = ObterTaxasSelecionadas();
            locacao.DataLocacao = DateTime.Today;
            locacao.DataDevolucaoPrevista = dateTimePickerDataDevolucaoPrevista.Value.Date;
        }

        private decimal CalcularValorTotalPrevisto()
        {
            ObterDadosTela();

            var resultado = calculadora.CalcularValorTotalPrevisto(locacao);
            return resultado;
        }

        private void AtualizarLabelValorTotalPrevisto()
        {
            var valor = Math.Round(CalcularValorTotalPrevisto(), 2);

            labelValorPrevisto.Text = "R$ " + valor;
        }

        private void CarregarClientes()
        {
            if (clientes.Count > 0)
                foreach (var cliente in clientes)
                    comboBoxClientes.Items.Add(cliente);
        }

        private void CarregarGrupos()
        {
            if (gruposDeVeiculo.Count > 0)
                foreach (var grupo in gruposDeVeiculo)
                    comboBoxGrupoVeiculos.Items.Add(grupo);
        }

        private void CarregarTaxas()
        {
            if (taxas.Count > 0)
                foreach (var taxa in taxas)
                    if (taxa.TipoTaxa == TipoTaxa.TaxaLocacao)
                        checkedListBoxTaxas.Items.Add(taxa);
        }

        private void CarregarCondutores(Cliente cliente)
        {
            comboBoxCondutores.Items.Clear();

            var condutoresCliente = condutores.FindAll(x => x.Cliente == cliente);

            if (condutoresCliente.Count > 0)
                foreach (var condutor in condutoresCliente)
                    comboBoxCondutores.Items.Add(condutor);
        }

        private void CarregarVeiculos(GrupoVeiculos grupo)
        {
            comboBoxVeiculos.Items.Clear();

            var veiculosGrupo = veiculos.FindAll(x => x.GrupoVeiculos == grupo);

            if (veiculosGrupo.Count > 0)
                foreach (var veiculo in veiculosGrupo)
                    comboBoxVeiculos.Items.Add(veiculo);
        }

        private void CarregarPlanoSelecionado(GrupoVeiculos grupo)
        {
            labelGrupoVeiculos.Text = grupo.Nome;

            var planoCobrancaGrupo = planosDeCobranca.Find(x => x.GrupoVeiculos == grupo);
            if (planoCobrancaGrupo != null)
            {
                planoTela = planoCobrancaGrupo;
                labelDiarioValorDia.Text = $"R$ {planoCobrancaGrupo.DiarioValorDia}";
                labelDiarioValorKm.Text = $"R$ {planoCobrancaGrupo.DiarioValorKm}";

                labelKmControladoValorDia.Text = $"R$ {planoCobrancaGrupo.KmControladoValorDia}";
                labelKmControladoValorKm.Text = $"R$ {planoCobrancaGrupo.KmControladoValorKm}";
                labelKmControladoLimiteKm.Text = $"{planoCobrancaGrupo.KmControladoLimiteKm} Km";

                labelKmLivreValorDia.Text = $"R$ {planoCobrancaGrupo.KmLivreValorDia}";
            }
            else
            {
                MessageBox.Show("O grupo de veículos selecionado ainda não possui um plano de cobrança relacionado!",
                    "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void ExibirImagem(byte[] imagem)
        {
            using (var img = new MemoryStream(imagem))
            {
                pictureBoxImagem.Image = Image.FromStream(img);
            }
        }

        private void LimparDadosVeiculoSelecionado()
        {
            labelModelo.Text = "";
            labelPlaca.Text = "";
            pictureBoxImagem.Image = null;
            pictureBoxImagem.Update();

        }

        private void ExibirDadosVeiculoSelecionado(Veiculo veiculo)
        {
            labelModelo.Text = veiculo.Modelo;
            labelPlaca.Text = veiculo.Placa;
            labelKmInicial.Text = veiculo.QuilometragemPercorrida + " Km";
            comboBoxVeiculos.SelectedItem = veiculo;
            ExibirImagem(veiculo.Imagem);
        }

        private TipoPlano ObterTipoPlanoSelecionado()
        {
            TipoPlano retorno = 0;
            if (radioButtonPlanoDiario.Checked)
                retorno = TipoPlano.Diario;
            else if (radioButtonKmControlado.Checked)
                retorno = TipoPlano.Controlado;
            else if (radioButtonKmLivre.Checked)
                retorno = TipoPlano.Livre;
            return retorno;
        }

        private List<Taxa> ObterTaxasSelecionadas()
        {
            List<Taxa> lista = new List<Taxa>();
            if (checkedListBoxTaxas.Items.Count > 0)
                lista.AddRange(checkedListBoxTaxas.CheckedItems.Cast<Taxa>().ToList());
            return lista;
        }

        private void LimparCampos()
        {
            comboBoxClientes.SelectedIndex = -1;
            comboBoxCondutores.Items.Clear();

            comboBoxVeiculos.SelectedIndex = -1;
            comboBoxGrupoVeiculos.SelectedIndex = -1;
            labelGrupoVeiculos.Text = "";

            DesabilitarCamposPlanoCobranca();
            labelValorPrevisto.Text = "";
            labelDiarioValorDia.Text = "";
            labelDiarioValorKm.Text = "";
            labelKmControladoValorDia.Text = "";
            labelKmControladoValorKm.Text = "";
            labelKmControladoLimiteKm.Text = "";
            labelKmLivreValorDia.Text = "";

            for (int i = 0; i < checkedListBoxTaxas.Items.Count; i++)
            {
                checkedListBoxTaxas.SetItemChecked(i, false);
                checkedListBoxTaxas.SetSelected(i, false);
            }

            dateTimePickerDataDevolucaoPrevista.Value = DateTime.Today;
        }

        private void PreencherDadosNaTela()
        {
            if (locacao.Condutor != null)
            {
                comboBoxClientes.SelectedItem = locacao.Condutor.Cliente;
                comboBoxCondutores.SelectedItem = locacao.Condutor;
            }

            if (locacao.Veiculo != null)
            {
                ExibirDadosVeiculoSelecionado(locacao.Veiculo);

                if (locacao.Veiculo.GrupoVeiculos != null)
                {
                    comboBoxGrupoVeiculos.SelectedItem = locacao.Veiculo.GrupoVeiculos;
                    labelGrupoVeiculos.Text = locacao.Veiculo.GrupoVeiculos.Nome;
                }
            }

            if (locacao.PlanoCobranca != null)
            {
                HabilitarCamposPlanoCobranca();

                CarregarPlanoSelecionado(locacao.Veiculo.GrupoVeiculos);

                planoTela = locacao.PlanoCobranca;

                switch (locacao.TipoPlanoSelecionado)
                {
                    case TipoPlano.Diario:
                        radioButtonPlanoDiario.Checked = true;
                        break;
                    case TipoPlano.Controlado:
                        radioButtonKmControlado.Checked = true;
                        break;
                    case TipoPlano.Livre:
                        radioButtonKmLivre.Checked = true;
                        break;
                }
            }

            if (locacao.TaxasSelecionadas.Count > 0)
            {
                var lista = locacao.TaxasSelecionadas;

                for (int i = 0; i < checkedListBoxTaxas.Items.Count; i++)
                {
                    if (lista.Contains((Taxa)checkedListBoxTaxas.Items[i]))
                        checkedListBoxTaxas.SetItemChecked(i, true);
                }
            }
            if (locacao.DataDevolucaoPrevista != new DateTime(1, 1, 1))
                dateTimePickerDataDevolucaoPrevista.Value = locacao.DataDevolucaoPrevista;
            if (locacao.ValorTotalPrevisto != 0)
                AtualizarLabelValorTotalPrevisto();
        }

        private void HabilitarCamposPlanoCobranca()
        {
            radioButtonPlanoDiario.Checked = true;
            radioButtonKmControlado.Checked = false;
            radioButtonKmLivre.Checked = false;
            radioButtonPlanoDiario.Enabled = true;
            radioButtonKmControlado.Enabled = true;
            radioButtonKmLivre.Enabled = true;
        }

        private void DesabilitarCamposPlanoCobranca()
        {
            radioButtonPlanoDiario.Checked = false;
            radioButtonKmControlado.Checked = false;
            radioButtonKmLivre.Checked = false;
            radioButtonPlanoDiario.Enabled = false;
            radioButtonKmControlado.Enabled = false;
            radioButtonKmLivre.Enabled = false;
        }

        #endregion

        #region EVENTOS

        private void btnGravar_Click(object sender, EventArgs e)
        {
            ObterDadosTela();

            locacao.ValorTotalPrevisto = CalcularValorTotalPrevisto();

            var resultadoValidacao = GravarRegistro(locacao);

            if (resultadoValidacao.IsFailed)
            {
                string erro = resultadoValidacao.Errors[0].Message;

                if (erro.StartsWith("Falha no sistema"))
                {
                    MessageBox.Show(erro,
                        "Inserção de Locação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                    DialogResult = DialogResult.None;
                }
            }
        }

        private void comboBoxClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxClientes.SelectedIndex != -1)
                CarregarCondutores((Cliente)comboBoxClientes.SelectedItem);
        }

        private void comboBoxGrupoVeiculos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxGrupoVeiculos.SelectedIndex != -1)
            {
                CarregarVeiculos((GrupoVeiculos)comboBoxGrupoVeiculos.SelectedItem);
                CarregarPlanoSelecionado((GrupoVeiculos)comboBoxGrupoVeiculos.SelectedItem);
                LimparDadosVeiculoSelecionado();
                HabilitarCamposPlanoCobranca();
                AtualizarLabelValorTotalPrevisto();
            }
            else
            {
                DesabilitarCamposPlanoCobranca();
                planoTela = null;
            }
        }

        private void comboBoxVeiculos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxVeiculos.SelectedIndex != -1)
            {
                var veiculo = (Veiculo)comboBoxVeiculos.SelectedItem;
                ExibirDadosVeiculoSelecionado(veiculo);
            }
            else
                LimparDadosVeiculoSelecionado();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void radioButtonPlanoDiario_CheckedChanged(object sender, EventArgs e)
        {
            AtualizarLabelValorTotalPrevisto();
        }

        private void radioButtonKmControlado_CheckedChanged(object sender, EventArgs e)
        {
            AtualizarLabelValorTotalPrevisto();
        }

        private void radioButtonKmLivre_CheckedChanged(object sender, EventArgs e)
        {
            AtualizarLabelValorTotalPrevisto();
        }

        private void dateTimePickerDataDevolucaoPrevista_ValueChanged(object sender, EventArgs e)
        {
            AtualizarLabelValorTotalPrevisto();
        }

        private void checkedListBoxTaxas_SelectedValueChanged(object sender, EventArgs e)
        {
            AtualizarLabelValorTotalPrevisto();
        }

        #endregion
    }
}