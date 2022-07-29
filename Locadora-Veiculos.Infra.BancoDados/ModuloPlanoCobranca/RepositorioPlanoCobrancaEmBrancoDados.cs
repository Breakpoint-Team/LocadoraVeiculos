using Locadora_Veiculos.Dominio.ModuloPlanoCobranca;
using Locadora_Veiculos.Infra.BancoDados.Compartilhado;
using System;
using System.Data.SqlClient;

namespace Locadora_Veiculos.Infra.BancoDados.ModuloPlanoCobranca
{
    public class RepositorioPlanoCobrancaEmBancoDados :
        RepositorioBase<PlanoCobranca, MapeadorPlanoCobranca>,
        IRepositorioPlanoCobranca
    {
        protected override string sqlInserir =>
            @"INSERT INTO [TBPLANOCOBRANCA]
				(
					[ID],
					[DIARIO_VALOR_DIA],
					[DIARIO_VALOR_KM],
					[KM_CONTROLADO_VALOR_DIA],
					[KM_CONTROLADO_VALOR_KM],
					[KM_CONTROLADO_LIMITE_KM],
					[KM_LIVRE_VALOR_DIA],
					[ID_GRUPO_VEICULOS]
				)
			VALUES
				(
					@ID,
					@DIARIO_VALOR_DIA,
					@DIARIO_VALOR_KM,
					@KM_CONTROLADO_VALOR_DIA,
					@KM_CONTROLADO_VALOR_KM,
					@KM_CONTROLADO_LIMITE_KM,
					@KM_LIVRE_VALOR_DIA,
					@ID_GRUPO_VEICULOS
				);";

        protected override string sqlEditar =>
            @"UPDATE [TBPLANOCOBRANCA]
				SET 
					[DIARIO_VALOR_DIA] = @DIARIO_VALOR_DIA,
					[DIARIO_VALOR_KM] = @DIARIO_VALOR_KM,
					[KM_CONTROLADO_VALOR_DIA] = @KM_CONTROLADO_VALOR_DIA,
					[KM_CONTROLADO_VALOR_KM] = @KM_CONTROLADO_VALOR_KM,
					[KM_CONTROLADO_LIMITE_KM] = @KM_CONTROLADO_LIMITE_KM,
					[KM_LIVRE_VALOR_DIA] = @KM_LIVRE_VALOR_DIA,
					[ID_GRUPO_VEICULOS] = @ID_GRUPO_VEICULOS 
				WHERE
					 [ID] = @ID";

        protected override string sqlExcluir =>
            @"DELETE FROM [TBPLANOCOBRANCA]
				WHERE [ID] = @ID";

        protected override string sqlSelecionarPorId =>
            @"SELECT 
                PLANO.[ID] AS PLANO_ID,
                PLANO.[DIARIO_VALOR_DIA] AS PLANO_DIARIO_VALOR_DIA,
                PLANO.[DIARIO_VALOR_KM] AS PLANO_DIARIO_VALOR_KM,
                PLANO.[KM_CONTROLADO_VALOR_DIA] AS PLANO_KM_CONTROLADO_VALOR_DIA,
                PLANO.[KM_CONTROLADO_VALOR_KM] AS PLANO_KM_CONTROLADO_VALOR_KM,
                PLANO.[KM_CONTROLADO_LIMITE_KM] AS PLANO_KM_CONTROLADO_LIMITE_KM,
                PLANO.[KM_LIVRE_VALOR_DIA] PLANO_KM_LIVRE_VALOR_DIA,

                GRUPO.[ID] AS GRUPOVEICULOS_ID,
                GRUPO.[NOME] AS GRUPOVEICULOS_NOME
            FROM
                [TBPLANOCOBRANCA] AS PLANO INNER JOIN [TBGRUPOVEICULOS] AS GRUPO
            ON 
                PLANO.[ID_GRUPO_VEICULOS] = GRUPO.[ID]
            WHERE
                PLANO.[ID] = @ID";

        protected override string sqlSelecionarTodos =>
            @"SELECT 
                PLANO.[ID] AS PLANO_ID,
                PLANO.[DIARIO_VALOR_DIA] AS PLANO_DIARIO_VALOR_DIA,
                PLANO.[DIARIO_VALOR_KM] AS PLANO_DIARIO_VALOR_KM,
                PLANO.[KM_CONTROLADO_VALOR_DIA] AS PLANO_KM_CONTROLADO_VALOR_DIA,
                PLANO.[KM_CONTROLADO_VALOR_KM] AS PLANO_KM_CONTROLADO_VALOR_KM,
                PLANO.[KM_CONTROLADO_LIMITE_KM] AS PLANO_KM_CONTROLADO_LIMITE_KM,
                PLANO.[KM_LIVRE_VALOR_DIA] PLANO_KM_LIVRE_VALOR_DIA,

                GRUPO.[ID] AS GRUPOVEICULOS_ID,
                GRUPO.[NOME] AS GRUPOVEICULOS_NOME
            FROM
                [TBPLANOCOBRANCA] AS PLANO INNER JOIN [TBGRUPOVEICULOS] AS GRUPO
            ON 
                PLANO.[ID_GRUPO_VEICULOS] = GRUPO.[ID]";

        private string sqlSelecionarPlanoPorIdDoGrupoVeiculo =>
            @"SELECT 
                PLANO.[ID] AS PLANO_ID,
                PLANO.[DIARIO_VALOR_DIA] AS PLANO_DIARIO_VALOR_DIA,
                PLANO.[DIARIO_VALOR_KM] AS PLANO_DIARIO_VALOR_KM,
                PLANO.[KM_CONTROLADO_VALOR_DIA] AS PLANO_KM_CONTROLADO_VALOR_DIA,
                PLANO.[KM_CONTROLADO_VALOR_KM] AS PLANO_KM_CONTROLADO_VALOR_KM,
                PLANO.[KM_CONTROLADO_LIMITE_KM] AS PLANO_KM_CONTROLADO_LIMITE_KM,
                PLANO.[KM_LIVRE_VALOR_DIA] PLANO_KM_LIVRE_VALOR_DIA,

                GRUPO.[ID] AS GRUPOVEICULOS_ID,
                GRUPO.[NOME] AS GRUPOVEICULOS_NOME
            FROM
                [TBPLANOCOBRANCA] AS PLANO INNER JOIN [TBGRUPOVEICULOS] AS GRUPO
            ON 
                PLANO.[ID_GRUPO_VEICULOS] = GRUPO.[ID]
            WHERE
                GRUPO.[ID] = @ID";

        private string sqlCountPlanos =>
            @"SELECT COUNT(*) 
                FROM TBPLANOCOBRANCA;";

        public int QuantidadePlanosCadastrados()
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comando = new SqlCommand(sqlCountPlanos, conexaoComBanco);

            conexaoComBanco.Open();

            var count = Convert.ToInt32(comando.ExecuteScalar());

            return count;
        }

        public PlanoCobranca SelecionarPlanoPorIdDoGrupoVeiculos(Guid idGrupoVeiculo)
        {
            return SelecionarPorParametro(sqlSelecionarPlanoPorIdDoGrupoVeiculo, new SqlParameter("ID", idGrupoVeiculo));
        }
    }
}