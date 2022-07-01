using FluentValidation.Results;
using Locadora_Veiculos.Dominio.ModuloCondutor;

namespace LocadoraVeiculos.Aplicacao.ModuloCondutor
{
    public class ServicoCondutor
    {
        private IRepositorioCondutor repositorioCondutor;

        public ServicoCondutor(IRepositorioCondutor repositorioCondutor)
        {
            this.repositorioCondutor = repositorioCondutor;
        }

        public ValidationResult Inserir(Condutor condutor)
        {
            var resultadoValidacao = Validar(condutor);

            if (resultadoValidacao.IsValid)
                repositorioCondutor.Inserir(condutor);

            return resultadoValidacao;
        }

        public ValidationResult Editar(Condutor condutor)
        {
            var resultadoValidacao = Validar(condutor);

            if (resultadoValidacao.IsValid)
                repositorioCondutor.Editar(condutor);

            return resultadoValidacao;
        }

        #region MÉTODOS PRIVADOS

        private ValidationResult Validar(Condutor condutor)
        {
            ValidadorCondutor validador = new ValidadorCondutor();

            var resultadoValidacao = validador.Validate(condutor);

            if (CpfDuplicado(condutor))
                resultadoValidacao.Errors.Add(new ValidationFailure("CPF", "CPF já está cadastrado!"));
            
            if (CnhDuplicada(condutor))
                resultadoValidacao.Errors.Add(new ValidationFailure("CNH", "CNH já está cadastrada!"));

            return resultadoValidacao;
        }

        private bool CnhDuplicada(Condutor condutor)
        {
            var condutorEncontrado = repositorioCondutor.SelecionarCondutorPorCNH(condutor.Cnh);

            return condutorEncontrado != null &&
                   condutorEncontrado.Cnh == condutor.Cnh &&
                   condutorEncontrado.Id != condutor.Id;
        }

        private bool CpfDuplicado(Condutor condutor)
        {
            var condutorEncontrado = repositorioCondutor.SelecionarCondutorPorCPF(condutor.Cpf);

            return condutorEncontrado != null &&
                   condutorEncontrado.Cpf == condutor.Cpf &&
                   condutorEncontrado.Id != condutor.Id;
        }
        
        #endregion
    }
}