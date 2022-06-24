using Locadora_Veiculos.WinApp.Compartilhado;

namespace Locadora_Veiculos.WinApp.ModuloTaxas
{
    public class ConfiguracaoToolBoxTaxa : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Cadastro de taxa";

        public override string TooltipInserir => "Inserir uma nova taxa";

        public override string TooltipEditar => "Editar uma taxa existente";

        public override string TooltipExcluir => "Excluir uma taxa existente";
    }
}
