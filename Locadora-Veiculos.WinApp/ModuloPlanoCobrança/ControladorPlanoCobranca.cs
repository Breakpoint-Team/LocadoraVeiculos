using Locadora_Veiculos.Dominio.ModuloGrupoVeiculos;
using Locadora_Veiculos.Dominio.ModuloPlanoCobranca;
using Locadora_Veiculos.WinApp.Compartilhado;
using LocadoraVeiculos.Aplicacao.ModuloPlanoCobranca;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Locadora_Veiculos.WinApp.ModuloPlanoCobrança
{
    public class ControladorPlanoCobranca : ControladorBase
    {
        private readonly IRepositorioPlanoCobranca repositorioPlanoCobranca;
        private readonly IRepositorioGrupoVeiculos repositorioGrupoVeiculos;
        private readonly ServicoPlanoCobranca servicoPlanoCobranca;
        private ListagemPlanoCobrancaControl listagemPlanoCobranca;

        public ControladorPlanoCobranca(IRepositorioPlanoCobranca repositorioPlanoCobranca,
            ServicoPlanoCobranca servicoPlanoCobranca, IRepositorioGrupoVeiculos repositorioGrupoVeiculos)
        {
            this.repositorioPlanoCobranca = repositorioPlanoCobranca;
            this.servicoPlanoCobranca = servicoPlanoCobranca;
            this.repositorioGrupoVeiculos = repositorioGrupoVeiculos;
        }

        public override void Inserir()
        {
            int qtd = repositorioGrupoVeiculos.QuantidadeGrupoVeiculosCadastrados();

            if (qtd == 0)
            {
                MessageBox.Show("Para cadastrar um Plano de Cobrança, é necessário que haja um Grupo de Veículos cadastrado!",
                "Inserção de Plano de Cobrança", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var tela = new TelaCadastroPlanoCobrancaForm(ObterGrupos());

            tela.PlanoCobranca = new PlanoCobranca();

            tela.GravarRegistro = servicoPlanoCobranca.Inserir;

            DialogResult resultado = tela.ShowDialog();

            CarregarPlanos();
        }

        public override void Editar()
        {
            PlanoCobranca planoCobrancaSelecionado = ObtemPlanoCobrancaSelecionado();

            if (planoCobrancaSelecionado == null)
            {
                MessageBox.Show("Selecione um plano de cobrança primeiro!",
                "Edição de Plano de Cobrança", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var tela = new TelaCadastroPlanoCobrancaForm(ObterGrupos());

            tela.PlanoCobranca = planoCobrancaSelecionado;

            tela.GravarRegistro = servicoPlanoCobranca.Editar;

            DialogResult resultado = tela.ShowDialog();

            CarregarPlanos();
        }

        public override void Excluir()
        {
            PlanoCobranca planoCobrancaSelecionado = ObtemPlanoCobrancaSelecionado();

            if (planoCobrancaSelecionado == null)
            {
                MessageBox.Show("Selecione um plano de cobrança primeiro!",
                "Exclusão de Plano de Cobrança", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir o plano de cobrança?",
            "Exclusão de Plano de Cobrança", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repositorioPlanoCobranca.Excluir(planoCobrancaSelecionado);
                CarregarPlanos();
            }
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxPlanoCobranca();
        }

        public override UserControl ObtemListagem()
        {
            if (listagemPlanoCobranca == null)
                listagemPlanoCobranca = new ListagemPlanoCobrancaControl();

            CarregarPlanos();

            return listagemPlanoCobranca;
        }

        #region MÉTODOS PRIVADOS

        private void CarregarPlanos()
        {
            List<PlanoCobranca> planos = repositorioPlanoCobranca.SelecionarTodos();

            listagemPlanoCobranca.AtualizarRegistros(planos);

            TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {planos.Count} plano(s) de cobrança");
        }

        private PlanoCobranca ObtemPlanoCobrancaSelecionado()
        {
            var id = listagemPlanoCobranca.ObtemIdPlanoCobrancaSelecionado();

            return repositorioPlanoCobranca.SelecionarPorId(id);
        }

        private List<GrupoVeiculos> ObterGrupos()
        {
            return repositorioGrupoVeiculos.SelecionarTodos();
        }

        #endregion
    }
}
