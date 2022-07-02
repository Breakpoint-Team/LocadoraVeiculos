using Locadora_Veiculos.Infra.BancoDados.ModuloCliente;
using Locadora_Veiculos.Infra.BancoDados.ModuloFuncionario;
using Locadora_Veiculos.Infra.BancoDados.ModuloGrupoVeiculos;
using Locadora_Veiculos.Infra.BancoDados.ModuloTaxa;
using Locadora_Veiculos.WinApp.Compartilhado;
using Locadora_Veiculos.WinApp.ModuloCliente;
using Locadora_Veiculos.WinApp.ModuloFuncionario;
using Locadora_Veiculos.WinApp.ModuloGrupoVeiculos;
using Locadora_Veiculos.WinApp.ModuloTaxas;
using LocadoraVeiculos.Aplicacao.ModuloCliente;
using LocadoraVeiculos.Aplicacao.ModuloFuncionario;
using LocadoraVeiculos.Aplicacao.ModuloTaxa;
using LocadoraVeiculos.Aplicacao.ModuloGrupoVeiculos;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Locadora_Veiculos.Infra.BancoDados.ModuloCondutor;
using LocadoraVeiculos.Aplicacao.ModuloCondutor;
using Locadora_Veiculos.WinApp.ModuloCondutor;
using Locadora_Veiculos.Infra.BancoDados.ModuloVeiculo;
using LocadoraVeiculos.Aplicacao.ModuloVeiculo;
using Locadora_Veiculos.WinApp.ModuloVeiculo;

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
       
        private void condutoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal((ToolStripMenuItem)sender);
        }


        private void veiculosMenuItem_Click(object sender, EventArgs e)
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
            btnInserir.Visible = configuracao.InserirHabilitado;
            btnEditar.Visible = configuracao.EditarHabilitado;
            btnExcluir.Visible = configuracao.ExcluirHabilitado;
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
            var repositorioFuncionario = new RepositorioFuncionarioEmBancoDados();
            var repositorioCondutor = new RepositorioCondutorEmBancoDados();
            var repositorioVeiculo = new RepositorioVeiculoEmBancoDados();

            var servicoFuncionario = new ServicoFuncionario(repositorioFuncionario);
            var servicoCliente = new ServicoCliente(repositorioCliente);
            var servicoGrupoVeiculos = new ServicoGrupoVeiculos(repositorioGrupoVeiculos);
            var servicoTaxa = new ServicoTaxa(repositorioTaxa);
            var servicoCondutor = new ServicoCondutor(repositorioCondutor);
            var servicoVeiculo = new ServicoVeiculo(repositorioVeiculo);

            controladores = new Dictionary<string, ControladorBase>();

            controladores.Add("Clientes", new ControladorCliente(repositorioCliente, servicoCliente));
            controladores.Add("Grupos de veículos", new ControladorGrupoVeiculos(repositorioGrupoVeiculos, servicoGrupoVeiculos));
            controladores.Add("Taxas", new ControladorTaxa(repositorioTaxa, servicoTaxa));
            controladores.Add("Funcionários", new ControladorFuncionario(repositorioFuncionario, servicoFuncionario));
            controladores.Add("Veículos", new ControladorVeiculo(repositorioVeiculo, servicoVeiculo));
            controladores.Add("Condutores", new ControladorCondutor(repositorioCondutor,repositorioCliente, servicoCondutor));
        }

    }
}