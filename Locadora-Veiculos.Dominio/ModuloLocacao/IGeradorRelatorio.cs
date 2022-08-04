
namespace Locadora_Veiculos.Dominio.ModuloLocacao
{
    public interface IGeradorRelatorio
    {
        void GerarRelatorioLocacaoPDF(Locacao locacao);
        void GerarRelatorioDevolucaoPDF(Locacao locacao);
    }
}
