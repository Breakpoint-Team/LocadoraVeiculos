using Locadora_Veiculos.Dominio.Compartilhado;

namespace Locadora_Veiculos.Dominio.ModuloVeiculo
{
    public interface IRepositorioVeiculo : IRepositorio<Veiculo>
    {
        Veiculo SelecionarVeiculoPorPlaca(string placa);
        
        int QuantidadeVeiculosCadastrados();
    }
}
