using Locadora_Veiculos.Infra.Configs;
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
            txtDiretorioRelatorios.Text = configuracao.ConfiguracaoRelatorio.DiretorioSaida;
            txtDiretorioLogs.Text = configuracao.ConfiguracaoLogs.DiretorioSaida;
            numPrecoGNV.Value = configuracao.ConfiguracaoPrecoCombustivel.PrecoGNV;
            numPrecoGasolina.Value = configuracao.ConfiguracaoPrecoCombustivel.PrecoGasolina;
            numPrecoDiesel.Value = configuracao.ConfiguracaoPrecoCombustivel.PrecoDiesel;
            numPrecoAlcool.Value = configuracao.ConfiguracaoPrecoCombustivel.PrecoAlcool;
            txtDataAtualizacao.Text = configuracao.ConfiguracaoPrecoCombustivel.DataAtualizacao.ToString();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            var newConfig = new ConfiguracaoAplicacao();
            newConfig.ConfiguracaoRelatorio = new ConfiguracaoRelatorio()
            {
                DiretorioSaida = txtDiretorioRelatorios.Text
            };
            newConfig.ConfiguracaoLogs = new ConfiguracaoLogs() {
                DiretorioSaida = txtDiretorioLogs.Text
            };
            newConfig.ConfiguracaoPrecoCombustivel = new ConfiguracaoPrecoCombustivel
            {
                PrecoAlcool = numPrecoAlcool.Value,
                PrecoDiesel = numPrecoDiesel.Value,
                PrecoGasolina = numPrecoGasolina.Value,
                PrecoGNV = numPrecoGNV.Value,
                DataAtualizacao = DateTime.Now.ToString()
            };

            configuracao.Atualizar(newConfig);

            MessageBox.Show("Configurações gravadas com sucesso!", "Configurações",MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
