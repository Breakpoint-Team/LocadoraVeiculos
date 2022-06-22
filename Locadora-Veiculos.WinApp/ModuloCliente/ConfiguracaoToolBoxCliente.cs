using Locadora_Veiculos.WinApp.Compartilhado;

namespace Locadora_Veiculos.WinApp.ModuloCliente
{
    public class ConfiguracaoToolBoxCliente : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Cadastro de Clientes";

        public override string TooltipInserir => "Inserir um novo Cliente";

        public override string TooltipEditar => "Editar um Cliente existente";

        public override string TooltipExcluir => "Excluir um Cliente existente";
    }
}
