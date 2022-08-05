using Microsoft.Extensions.Configuration;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Locadora_Veiculos.Infra.Configs
{
    public class ConfiguracaoAplicacao
    {
        public ConfiguracaoAplicacao()
        {
            var configuracao = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("ConfiguracaoAplicacao.json")
                .Build()
                .Get<Config>();

            var connectionString = configuracao.ConnectionStrings.SqlServer;
            ConnectionStrings = new ConnectionStrings { SqlServer = connectionString };

            var diretorioSaida = configuracao.ConfiguracaoLogs.DiretorioSaida;
            ConfiguracaoLogs = new ConfiguracaoLogs { DiretorioSaida = diretorioSaida };


            var precoGNV = configuracao.ConfiguracaoPrecoCombustivel.PrecoGNV;
            var precoAlcool = configuracao.ConfiguracaoPrecoCombustivel.PrecoAlcool;
            var precoGasolina = configuracao.ConfiguracaoPrecoCombustivel.PrecoGasolina;
            var precoDiesel = configuracao.ConfiguracaoPrecoCombustivel.PrecoDiesel;
            var dataAtualizacao = configuracao.ConfiguracaoPrecoCombustivel.DataAtualizacao;
            ConfiguracaoPrecoCombustivel = new ConfiguracaoPrecoCombustivel {
                PrecoGNV = precoGNV,
                PrecoAlcool = precoAlcool,
                PrecoGasolina = precoGasolina,
                PrecoDiesel = precoDiesel,
                DataAtualizacao = dataAtualizacao
            };


        }


        public ConfiguracaoLogs ConfiguracaoLogs { get; set; }

        public ConnectionStrings ConnectionStrings { get; set; }

        public ConfiguracaoPrecoCombustivel ConfiguracaoPrecoCombustivel { get; set; }
        public void Atualizar(ConfiguracaoAplicacao novaConfig)
        {
            var c = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("ConfiguracaoAplicacao.json")
            .Build()
            .Get<Config>();

            c.ConfiguracaoLogs.DiretorioSaida = novaConfig.ConfiguracaoLogs.DiretorioSaida;
            c.ConfiguracaoPrecoCombustivel.PrecoAlcool = novaConfig.ConfiguracaoPrecoCombustivel.PrecoAlcool;
            c.ConfiguracaoPrecoCombustivel.PrecoGNV = novaConfig.ConfiguracaoPrecoCombustivel.PrecoGNV;
            c.ConfiguracaoPrecoCombustivel.PrecoGasolina = novaConfig.ConfiguracaoPrecoCombustivel.PrecoGasolina;
            c.ConfiguracaoPrecoCombustivel.PrecoDiesel = novaConfig.ConfiguracaoPrecoCombustivel.PrecoDiesel;
            c.ConfiguracaoPrecoCombustivel.DataAtualizacao = novaConfig.ConfiguracaoPrecoCombustivel.DataAtualizacao;

            var jsonWriteOptions = new JsonSerializerOptions()
            {
                WriteIndented = true
            };

            jsonWriteOptions.Converters.Add(new JsonStringEnumConverter());

            var newJson = System.Text.Json.JsonSerializer.Serialize(c, jsonWriteOptions);
            var appSettingsPath = Path.Combine("..\\..\\..\\.\\", "ConfiguracaoAplicacao.json");
            File.WriteAllText(appSettingsPath, newJson);
        }

    }

    public class Config
    {
        public ConfiguracaoLogs ConfiguracaoLogs { get; set; }
        public ConnectionStrings ConnectionStrings { get; set; }
        public ConfiguracaoPrecoCombustivel ConfiguracaoPrecoCombustivel { get; set; }

    }

    public class ConfiguracaoLogs
    {
        public string DiretorioSaida { get; set; }
    }

    public class ConnectionStrings
    {
        public string SqlServer { get; set; }
    }

    public class ConfiguracaoPrecoCombustivel {
        public decimal PrecoGasolina { get; set; }
        public decimal PrecoDiesel { get; set; }
        public decimal PrecoAlcool { get; set; }
        public decimal PrecoGNV { get; set; }
        public string DataAtualizacao { get; set; }
    }

}
