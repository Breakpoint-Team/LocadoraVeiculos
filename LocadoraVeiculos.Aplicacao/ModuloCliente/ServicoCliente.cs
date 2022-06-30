using FluentValidation.Results;
using Locadora_Veiculos.Dominio.ModuloCliente;

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
            var resultadoValidacao = Validar(cliente);

            if (resultadoValidacao.IsValid)
                repositorioCliente.Inserir(cliente);

            return resultadoValidacao;
        }

        public ValidationResult Editar(Cliente cliente)
        {
            var resultadoValidacao = Validar(cliente);

            if (resultadoValidacao.IsValid)
                repositorioCliente.Editar(cliente);

            return resultadoValidacao;
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
    }
}