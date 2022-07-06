using FluentValidation.Results;
using Locadora_Veiculos.Dominio.ModuloGrupoVeiculos;
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
            ValidationResult resultadoValidacao = Validar(grupoVeiculos);

            if (resultadoValidacao.IsValid)
                repositorioGrupoVeiculos.Inserir(grupoVeiculos);

            return resultadoValidacao;
        }

        public ValidationResult Editar(GrupoVeiculos grupoVeiculos)
        {
            ValidationResult resultadoValidacao = Validar(grupoVeiculos);

            if (resultadoValidacao.IsValid)
                repositorioGrupoVeiculos.Editar(grupoVeiculos);

            return resultadoValidacao;
        }

        public ValidationResult Excluir(GrupoVeiculos grupoVeiculos)
        {
            var resultadoValidacao = ExclusaoValida(grupoVeiculos);

            if (resultadoValidacao.IsValid)
                repositorioGrupoVeiculos.Excluir(grupoVeiculos);

            return resultadoValidacao;
        }

        #region MÉTODOS PRIVADOS

        private ValidationResult ExclusaoValida(GrupoVeiculos grupoVeiculos)
        {
            ValidationResult resultadoValidacao = new ValidationResult();

            if (TemVeiculosRelacionados(grupoVeiculos))
                resultadoValidacao.Errors.Add(new ValidationFailure("", "Não é possível excluir um Grupo de veículos que possui Veículos relacionados"));

            return resultadoValidacao;
        }

        private bool TemVeiculosRelacionados(GrupoVeiculos grupoVeiculos)
        {
            int qtdCondutoresRelacionados = repositorioGrupoVeiculos.QuantidadeVeiculosRelacionadosAoGrupo(grupoVeiculos.Id);

            if (qtdCondutoresRelacionados > 0)
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