using Locadora_Veiculos.Dominio.ModuloCliente;
using Locadora_Veiculos.Infra.BancoDados.Compartilhado;
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

        public Cliente SelecionarClientePorDocumento(string documento)
        {
            return SelecionarPorParametro(sqlSelecionarClientePorDocumento, new SqlParameter("DOCUMENTO", documento));
        }
    }
}