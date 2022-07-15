using FluentResults;
using FluentValidation.Results;
using Locadora_Veiculos.Dominio.ModuloFuncionario;
using Locadora_Veiculos.Infra.BancoDados.Compartilhado;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraVeiculos.Aplicacao.ModuloFuncionario
{
    public class ServicoFuncionario
    {
        private IRepositorioFuncionario repositorioFuncionario;

        public ServicoFuncionario(IRepositorioFuncionario repositorioFuncionario)
        {
            this.repositorioFuncionario = repositorioFuncionario;
        }

        public Result<Funcionario> Inserir(Funcionario funcionario)
        {
            Log.Logger.Debug("Tentando inserir Funcionário... {@Funcionario}", funcionario);

            Result resultadoValidacao = ValidarFuncionario(funcionario);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir o Funcionário {FuncionarioId} - {Motivo}",
                       funcionario.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioFuncionario.Inserir(funcionario);

                Log.Logger.Information("Funcionário {FuncionarioId} inserido com sucesso", funcionario.Id);

                return Result.Ok(funcionario);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar inserir o funcionário";

                Log.Logger.Error(ex, msgErro + " {FuncionarioId}", funcionario.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<Funcionario> Editar(Funcionario funcionario)
        {
            Log.Logger.Debug("Tentando editar Funcionário... {@Funcionario}", funcionario);

            Result resultadoValidacao = ValidarFuncionario(funcionario);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar o Funcionário {FuncionarioId} - {Motivo}",
                       funcionario.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioFuncionario.Editar(funcionario);

                Log.Logger.Information("Funcionário {FuncionarioId} editado com sucesso", funcionario.Id);

                return Result.Ok(funcionario);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar editar o funcionário";

                Log.Logger.Error(ex, msgErro + " {FuncionarioId}", funcionario.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(Funcionario funcionario)
        {
            Log.Logger.Debug("Tentando excluir Funcionário... {@Funcionario}", funcionario);

            try
            {
                repositorioFuncionario.Excluir(funcionario);

                Log.Logger.Information("Funcionário {FuncionarioId} excluído com sucesso", funcionario.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar excluir o funcionário";

                Log.Logger.Error(ex, msgErro + " {FuncionarioId}", funcionario.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<List<Funcionario>> SelecionarTodos()
        {
            try
            {
                return Result.Ok(repositorioFuncionario.SelecionarTodos());
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar todos os funcionários";

                Log.Logger.Error(ex, msgErro);

                return Result.Fail(msgErro);
            }
        }

        public Result<Funcionario> SelecionarPorId(Guid id)
        {
            try
            {
                return Result.Ok(repositorioFuncionario.SelecionarPorId(id));
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar o funcionário";

                Log.Logger.Error(ex, msgErro + " {FuncionarioId}", id);

                return Result.Fail(msgErro);
            }
        }

        #region MÉTODOS PRIVADOS

        private Result ValidarFuncionario(Funcionario funcionario)
        {
            var validador = new ValidadorFuncionario();

            var resultadoValidacao = validador.Validate(funcionario);

            List<Error> erros = new List<Error>(); 

            foreach (ValidationFailure item in resultadoValidacao.Errors)             
                erros.Add(new Error(item.ErrorMessage));

            var resultadoComparacao = LoginDuplicado(funcionario);

            if (resultadoComparacao.IsSuccess)
            {
                if (resultadoComparacao.Value == true)
                    erros.Add(new Error("Login já está cadastrado!"));
            }
            else
                erros.Add(new Error(resultadoComparacao.Errors[0].Message));

            if (erros.Any())
                return Result.Fail(erros);

            return Result.Ok();
        }

        private Result<bool> LoginDuplicado(Funcionario funcionario)
        {
            try
            {
                var funcionarioEncontrado = repositorioFuncionario.SelecionarFuncionarioPorLogin(funcionario.Login);

                bool resultadoComparacao = funcionarioEncontrado != null &&
                       funcionarioEncontrado.Login.Equals(funcionario.Login, StringComparison.OrdinalIgnoreCase) &&
                       funcionarioEncontrado.Id != funcionario.Id;

                return Result.Ok(resultadoComparacao);
            }
            catch (ConexaoSqlException ex)
            {
                string msgErro = "Falha no sistema ao tentar comparar o login do funcionário";

                Log.Logger.Error(ex, msgErro + " {FuncionarioId}", funcionario.Id);

                return Result.Fail(msgErro);
            }
        }

        #endregion
    }
}