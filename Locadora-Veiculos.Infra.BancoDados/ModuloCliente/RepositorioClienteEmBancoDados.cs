using Locadora_Veiculos.Dominio.ModuloCliente;
using Locadora_Veiculos.Infra.BancoDados.Compartilhado;

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
	            [ID],
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
            FROM
                [TBCLIENTE]
            WHERE
                [ID] = @ID";

        protected override string sqlSelecionarTodos =>
            @"SELECT 
	            [ID],
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
            FROM
                [TBCLIENTE]";

        public Cliente SelecionarClientePorDocumento(string documento)
        {
            throw new System.NotImplementedException();
        }
    }
}