using Serilog;

namespace Locadora_Veiculos.Infra.Logging
{
    public class ConfiguracaoLogsLocadora
    {
        public static void ConfigurarEscritaLogs()
        {
            Log.Logger = new LoggerConfiguration()
               .MinimumLevel.Debug()
               .WriteTo.File("logs/log.txt",
               rollingInterval: RollingInterval.Day,
               outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
               .CreateLogger();
        }
    }
}
