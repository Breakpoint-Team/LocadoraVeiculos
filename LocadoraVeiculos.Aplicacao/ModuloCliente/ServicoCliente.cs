using FluentValidation.Results;
using Locadora_Veiculos.Dominio.ModuloCliente;
using Serilog;

namespace LocadoraVeiculos.Aplicacao.ModuloCliente
{
    public class ServicoCliente
    {
        private IRepositorioCliente repositorioCliente;

        public ServicoCliente(IRepositorioCliente repositorioCliente)
        {
            this.repositorioCliente = repositorioCliente;
        }

        public ValidationResult Inserir(Cliente cliente)
        {
            Log.Logger.Debug("Tentando inserir Cliente... {@Cliente}", cliente);

            var resultadoValidacao = Validar(cliente);

            if (resultadoValidacao.IsValid)
            {
                repositorioCliente.Inserir(cliente);
                Log.Logger.Debug("Cliente '{ClienteNome}' inserido com sucesso", cliente.Nome);
            }
            else
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir um Cliente '{ClienteNome}' - {Motivo}",
                        cliente.Nome, erro.ErrorMessage);
                }
            }

            return resultadoValidacao;
        }

        public ValidationResult Editar(Cliente cliente)
        {
            Log.Logger.Debug("Tentando editar Cliente... {@Cliente}", cliente);

            var resultadoValidacao = Validar(cliente);

            if (resultadoValidacao.IsValid)
            {
                repositorioCliente.Editar(cliente);
                Log.Logger.Debug("Cliente com Id = '{ClienteId}' editado com sucesso", cliente.Id);
            }
            else
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar o Cliente com Id = '{ClienteId}' - {Motivo}",
                        cliente.Id, erro.ErrorMessage);
                }
            }

            return resultadoValidacao;
        }

        public ValidationResult Excluir(Cliente cliente)
        {
            Log.Logger.Debug("Tentando excluir Cliente... {@Cliente}", cliente);

            var resultadoValidacao = ExclusaoValida(cliente);

            if (resultadoValidacao.IsValid)
            {
                repositorioCliente.Excluir(cliente);
                Log.Logger.Debug("Cliente com Id = '{ClienteId}' excluído com sucesso", cliente.Id);
            }
            else
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar excluir o Cliente com Id = '{ClienteId}' - {Motivo}",
                        cliente.Id, erro.ErrorMessage);
                }
            }

            return resultadoValidacao;
        }

        #region MÉTODOS PRIVADOS

        private ValidationResult ExclusaoValida(Cliente cliente)
        {
            ValidationResult resultadoValidacao = new ValidationResult();

            if (TemCondutoresRelacionados(cliente))
                resultadoValidacao.Errors.Add(new ValidationFailure("", "Não é possível excluir um Cliente que possui Condutores relacionados!"));

            return resultadoValidacao;
        }

        private bool TemCondutoresRelacionados(Cliente cliente)
        {
            int qtdCondutoresRelacionados = repositorioCliente.QuantidadeCondutoresRelacionadosAoCliente(cliente.Id);

            if (qtdCondutoresRelacionados > 0)
                return true;

            return false;
        }

        private ValidationResult Validar(Cliente cliente)
        {
            ValidadorCliente validador = new ValidadorCliente();

            var resultadoValidacao = validador.Validate(cliente);

            if (DocumentoDuplicado(cliente))
                resultadoValidacao.Errors.Add(new ValidationFailure("Documento", "Documento já está cadastrado!"));

            return resultadoValidacao;
        }

        private bool DocumentoDuplicado(Cliente cliente)
        {
            var clienteEncontrado = repositorioCliente.SelecionarClientePorDocumento(cliente.Documento);

            return clienteEncontrado != null &&
                   clienteEncontrado.Documento == cliente.Documento &&
                   clienteEncontrado.Id != cliente.Id;
        }

        #endregion
    }
}