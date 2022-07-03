using Locadora_Veiculos.Dominio.ModuloCliente;
using Locadora_Veiculos.Infra.BancoDados.Compartilhado;
using System;
using System.Data.SqlClient;

namespace Locadora_Veiculos.Infra.BancoDados.ModuloCliente
{
    public class RepositorioClienteEmBancoDados : RepositorioBase<Cliente, MapeadorCliente>,
        IRepositorioCliente
    {
        protected override string sqlInserir =>
            @"INSERT INTO [TBCLIENTE]
                 (
		            [NOME],
                    [DOCUMENTO],
                    [EMAIL],
                    [TELEFONE],
                    [TIPO_CLIENTE],
                    [ESTADO],
                    [CIDADE],
                    [BAIRRO],
                    [RUA],
                    [NUMERO]
		         )
            VALUES
                (
		            @NOME, 
                    @DOCUMENTO, 
                    @EMAIL,
                    @TELEFONE,
                    @TIPO_CLIENTE,
                    @ESTADO,
                    @CIDADE,
                    @BAIRRO,
                    @RUA,
                    @NUMERO
			);SELECT SCOPE_IDENTITY();";

        protected override string sqlEditar =>
            @"UPDATE [TBCLIENTE]
                SET
		            [NOME] = @NOME,
                    [DOCUMENTO] = @DOCUMENTO,
                    [EMAIL] = @EMAIL,
                    [TELEFONE] = @TELEFONE,
                    [TIPO_CLIENTE] = @TIPO_CLIENTE,
                    [ESTADO] = @ESTADO,
                    [CIDADE] = @CIDADE,
                    [BAIRRO] = @BAIRRO,
                    [RUA] = @RUA,
                    [NUMERO] = @NUMERO
                WHERE
                    [ID] = @ID";

        protected override string sqlExcluir =>
            @"DELETE FROM [TBCLIENTE]
                WHERE [ID] = @ID";

        protected override string sqlSelecionarPorId =>
            @"SELECT 
	            [ID] CLIENTE_ID,
                [NOME] CLIENTE_NOME,
                [DOCUMENTO] CLIENTE_DOCUMENTO,
                [EMAIL] CLIENTE_EMAIL,
                [TELEFONE] CLIENTE_TELEFONE,
                [TIPO_CLIENTE] CLIENTE_TIPO_CLIENTE,
                [ESTADO] CLIENTE_ESTADO,
                [CIDADE] CLIENTE_CIDADE,
                [BAIRRO] CLIENTE_BAIRRO,
                [RUA] CLIENTE_RUA,
                [NUMERO] CLIENTE_NUMERO
            FROM
                [TBCLIENTE]
            WHERE
                [ID] = @ID";

        protected override string sqlSelecionarTodos =>
            @"SELECT 
	            [ID] CLIENTE_ID,
                [NOME] CLIENTE_NOME,
                [DOCUMENTO] CLIENTE_DOCUMENTO,
                [EMAIL] CLIENTE_EMAIL,
                [TELEFONE] CLIENTE_TELEFONE,
                [TIPO_CLIENTE] CLIENTE_TIPO_CLIENTE,
                [ESTADO] CLIENTE_ESTADO,
                [CIDADE] CLIENTE_CIDADE,
                [BAIRRO] CLIENTE_BAIRRO,
                [RUA] CLIENTE_RUA,
                [NUMERO] CLIENTE_NUMERO
            FROM
                [TBCLIENTE]";

        private string sqlSelecionarClientePorDocumento =>
            @"SELECT 
	            [ID] CLIENTE_ID,
                [NOME] CLIENTE_NOME,
                [DOCUMENTO] CLIENTE_DOCUMENTO,
                [EMAIL] CLIENTE_EMAIL,
                [TELEFONE] CLIENTE_TELEFONE,
                [TIPO_CLIENTE] CLIENTE_TIPO_CLIENTE,
                [ESTADO] CLIENTE_ESTADO,
                [CIDADE] CLIENTE_CIDADE,
                [BAIRRO] CLIENTE_BAIRRO,
                [RUA] CLIENTE_RUA,
                [NUMERO] CLIENTE_NUMERO
            FROM
                [TBCLIENTE]
            WHERE
                [DOCUMENTO] = @DOCUMENTO";
        
        private string sqlCountClientes =>
            @"SELECT COUNT(*) 
                FROM TBCLIENTE;";

        private string sqlCountCondutoresRelacionados =>
            @"SELECT COUNT(*)
                FROM
                    TBCLIENTE AS CLIENTE INNER JOIN TBCONDUTOR AS CONDUTOR
                ON 
                    CONDUTOR.[ID_CLIENTE] = @ID";

        public int QuantidadeClientesCadastrados()
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comando = new SqlCommand(sqlCountClientes, conexaoComBanco);

            conexaoComBanco.Open();

            var count = Convert.ToInt32(comando.ExecuteScalar());

            return count;
        }

        public int QuantidadeCondutoresRelacionadosAoCliente(int id)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comando = new SqlCommand(sqlCountCondutoresRelacionados, conexaoComBanco);

            comando.Parameters.AddWithValue("ID", id);

            conexaoComBanco.Open();

            var count = Convert.ToInt32(comando.ExecuteScalar());

            return count;
        }

        public Cliente SelecionarClientePorDocumento(string documento)
        {
            return SelecionarPorParametro(sqlSelecionarClientePorDocumento, new SqlParameter("DOCUMENTO", documento));
        }
    }
}