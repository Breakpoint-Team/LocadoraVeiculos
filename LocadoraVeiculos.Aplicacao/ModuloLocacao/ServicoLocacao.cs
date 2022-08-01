using FluentResults;
using FluentValidation.Results;
using Locadora_Veiculos.Dominio.Compartilhado;
using Locadora_Veiculos.Dominio.ModuloLocacao;
using Locadora_Veiculos.Dominio.ModuloVeiculo;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraVeiculos.Aplicacao.ModuloLocacao
{
    public class ServicoLocacao
    {
        private IRepositorioLocacao repositorioLocacao;
        private IContextoPersistencia contextoPersistencia;

        public ServicoLocacao(IRepositorioLocacao repositorioLocacao,
            IContextoPersistencia contextoPersistencia)
        {
            this.repositorioLocacao = repositorioLocacao;
            this.contextoPersistencia = contextoPersistencia;
        }

        public Result<Locacao> Inserir(Locacao locacao)
        {
            Log.Logger.Debug("Tentando inserir Locação... {@Locacao}", locacao);

            Result resultadoValidacao = ValidarLocacao(locacao);

            if (resultadoValidacao.IsFailed)
            {
                foreach (Error erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir a Locação {LocacaoId} - {Motivo}",
                        locacao.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioLocacao.Inserir(locacao);

                locacao.Veiculo.AtualizarStatus();

                contextoPersistencia.GravarDados();

                Log.Logger.Information("Locação {LocacaoId} inserida com sucesso", locacao.Id);

                return Result.Ok(locacao);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar inserir a locação";

                Log.Logger.Error(ex, msgErro + " {LocacaoId}", locacao.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<Locacao> Editar(Locacao locacao)
        {
            Log.Logger.Debug("Tentando editar Locação... {@Locacao}", locacao);

            Result resultadoValidacao = ValidarLocacao(locacao);

            if (resultadoValidacao.IsFailed)
            {
                foreach (Error erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar a Locação {LocacaoId} - {Motivo}",
                        locacao.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioLocacao.Editar(locacao);

                contextoPersistencia.GravarDados();

                Log.Logger.Information("Locação {LocacaoId} editada com sucesso", locacao.Id);

                return Result.Ok(locacao);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar editar a locação";

                Log.Logger.Error(ex, msgErro + " {LocacaoId}", locacao.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<Locacao> DevolverLocacao(Locacao locacao)
        {
            Log.Logger.Debug("Tentando devolver Locação... {@Locacao}", locacao);

            Result resultadoValidacao = ValidarLocacao(locacao);

            if (resultadoValidacao.IsFailed)
            {
                foreach (Error erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar devolver a Locação {LocacaoId} - {Motivo}",
                        locacao.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioLocacao.Editar(locacao);

                locacao.StatusLocacao = StatusLocacao.Fechada;

                locacao.Veiculo.StatusVeiculo = StatusVeiculo.Disponivel;

                int quilometragemLocacao = Convert.ToInt32(locacao.QuilometragemFinalVeiculo - locacao.QuilometragemInicialVeiculo);

                locacao.Veiculo.QuilometragemPercorrida = quilometragemLocacao;

                contextoPersistencia.GravarDados();

                Log.Logger.Information("Locação {LocacaoId} devolvida com sucesso", locacao.Id);

                return Result.Ok(locacao);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar devolver a locação";

                Log.Logger.Error(ex, msgErro + " {LocacaoId}", locacao.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(Locacao locacao)
        {
            Log.Logger.Debug("Tentando excluir Locação... {@Locacao}", locacao);

            try
            {
                locacao.Veiculo.AtualizarStatus();

                repositorioLocacao.Excluir(locacao);

                contextoPersistencia.GravarDados();

                Log.Logger.Information("Locação {LocacaoId} excluída com sucesso", locacao.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar excluir a locação";

                Log.Logger.Error(ex, msgErro + " {LocacaoId}", locacao.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<List<Locacao>> SelecionarTodos()
        {
            try
            {
                return Result.Ok(repositorioLocacao.SelecionarTodos());
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar todas as locações";

                Log.Logger.Error(ex, msgErro);

                return Result.Fail(msgErro);
            }
        }

        public Result<Locacao> SelecionarPorId(Guid id)
        {
            try
            {
                return Result.Ok(repositorioLocacao.SelecionarPorId(id));
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar a locação";

                Log.Logger.Error(ex, msgErro + " {LocacaoId}", id);

                return Result.Fail(msgErro);
            }
        }

        #region MÉTODOS PRIVADOS

        private Result ValidarLocacao(Locacao locacao)
        {
            ValidadorLocacao validador = new ValidadorLocacao();

            var resultadoValidacao = validador.Validate(locacao);

            List<Error> erros = new List<Error>();

            foreach (ValidationFailure item in resultadoValidacao.Errors)
                erros.Add(new Error(item.ErrorMessage));

            if (erros.Any())
                return Result.Fail(erros);

            return Result.Ok();
        }

        #endregion
    }
}
