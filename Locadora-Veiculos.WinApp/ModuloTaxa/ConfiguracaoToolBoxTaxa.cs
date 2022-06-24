using Locadora_Veiculos.WinApp.Compartilhado;

namespace Locadora_Veiculos.WinApp.ModuloTaxas
{
    public class ConfiguracaoToolBoxTaxa : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Cadastro de Taxas";

        public override string TooltipInserir => "Inserir uma nova Taxa";

        public override string TooltipEditar => "Editar uma Taxa existente";

        public override string TooltipExcluir => "Excluir uma Taxa existente";
    }
}
