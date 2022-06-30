using FluentValidation.Results;
using Locadora_Veiculos.Dominio.ModuloFuncionario;
using Locadora_Veiculos.Infra.BancoDados.Compartilhado;
using System;
using System.Linq;

namespace Locadora_Veiculos.Infra.BancoDados.ModuloFuncionario
{
    public class RepositorioFuncionarioEmBancoDados :
        RepositorioBase<Funcionario, ValidadorFuncionario, MapeadorFuncionario>,
        IRepositorioFuncionario
    {
        protected override string sqlInserir =>
            @"INSERT INTO [TBFUNCIONARIO]
                   (
                   [NOME],
                   [USUARIO],
                   [SENHA],
                   [DATA_ENTRADA],
                   [SALARIO],
                   [IS_ADMIN],
                   [ESTA_ATIVO]
                    )
             VALUES
               (
                   @NOME,
                   @USUARIO,
                   @SENHA,
                   @DATA_ENTRADA,
                   @SALARIO,
                   @IS_ADMIN,
                   @ESTA_ATIVO
                );  SELECT SCOPE_IDENTITY();";

        protected override string sqlEditar =>
             @" UPDATE [TBFUNCIONARIO]
                    SET 
                   [NOME] = @NOME,
                   [USUARIO] = @USUARIO,
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
                   [USUARIO],
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
                   [USUARIO],
                   [SENHA],
                   [DATA_ENTRADA],
                   [SALARIO],
                   [IS_ADMIN],
                   [ESTA_ATIVO]
            FROM
                [TBFUNCIONARIO]";

        public Funcionario SelecionarFuncionarioPorLogin(string login)
        {
            throw new NotImplementedException();
        }

        public override ValidationResult Validar(Funcionario registro)
        {
            var validator = new ValidadorFuncionario();

            var resultadoValidacao = validator.Validate(registro);

            if (resultadoValidacao.IsValid == false)
                return resultadoValidacao;

            bool loginEncontrado = false;
            var funcionarios = SelecionarTodos();
            foreach(var f in funcionarios)
            {
                if (f.Login.ToLower() == registro.Login.ToLower() && f.Id != registro.Id)
                    loginEncontrado = true;
            }

            if (loginEncontrado)
                    resultadoValidacao.Errors.Add(new ValidationFailure("", "Login já está cadastrado"));

                 

            return resultadoValidacao;
        }
    }
}
