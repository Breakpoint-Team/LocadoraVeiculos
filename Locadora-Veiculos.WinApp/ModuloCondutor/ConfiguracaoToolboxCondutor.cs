using Locadora_Veiculos.WinApp.Compartilhado;

namespace Locadora_Veiculos.WinApp.ModuloCondutor
{
    public class ConfiguracaoToolboxCondutor : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Cadastro de Condutor";

        public override string TooltipInserir => "Inserir um novo Condutor";

        public override string TooltipEditar => "Editar um Condutor existente";

        public override string TooltipExcluir => "Excluir um Condutor existente";
    }
}