using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace Locadora_Veiculos.Infra.BancoDados.Compartilhado
{
    public static class Db
    {
        private static IConfigurationRoot configuracao = new ConfigurationBuilder()
                  .SetBasePath(Directory.GetCurrentDirectory())
                  .AddJsonFile("ConfiguracaoAplicacao.json")
                  .Build();

        public static string enderecoBanco = configuracao.GetConnectionString("SqlServer");

        public static void ExecutarSql(string sql)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comando = new SqlCommand(sql, conexaoComBanco);

            conexaoComBanco.Open();
            comando.ExecuteNonQuery();
            conexaoComBanco.Close();
        }
    }
}