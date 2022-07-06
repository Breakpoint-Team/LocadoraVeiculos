using Locadora_Veiculos.WinApp.Compartilhado;

namespace Locadora_Veiculos.WinApp.ModuloPlanoCobrança
{
    public class ConfiguracaoToolboxPlanoCobranca : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Cadastro de Plano de Cobrança";

        public override string TooltipInserir => "Inserir um novo Plano de Cobrança";

        public override string TooltipEditar => "Editar um Plano de Cobrança existente";

        public override string TooltipExcluir => "Excluir um Plano de Cobrança existente";
    }
}
