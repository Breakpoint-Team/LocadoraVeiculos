using Locadora_Veiculos.Dominio.ModuloPlanoCobranca;
using Locadora_Veiculos.Infra.BancoDados.Compartilhado;
using Locadora_Veiculos.Infra.BancoDados.ModuloGrupoVeiculos;
using System;
using System.Data.SqlClient;

namespace Locadora_Veiculos.Infra.BancoDados.ModuloPlanoCobranca
{
    public class MapeadorPlanoCobranca : MapeadorBase<PlanoCobranca>
    {
        public override void ConfigurarParametros(PlanoCobranca registro, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", registro.Id);
            comando.Parameters.AddWithValue("DIARIO_VALOR_DIA", registro.DiarioValorDia);
            comando.Parameters.AddWithValue("DIARIO_VALOR_KM", registro.DiarioValorKm);
            comando.Parameters.AddWithValue("KM_CONTROLADO_VALOR_DIA", registro.KmControladoValorDia);
            comando.Parameters.AddWithValue("KM_CONTROLADO_VALOR_KM", registro.KmControladoValorKm);
            comando.Parameters.AddWithValue("KM_CONTROLADO_LIMITE_KM", registro.KmControladoLimiteKm);
            comando.Parameters.AddWithValue("KM_LIVRE_VALOR_DIA", registro.KmLivreValorDia);
            comando.Parameters.AddWithValue("ID_GRUPO_VEICULOS", registro.GrupoVeiculos.Id);
        }

        public override PlanoCobranca ConverterRegistro(SqlDataReader leitorRegistro)
        {
            var id = Guid.Parse(leitorRegistro["PLANO_ID"].ToString());
            var diarioValorDia = Convert.ToDecimal(leitorRegistro["PLANO_DIARIO_VALOR_DIA"]);
            var diarioValorKm = Convert.ToDecimal(leitorRegistro["PLANO_DIARIO_VALOR_KM"]);
            var kmControladoValorDia = Convert.ToDecimal(leitorRegistro["PLANO_KM_CONTROLADO_VALOR_DIA"]);
            var kmControladoValorKm = Convert.ToDecimal(leitorRegistro["PLANO_KM_CONTROLADO_VALOR_KM"]);
            var kmControladoLimiteKm = Convert.ToDecimal(leitorRegistro["PLANO_KM_CONTROLADO_LIMITE_KM"]);
            var kmLivreValorDia = Convert.ToDecimal(leitorRegistro["PLANO_KM_LIVRE_VALOR_DIA"]);

            PlanoCobranca plano = new PlanoCobranca()
            {
                Id = id,
                DiarioValorDia = diarioValorDia,
                DiarioValorKm = diarioValorKm,
                KmControladoValorDia = kmControladoValorDia,
                KmControladoValorKm = kmControladoValorKm,
                KmControladoLimiteKm = kmControladoLimiteKm,
                KmLivreValorDia = kmLivreValorDia
            };

            var grupo = new MapeadorGrupoVeiculos().ConverterRegistro(leitorRegistro);
            plano.GrupoVeiculos = grupo;

            return plano;
        }
    }
}