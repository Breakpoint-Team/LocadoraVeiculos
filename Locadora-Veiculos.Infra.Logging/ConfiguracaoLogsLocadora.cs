using Locadora_Veiculos.Infra.Configs;
using Serilog;

namespace Locadora_Veiculos.Infra.Logging
{
    public class ConfiguracaoLogsLocadora
    {
        public static void ConfigurarEscritaLogs()
        {
            var config = new ConfiguracaoAplicacao();

            string diretorioSaida = config.ConfiguracaoLogs.DiretorioSaida;

            var configuracaoLogsEmArquivo = new LoggerConfiguration()
               .MinimumLevel.Debug()
               .WriteTo.Debug()
               .WriteTo.File(diretorioSaida + "\\log.txt",
               rollingInterval: RollingInterval.Day,
               outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}");

            var configuracaoLogsNaWeb = new LoggerConfiguration()
               .MinimumLevel.Debug()
               .WriteTo.Debug()
               .WriteTo.Seq("http://localhost:5341");

            //Log.Logger = configuracaoLogsNaWeb.CreateLogger();
            Log.Logger = configuracaoLogsEmArquivo.CreateLogger();
        }
    }
}