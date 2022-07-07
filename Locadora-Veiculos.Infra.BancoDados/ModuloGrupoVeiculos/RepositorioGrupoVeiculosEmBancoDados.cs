using Locadora_Veiculos.Dominio.ModuloGrupoVeiculos;
using Locadora_Veiculos.Infra.BancoDados.Compartilhado;
using System;
using System.Data.SqlClient;

namespace Locadora_Veiculos.Infra.BancoDados.ModuloGrupoVeiculos
{
    public class RepositorioGrupoVeiculosEmBancoDados :
        RepositorioBase<GrupoVeiculos, MapeadorGrupoVeiculos>,
        IRepositorioGrupoVeiculos
    {
        protected override string sqlInserir =>
            @"INSERT INTO [TBGRUPOVEICULOS]
                (
                    [NOME]    
                )
            VALUES
                (
                    @NOME
                ); SELECT SCOPE_IDENTITY();";

        protected override string sqlEditar =>
            @" UPDATE [TBGRUPOVEICULOS]
                    SET 
                        [NOME] = @NOME
                    WHERE [ID] = @ID";

        protected override string sqlExcluir =>
            @"DELETE FROM [TBGRUPOVEICULOS]
                WHERE [ID] = @ID";

        protected override string sqlSelecionarPorId =>
            @"SELECT 
                [ID] GRUPOVEICULOS_ID,       
                [NOME] GRUPOVEICULOS_NOME
            FROM
                [TBGRUPOVEICULOS]
            WHERE 
             [ID] = @ID";

        protected override string sqlSelecionarTodos =>
            @"SELECT 
                [ID] GRUPOVEICULOS_ID,       
                [NOME] GRUPOVEICULOS_NOME
            FROM
                [TBGRUPOVEICULOS]";

        protected string sqlSelecionarGrupoVeiculosPorNome =>
            @"SELECT 
                [ID] GRUPOVEICULOS_ID,       
                [NOME] GRUPOVEICULOS_NOME
            FROM
                [TBGRUPOVEICULOS]
            WHERE 
             [NOME] = @NOME";

        private string sqlCountGrupoVeiculos =>
            @"SELECT COUNT(*) FROM TBGRUPOVEICULOS;";

        private string sqlCountVeiculosRelacionados =>
            @"SELECT COUNT(*) FROM TBGRUPOVEICULOS 
                AS GV INNER JOIN TBVEICULO AS V
                ON V.[ID_GRUPO_VEICULOS] = @ID";

        private string sqlCountPlanosDeCobrancaRelacionados =>
            @"SELECT COUNT(*) FROM TBGRUPOVEICULOS 
                AS GV INNER JOIN TBPLANOCOBRANCA AS PC
                ON PC.[ID_GRUPO_VEICULOS] = @ID";

        public GrupoVeiculos SelecionarGrupoVeiculosPorNome(string nome)
        {
            return SelecionarPorParametro(sqlSelecionarGrupoVeiculosPorNome, new SqlParameter("NOME", nome));
        }

        public int QuantidadeGrupoVeiculosCadastrados()
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoSelecao = new SqlCommand(sqlCountGrupoVeiculos, conexaoComBanco);

            conexaoComBanco.Open();

            Int32 count = (Int32)comandoSelecao.ExecuteScalar();

            return count;
        }

        public int QuantidadeVeiculosRelacionadosAoGrupo(int id)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoSelecao = new SqlCommand(sqlCountVeiculosRelacionados, conexaoComBanco);

            comandoSelecao.Parameters.AddWithValue("ID", id);

            conexaoComBanco.Open();

            Int32 count = (Int32)comandoSelecao.ExecuteScalar();

            return count;
        }

        public int QuantidadePlanosDeCobrancaRelacionadosAoGrupo(int id)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoSelecao = new SqlCommand(sqlCountPlanosDeCobrancaRelacionados, conexaoComBanco);

            comandoSelecao.Parameters.AddWithValue("ID", id);

            conexaoComBanco.Open();

            Int32 count = (Int32)comandoSelecao.ExecuteScalar();

            return count;
        }
    }
}