using Microsoft.Extensions.Configuration;
using Serilog;
using System.IO;

namespace Locadora_Veiculos.Infra.Logging
{
    public class ConfiguracaoLogsLocadora
    {
        public static void ConfigurarEscritaLogs()
        {
            string caminhoDiretorioLogs = ObterCaminhoDiretorioLogs();

            var configuracaoLogsEmArquivo = new LoggerConfiguration()
               .MinimumLevel.Debug()
               .WriteTo.Debug()
               .WriteTo.File(caminhoDiretorioLogs + "\\log.txt",
               rollingInterval: RollingInterval.Day,
               outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}");
            
            var configuracaoLogsNaWeb = new LoggerConfiguration()
               .MinimumLevel.Debug()
               .WriteTo.Debug()
               .WriteTo.Seq("http://localhost:5341");
            
            //Log.Logger = configuracaoLogsNaWeb.CreateLogger();
            Log.Logger = configuracaoLogsEmArquivo.CreateLogger();
        }

        private static string ObterCaminhoDiretorioLogs()
        {
            var configuracao = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("ConfiguracaoAplicacao.json")
                .Build();

            var caminho = configuracao
                 .GetSection("ConfiguracaoLogs")
                .GetSection("DiretorioSaida")
                .Value;

            return caminho;
        }
    }
}