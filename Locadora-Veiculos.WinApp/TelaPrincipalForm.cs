using Locadora_Veiculos.Infra.BancoDados.ModuloCliente;
using Locadora_Veiculos.Infra.BancoDados.ModuloGrupoVeiculos;
using Locadora_Veiculos.Infra.BancoDados.ModuloTaxa;
using Locadora_Veiculos.WinApp.Compartilhado;
using Locadora_Veiculos.WinApp.ModuloCliente;
using Locadora_Veiculos.WinApp.ModuloGrupoVeiculos;
using Locadora_Veiculos.WinApp.ModuloTaxas;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Locadora_Veiculos.WinApp
{
    public partial class TelaPrincipalForm : Form
    {
        private ControladorBase controlador;
        private Dictionary<string, ControladorBase> controladores;
        
        public TelaPrincipalForm()
        {
            InitializeComponent();

            Instancia = this;

            AtualizarRodape(string.Empty);

            labelTipoCadastro.Text = string.Empty;

            InicializarControladores();
        }

        public static TelaPrincipalForm Instancia
        {
            get;
            private set;
        }

        private void clientesMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal((ToolStripMenuItem)sender);
        }

        private void funcionariosMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal((ToolStripMenuItem)sender);
        }

        private void grupoVeiculosMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal((ToolStripMenuItem)sender);
        }

        private void taxasMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal((ToolStripMenuItem)sender);
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            controlador.Inserir();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            controlador.Editar();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            controlador.Excluir();
        }

        private void ConfigurarBotoes(ConfiguracaoToolboxBase configuracao)
        {
            btnInserir.Enabled = configuracao.InserirHabilitado;
            btnEditar.Visible = configuracao.EditarHabilitado;
            btnExcluir.Enabled = configuracao.ExcluirHabilitado;
        }

        private void ConfigurarTooltips(ConfiguracaoToolboxBase configuracao)
        {
            btnInserir.ToolTipText = configuracao.TooltipInserir;
            btnEditar.ToolTipText = configuracao.TooltipEditar;
            btnExcluir.ToolTipText = configuracao.TooltipExcluir;
        }

        private void ConfigurarTelaPrincipal(ToolStripMenuItem opcaoSelecionada)
        {
            var tipo = opcaoSelecionada.Text;

            controlador = controladores[tipo];

            ConfigurarToolbox();

            ConfigurarListagem();
        }

        public void AtualizarRodape(string mensagem)
        {
            labelRodape.Text = mensagem;
        }

        private void ConfigurarToolbox()
        {
            ConfiguracaoToolboxBase configuracao = controlador.ObtemConfiguracaoToolbox();

            if (configuracao != null)
            {
                toolbox.Enabled = true;

                labelTipoCadastro.Text = configuracao.TipoCadastro;

                ConfigurarTooltips(configuracao);

                ConfigurarBotoes(configuracao);
            }
        }

        private void ConfigurarListagem()
        {
            AtualizarRodape("");

            var listagemControl = controlador.ObtemListagem();

            panelRegistros.Controls.Clear();

            listagemControl.Dock = DockStyle.Fill;

            panelRegistros.Controls.Add(listagemControl);
        }

        private void InicializarControladores()
        {
            var repositorioCliente = new RepositorioClienteEmBancoDados();
            var repositorioGrupoVeiculos = new RepositorioGrupoVeiculosEmBancoDados();
            var repositorioTaxa = new RepositorioTaxaEmBancoDados();
            //var repositorioFuncionario = new RepositorioTesteFuncionarioEmBancoDados();

            controladores = new Dictionary<string, ControladorBase>();

            controladores.Add("Clientes", new ControladorCliente(repositorioCliente));
            controladores.Add("Grupos de veículos", new ControladorGrupoVeiculos(repositorioGrupoVeiculos));
            controladores.Add("Taxas", new ControladorTaxa(repositorioTaxa));
            //controladores.Add("Funcionários", new ControladorTeste(repositorioQuestao, repositorioDisciplina,


        }
    }
}
