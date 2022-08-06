using Locadora_Veiculos.Dominio.ModuloTaxa;
using Locadora_Veiculos.WinApp.Compartilhado;
using LocadoraVeiculos.Aplicacao.ModuloTaxa;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Locadora_Veiculos.WinApp.ModuloTaxas
{
    public class ControladorTaxa : ControladorBase
    {
        private ListagemTaxaControl listagemTaxa;
        private ServicoTaxa servicoTaxa;

        public ControladorTaxa(ServicoTaxa servicoTaxa)
        {
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
            var id = listagemTaxa.ObtemIdTaxaSelecionada();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione uma taxa primeiro!",
                "Edição de Taxa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultado = servicoTaxa.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
                "Edição de Taxas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var taxaSelecionada = resultado.Value;

            var tela = new TelaCadastroTaxaForm();
            tela.Taxa = taxaSelecionada;
            tela.GravarRegistro = servicoTaxa.Editar;

            if (tela.ShowDialog() == DialogResult.OK)
                CarregarTaxas();

        }

        public override void Excluir()
        {
            var id = listagemTaxa.ObtemIdTaxaSelecionada();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione uma taxa primeiro!",
                "Exclusão de Taxa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            var resultado = servicoTaxa.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
                "Exclusão de Taxa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var taxaSelecionada = resultado.Value;


            if (MessageBox.Show("Deseja realmente excluir a taxa?", "Exclusão de Taxa",
                  MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var resultadoExclusao = servicoTaxa.Excluir(taxaSelecionada);

                if (resultadoExclusao.IsSuccess)
                    CarregarTaxas();
                else
                    MessageBox.Show(resultadoExclusao.Errors[0].Message,
                        "Exclusão de Taxa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxTaxa();
        }

        public override UserControl ObtemListagem()
        {
            if (listagemTaxa == null)
                listagemTaxa = new ListagemTaxaControl();

            CarregarTaxas();

            return listagemTaxa;
        }

        #region MÉTODOS PRIVADOS

        private void CarregarTaxas()
        {
            var resultado = servicoTaxa.SelecionarTodos();
            if (resultado.IsSuccess)
            {
                List<Taxa> taxas = resultado.Value;
                listagemTaxa.AtualizarRegistros(taxas);
                TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {taxas.Count} taxa(s)");
            }
            else
            {
                MessageBox.Show(resultado.Errors[0].Message, "Visualização de Taxa",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}