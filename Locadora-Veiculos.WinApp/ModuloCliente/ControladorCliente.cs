using Locadora_Veiculos.Dominio.ModuloCliente;
using Locadora_Veiculos.WinApp.Compartilhado;
using LocadoraVeiculos.Aplicacao.ModuloCliente;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Locadora_Veiculos.WinApp.ModuloCliente
{
    public class ControladorCliente : ControladorBase
    {
        private ListagemClientesControl listagemClientes;
        private readonly ServicoCliente servicoCliente;

        public ControladorCliente(ServicoCliente servicoCliente)
        {
            this.servicoCliente = servicoCliente;
        }

        public override void Inserir()
        {
            TelaCadastroClienteForm tela = new TelaCadastroClienteForm();

            tela.Cliente = new Cliente();

            tela.GravarRegistro = servicoCliente.Inserir;

            DialogResult resultado = tela.ShowDialog();

            CarregarClientes();
        }

        public override void Editar()
        {
            var id = listagemClientes.ObtemIdClienteSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um cliente primeiro!",
                "Edição de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultado = servicoCliente.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
                    "Edição de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var clienteSelecionado = resultado.Value;

            TelaCadastroClienteForm tela = new TelaCadastroClienteForm();

            tela.Cliente = clienteSelecionado.Clone();

            tela.GravarRegistro = servicoCliente.Editar;

            if (tela.ShowDialog() == DialogResult.OK)
                CarregarClientes();
        }

        public override void Excluir()
        {
            var id = listagemClientes.ObtemIdClienteSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um cliente primeiro!",
                "Exclusão de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultadoSelecao = servicoCliente.SelecionarPorId(id);

            if (resultadoSelecao.IsFailed)
            {
                MessageBox.Show(resultadoSelecao.Errors[0].Message,
                    "Exclusão de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var clienteSelecionado = resultadoSelecao.Value;

            if (MessageBox.Show("Deseja realmente excluir o cliente?",
                "Exclusão de Cliente", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var resultadoExclusao = servicoCliente.Excluir(clienteSelecionado);

                if (resultadoExclusao.IsSuccess)
                    CarregarClientes();
                else
                {
                    MessageBox.Show(resultadoExclusao.Errors[0].Message,
                                    "Exclusão de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxCliente();
        }

        public override UserControl ObtemListagem()
        {
            if (listagemClientes == null)
                listagemClientes = new ListagemClientesControl();

            CarregarClientes();

            return listagemClientes;
        }

        #region MÉTODOS PRIVADOS

        private void CarregarClientes()
        {
            var resultado = servicoCliente.SelecionarTodos();

            if (resultado.IsSuccess)
            {
                List<Cliente> clientes = resultado.Value;

                listagemClientes.AtualizarRegistros(clientes);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {clientes.Count} cliente(s)");
            }
            else
            {
                MessageBox.Show(resultado.Errors[0].Message, "Visualização de Cliente",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}