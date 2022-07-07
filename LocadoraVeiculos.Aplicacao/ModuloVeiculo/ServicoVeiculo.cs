using FluentValidation.Results;
using Locadora_Veiculos.Dominio.ModuloVeiculo;
using Serilog;
using System;

namespace LocadoraVeiculos.Aplicacao.ModuloVeiculo
{
    public class ServicoVeiculo
    {
        private IRepositorioVeiculo repositorioVeiculo;

        public ServicoVeiculo(IRepositorioVeiculo repositorioVeiculo)
        {
            this.repositorioVeiculo = repositorioVeiculo;
        }

        public ValidationResult Inserir(Veiculo veiculo)
        {
            Log.Logger.Debug("Tentando inserir Veículo... {@Veiculo}", veiculo);

            ValidationResult resultadoValidacao = Validar(veiculo);

            if (resultadoValidacao.IsValid)
            {
                repositorioVeiculo.Inserir(veiculo);
                Log.Logger.Debug("Veículo '{VeiculoModelo}' inserido com sucesso", veiculo.Modelo);
            }
            else
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir um Veículo '{VeiculoModelo}' - {Motivo}",
                        veiculo.Modelo, erro.ErrorMessage);
                }
            }

            return resultadoValidacao;
        }

        public ValidationResult Editar(Veiculo veiculo)
        {
            Log.Logger.Debug("Tentando editar Veículo... {@Veiculo}", veiculo);

            ValidationResult resultadoValidacao = Validar(veiculo);

            if (resultadoValidacao.IsValid)
            {
                repositorioVeiculo.Editar(veiculo);
                Log.Logger.Debug("Veículo com Id = '{VeiculoId}' editado com sucesso", veiculo.Id);
            }
            else
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar o Veículo com Id = '{VeiculoId}' - {Motivo}",
                        veiculo.Id, erro.ErrorMessage);
                }
            }

            return resultadoValidacao;
        }

        #region MÉTODOS PRIVADOS

        private ValidationResult Validar(Veiculo veiculo)
        {
            var validador = new ValidadorVeiculo();

            var resultadoValidacao = validador.Validate(veiculo);

            if (PlacaDuplicada(veiculo))
                resultadoValidacao.Errors.Add(new ValidationFailure("Placa", "Placa já está cadastrada!"));

            return resultadoValidacao;
        }

        private bool PlacaDuplicada(Veiculo veiculo)
        {
            var placaEncontrada = repositorioVeiculo.SelecionarVeiculoPorPlaca(veiculo.Placa);

            return placaEncontrada != null &&
                   placaEncontrada.Placa.Equals(veiculo.Placa, StringComparison.OrdinalIgnoreCase) &&
                   placaEncontrada.Id != veiculo.Id;
        }

        #endregion
    }
}