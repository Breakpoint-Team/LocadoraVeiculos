﻿using FluentResults;
using FluentValidation.Results;
using Locadora_Veiculos.Dominio.ModuloPlanoCobranca;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraVeiculos.Aplicacao.ModuloPlanoCobranca
{
    public class ServicoPlanoCobranca
    {
        private IRepositorioPlanoCobranca repositorioPlanoCobranca;

        public ServicoPlanoCobranca(IRepositorioPlanoCobranca repositorioPlanoCobranca)
        {
            this.repositorioPlanoCobranca = repositorioPlanoCobranca;
        }

        public Result<PlanoCobranca> Inserir(PlanoCobranca planoCobranca)
        {
            Log.Logger.Debug("Tentando inserir Plano de Cobrança... {@PlanoCobranca}", planoCobranca);

            Result resultadoValidacao = Validar(planoCobranca);
            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir o Plano de Cobrança {PlanoCobrancaId} - {Motivo}",
                       planoCobranca.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioPlanoCobranca.Inserir(planoCobranca);

                Log.Logger.Information("Plano Cobrança {PlanoCobrancaId} inserido com sucesso", planoCobranca.Id);

                return Result.Ok(planoCobranca);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar inserir o Plano de Cobrança";

                Log.Logger.Error(ex, msgErro + "{PlanoCobrancaId}", planoCobranca.Id);

                return Result.Fail(msgErro);
            }

            

            return resultadoValidacao;
        }

        public Result<PlanoCobranca> Editar(PlanoCobranca planoCobranca)
        {
            Log.Logger.Debug("Tentando editar Plano de Cobrança... {@PlanoCobranca}", planoCobranca);

            Result resultadoValidacao = Validar(planoCobranca);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar o plano de cobrança {PlanoCobrancaId} - {Motivo}",
                       planoCobranca.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioPlanoCobranca.Editar(planoCobranca);

                Log.Logger.Information("Plano de cobrança {PlanoCobrancaId} editado com sucesso", planoCobranca.Id);

                return Result.Ok(planoCobranca);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar editar o plano de cobrança";

                Log.Logger.Error(ex, msgErro + "{PlanoCobrancaId}", planoCobranca.Id);

                return Result.Fail(msgErro);
                
            }
            return resultadoValidacao;
        }

        public Result<List<PlanoCobranca>> SelecionarTodos()
        {
            try
            {
                return Result.Ok(repositorioPlanoCobranca.SelecionarTodos());
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar todos os planos de cobranças";

                Log.Logger.Error(ex, msgErro);

                return Result.Fail(msgErro);
            }
        }

        public Result<PlanoCobranca> SelecionarPorId(Guid id)
        {
            try
            {
                return Result.Ok(repositorioPlanoCobranca.SelecionarPorId(id));
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar o plano de cobranças";

                Log.Logger.Error(ex, msgErro + "{PlanoCobrancasId}", id);

                return Result.Fail(msgErro);
            }
        }

        public Result<PlanoCobranca> Excluir(PlanoCobranca planoCobranca)
        {
            Log.Logger.Debug("Tentando excluir Plano de Cobrança... {@PlanoCobranca}", planoCobranca);
            try
            {
                repositorioPlanoCobranca.Excluir(planoCobranca);
                Log.Logger.Information("Plano de Cobrança {PlanoCobrancaId} excluído com sucesso",planoCobranca.Id);
                return Result.Ok();
            }
            catch(Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar excluir o Plano de Cobranças";
                Log.Logger.Error(ex, msgErro + "{PlanoCobrancaId}", planoCobranca.Id);
                return Result.Fail(msgErro);
            }
        }

        

        #region MÉTODOS PRIVADOS

        private Result Validar(PlanoCobranca planoCobranca)
        {
            var validador = new ValidadorPlanoCobranca();

            var resultadoValidacao = validador.Validate(planoCobranca);

            List<Error> erros =new List<Error>();

            foreach (ValidationFailure item in resultadoValidacao.Errors)
                erros.Add(new Error(item.ErrorMessage));

            if (GrupoVeiculoJaTemPlanoRelacionado(planoCobranca))
                resultadoValidacao.Errors.Add(new ValidationFailure("Grupo de Veículos", "O Grupo de Veículos selecionado ja possui um plano de cobrança relacionado!"));

            if (erros.Any())
                return Result.Fail(erros);

            return Result.Ok();
        }

        private bool GrupoVeiculoJaTemPlanoRelacionado(PlanoCobranca plano)
        {
            var planoEncontrado = repositorioPlanoCobranca.SelecionarPlanoPorIdDoGrupoVeiculos(plano.GrupoVeiculos.Id);

            return planoEncontrado != null &&
                   planoEncontrado.GrupoVeiculos.Id == plano.GrupoVeiculos.Id &&
                   planoEncontrado.Id != plano.Id;
        }

        #endregion

    }
}
