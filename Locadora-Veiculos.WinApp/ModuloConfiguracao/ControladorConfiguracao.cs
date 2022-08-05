using Locadora_Veiculos.Infra.Configs;
using Locadora_Veiculos.WinApp.Compartilhado;
using System;
using System.Windows.Forms;

namespace Locadora_Veiculos.WinApp.ModuloConfiguracao
{
    public class ControladorConfiguracao : ControladorBase
    {
        private ConfiguracaoAplicacao configuracao;

        public ControladorConfiguracao(ConfiguracaoAplicacao configuracao)
        {
            this.configuracao = configuracao;
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolBoxConfiguracao();
        }

        public override UserControl ObtemListagem()
        {
            return new ConfiguracaoControl(configuracao);
        }


        #region 
        public override void Inserir()
        {

        }
        public override void Editar()
        {

        }
        public override void Excluir()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
