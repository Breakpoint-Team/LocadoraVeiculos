namespace Locadora_Veiculos.Dominio.Compartilhado
{
    public interface IContextoPersistencia
    {
        void GravarDados();

        void DesfazerAlteracoes();
    }
}