﻿using Locadora_Veiculos.Infra.Configs;
using System;
using System.Windows.Forms;

namespace Locadora_Veiculos.WinApp.ModuloConfiguracao
{
    public partial class ConfiguracaoControl : UserControl
    {
        private ConfiguracaoAplicacao configuracao;
        public ConfiguracaoControl(ConfiguracaoAplicacao configuracao)
        {
            InitializeComponent();
            this.configuracao = new ConfiguracaoAplicacao();

            ExibirConfigPrecoCombustivel(configuracao);
        }

        private void ExibirConfigPrecoCombustivel(ConfiguracaoAplicacao configuracao)
        {
            txtDiretorioLogs.Text = configuracao.ConfiguracaoLogs.DiretorioSaida;
            numPrecoGNV.Value = configuracao.ConfiguracaoPrecoCombustivel.PrecoGNV;
            numPrecoGasolina.Value = configuracao.ConfiguracaoPrecoCombustivel.PrecoGasolina;
            numPrecoDiesel.Value = configuracao.ConfiguracaoPrecoCombustivel.PrecoDiesel;
            numPrecoAlcool.Value = configuracao.ConfiguracaoPrecoCombustivel.PrecoAlcool;
            txtDataAtualizacao.Text = configuracao.ConfiguracaoPrecoCombustivel.DataAtualizacao;
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {


            MessageBox.Show("Configuração gravada com sucesso!", "Configuração", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }


    }
}
