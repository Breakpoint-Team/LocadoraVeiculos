using Locadora_Veiculos.Dominio.Compartilhado;

namespace Locadora_Veiculos.Dominio.ModuloCondutor
{
    public interface IRepositorioCondutor : IRepositorio<Condutor>
    {
        Condutor SelecionarCondutorPorCPF(string cpf);

        Condutor SelecionarCondutorPorCNH(string cnh);

        int QuantidadeCondutoresCadastrados();

    }
}