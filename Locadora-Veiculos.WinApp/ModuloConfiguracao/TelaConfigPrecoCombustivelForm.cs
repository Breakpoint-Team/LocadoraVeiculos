using Locadora_Veiculos.Dominio.ModuloConfiguracao;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace Locadora_Veiculos.WinApp.ModuloConfiguracao
{
    public partial class TelaConfigPrecoCombustivelForm : Form
    {
        public TelaConfigPrecoCombustivelForm()
        {
            InitializeComponent();
            ExibirDados();

        }

        private void ExibirDados()
        {
            try
            {
                var json = File.ReadAllText("arquivoConfig.json");
                var jObject = JObject.Parse(json);
                numPrecoGNV.Value = (decimal)jObject["PrecoGNV"];
                numPrecoGasolina.Value = (decimal)jObject["PrecoGasolina"];
                numPrecoDiesel.Value = (decimal)jObject["PrecoDiesel"];
                numPrecoAlcool.Value = (decimal)jObject["PrecoAlcool"];
                data.Value = (DateTime)jObject["DataAtualizacao"];

            }
            catch
            {

            }

        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            var registro = new PrecoCombustivel()
            {
                PrecoAlcool = numPrecoAlcool.Value,
                PrecoDiesel = numPrecoDiesel.Value,
                PrecoGasolina = numPrecoGasolina.Value,
                PrecoGNV = numPrecoGNV.Value,
                DataAtualizacao = DateTime.Now
            };

            string arquivo = "arquivoConfig.json";

            string jsonString = JsonSerializer.Serialize(registro);
            File.WriteAllText(arquivo, jsonString);

        }



    }
}
