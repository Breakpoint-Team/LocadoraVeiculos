using Locadora_Veiculos.WinApp.Compartilhado;

namespace Locadora_Veiculos.WinApp.ModuloConfiguracao
{
    public class ConfiguracaoToolBoxConfiguracao : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "";

        public override string TooltipInserir => "";

        public override string TooltipEditar => "";

        public override string TooltipExcluir => "";

        public override bool InserirHabilitado { get { return false; } }

        public override bool EditarHabilitado { get { return false; } }

        public override bool ExcluirHabilitado { get { return false; } }

    }
}
