
namespace Locadora_Veiculos.WinApp.Compartilhado.Servicelocator
{
    public interface IServiceLocator
    {
        T Get<T>() where T : ControladorBase;
    }
}
