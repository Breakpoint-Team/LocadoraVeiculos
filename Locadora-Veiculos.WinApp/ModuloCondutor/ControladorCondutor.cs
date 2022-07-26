using FluentResults;
using Locadora_Veiculos.Dominio.ModuloCliente;
using Locadora_Veiculos.Dominio.ModuloCondutor;
using Locadora_Veiculos.WinApp.Compartilhado;
using LocadoraVeiculos.Aplicacao.ModuloCliente;
using LocadoraVeiculos.Aplicacao.ModuloCondutor;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Locadora_Veiculos.WinApp.ModuloCondutor
{
    public class ControladorCondutor : ControladorBase
    {
        private ListagemCondutoresControl listagemCondutores;
        private readonly ServicoCondutor servicoCondutor;
        private readonly ServicoCliente servicoCliente;

        public ControladorCondutor(ServicoCliente servicoCliente,
            ServicoCondutor servicoCondutor)
        {
            this.servicoCondutor = servicoCondutor;
            this.servicoCliente = servicoCliente;
        }

        public override void Inserir()
        {
            var resultado = servicoCliente.QuantidadeClientesCadastrados();

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
                    "Inserção de Condutor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var qtd = resultado.Value;

            if (qtd == 0)
            {
                MessageBox.Show("Para cadastrar um Condutor, é necessário que haja um Cliente cadastrado!",
                "Inserção de Condutor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCadastroCondutorForm tela = new TelaCadastroCondutorForm(ObterClientes());

            tela.Condutor = new Condutor();

            tela.GravarRegistro = servicoCondutor.Inserir;

            if (tela.ShowDialog() == DialogResult.OK)
                CarregarCondutores();
        }

        public override void Editar()
        {
            var id = listagemCondutores.ObtemIdCondutorSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um condutor primeiro!",
                "Edição de Condutor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Result<Condutor> resultado = servicoCondutor.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
                    "Edição de Condutor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var condutorSelecionado = resultado.Value;

            TelaCadastroCondutorForm tela = new TelaCadastroCondutorForm(ObterClientes());

            tela.Condutor = condutorSelecionado;

            tela.GravarRegistro = servicoCondutor.Editar;

            if (tela.ShowDialog() == DialogResult.OK)
                CarregarCondutores();
        }

        public override void Excluir()
        {
            var id = listagemCondutores.ObtemIdCondutorSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um condutor primeiro!",
                "Exclusão de Condutor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultadoSelecao = servicoCondutor.SelecionarPorId(id);

            if (resultadoSelecao.IsFailed)
            {
                MessageBox.Show(resultadoSelecao.Errors[0].Message,
                    "Exclusão de Condutor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var condutorSelecionado = resultadoSelecao.Value;

            if (MessageBox.Show("Deseja realmente excluir o condutor?",
                "Exclusão de Condutor", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var resultadoExclusao = servicoCondutor.Excluir(condutorSelecionado);

                if (resultadoExclusao.IsSuccess)
                    CarregarCondutores();
                else
                    MessageBox.Show(resultadoExclusao.Errors[0].Message,
                        "Exclusão de Condutor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxCondutor();
        }

        public override UserControl ObtemListagem()
        {
            if (listagemCondutores == null)
                listagemCondutores = new ListagemCondutoresControl();

            CarregarCondutores();

            return listagemCondutores;
        }

        #region MÉTODOS PRIVADOS

        private void CarregarCondutores()
        {
            var resultado = servicoCondutor.SelecionarTodos();

            if (resultado.IsSuccess)
            {
                List<Condutor> condutores = resultado.Value;

                listagemCondutores.AtualizarRegistros(condutores);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {condutores.Count} condutor(es)");
            }
            else
            {
                MessageBox.Show(resultado.Errors[0].Message, "Visualização de Condutor",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<Cliente> ObterClientes()
        {
            var resultado = servicoCliente.SelecionarTodos();

            List<Cliente> lista = new List<Cliente>();

            if (resultado.IsSuccess)
                lista = resultado.Value;

            return lista;
        }

        #endregion
    }
}