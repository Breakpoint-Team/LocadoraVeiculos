using Locadora_Veiculos.Infra.Logging;
using Locadora_Veiculos.WinApp.Compartilhado.Servicelocator;
using System;
using System.Windows.Forms;

namespace Locadora_Veiculos.WinApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            //MigradorBancoDadosLocadoraVeiculos.AtualizarBancoDados();
            ConfiguracaoLogsLocadora.ConfigurarEscritaLogs();
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            IServiceLocator servicelocator = new ServiceLocatorComAutoFac();

            Application.Run(new TelaPrincipalForm(servicelocator));

        }
    }
}