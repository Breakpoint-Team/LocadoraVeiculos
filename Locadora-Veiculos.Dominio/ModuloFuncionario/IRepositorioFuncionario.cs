using Locadora_Veiculos.Dominio.Compartilhado;

namespace Locadora_Veiculos.Dominio.ModuloFuncionario
{
    public interface IRepositorioFuncionario : IRepositorio<Funcionario>
    {
        Funcionario SelecionarFuncionarioPorLogin(string login);
    }
}