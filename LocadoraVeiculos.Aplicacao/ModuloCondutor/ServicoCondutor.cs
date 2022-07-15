using FluentResults;
using FluentValidation.Results;
using Locadora_Veiculos.Dominio.ModuloCondutor;
using Locadora_Veiculos.Infra.BancoDados.Compartilhado;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraVeiculos.Aplicacao.ModuloCondutor
{
    public class ServicoCondutor
    {
        private IRepositorioCondutor repositorioCondutor;

        public ServicoCondutor(IRepositorioCondutor repositorioCondutor)
        {
            this.repositorioCondutor = repositorioCondutor;
        }

        public Result<Condutor> Inserir(Condutor condutor)
        {
            Log.Logger.Debug("Tentando inserir Condutor... {@Condutor}", condutor);

            Result resultadoValidacao = ValidarCondutor(condutor);

            if (resultadoValidacao.IsFailed)
            {
                foreach (Error erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir o Condutor {CondutorId} - {Motivo}",
                        condutor.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioCondutor.Inserir(condutor);

                Log.Logger.Information("Condutor {CondutorId} inserido com sucesso", condutor.Id);

                return Result.Ok(condutor);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar inserir o condutor";

                Log.Logger.Error(ex, msgErro + " {CondutorId}", condutor.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<Condutor> Editar(Condutor condutor)
        {
            Log.Logger.Debug("Tentando editar Condutor... {@Condutor}", condutor);

            Result resultadoValidacao = ValidarCondutor(condutor);

            if (resultadoValidacao.IsFailed)
            {
                foreach (Error erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar o Condutor {CondutorId} - {Motivo}",
                        condutor.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioCondutor.Editar(condutor);

                Log.Logger.Information("Condutor {CondutorId} editado com sucesso", condutor.Id);

                return Result.Ok(condutor);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar editar o condutor";

                Log.Logger.Error(ex, msgErro + " {CondutorId}", condutor.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(Condutor condutor)
        {
            Log.Logger.Debug("Tentando excluir Condutor... {@Condutor}", condutor);

            try
            {
                repositorioCondutor.Excluir(condutor);

                Log.Logger.Information("Condutor {CondutorId} excluído com sucesso", condutor.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar excluir o condutor";

                Log.Logger.Error(ex, msgErro + " {CondutorId}", condutor.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<List<Condutor>> SelecionarTodos()
        {
            try
            {
                return Result.Ok(repositorioCondutor.SelecionarTodos());
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar todos os condutores";

                Log.Logger.Error(ex, msgErro);

                return Result.Fail(msgErro);
            }
        }

        public Result<Condutor> SelecionarPorId(Guid id)
        {
            try
            {
                return Result.Ok(repositorioCondutor.SelecionarPorId(id));
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar seleciona o condutor";

                Log.Logger.Error(ex, msgErro + " {CondutorId}", id);

                return Result.Fail(msgErro);
            }
        }

        #region MÉTODOS PRIVADOS

        private Result ValidarCondutor(Condutor condutor)
        {
            ValidadorCondutor validador = new ValidadorCondutor();

            var resultadoValidacao = validador.Validate(condutor);

            List<Error> erros = new List<Error>();

            foreach (ValidationFailure item in resultadoValidacao.Errors)
                erros.Add(new Error(item.ErrorMessage));

            var resultadoComparacaoCPF = CpfDuplicado(condutor);

            if (resultadoComparacaoCPF.IsSuccess)
            {
                if (resultadoComparacaoCPF.Value == true)
                    erros.Add(new Error("CPF já está cadastrado como condutor!"));
            }
            else
                erros.Add(new Error(resultadoComparacaoCPF.Errors[0].Message));

            var resultadoComparacaoCNH = CnhDuplicada(condutor);

            if (resultadoComparacaoCNH.IsSuccess)
            {
                if (resultadoComparacaoCPF.Value == true)
                    erros.Add(new Error("CNH já está cadastrada como condutor!"));
            }
            else
                erros.Add(new Error(resultadoComparacaoCPF.Errors[0].Message));

            if (erros.Any())
                return Result.Fail(erros);

            return Result.Ok();
        }

        private Result<bool> CnhDuplicada(Condutor condutor)
        {
            try
            {
                var condutorEncontrado = repositorioCondutor.SelecionarCondutorPorCNH(condutor.Cnh);

                var resultadoComparacao = condutorEncontrado != null &&
                       condutorEncontrado.Cnh == condutor.Cnh &&
                       condutorEncontrado.Id != condutor.Id;

                return Result.Ok(resultadoComparacao);
            }
            catch (ConexaoSqlException ex)
            {
                string msgErro = "Falha no sistema ao tentar comparar a CNH do condutor";

                Log.Logger.Error(ex, msgErro + " {CondutorId}", condutor.Id);

                return Result.Fail(msgErro);
            }
        }

        private Result<bool> CpfDuplicado(Condutor condutor)
        {
            try
            {
                var condutorEncontrado = repositorioCondutor.SelecionarCondutorPorCPF(condutor.Cpf);

                var resultadoComparacao = condutorEncontrado != null &&
                       condutorEncontrado.Cpf == condutor.Cpf &&
                       condutorEncontrado.Id != condutor.Id;

                return Result.Ok(resultadoComparacao);
            }
            catch (ConexaoSqlException ex)
            {
                string msgErro = "Falha no sistema ao tentar comparar o CPF do condutor";

                Log.Logger.Error(ex, msgErro + " {CondutorId}", condutor.Id);

                return Result.Fail(msgErro);
            }
        }

        #endregion
    }
}