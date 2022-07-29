using Locadora_Veiculos.Dominio.ModuloVeiculo;
using Locadora_Veiculos.Infra.BancoDados.Compartilhado;
using System;
using System.Data.SqlClient;

namespace Locadora_Veiculos.Infra.BancoDados.ModuloVeiculo
{
    public class RepositorioVeiculoEmBancoDados : RepositorioBase<Veiculo, MapeadorVeiculo>,
        IRepositorioVeiculo
    {
        protected override string sqlInserir =>
            @"INSERT INTO [TBVEICULO]
               (
                [ID],
                [MODELO],
                [MARCA],
                [ANO],
                [COR],
                [PLACA],
                [TIPO_COMBUSTIVEL],
                [QUILOMETRAGEM_PERCORRIDA],
                [CAPACIDADE_TANQUE],
                [ID_GRUPO_VEICULOS],
                [IMAGEM]
                )
             VALUES
                (
                @ID,
                @MODELO,
                @MARCA,
                @ANO,
                @COR,
                @PLACA,
                @TIPO_COMBUSTIVEL,
                @QUILOMETRAGEM_PERCORRIDA,
                @CAPACIDADE_TANQUE,
                @ID_GRUPO_VEICULOS,
                @IMAGEM
                );";

        protected override string sqlEditar =>
            @"UPDATE [TBVEICULO]
                SET 
                [MODELO] = @MODELO,
                [MARCA] = @MARCA,
                [ANO] = @ANO,
                [COR] = @COR,
                [PLACA] = @PLACA,
                [TIPO_COMBUSTIVEL] = @TIPO_COMBUSTIVEL,
                [QUILOMETRAGEM_PERCORRIDA] = @QUILOMETRAGEM_PERCORRIDA,
                [CAPACIDADE_TANQUE] = @CAPACIDADE_TANQUE,
                [ID_GRUPO_VEICULOS] = @ID_GRUPO_VEICULOS,
                [IMAGEM] = @IMAGEM

                WHERE [ID] = @ID
                ";

        protected override string sqlExcluir =>
            @"DELETE FROM [TBVEICULO]
                WHERE [ID] = @ID              
            ";

        protected override string sqlSelecionarPorId =>
            @"SELECT 
               VEICULO.[ID],
               VEICULO.[MODELO],
               VEICULO.[MARCA],
               VEICULO.[ANO],
               VEICULO.[COR],
               VEICULO.[PLACA],
               VEICULO.[TIPO_COMBUSTIVEL],
               VEICULO.[QUILOMETRAGEM_PERCORRIDA],
               VEICULO.[CAPACIDADE_TANQUE],
               VEICULO.[ID_GRUPO_VEICULOS],
               VEICULO.[IMAGEM],

               GRUPOVEICULOS.[ID] GRUPOVEICULOS_ID,
               GRUPOVEICULOS.[NOME] GRUPOVEICULOS_NOME

            FROM [TBVEICULO] AS VEICULO

            INNER JOIN [TBGRUPOVEICULOS] AS GRUPOVEICULOS
                ON GRUPOVEICULOS.ID = VEICULO.ID_GRUPO_VEICULOS

            WHERE VEICULO.ID = @ID";

        protected override string sqlSelecionarTodos =>
            @"SELECT 
               VEICULO.[ID],
               VEICULO.[MODELO],
               VEICULO.[MARCA],
               VEICULO.[ANO],
               VEICULO.[COR],
               VEICULO.[PLACA],
               VEICULO.[TIPO_COMBUSTIVEL],
               VEICULO.[QUILOMETRAGEM_PERCORRIDA],
               VEICULO.[CAPACIDADE_TANQUE],
               VEICULO.[ID_GRUPO_VEICULOS],
               VEICULO.[IMAGEM],
               
               GRUPOVEICULOS.[ID] GRUPOVEICULOS_ID,
               GRUPOVEICULOS.[NOME] GRUPOVEICULOS_NOME

            FROM [TBVEICULO] AS VEICULO

            INNER JOIN [TBGRUPOVEICULOS] AS GRUPOVEICULOS
                ON GRUPOVEICULOS.ID = VEICULO.ID_GRUPO_VEICULOS";

        protected string sqlSelecionarVeiculoPorPlaca =>
            @"SELECT
               VEICULO.[ID],
               VEICULO.[MODELO],
               VEICULO.[MARCA],
               VEICULO.[ANO],
               VEICULO.[COR],
               VEICULO.[PLACA],
               VEICULO.[TIPO_COMBUSTIVEL],
               VEICULO.[QUILOMETRAGEM_PERCORRIDA],
               VEICULO.[CAPACIDADE_TANQUE],
               VEICULO.[ID_GRUPO_VEICULOS],
               VEICULO.[IMAGEM],

               GRUPOVEICULOS.[ID] GRUPOVEICULOS_ID,
               GRUPOVEICULOS.[NOME] GRUPOVEICULOS_NOME

            FROM [TBVEICULO] AS VEICULO

            INNER JOIN [TBGRUPOVEICULOS] AS GRUPOVEICULOS
                ON GRUPOVEICULOS.ID = VEICULO.ID_GRUPO_VEICULOS

            WHERE VEICULO.PLACA = @PLACA
            ";

        private string sqlCountVeiculos =>
            @"SELECT COUNT(*) 
                FROM TBVEICULO;";

        public int QuantidadeVeiculosCadastrados()
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comando = new SqlCommand(sqlCountVeiculos, conexaoComBanco);

            conexaoComBanco.Open();

            var count = Convert.ToInt32(comando.ExecuteScalar());

            return count;
        }

        public Veiculo SelecionarVeiculoPorPlaca(string placa)
        {
            return SelecionarPorParametro(sqlSelecionarVeiculoPorPlaca, new SqlParameter("PLACA", placa));
        }
    }
}