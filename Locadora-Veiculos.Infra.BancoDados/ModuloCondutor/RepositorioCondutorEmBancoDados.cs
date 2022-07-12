using Locadora_Veiculos.Dominio.ModuloCondutor;
using Locadora_Veiculos.Infra.BancoDados.Compartilhado;
using System.Data.SqlClient;

namespace Locadora_Veiculos.Infra.BancoDados.ModuloCondutor
{
    public class RepositorioCondutorEmBancoDados : RepositorioBase<Condutor, MapeadorCondutor>,
        IRepositorioCondutor
    {
        protected override string sqlInserir =>
            @"INSERT INTO [TBCONDUTOR]
                 (
		                [ID],
		                [NOME],
                        [TELEFONE],
                        [EMAIL],
                        [NUMERO],
                        [RUA],
                        [BAIRRO],
                        [CIDADE],
                        [ESTADO],
                        [CPF],
                        [CNH],
                        [DATA_VALIDADE_CNH],
                        [ID_CLIENTE]
		         )
            VALUES
                (
		                @ID,
		                @NOME,
                        @TELEFONE,
                        @EMAIL,
                        @NUMERO,
                        @RUA,
                        @BAIRRO,
                        @CIDADE,
                        @ESTADO,
                        @CPF,
                        @CNH,
                        @DATA_VALIDADE_CNH,
                        @ID_CLIENTE
			    );";

        protected override string sqlEditar =>
            @"UPDATE [TBCONDUTOR]
                SET
		                [NOME] = @NOME,
                        [TELEFONE] = @TELEFONE,
                        [EMAIL] = @EMAIL,
                        [NUMERO] = @NUMERO,
                        [RUA] = @RUA,
                        [BAIRRO] = @BAIRRO,
                        [CIDADE] = @CIDADE,
                        [ESTADO] = @ESTADO,
                        [CPF] = @CPF,
                        [CNH] = @CNH,
                        [DATA_VALIDADE_CNH] = @DATA_VALIDADE_CNH,
                        [ID_CLIENTE] = @ID_CLIENTE
                WHERE
                    [ID] = @ID";

        protected override string sqlExcluir =>
            @"DELETE FROM [TBCONDUTOR]
                WHERE [ID] = @ID";

        protected override string sqlSelecionarPorId =>
            @"SELECT
                CONDUTOR.ID AS CONDUTOR_ID,
                CONDUTOR.NOME AS CONDUTOR_NOME ,
                CONDUTOR.TELEFONE AS CONDUTOR_TELEFONE,
                CONDUTOR.EMAIL AS CONDUTOR_EMAIL,
                CONDUTOR.NUMERO AS CONDUTOR_NUMERO,
                CONDUTOR.RUA AS CONDUTOR_RUA,
                CONDUTOR.BAIRRO AS CONDUTOR_BAIRRO,
                CONDUTOR.CIDADE AS CONDUTOR_CIDADE,
                CONDUTOR.ESTADO AS CONDUTOR_ESTADO,
                CONDUTOR.CPF AS CONDUTOR_CPF,
                CONDUTOR.CNH AS CONDUTOR_CNH,
                CONDUTOR.DATA_VALIDADE_CNH AS CONDUTOR_DATA_VALIDADE_CNH,
                
                CLIENTE.ID AS CLIENTE_ID,
                CLIENTE.NOME AS CLIENTE_NOME,
                CLIENTE.DOCUMENTO AS CLIENTE_DOCUMENTO,
                CLIENTE.EMAIL AS CLIENTE_EMAIL,
                CLIENTE.TELEFONE AS CLIENTE_TELEFONE,
                CLIENTE.TIPO_CLIENTE AS CLIENTE_TIPO_CLIENTE,
                CLIENTE.ESTADO AS CLIENTE_ESTADO,
                CLIENTE.CIDADE AS CLIENTE_CIDADE,
                CLIENTE.BAIRRO AS CLIENTE_BAIRRO,
                CLIENTE.RUA AS CLIENTE_RUA,
                CLIENTE.NUMERO AS CLIENTE_NUMERO
            FROM
                [TBCONDUTOR] AS CONDUTOR INNER JOIN [TBCLIENTE] AS CLIENTE
            ON 
                CONDUTOR.[ID_CLIENTE] = CLIENTE.[ID]
            WHERE
                CONDUTOR.[ID] = @ID";

        protected override string sqlSelecionarTodos =>
            @"SELECT
                CONDUTOR.ID AS CONDUTOR_ID,
                CONDUTOR.NOME AS CONDUTOR_NOME ,
                CONDUTOR.TELEFONE AS CONDUTOR_TELEFONE,
                CONDUTOR.EMAIL AS CONDUTOR_EMAIL,
                CONDUTOR.NUMERO AS CONDUTOR_NUMERO,
                CONDUTOR.RUA AS CONDUTOR_RUA,
                CONDUTOR.BAIRRO AS CONDUTOR_BAIRRO,
                CONDUTOR.CIDADE AS CONDUTOR_CIDADE,
                CONDUTOR.ESTADO AS CONDUTOR_ESTADO,
                CONDUTOR.CPF AS CONDUTOR_CPF,
                CONDUTOR.CNH AS CONDUTOR_CNH,
                CONDUTOR.DATA_VALIDADE_CNH AS CONDUTOR_DATA_VALIDADE_CNH,
                
                CLIENTE.ID AS CLIENTE_ID,
                CLIENTE.NOME AS CLIENTE_NOME,
                CLIENTE.DOCUMENTO AS CLIENTE_DOCUMENTO,
                CLIENTE.EMAIL AS CLIENTE_EMAIL,
                CLIENTE.TELEFONE AS CLIENTE_TELEFONE,
                CLIENTE.TIPO_CLIENTE AS CLIENTE_TIPO_CLIENTE,
                CLIENTE.ESTADO AS CLIENTE_ESTADO,
                CLIENTE.CIDADE AS CLIENTE_CIDADE,
                CLIENTE.BAIRRO AS CLIENTE_BAIRRO,
                CLIENTE.RUA AS CLIENTE_RUA,
                CLIENTE.NUMERO AS CLIENTE_NUMERO
            FROM
                [TBCONDUTOR] AS CONDUTOR INNER JOIN [TBCLIENTE] AS CLIENTE
            ON 
                CONDUTOR.[ID_CLIENTE] = CLIENTE.[ID]";

        private string sqlSelecionarCondutorPorCNH =>
            @"SELECT
                CONDUTOR.ID AS CONDUTOR_ID,
                CONDUTOR.NOME AS CONDUTOR_NOME ,
                CONDUTOR.TELEFONE AS CONDUTOR_TELEFONE,
                CONDUTOR.EMAIL AS CONDUTOR_EMAIL,
                CONDUTOR.NUMERO AS CONDUTOR_NUMERO,
                CONDUTOR.RUA AS CONDUTOR_RUA,
                CONDUTOR.BAIRRO AS CONDUTOR_BAIRRO,
                CONDUTOR.CIDADE AS CONDUTOR_CIDADE,
                CONDUTOR.ESTADO AS CONDUTOR_ESTADO,
                CONDUTOR.CPF AS CONDUTOR_CPF,
                CONDUTOR.CNH AS CONDUTOR_CNH,
                CONDUTOR.DATA_VALIDADE_CNH AS CONDUTOR_DATA_VALIDADE_CNH,
                
                CLIENTE.ID AS CLIENTE_ID,
                CLIENTE.NOME AS CLIENTE_NOME,
                CLIENTE.DOCUMENTO AS CLIENTE_DOCUMENTO,
                CLIENTE.EMAIL AS CLIENTE_EMAIL,
                CLIENTE.TELEFONE AS CLIENTE_TELEFONE,
                CLIENTE.TIPO_CLIENTE AS CLIENTE_TIPO_CLIENTE,
                CLIENTE.ESTADO AS CLIENTE_ESTADO,
                CLIENTE.CIDADE AS CLIENTE_CIDADE,
                CLIENTE.BAIRRO AS CLIENTE_BAIRRO,
                CLIENTE.RUA AS CLIENTE_RUA,
                CLIENTE.NUMERO AS CLIENTE_NUMERO
            FROM
                [TBCONDUTOR] AS CONDUTOR INNER JOIN [TBCLIENTE] AS CLIENTE
            ON 
                CONDUTOR.[ID_CLIENTE] = CLIENTE.[ID]
            WHERE
                CONDUTOR.[CNH] = @CNH";

        private string sqlSelecionarCondutorPorCPF =>
            @"SELECT
                CONDUTOR.ID AS CONDUTOR_ID,
                CONDUTOR.NOME AS CONDUTOR_NOME ,
                CONDUTOR.TELEFONE AS CONDUTOR_TELEFONE,
                CONDUTOR.EMAIL AS CONDUTOR_EMAIL,
                CONDUTOR.NUMERO AS CONDUTOR_NUMERO,
                CONDUTOR.RUA AS CONDUTOR_RUA,
                CONDUTOR.BAIRRO AS CONDUTOR_BAIRRO,
                CONDUTOR.CIDADE AS CONDUTOR_CIDADE,
                CONDUTOR.ESTADO AS CONDUTOR_ESTADO,
                CONDUTOR.CPF AS CONDUTOR_CPF,
                CONDUTOR.CNH AS CONDUTOR_CNH,
                CONDUTOR.DATA_VALIDADE_CNH AS CONDUTOR_DATA_VALIDADE_CNH,
                
                CLIENTE.ID AS CLIENTE_ID,
                CLIENTE.NOME AS CLIENTE_NOME,
                CLIENTE.DOCUMENTO AS CLIENTE_DOCUMENTO,
                CLIENTE.EMAIL AS CLIENTE_EMAIL,
                CLIENTE.TELEFONE AS CLIENTE_TELEFONE,
                CLIENTE.TIPO_CLIENTE AS CLIENTE_TIPO_CLIENTE,
                CLIENTE.ESTADO AS CLIENTE_ESTADO,
                CLIENTE.CIDADE AS CLIENTE_CIDADE,
                CLIENTE.BAIRRO AS CLIENTE_BAIRRO,
                CLIENTE.RUA AS CLIENTE_RUA,
                CLIENTE.NUMERO AS CLIENTE_NUMERO
            FROM
                [TBCONDUTOR] AS CONDUTOR INNER JOIN [TBCLIENTE] AS CLIENTE
            ON 
                CONDUTOR.[ID_CLIENTE] = CLIENTE.[ID]
            WHERE
                CONDUTOR.[CPF] = @CPF";

        public Condutor SelecionarCondutorPorCNH(string cnh)
        {
            return SelecionarPorParametro(sqlSelecionarCondutorPorCNH, new SqlParameter("CNH", cnh));
        }

        public Condutor SelecionarCondutorPorCPF(string cpf)
        {
            return SelecionarPorParametro(sqlSelecionarCondutorPorCPF, new SqlParameter("CPF", cpf));
        }
    }
}