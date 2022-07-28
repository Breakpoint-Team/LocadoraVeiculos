using FluentResults;
using FluentValidation.Results;
using Locadora_Veiculos.Dominio.Compartilhado;
using Locadora_Veiculos.Dominio.ModuloGrupoVeiculos;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraVeiculos.Aplicacao.ModuloGrupoVeiculos
{
    public class ServicoGrupoVeiculos
    {
        private IRepositorioGrupoVeiculos repositorioGrupoVeiculos;
        private IContextoPersistencia contextoPersistencia;

        public ServicoGrupoVeiculos(IRepositorioGrupoVeiculos repositorioGrupoVeiculos,
            IContextoPersistencia contextoPersistencia)
        {
            this.repositorioGrupoVeiculos = repositorioGrupoVeiculos;
            this.contextoPersistencia = contextoPersistencia;
        }

        public Result<GrupoVeiculos> Inserir(GrupoVeiculos grupoVeiculos)
        {
            Log.Logger.Debug("Tentando inserir Grupo de Veículos... {@GrupoVeiculos}", grupoVeiculos);

            Result resultadoValidacao = Validar(grupoVeiculos);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir o Grupo de Veículos {GrupoVeiculosId} - {Motivo}",
                        grupoVeiculos.Id, erro.Message);
                }
                return Result.Fail(resultadoValidacao.Errors);

            }
            try
            {
                repositorioGrupoVeiculos.Inserir(grupoVeiculos);

                contextoPersistencia.GravarDados();

                Log.Logger.Debug("Grupo de Veículos {GrupoVeiculosId} inserido com sucesso", grupoVeiculos.Id);

                return Result.Ok(grupoVeiculos);

            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar inserir o Grupo de Veículos";

                Log.Logger.Error(ex, msgErro + "{GrupoVeiculosId}", grupoVeiculos.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<GrupoVeiculos> Editar(GrupoVeiculos grupoVeiculos)
        {
            Log.Logger.Debug("Tentando editar Grupo de Veículos... {@GrupoVeiculos}", grupoVeiculos);

            Result resultadoValidacao = Validar(grupoVeiculos);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar o Grupo de Veículos {GrupoVeiculosId} - {Motivo}",
                        grupoVeiculos.Id, erro.Message);
                }
                return Result.Fail(resultadoValidacao.Errors);

            }

            try
            {
                repositorioGrupoVeiculos.Editar(grupoVeiculos);

                contextoPersistencia.GravarDados();

                Log.Logger.Information("Grupo de Veículos {GrupoVeiculosId} editado com sucesso", grupoVeiculos.Id);

                return Result.Ok(grupoVeiculos);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar editar o grupo de veículos";

                Log.Logger.Error(ex, msgErro + "{GrupoVeiculosId}", grupoVeiculos.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(GrupoVeiculos grupoVeiculos)
        {
            Log.Logger.Debug("Tentando excluir Grupo de Veículos... {@GrupoVeiculos}", grupoVeiculos);
            try
            {
                repositorioGrupoVeiculos.Excluir(grupoVeiculos);

                contextoPersistencia.GravarDados();

                Log.Logger.Information("Grupo de Veículos {GrupoVeiculosId} excluído com sucesso", grupoVeiculos.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                string msgErro = "";

                if (ex is DbUpdateException || ex is InvalidOperationException)
                {
                    msgErro = $"O grupo de veículos {grupoVeiculos.Nome} está relacionado com um veículo ou plano de cobrança e não pode ser excluído";

                    contextoPersistencia.DesfazerAlteracoes();
                }
                else
                {
                    msgErro = "Falha no sistema ao tentar excluir o Grupo de Veículos";
                }
                
                Log.Logger.Error(ex, msgErro + "{GrupoVeiculosId}", grupoVeiculos.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<List<GrupoVeiculos>> SelecionarTodos()
        {
            try
            {
                return Result.Ok(repositorioGrupoVeiculos.SelecionarTodos());
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar todos os grupos de veículos";

                Log.Logger.Error(ex, msgErro);

                return Result.Fail(msgErro);
            }
        }

        public Result<GrupoVeiculos> SelecionarPorId(Guid id)
        {
            try
            {
                return Result.Ok(repositorioGrupoVeiculos.SelecionarPorId(id));
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar o grupo de veículos";

                Log.Logger.Error(ex, msgErro + "{GrupoVeiculosId}", id);

                return Result.Fail(msgErro);
            }
        }

        #region MÉTODOS PRIVADOS
        private Result Validar(GrupoVeiculos grupoVeiculos)
        {
            var validador = new ValidadorGrupoVeiculos();

            var resultadoValidacao = validador.Validate(grupoVeiculos);

            List<Error> erros = new List<Error>(); //FluentResult

            foreach (ValidationFailure item in resultadoValidacao.Errors) //FluentValidation            
                erros.Add(new Error(item.ErrorMessage));

            var resultadoComparacao = NomeDuplicado(grupoVeiculos);

            if (resultadoComparacao.IsSuccess)
            {
                if (resultadoComparacao.Value == true)
                {
                    erros.Add(new Error("Nome já está cadastrado!"));
                }
            }
            else
            {
                erros.Add(new Error(resultadoComparacao.Errors[0].Message));
            }

            if (erros.Any())
                return Result.Fail(erros);

            return Result.Ok();
        }

        private Result<bool> NomeDuplicado(GrupoVeiculos grupoVeiculos)
        {
            try
            {
                var grupoVeiculosEncontrado = repositorioGrupoVeiculos.SelecionarGrupoVeiculosPorNome(grupoVeiculos.Nome);
                var resultadoComparacao = grupoVeiculosEncontrado != null &&
                       grupoVeiculosEncontrado.Nome.Equals(grupoVeiculos.Nome, StringComparison.OrdinalIgnoreCase) &&
                       grupoVeiculosEncontrado.Id != grupoVeiculos.Id;

                return Result.Ok(resultadoComparacao);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar comparar o nome do grupo de veículos";

                Log.Logger.Error(ex, msgErro + " {GrupoVeiculosId}", grupoVeiculos.Id);

                return Result.Fail(msgErro);
            }


        }

        public Result<int> QuantidadeGrupoVeiculosCadastrados()
        {
            try
            {
                return Result.Ok(repositorioGrupoVeiculos.QuantidadeGrupoVeiculosCadastrados());
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar a quantidade de grupo de veículos";

                Log.Logger.Error(ex, msgErro);

                return Result.Fail(msgErro);
            }
        }


        #endregion
    }
}