using FluentValidation.Results;
using Locadora_Veiculos.Dominio.ModuloTaxa;
using Serilog;
using System;

namespace LocadoraVeiculos.Aplicacao.ModuloTaxa
{
    public class ServicoTaxa
    {
        private IRepositorioTaxa repositorioTaxa;

        public ServicoTaxa(IRepositorioTaxa repositorioTaxa)
        {
            this.repositorioTaxa = repositorioTaxa;
        }

        public ValidationResult Inserir(Taxa taxa)
        {
            Log.Logger.Debug("Tentando inserir Taxa... {@Taxa}", taxa);

            ValidationResult resultadoValidacao = Validar(taxa);

            if (resultadoValidacao.IsValid)
            {
                repositorioTaxa.Inserir(taxa);
                Log.Logger.Debug("Taxa '{TaxaDescricao}' inserido com sucesso", taxa.Descricao);

            }
            else
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir uma Taxa '{TaxaDescricao}' - {Motivo}",
                        taxa.Descricao, erro.ErrorMessage);
                }
            }

            return resultadoValidacao;
        }

        public ValidationResult Editar(Taxa taxa)
        {
            Log.Logger.Debug("Tentando editar Taxa... {@Taxa}", taxa);
            ValidationResult resultadoValidacao = Validar(taxa);

            if (resultadoValidacao.IsValid)
            {
                repositorioTaxa.Editar(taxa);
                Log.Logger.Debug("Taxa com Id = '{TaxaId}' editada com sucesso", taxa.Id);

            }
            else
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar a Taxa com Id = '{TaxaId}' - {Motivo}",
                        taxa.Id, erro.ErrorMessage);
                }
            }

            return resultadoValidacao;
        }

        #region MÉTODOS PRIVADOS

        private ValidationResult Validar(Taxa taxa)
        {
            var validador = new ValidadorTaxa();

            var resultadoValidacao = validador.Validate(taxa);

            if (DescricaoDuplicada(taxa))
                resultadoValidacao.Errors.Add(new ValidationFailure("Nome", "Nome já está cadastrado!"));

            return resultadoValidacao;
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