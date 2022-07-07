using FluentValidation.Results;
using Locadora_Veiculos.Dominio.ModuloGrupoVeiculos;
using Serilog;
using System;

namespace LocadoraVeiculos.Aplicacao.ModuloGrupoVeiculos
{
    public class ServicoGrupoVeiculos
    {
        private IRepositorioGrupoVeiculos repositorioGrupoVeiculos;

        public ServicoGrupoVeiculos(IRepositorioGrupoVeiculos repositorioGrupoVeiculos)
        {
            this.repositorioGrupoVeiculos = repositorioGrupoVeiculos;
        }

        public ValidationResult Inserir(GrupoVeiculos grupoVeiculos)
        {
            Log.Logger.Debug("Tentando inserir Grupo de Veículos... {@GrupoVeiculos}", grupoVeiculos);
            ValidationResult resultadoValidacao = Validar(grupoVeiculos);

            if (resultadoValidacao.IsValid)
            {
                repositorioGrupoVeiculos.Inserir(grupoVeiculos);
                Log.Logger.Debug("Grupo de Veículos '{GrupoVeiculosNome}' inserido com sucesso", grupoVeiculos.Nome);
            }
            else
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir um Grupo de Veículos '{GrupoVeiculosNome}' - {Motivo}",
                        grupoVeiculos.Nome, erro.ErrorMessage);
                }
            }
            return resultadoValidacao;
        }

        public ValidationResult Editar(GrupoVeiculos grupoVeiculos)
        {
            Log.Logger.Debug("Tentando editar Grupo de Veículos... {@GrupoVeiculos}", grupoVeiculos);

            ValidationResult resultadoValidacao = Validar(grupoVeiculos);

            if (resultadoValidacao.IsValid)
            {
                repositorioGrupoVeiculos.Editar(grupoVeiculos);
                Log.Logger.Debug("Grupo de Veículos com Id = '{GrupoVeiculosId}' editado com sucesso", grupoVeiculos.Id);
            }
            else
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar o Grupo de Veículos com Id = '{GrupoVeiculosId}' - {Motivo}",
                        grupoVeiculos.Id, erro.ErrorMessage);
                }
            }

            return resultadoValidacao;
        }

        public ValidationResult Excluir(GrupoVeiculos grupoVeiculos)
        {
            Log.Logger.Debug("Tentando excluir Grupo de Veículos... {@GrupoVeiculos}", grupoVeiculos);
            var resultadoValidacao = ExclusaoValida(grupoVeiculos);

            if (resultadoValidacao.IsValid)
            {
                repositorioGrupoVeiculos.Excluir(grupoVeiculos);
                Log.Logger.Debug("Grupo de Veículos com Id = '{GrupoVeiculosId}' excluído com sucesso", grupoVeiculos.Id);
            }
            else
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar excluir o Grupo de Veículos com Id = '{GrupoVeiculosId}' - {Motivo}",
                        grupoVeiculos.Id, erro.ErrorMessage);
                }
            }
            return resultadoValidacao;
        }

        #region MÉTODOS PRIVADOS

        private ValidationResult ExclusaoValida(GrupoVeiculos grupoVeiculos)
        {
            ValidationResult resultadoValidacao = new ValidationResult();

            if (TemVeiculosRelacionados(grupoVeiculos))
                resultadoValidacao.Errors.Add(new ValidationFailure("", "Não é possível excluir um Grupo de veículos que possui Veículos relacionados!"));

            if (TemPlanosDeCobrancaRelacionados(grupoVeiculos))
                resultadoValidacao.Errors.Add(new ValidationFailure("", "Não é possível excluir um Grupo de veículos que possui Planos de Cobrança relacionados!"));

            return resultadoValidacao;
        }

        private bool TemVeiculosRelacionados(GrupoVeiculos grupoVeiculos)
        {
            int qtdVeiculosRelacionados = repositorioGrupoVeiculos.QuantidadeVeiculosRelacionadosAoGrupo(grupoVeiculos.Id);

            if (qtdVeiculosRelacionados > 0)
                return true;

            return false;
        }

        private bool TemPlanosDeCobrancaRelacionados(GrupoVeiculos grupoVeiculos)
        {
            int qtdPlanosRelacionados = repositorioGrupoVeiculos.QuantidadePlanosDeCobrancaRelacionadosAoGrupo(grupoVeiculos.Id);

            if (qtdPlanosRelacionados > 0)
                return true;

            return false;
        }

        private ValidationResult Validar(GrupoVeiculos grupoVeiculos)
        {
            var validador = new ValidadorGrupoVeiculos();

            var resultadoValidacao = validador.Validate(grupoVeiculos);

            if (NomeDuplicado(grupoVeiculos))
                resultadoValidacao.Errors.Add(new ValidationFailure("Nome", "Nome já está cadastrado!"));

            return resultadoValidacao;
        }

        private bool NomeDuplicado(GrupoVeiculos grupoVeiculos)
        {
            var grupoVeiculosEncontrado = repositorioGrupoVeiculos.SelecionarGrupoVeiculosPorNome(grupoVeiculos.Nome);

            return grupoVeiculosEncontrado != null &&
                   grupoVeiculosEncontrado.Nome.Equals(grupoVeiculos.Nome, StringComparison.OrdinalIgnoreCase) &&
                   grupoVeiculosEncontrado.Id != grupoVeiculos.Id;

        }

        #endregion
    }
}