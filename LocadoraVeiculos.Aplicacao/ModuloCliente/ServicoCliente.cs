using FluentValidation.Results;
using Locadora_Veiculos.Dominio.ModuloCliente;
using Locadora_Veiculos.Infra.BancoDados.ModuloCliente;

namespace LocadoraVeiculos.Aplicacao.ModuloCliente
{
    public class ServicoCliente
    {
        private RepositorioClienteEmBancoDados repositorioCliente;

        public ServicoCliente(RepositorioClienteEmBancoDados repositorioCliente)
        {
            this.repositorioCliente = repositorioCliente;
        }

        public ValidationResult Inserir(Cliente cliente)
        {
            var resultadoValidacao = ValidarCliente(cliente);

            if (resultadoValidacao.IsValid)
                repositorioCliente.Inserir(cliente);

            return resultadoValidacao;
        }

        public ValidationResult Editar(Cliente cliente)
        {
            var resultadoValidacao = ValidarCliente(cliente);

            if (resultadoValidacao.IsValid)
                repositorioCliente.Editar(cliente);

            return resultadoValidacao;
        }

        private ValidationResult ValidarCliente(Cliente cliente)
        {
            ValidadorCliente validador = new ValidadorCliente();
        
            var resultadoValidacao = validador.Validate(cliente);
            
            return resultadoValidacao;
        }
    }
}