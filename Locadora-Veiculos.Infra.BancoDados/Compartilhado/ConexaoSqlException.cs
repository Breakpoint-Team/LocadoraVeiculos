
using System;

namespace Locadora_Veiculos.Infra.BancoDados.Compartilhado
{
    public class ConexaoSqlException: Exception
    {
        public ConexaoSqlException(Exception ex): base("", ex)
        {

        }
    }
}