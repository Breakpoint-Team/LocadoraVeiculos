using FluentValidation.Results;
using Locadora_Veiculos.Dominio.ModuloPlanoCobranca;
using System;

namespace LocadoraVeiculos.Aplicacao.ModuloPlanoCobranca
{
    public class ServicoPlanoCobranca
    {
        private IRepositorioPlanoCobranca repositorioPlanoCobranca;

        public ServicoPlanoCobranca(IRepositorioPlanoCobranca repositorioPlanoCobranca)
        {
            this.repositorioPlanoCobranca = repositorioPlanoCobranca;
        }

        public ValidationResult Inserir(PlanoCobranca grupoVeiculos)
        {
            ValidationResult resultadoValidacao = Validar(grupoVeiculos);

            if (resultadoValidacao.IsValid)
                repositorioPlanoCobranca.Inserir(grupoVeiculos);

            return resultadoValidacao;
        }

        public ValidationResult Editar(PlanoCobranca grupoVeiculos)
        {
            ValidationResult resultadoValidacao = Validar(grupoVeiculos);

            if (resultadoValidacao.IsValid)
                repositorioPlanoCobranca.Editar(grupoVeiculos);

            return resultadoValidacao;
        }

        #region MÉTODOS PRIVADOS

        private ValidationResult Validar(PlanoCobranca planoCobranca)
        {
            var validador = new ValidadorPlanoCobranca();

            var resultadoValidacao = validador.Validate(planoCobranca);

            if (NomeDuplicado(planoCobranca))
                resultadoValidacao.Errors.Add(new ValidationFailure("Nome", "Nome já está cadastrado!"));

            return resultadoValidacao;
        }

        private bool NomeDuplicado(PlanoCobranca planoCobranca)
        {
            var grupoVeiculosEncontrado = repositorioPlanoCobranca.SelecionarPlanoCobrancaPorNome(planoCobranca.Nome);

            return grupoVeiculosEncontrado != null &&
                   grupoVeiculosEncontrado.Nome.Equals(planoCobranca.Nome, StringComparison.OrdinalIgnoreCase) &&
                   grupoVeiculosEncontrado.Id != planoCobranca.Id;

        }

        #endregion

    }
}
