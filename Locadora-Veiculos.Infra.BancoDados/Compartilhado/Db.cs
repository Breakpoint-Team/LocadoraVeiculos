using Locadora_Veiculos.Infra.Configs;
using System.Data.SqlClient;

namespace Locadora_Veiculos.Infra.BancoDados.Compartilhado
{
    public static class Db
    {
        private static ConfiguracaoAplicacao config = new ConfiguracaoAplicacao();

        private static string connectionString = config.ConnectionStrings.SqlServer;

        public static void ExecutarSql(string sql)
        {
            SqlConnection conexaoComBanco = new SqlConnection(connectionString);

            SqlCommand comando = new SqlCommand(sql, conexaoComBanco);

            conexaoComBanco.Open();
            comando.ExecuteNonQuery();
            conexaoComBanco.Close();
        }
    }
}