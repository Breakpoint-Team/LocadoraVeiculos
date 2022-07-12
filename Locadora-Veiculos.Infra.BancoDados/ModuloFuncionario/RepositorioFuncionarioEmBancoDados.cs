using Locadora_Veiculos.Dominio.ModuloFuncionario;
using Locadora_Veiculos.Infra.BancoDados.Compartilhado;
using System.Data.SqlClient;

namespace Locadora_Veiculos.Infra.BancoDados.ModuloFuncionario
{
    public class RepositorioFuncionarioEmBancoDados :
        RepositorioBase<Funcionario, MapeadorFuncionario>,
        IRepositorioFuncionario
    {
        protected override string sqlInserir =>
            @"INSERT INTO [TBFUNCIONARIO]
                   (
                   [ID],
                   [NOME],
                   [LOGIN],
                   [SENHA],
                   [DATA_ENTRADA],
                   [SALARIO],
                   [IS_ADMIN],
                   [ESTA_ATIVO]
                    )
             VALUES
               (
                   @ID,
                   @NOME,
                   @LOGIN,
                   @SENHA,
                   @DATA_ENTRADA,
                   @SALARIO,
                   @IS_ADMIN,
                   @ESTA_ATIVO
                );";

        protected override string sqlEditar =>
            @" UPDATE [TBFUNCIONARIO]
                    SET 
                   [NOME] = @NOME,
                   [LOGIN] = @LOGIN,
                   [SENHA] = @SENHA,
                   [DATA_ENTRADA] = @DATA_ENTRADA,
                   [SALARIO] = @SALARIO,
                   [IS_ADMIN] = @IS_ADMIN,
                   [ESTA_ATIVO] = @ESTA_ATIVO

                    WHERE [ID] = @ID";

        protected override string sqlExcluir =>
            @"DELETE FROM [TBFUNCIONARIO]
                WHERE [ID] = @ID";

        protected override string sqlSelecionarPorId =>
            @"SELECT 
                   [ID],       
                   [NOME],
                   [LOGIN],
                   [SENHA],
                   [DATA_ENTRADA],
                   [SALARIO],
                   [IS_ADMIN],
                   [ESTA_ATIVO]
            FROM
                [TBFUNCIONARIO]
            WHERE 
             [ID] = @ID";

        protected override string sqlSelecionarTodos =>
            @"SELECT 
                   [ID],       
                   [NOME],
                   [LOGIN],
                   [SENHA],
                   [DATA_ENTRADA],
                   [SALARIO],
                   [IS_ADMIN],
                   [ESTA_ATIVO]
            FROM
                [TBFUNCIONARIO]";

        private string sqlSelecionarPorLogin =>
            @"SELECT 
                   [ID],       
                   [NOME],
                   [LOGIN],
                   [SENHA],
                   [DATA_ENTRADA],
                   [SALARIO],
                   [IS_ADMIN],
                   [ESTA_ATIVO]
            FROM
                [TBFUNCIONARIO]
            WHERE 
                [LOGIN] = @LOGIN";

        public Funcionario SelecionarFuncionarioPorLogin(string login)
        {
            return SelecionarPorParametro(sqlSelecionarPorLogin, new SqlParameter("LOGIN", login));
        }
    }
}