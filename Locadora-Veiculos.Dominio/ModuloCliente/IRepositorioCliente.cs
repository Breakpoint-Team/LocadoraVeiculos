using Locadora_Veiculos.Dominio.Compartilhado;

namespace Locadora_Veiculos.Dominio.ModuloCliente
{
    public interface IRepositorioCliente : IRepositorio<Cliente>
    {
        Cliente SelecionarClientePorDocumento(string documento);

        int QuantidadeClientesCadastrados();

        int QuantidadeCondutoresRelacionadosAoCliente(int id);
    }
}