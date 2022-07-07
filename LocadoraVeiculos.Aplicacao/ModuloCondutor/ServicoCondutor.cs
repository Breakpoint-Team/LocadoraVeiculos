using FluentValidation.Results;
using Locadora_Veiculos.Dominio.ModuloCondutor;
using Serilog;

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
            Log.Logger.Debug("Tentando inserir Condutor... {@Condutor}", condutor);

            var resultadoValidacao = Validar(condutor);

            if (resultadoValidacao.IsValid)
            {
                repositorioCondutor.Inserir(condutor);
                Log.Logger.Debug("Condutor '{CondutorNome}' inserido com sucesso", condutor.Nome);
            }
            else
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir um Condutor '{CondutorNome}' - {Motivo}",
                       condutor.Nome, erro.ErrorMessage);
                }
            }

            return resultadoValidacao;
        }

        public ValidationResult Editar(Condutor condutor)
        {
            Log.Logger.Debug("Tentando editar Condutor... {@Condutor}", condutor);

            var resultadoValidacao = Validar(condutor);

            if (resultadoValidacao.IsValid)
            {
                repositorioCondutor.Editar(condutor);
                Log.Logger.Debug("Condutor com Id = '{CondutorId}' editado com sucesso", condutor.Id);

            }
            else
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar o Condutor com Id = '{CondutorId}' - {Motivo}",
                        condutor.Id, erro.ErrorMessage);
                }
            }

            return resultadoValidacao;
        }

        public ValidationResult Excluir(Condutor condutor)
        {
            Log.Logger.Debug("Tentando excluir Condutor... {@Condutor}", condutor);

            repositorioCondutor.Excluir(condutor);

            Log.Logger.Debug("Condutor com Id = '{CondutorId}' excluído com sucesso", condutor.Id);

            return new ValidationResult();
        }

        #region MÉTODOS PRIVADOS

        private ValidationResult Validar(Condutor condutor)
        {
            ValidadorCondutor validador = new ValidadorCondutor();

            var resultadoValidacao = validador.Validate(condutor);

            if (CpfDuplicado(condutor))
                resultadoValidacao.Errors.Add(new ValidationFailure("CPF", "CPF já está cadastrado como condutor!"));

            if (CnhDuplicada(condutor))
                resultadoValidacao.Errors.Add(new ValidationFailure("CNH", "CNH já está cadastrada como condutor!"));

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