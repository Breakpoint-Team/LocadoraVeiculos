using Locadora_Veiculos.WinApp.Compartilhado;

namespace Locadora_Veiculos.WinApp.ModuloLocacao
{
    public class ConfiguracaoToolBoxLocacao : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Cadastro de Locações";

        public override string TooltipInserir => "Inserir uma nova Locação";

        public override string TooltipEditar => "Editar uma Locação existente";

        public override string TooltipExcluir => "Excluir uma Locação existente";
    }
}
