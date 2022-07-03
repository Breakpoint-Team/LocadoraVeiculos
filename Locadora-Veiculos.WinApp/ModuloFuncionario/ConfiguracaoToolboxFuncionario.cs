using Locadora_Veiculos.WinApp.Compartilhado;

namespace Locadora_Veiculos.WinApp.ModuloFuncionario
{
    public class ConfiguracaoToolboxFuncionario : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Cadastro de Funcionários";

        public override string TooltipInserir => "Inserir um novo Funcionário";

        public override string TooltipEditar => "Editar um Funcionário existente";

        public override string TooltipExcluir => "Excluir um Funcionário existente";
    }
}