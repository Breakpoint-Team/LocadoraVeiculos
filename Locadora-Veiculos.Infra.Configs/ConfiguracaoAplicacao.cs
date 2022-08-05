using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Locadora_Veiculos.Infra.Configs
{
    public class ConfiguracaoAplicacao
    {
        public ConfiguracaoAplicacao()
        {
            IConfiguration configuracao = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("ConfiguracaoAplicacao.json")
                .Build();


            var connectionString = configuracao.GetConnectionString("SqlServer");
            ConnectionStrings = new ConnectionStrings { SqlServer = connectionString };

            var diretorioSaida = configuracao
                .GetSection("ConfiguracaoLogs")
                .GetSection("DiretorioSaida")
                .Value;
            ConfiguracaoLogs = new ConfiguracaoLogs { DiretorioSaida = diretorioSaida };


            #region PrecoCombustivel
            var precoGNV = configuracao
             .GetSection("ConfiguracaoPrecoCombustivel")
             .GetSection("PrecoGNV")
             .Value;
            var auxGNV = precoGNV.Replace('.', ',');
            decimal pGNV = Convert.ToDecimal(auxGNV);

            var precoGasolina = configuracao
             .GetSection("ConfiguracaoPrecoCombustivel")
             .GetSection("PrecoGasolina")
             .Value;

            var auxGasolina = precoGasolina.Replace('.', ',');
            decimal pGasolina = Convert.ToDecimal(auxGasolina);

            var precoDiesel = configuracao
             .GetSection("ConfiguracaoPrecoCombustivel")
             .GetSection("PrecoDiesel")
             .Value;

            var auxDiesel = precoDiesel.Replace('.', ',');
            decimal pDiesel = Convert.ToDecimal(auxDiesel);

            var precoAlcool = configuracao
             .GetSection("ConfiguracaoPrecoCombustivel")
             .GetSection("PrecoAlcool")
             .Value;

            var auxAlcool = precoAlcool.Replace('.', ',');
            decimal pAlcool = Convert.ToDecimal(auxAlcool);

            var data = configuracao
             .GetSection("ConfiguracaoPrecoCombustivel")
             .GetSection("DataAtualizacao")
             .Value;
            #endregion

            ConfiguracaoPrecoCombustivel = new ConfiguracaoPrecoCombustivel
            {
                PrecoGNV = pGNV,
                PrecoGasolina = pGasolina,
                PrecoDiesel = pDiesel,
                PrecoAlcool = pAlcool,
                DataAtualizacao = data
            };


        }

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

    public class ConfiguracaoPrecoCombustivel
    {
        public decimal PrecoGasolina { get; set; }
        public decimal PrecoDiesel { get; set; }
        public decimal PrecoAlcool { get; set; }
        public decimal PrecoGNV { get; set; }
        public string DataAtualizacao { get; set; }
    }

}
