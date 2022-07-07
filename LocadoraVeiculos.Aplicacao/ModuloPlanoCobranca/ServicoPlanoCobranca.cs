using FluentValidation.Results;
using Locadora_Veiculos.Dominio.ModuloPlanoCobranca;

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

            if (GrupoVeiculoJaTemPlanoRelacionado(planoCobranca))
                resultadoValidacao.Errors.Add(new ValidationFailure("Grupo de Veículos", "O Grupo de Veículos selecionado já possui um plano de cobrança relacionado!"));

            return resultadoValidacao;
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
