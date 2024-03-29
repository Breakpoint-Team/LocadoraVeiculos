﻿using Locadora_Veiculos.Dominio.ModuloTaxa;
using Locadora_Veiculos.Infra.BancoDados.Compartilhado;
using System;
using System.Data.SqlClient;

namespace Locadora_Veiculos.Infra.BancoDados.ModuloTaxa
{
    public class RepositorioTaxaEmBancoDados :
        RepositorioBase<Taxa, MapeadorTaxa>,
        IRepositorioTaxa
    {
        protected override string sqlInserir =>
            @"INSERT INTO [TBTAXA]
                (
                    [ID],
                    [DESCRICAO],
                    [VALOR],
                    [TIPOCALCULO]
                )
            VALUES
                (
                    @ID,
                    @DESCRICAO,
                    @VALOR,
                    @TIPOCALCULO
                );";

        protected override string sqlEditar =>
            @" UPDATE [TBTAXA]
                    SET 
                        [DESCRICAO] = @DESCRICAO,
                        [VALOR] = @VALOR,
                        [TIPOCALCULO] = @TIPOCALCULO
                    WHERE [ID] = @ID";

        protected override string sqlExcluir =>
            @"DELETE FROM [TBTAXA]
                WHERE [ID] = @ID";

        protected override string sqlSelecionarPorId =>
            @"SELECT 
                [ID],       
                [DESCRICAO],
                [VALOR],
                [TIPOCALCULO]
            FROM
                [TBTAXA]
            WHERE 
             [ID] = @ID";

        protected override string sqlSelecionarTodos =>
            @"SELECT 
                [ID],       
                [DESCRICAO],
                [VALOR],
                [TIPOCALCULO]
            FROM
                [TBTAXA]";

        protected string sqlSelecionarTaxaPorDescricao =>
            @"SELECT 
                [ID],       
                [DESCRICAO],
                [VALOR],
                [TIPOCALCULO]
            FROM
                [TBTAXA]
            WHERE 
             [DESCRICAO] = @DESCRICAO";

        private string sqlCountTaxas =>
           @"SELECT COUNT(*) 
                FROM TBTAXA;";

        public int QuantidadeTaxasCadastradas()
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comando = new SqlCommand(sqlCountTaxas, conexaoComBanco);

            conexaoComBanco.Open();

            var count = Convert.ToInt32(comando.ExecuteScalar());

            return count;
        }

        public Taxa SelecionarTaxaPorDescricao(string descricao)
        {
            return SelecionarPorParametro(sqlSelecionarTaxaPorDescricao, new SqlParameter("DESCRICAO", descricao));
        }
    }
}