using FluentResults;
using FluentValidation.Results;
using Locadora_Veiculos.Dominio.ModuloVeiculo;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraVeiculos.Aplicacao.ModuloVeiculo
{
    public class ServicoVeiculo
    {
        private IRepositorioVeiculo repositorioVeiculo;

        public ServicoVeiculo(IRepositorioVeiculo repositorioVeiculo)
        {
            this.repositorioVeiculo = repositorioVeiculo;
        }

        public Result<Veiculo> Inserir(Veiculo veiculo)
        {
            Log.Logger.Debug("Tentando inserir Veículo... {@Veiculo}", veiculo);

            Result resultadoValidacao = Validar(veiculo);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir o Veículo '{VeiculoId}' - {Motivo}",
                        veiculo.Id, erro.Message);
                }
                return Result.Fail(resultadoValidacao.Errors);
            }
            try
            {
                repositorioVeiculo.Inserir(veiculo);
                Log.Logger.Debug("Veículo {VeiculoId} inserido com sucesso", veiculo.Id);
                return Result.Ok(veiculo);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar inserir o Veículo";

                Log.Logger.Error(ex, msgErro + "{VeiculoId}", veiculo.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<Veiculo> Editar(Veiculo veiculo)
        {
            Log.Logger.Debug("Tentando editar Veículo... {@Veiculo}", veiculo);

            var resultadoValidacao = Validar(veiculo);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar o Veículo {VeiculoId} - {Motivo}",
                        veiculo.Id, erro.Message);
                }
                return Result.Fail(resultadoValidacao.Errors);
            }
            try
            {
                repositorioVeiculo.Editar(veiculo);
                Log.Logger.Information("Veículo {VeiculoId} editado com sucesso", veiculo.Id);
                return Result.Ok(veiculo);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar editar o veículo";

                Log.Logger.Error(ex, msgErro + "{VeiculoId}", veiculo.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(Veiculo veiculo)
        {
            Log.Logger.Debug("Tentando excluir Veículo... {@Veiculo}", veiculo);

            try
            {
                repositorioVeiculo.Excluir(veiculo);
                Log.Logger.Debug("Veículo '{VeiculoId}' excluído com sucesso", veiculo.Id);
                return Result.Ok();
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar excluir o veículo";

                Log.Logger.Error(ex, msgErro + "{VeiculoId}", veiculo.Id);

                return Result.Fail(msgErro);
            }

        }

        public Result<List<Veiculo>> SelecionarTodos()
        {
            try
            {
                return Result.Ok(repositorioVeiculo.SelecionarTodos());
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar todos os veículos";

                Log.Logger.Error(ex, msgErro);

                return Result.Fail(msgErro);
            }
        }

        public Result<Veiculo> SelecionarPorId(Guid id)
        {
            try
            {
                return Result.Ok(repositorioVeiculo.SelecionarPorId(id));
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar o veículo";

                Log.Logger.Error(ex, msgErro + "{VeiculoId}", id);

                return Result.Fail(msgErro);
            }
        }

        #region MÉTODOS PRIVADOS

        private Result Validar(Veiculo veiculo)
        {
            var validador = new ValidadorVeiculo();

            var resultadoValidacao = validador.Validate(veiculo);

            List<Error> erros = new List<Error>();

            foreach (ValidationFailure item in resultadoValidacao.Errors)
                erros.Add(new Error(item.ErrorMessage));

            var resultadoComparacao = PlacaDuplicada(veiculo);


            if (resultadoComparacao.IsSuccess)
            {
                if (resultadoComparacao.Value == true)
                {
                    erros.Add(new Error("Placa já está cadastrada!"));
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

        private Result<bool> PlacaDuplicada(Veiculo veiculo)
        {
            try
            {
                var placaEncontrada = repositorioVeiculo.SelecionarVeiculoPorPlaca(veiculo.Placa);
                var resultadoComparacao = placaEncontrada != null &&
                       placaEncontrada.Placa.Equals(veiculo.Placa, StringComparison.OrdinalIgnoreCase) &&
                       placaEncontrada.Id != veiculo.Id;
                return Result.Ok(resultadoComparacao);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar comparar a placa do veículo";

                Log.Logger.Error(ex, msgErro + " {VeiculosId}", veiculo.Id);

                return Result.Fail(msgErro);
            }


        }

        #endregion
    }
}