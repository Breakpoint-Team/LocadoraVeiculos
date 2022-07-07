using FluentValidation.Results;
using Locadora_Veiculos.Dominio.ModuloPlanoCobranca;
using Serilog;

namespace LocadoraVeiculos.Aplicacao.ModuloPlanoCobranca
{
    public class ServicoPlanoCobranca
    {
        private IRepositorioPlanoCobranca repositorioPlanoCobranca;

        public ServicoPlanoCobranca(IRepositorioPlanoCobranca repositorioPlanoCobranca)
        {
            this.repositorioPlanoCobranca = repositorioPlanoCobranca;
        }

        public ValidationResult Inserir(PlanoCobranca planoCobranca)
        {
            Log.Logger.Debug("Tentando inserir Plano de Cobrança... {@PlanoCobranca}", planoCobranca);

            ValidationResult resultadoValidacao = Validar(planoCobranca);

            if (resultadoValidacao.IsValid)
            {
                repositorioPlanoCobranca.Inserir(planoCobranca);
                Log.Logger.Debug("Plano de Cobrança do Grupo de Veículos = '{GrupoVeiculosNome}' inserido com sucesso", planoCobranca.GrupoVeiculos.Nome);

            } else
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir um Plano de Cobrança do Grupo de Veículos = '{GrupoVeiculosNome}' - {Motivo}",
                        planoCobranca.GrupoVeiculos.Nome, erro.ErrorMessage);
                }
            }

            return resultadoValidacao;
        }

        public ValidationResult Editar(PlanoCobranca planoCobranca)
        {
            Log.Logger.Debug("Tentando editar Plano de Cobrança... {@PlanoCobranca}", planoCobranca);

            ValidationResult resultadoValidacao = Validar(planoCobranca);

            if (resultadoValidacao.IsValid)
            {
                repositorioPlanoCobranca.Editar(planoCobranca);
                Log.Logger.Debug("Plano de Cobrança com Id = '{PlanoCobrancaId}' editado com sucesso", planoCobranca.Id);
            } else
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar o Plano de Cobrança com Id = '{PlanoCobrancaId}' - {Motivo}",
                        planoCobranca.Id, erro.ErrorMessage);
                }
            }

            return resultadoValidacao;
        }

        public ValidationResult Excluir(PlanoCobranca planoCobranca)
        {
            Log.Logger.Debug("Tentando excluir Plano de Cobrança... {@PlanoCobranca}", planoCobranca);

            repositorioPlanoCobranca.Excluir(planoCobranca);

            Log.Logger.Debug("Plano de Cobrança com Id = '{PlanoCobrancaId}' excluído com sucesso", planoCobranca.Id);

            return new ValidationResult();
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
