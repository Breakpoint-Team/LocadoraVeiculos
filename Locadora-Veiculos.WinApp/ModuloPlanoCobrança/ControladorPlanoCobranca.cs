using Locadora_Veiculos.Dominio.ModuloCliente;
using Locadora_Veiculos.Dominio.ModuloCondutor;
using Locadora_Veiculos.WinApp.Compartilhado;
using LocadoraVeiculos.Aplicacao.ModuloCondutor;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Locadora_Veiculos.WinApp.ModuloPlanoCobrança
{
    public class ControladorPlanoCobranca
    {
        private readonly IRepositorioPlanoCobranca repositorioPlanoCobranca;
        private ListagemPlanoCobrancaControl listagemPlanoCobranca;
        private readonly ServicoPlanoCobranca servicoPlanoCobranca;
        public override void Inserir()
        {
            var tela = new TelaCadastroPlanoCobrancaForm();

            tela.PlanoCobranca = new PlanoCobranca();

            tela.GravarRegistro = servicoPlanoCobranca.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarPlanoCobranca();
        }
        public override void Editar()
        {
            PlanoCobranca planoCobrancaSelecionado = ObtemPlanoCobrancaSelecionado();

            if (planoCobrancaSelecionado == null)
            {
                MessageBox.Show("Selecione um grupo de veículos primeiro!",
                "Edição de Grupo de Veículos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var tela = new TelaCadastroPlanoCobrancaForm();

            tela.PlanoCobranca = planoCobrancaSelecionado;

            tela.GravarRegistro = servicoPlanoCobranca.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarPlanos();
        }

        public override void Excluir()
        {
            PlanoCobranca planoCobrancaSelecionado = ObtemPlanoCobrancaSelecionado();

            if (planoCobrancaSelecionado == null)
            {
                MessageBox.Show("Selecione um grupo de veículos primeiro!",
                "Exclusão de Grupo de Veículos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            int qtdPlanosRelacionados = repositorioPlanoCobranca.QuantidadePlanosRelacionadosAoGrupo(planoCobrancaSelecionado.Id);
            if (qtdPlanosRelacionados > 0)
            {
                MessageBox.Show("Não é possível excluir um Grupo de Veículos que possui Veículos relacionados",
                "Exclusão de Grupo de Veículos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            DialogResult resultado = MessageBox.Show("Deseja realmente excluir o grupo de veículos?",
            "Exclusão de Grupo de Veículos", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repositorioPlanoCobranca.Excluir(planoCobrancaSelecionado);
                CarregarPlanos();
            }
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolBoxPlanoCobranca();
        }

        public override UserControl ObtemListagem()
        {
            if (listagemPlanoCobranca == null)
                listagemPlanoCobranca = new ListagemPlanoCobrancaControl();

            CarregarPlanos();

            return listagemPlanoCobrancas;
        }
    }
}
