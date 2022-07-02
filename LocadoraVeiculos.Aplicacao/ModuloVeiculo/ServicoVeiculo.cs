using FluentValidation.Results;
using Locadora_Veiculos.Dominio.ModuloVeiculo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Aplicacao.ModuloVeiculo
{
    public class ServicoVeiculo
    {
        IRepositorioVeiculo repositorioVeiculo;

        public ServicoVeiculo(IRepositorioVeiculo repositorioVeiculo)
        {
            this.repositorioVeiculo = repositorioVeiculo;
        }

        public ValidationResult Inserir(Veiculo veiculo)
        {
            ValidationResult resultadoValidacao = Validar(veiculo);

            if (resultadoValidacao.IsValid)
                repositorioVeiculo.Inserir(veiculo);

            return resultadoValidacao;
        }

        public ValidationResult Editar(Veiculo veiculo)
        {
            ValidationResult resultadoValidacao = Validar(veiculo);

            if (resultadoValidacao.IsValid)
                repositorioVeiculo.Editar(veiculo);

            return resultadoValidacao;
        }

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
    }
}
