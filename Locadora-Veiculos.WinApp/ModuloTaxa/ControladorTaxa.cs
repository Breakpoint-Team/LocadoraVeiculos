using Locadora_Veiculos.Dominio.ModuloTaxa;
using Locadora_Veiculos.WinApp.Compartilhado;
using LocadoraVeiculos.Aplicacao.ModuloTaxa;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Locadora_Veiculos.WinApp.ModuloTaxas
{
    public class ControladorTaxa : ControladorBase
    {
        private IRepositorioTaxa repositorioTaxa;
        private ListagemTaxaControl listagemTaxa;
        private ServicoTaxa servicoTaxa;

        public ControladorTaxa(IRepositorioTaxa repositorioTaxa, ServicoTaxa servicoTaxa)
        {
            this.repositorioTaxa = repositorioTaxa;
            this.servicoTaxa = servicoTaxa;
        }

        public override void Inserir()
        {
            var tela = new TelaCadastroTaxaForm();
            tela.Taxa = new Taxa();
            tela.GravarRegistro = servicoTaxa.Inserir;

            DialogResult resultado = tela.ShowDialog();
            CarregarTaxas();
        }

        public override void Editar()
        {
            Taxa taxaSelecionada = ObtemTaxaSelecionada();

            if (taxaSelecionada == null)
            {
                MessageBox.Show("Selecione uma taxa primeiro!",
                "Edição de Taxa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var tela = new TelaCadastroTaxaForm();

            tela.Taxa = taxaSelecionada;

            tela.GravarRegistro = servicoTaxa.Editar;

            DialogResult resultado = tela.ShowDialog();
            
            CarregarTaxas();
        }

        public override void Excluir()
        {
            Taxa taxaSelecionada = ObtemTaxaSelecionada();

            if (taxaSelecionada == null)
            {
                MessageBox.Show("Selecione uma taxa primeiro!",
                "Exclusão de Taxa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir a taxa?",
            "Exclusão de Taxa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repositorioTaxa.Excluir(taxaSelecionada);
            }
            CarregarTaxas();
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolBoxTaxa();
        }

        public override UserControl ObtemListagem()
        {
            if (listagemTaxa == null)
                listagemTaxa = new ListagemTaxaControl();

            CarregarTaxas();

            return listagemTaxa;
        }

        #region MÉTODOS PRIVADOS

        private Taxa ObtemTaxaSelecionada()
        {
            var id = listagemTaxa.ObtemIdTaxaSelecionada();

            return repositorioTaxa.SelecionarPorId(id);
        }

        private void CarregarTaxas()
        {
            List<Taxa> taxas = repositorioTaxa.SelecionarTodos();
            listagemTaxa.AtualizarRegistros(taxas);
            TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {taxas.Count} taxa(s)");
        }

        #endregion
    }
}