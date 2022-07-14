using FluentResults;
using FluentValidation.Results;
using Locadora_Veiculos.Dominio.ModuloTaxa;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraVeiculos.Aplicacao.ModuloTaxa
{
    public class ServicoTaxa
    {
        private IRepositorioTaxa repositorioTaxa;

        public ServicoTaxa(IRepositorioTaxa repositorioTaxa)
        {
            this.repositorioTaxa = repositorioTaxa;
        }

        public Result<Taxa> Inserir(Taxa taxa)
        {
            Log.Logger.Debug("Tentando inserir Taxa... {@Taxa}", taxa);

            Result resultadoValidacao = Validar(taxa);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir a Taxa '{TaxaId}' - {Motivo}",
                        taxa.Id, erro.Message);
                }
                return Result.Fail(resultadoValidacao.Errors);
            }
            try
            {
                repositorioTaxa.Inserir(taxa);
                Log.Logger.Debug("Taxa {TaxaId} inserida com sucesso", taxa.Id);
                return Result.Ok(taxa);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar inserir a Taxa";

                Log.Logger.Error(ex, msgErro + "{TaxaId}", taxa.Id);

                return Result.Fail(msgErro);
            }

            return resultadoValidacao;
        }

        public Result<Taxa> Editar(Taxa taxa)
        {
            Log.Logger.Debug("Tentando editar Taxa... {@Taxa}", taxa);

            var resultadoValidacao = Validar(taxa);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar a Taxa {TaxaId} - {Motivo}",
                        taxa.Id, erro.Message);
                }
                return Result.Fail(resultadoValidacao.Errors);

            }
            try
            {
                repositorioTaxa.Editar(taxa);
                Log.Logger.Information("Taxa {TaxaId} editada com sucesso", taxa.Id);
                return Result.Ok(taxa);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar editar a taxa";

                Log.Logger.Error(ex, msgErro + "{TaxaId}", taxa.Id);

                return Result.Fail(msgErro);
            }

            return resultadoValidacao;

        }

        public Result Excluir(Taxa taxa)
        {
            Log.Logger.Debug("Tentando excluir Taxa... {@Taxa}", taxa);
            try
            {
                repositorioTaxa.Excluir(taxa);
                Log.Logger.Debug("Taxa {TaxaId} excluída com sucesso", taxa.Id);
                return Result.Ok();
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar excluir a Taxa";

                Log.Logger.Error(ex, msgErro + "{TaxaId}", taxa.Id);

                return Result.Fail(msgErro);

            }
        }

        public Result<List<Taxa>> SelecionarTodos()
        {
            try
            {
                return Result.Ok(repositorioTaxa.SelecionarTodos());
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar todas as taxas";

                Log.Logger.Error(ex, msgErro);

                return Result.Fail(msgErro);
            }
        }

        public Result<Taxa> SelecionarPorId(Guid id)
        {
            try
            {
                return Result.Ok(repositorioTaxa.SelecionarPorId(id));
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar a taxa";

                Log.Logger.Error(ex, msgErro + "{TaxaId}", id);

                return Result.Fail(msgErro);
            }
        }

        #region MÉTODOS PRIVADOS

        private Result Validar(Taxa taxa)
        {
            var validador = new ValidadorTaxa();

            var resultadoValidacao = validador.Validate(taxa);

            List<Error> erros = new List<Error>(); //FluentResult

            foreach (ValidationFailure item in resultadoValidacao.Errors) //FluentValidation            
                erros.Add(new Error(item.ErrorMessage));

            if (DescricaoDuplicada(taxa))
                resultadoValidacao.Errors.Add(new ValidationFailure("", "Descrição já está cadastrada!"));

            if (erros.Any())
                return Result.Fail(erros);

            return Result.Ok();
        }

        private bool DescricaoDuplicada(Taxa taxa)
        {
            var taxaEncontrada = repositorioTaxa.SelecionarTaxaPorDescricao(taxa.Descricao);

            return taxaEncontrada != null &&
                   taxaEncontrada.Descricao.Equals(taxa.Descricao, StringComparison.OrdinalIgnoreCase) &&
                   taxaEncontrada.Id != taxa.Id;
        }

        #endregion
    }
}