using Locadora_Veiculos.Dominio.ModuloGrupoVeiculos;
using Locadora_Veiculos.Infra.BancoDados.Compartilhado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora_Veiculos.Infra.BancoDados.ModuloGrupoVeiculos
{
    public class MapeadorGrupoVeiculos : MapeadorBase<GrupoVeiculos>
    {
        public override void ConfigurarParametros(GrupoVeiculos registro, SqlCommand comando)
        {
            throw new NotImplementedException();
        }

        public override GrupoVeiculos ConverterRegistro(SqlDataReader leitorRegistro)
        {
            throw new NotImplementedException();
        }
    }
}
