using FluentValidation.Results;
using Locadora_Veiculos.Dominio.ModuloTaxa;

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
            ValidationResult resultadoValidacao = Validar(taxa);

            if (resultadoValidacao.IsValid)
                repositorioTaxa.Inserir(taxa);

            return resultadoValidacao;
        }

        public ValidationResult Editar(Taxa taxa)
        {
            ValidationResult resultadoValidacao = Validar(taxa);

            if (resultadoValidacao.IsValid)
                repositorioTaxa.Editar(taxa);

            return resultadoValidacao;
        }

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
            //var taxaEncontrada = repositorioTaxa.SelecionarTaxaPorDescricao(taxa.Descricao);

            //return taxaEncontrada != null &&
            //       taxaEncontrada.Descricao == taxa.Descricao &&
            //       taxaEncontrada.Id != taxa.Id;
            return true;
        }
    }
}