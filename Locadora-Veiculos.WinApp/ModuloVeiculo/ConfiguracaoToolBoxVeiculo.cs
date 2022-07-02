using Locadora_Veiculos.WinApp.Compartilhado;

namespace Locadora_Veiculos.WinApp.ModuloVeiculo
{
    public class ConfiguracaoToolBoxVeiculo : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Cadastro de Veículos";

        public override string TooltipInserir => "Inserir um novo Veículo";

        public override string TooltipEditar => "Editar um Veículo existente";

        public override string TooltipExcluir => "Excluir um Veículo existente";
    }
}
