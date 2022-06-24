using Locadora_Veiculos.Dominio.ModuloTaxa;
using Locadora_Veiculos.WinApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Locadora_Veiculos.WinApp.ModuloTaxas
{
    public class ControladorTaxa : ControladorBase
    {
        private IRepositorioTaxa repositorioTaxa;
        private ListagemTaxaControl listagemTaxa;
        public ControladorTaxa(IRepositorioTaxa repositorioTaxa)
        {
            this.repositorioTaxa = repositorioTaxa;
        }
        public override void Inserir()
        {
            var tela = new TelaCadastroTaxa();
            tela.Taxa = new Taxa();
            tela.GravarRegistro = repositorioTaxa.Inserir;

            DialogResult resultado = tela.ShowDialog();
            if (resultado == DialogResult.OK)
                CarregarTaxas();
        }

        public override void Editar()
        {
            Taxa taxaSelecionada = ObtemTaxaSelecionada();

            if (taxaSelecionada == null)
            {
                MessageBox.Show("Selecione uma primeiro",
                "Edição de Taxa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var tela = new TelaCadastroTaxa();

            tela.Taxa = taxaSelecionada;

            tela.GravarRegistro = repositorioTaxa.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarTaxas();
        }

        public override void Excluir()
        {
            Taxa taxaSelecionada = ObtemTaxaSelecionada();

            if (taxaSelecionada == null)
            {
                MessageBox.Show("Selecione uma primeiro",
                "Edição de Taxa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir a taxa?",
            "Exclusão de Taxa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repositorioTaxa.Excluir(taxaSelecionada);
                CarregarTaxas();
            }
        }

        private Taxa ObtemTaxaSelecionada()
        {
            var id = listagemTaxa.ObtemIdTaxaSelecionada();

            return repositorioTaxa.SelecionarPorId(id);
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

        private void CarregarTaxas()
        {
            List<Taxa> taxas = repositorioTaxa.SelecionarTodos();
            listagemTaxa.AtualizarRegistros(taxas);
            TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {taxas.Count} taxas");

        }
    }
}
