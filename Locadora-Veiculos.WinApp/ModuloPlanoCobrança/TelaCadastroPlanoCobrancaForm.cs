using FluentValidation.Results;
using Locadora_Veiculos.Dominio.ModuloGrupoVeiculos;
using Locadora_Veiculos.Dominio.ModuloPlanoCobranca;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Locadora_Veiculos.WinApp.ModuloPlanoCobrança
{
    public partial class TelaCadastroPlanoCobrancaForm : Form
    {
        private PlanoCobranca plano;
        private List<GrupoVeiculos> grupos;

        public TelaCadastroPlanoCobrancaForm(List<GrupoVeiculos> grupos)
        {
            InitializeComponent();

            this.grupos = grupos;

            CarregarGrupos();
        }

        public PlanoCobranca PlanoCobranca
        {
            get => plano;
            set
            {
                plano = value;
                PreencherDadosNaTela();
            }
        }

        public Func<PlanoCobranca, ValidationResult> GravarRegistro { get; set; }

        #region EVENTOS

        private void btnGravar_Click(object sender, EventArgs e)
        {
            ObterDadosTela();

            var resultadoValidacao = GravarRegistro(plano);

            if (resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;

                TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        #endregion

        #region MÉTODOS PRIVADOS

        private void ObterDadosTela()
        {
            plano.DiarioValorDia = numericUpDownDiarioValorDiario.Value;
            plano.DiarioValorKm = numericUpDownDiarioValorKm.Value;
            plano.KmControladoValorDia = numericUpDownKmControladoValorDiario.Value;
            plano.KmControladoValorKm = numericUpDownKmControladoValorKm.Value;
            plano.KmControladoLimiteKm = numericUpDownKmControladoLimiteKm.Value;
            plano.KmLivreValorDia = numericUpDownKmLivreValorDiario.Value;
            if (comboBoxGrupoVeiculos.SelectedIndex != -1)
                plano.GrupoVeiculos = (GrupoVeiculos)comboBoxGrupoVeiculos.SelectedItem;
        }

        private void PreencherDadosNaTela()
        {
            numericUpDownDiarioValorDiario.Value = plano.DiarioValorDia;
            numericUpDownDiarioValorKm.Value = plano.DiarioValorKm;
            numericUpDownKmControladoValorDiario.Value = plano.KmControladoValorDia;
            numericUpDownKmControladoValorKm.Value = plano.KmControladoValorKm;
            numericUpDownKmControladoLimiteKm.Value = plano.KmControladoLimiteKm;
            numericUpDownKmLivreValorDiario.Value = plano.KmLivreValorDia;
            comboBoxGrupoVeiculos.SelectedItem = plano.GrupoVeiculos;
        }

        private void LimparCampos()
        {
            numericUpDownDiarioValorDiario.Value = numericUpDownDiarioValorDiario.Minimum;
            numericUpDownDiarioValorKm.Value = numericUpDownDiarioValorKm.Minimum;
            numericUpDownKmControladoValorDiario.Value = numericUpDownKmControladoValorDiario.Minimum;
            numericUpDownKmControladoValorKm.Value = numericUpDownKmControladoValorKm.Minimum;
            numericUpDownKmControladoLimiteKm.Value = numericUpDownKmControladoLimiteKm.Minimum;
            numericUpDownKmLivreValorDiario.Value = numericUpDownKmLivreValorDiario.Minimum;
            comboBoxGrupoVeiculos.SelectedIndex = -1;
        }

        private void CarregarGrupos()
        {
            if (grupos.Count > 0)
                foreach (var grupo in grupos)
                    comboBoxGrupoVeiculos.Items.Add(grupo);
        }

        #endregion
    }
}