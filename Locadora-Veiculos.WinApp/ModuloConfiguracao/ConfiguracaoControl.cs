using Locadora_Veiculos.Dominio.ModuloConfiguracao;
using Locadora_Veiculos.Infra.Configs;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Text.Json;
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
         
            //var registro = new PrecoCombustivel()
            //{
            //    PrecoAlcool = numPrecoAlcool.Value,
            //    PrecoDiesel = numPrecoDiesel.Value,
            //    PrecoGasolina = numPrecoGasolina.Value,
            //    PrecoGNV = numPrecoGNV.Value,
            //    DataAtualizacao = DateTime.Now
            //};

            //string arquivo = "ConfiguracaoAplicacao.json";
            //string jsonString = JsonSerializer.Serialize(registro);
            //File.WriteAllText(arquivo, jsonString);

            //MessageBox.Show("Configuração gravada com sucesso!", "Configuração",MessageBoxButtons.OK, MessageBoxIcon.Information) ;

        }


    }
}
