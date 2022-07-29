using FluentResults;
using Locadora_Veiculos.Dominio.ModuloCliente;
using Locadora_Veiculos.Dominio.ModuloCondutor;
using Locadora_Veiculos.Dominio.ModuloGrupoVeiculos;
using Locadora_Veiculos.Dominio.ModuloLocacao;
using Locadora_Veiculos.Dominio.ModuloPlanoCobranca;
using Locadora_Veiculos.Dominio.ModuloTaxa;
using Locadora_Veiculos.Dominio.ModuloVeiculo;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Locadora_Veiculos.WinApp.ModuloLocacao
{
    public partial class TelaCadastroLocacaoForm : Form
    {
        private Locacao locacao;
        private List<Cliente> clientes;
        private List<Condutor> condutores;
        private List<GrupoVeiculos> gruposDeVeiculo;
        private List<Veiculo> veiculos;
        private List<Taxa> taxas;
        private List<PlanoCobranca> planosDeCobranca;
        
        public TelaCadastroLocacaoForm(List<Cliente> clientes, List<Condutor> condutores,
            List<GrupoVeiculos> gruposDeVeiculo, List<Veiculo> veiculos,
            List<Taxa> taxas, List<PlanoCobranca> planosDeCobranca)
        {
            InitializeComponent();

            this.clientes = clientes;
            this.condutores = condutores;
            this.gruposDeVeiculo = gruposDeVeiculo;
            this.veiculos = veiculos;
            this.taxas = taxas;
            this.planosDeCobranca = planosDeCobranca;

            CarregarClientes();
            CarregarPlanos();
            CarregarGrupos();
            CarregarVeiculos();
            CarregarTaxas();
        }

        public Locacao Locacao { 
            get => locacao;
            set
            {
                locacao = value;
            
            } }

        public Func<Locacao, Result<Locacao>> GravarRegistro { get; set; }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            ObterDadosTela();

            var resultadoValidacao = GravarRegistro(locacao);

            if (resultadoValidacao.IsFailed)
            {
                string erro = resultadoValidacao.Errors[0].Message;

                if (erro.StartsWith("Falha no sistema"))
                {
                    MessageBox.Show(erro,
                        "Inserção de Locação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                    DialogResult = DialogResult.None;
                }
            }
        }

        private void ObterDadosTela()
        {
            throw new NotImplementedException();
        }

        private void CarregarClientes()
        {
            if (clientes.Count > 0)
                foreach (var cliente in clientes)
                    comboBoxClientes.Items.Add(cliente);
        }
        private void CarregarPlanos()
        {
            if (planosDeCobranca.Count > 0)
                foreach (var plano in planosDeCobranca)
                    comboBoxPlanosCobranca.Items.Add(plano);
        }
        private void CarregarGrupos()
        {
            if (gruposDeVeiculo.Count > 0)
                foreach (var grupo in gruposDeVeiculo)
                    comboBoxGrupoVeiculos.Items.Add(grupo);
        }
        
        private void CarregarVeiculos()
        {
            if (veiculos.Count > 0)
                foreach (var veiculo in veiculos)
                    comboBoxVeiculos.Items.Add(veiculo);
        }
        
        private void CarregarTaxas()
        {
            if (taxas.Count > 0)
                foreach (var taxa in taxas)
                    checkedListBoxTaxas.Items.Add(taxa);
        }

    }
}
