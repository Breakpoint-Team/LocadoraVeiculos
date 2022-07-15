using Locadora_Veiculos.Dominio.ModuloFuncionario;
using Locadora_Veiculos.WinApp.Compartilhado;
using LocadoraVeiculos.Aplicacao.ModuloFuncionario;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Locadora_Veiculos.WinApp.ModuloFuncionario
{
    public class ControladorFuncionario : ControladorBase
    {
        private ListagemFuncionarioControl listagemFuncionarios;
        private readonly ServicoFuncionario servicoFuncionario;

        public ControladorFuncionario(ServicoFuncionario servicoFuncionario)
        {
            this.servicoFuncionario = servicoFuncionario;
        }

        public override void Inserir()
        {
            var tela = new TelaCadastroFuncionarioForm();
            tela.Funcionario = new Funcionario();
            tela.GravarRegistro = servicoFuncionario.Inserir;

            if (tela.ShowDialog() == DialogResult.OK)
                CarregarFuncionarios();
        }

        public override void Editar()
        {
            var id = listagemFuncionarios.ObtemIdFuncionarioSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um funcionário primeiro!",
                "Edição de Funcionário", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultado = servicoFuncionario.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
                    "Edição de Funcionário", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var funcionarioSelecionado = resultado.Value;

            TelaCadastroFuncionarioForm tela = new TelaCadastroFuncionarioForm();

            tela.Funcionario = funcionarioSelecionado.Clone();

            tela.GravarRegistro = servicoFuncionario.Editar;

            if (tela.ShowDialog() == DialogResult.OK)
                CarregarFuncionarios();
        }

        public override void Excluir()
        {
            var id = listagemFuncionarios.ObtemIdFuncionarioSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um funcionário primeiro!",
                "Exclusão de Funcionário", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultadoSelecao = servicoFuncionario.SelecionarPorId(id);

            if (resultadoSelecao.IsFailed)
            {
                MessageBox.Show(resultadoSelecao.Errors[0].Message,
                    "Exclusão de Funcionário", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var funcionarioSelecionado = resultadoSelecao.Value;

            if (MessageBox.Show("Deseja realmente excluir o funcionário?", "Exclusão de Funcionário",
                  MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var resultadoExclusao = servicoFuncionario.Excluir(funcionarioSelecionado);

                if (resultadoExclusao.IsSuccess)
                    CarregarFuncionarios();
                else
                    MessageBox.Show(resultadoExclusao.Errors[0].Message,
                        "Exclusão de Funcionário", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxFuncionario();
        }

        public override UserControl ObtemListagem()
        {
            if (listagemFuncionarios == null)
                listagemFuncionarios = new ListagemFuncionarioControl();

            CarregarFuncionarios();

            return listagemFuncionarios;
        }

        #region MÉTODOS PRIVADOS

        private void CarregarFuncionarios()
        {
            var resultado = servicoFuncionario.SelecionarTodos();

            if (resultado.IsSuccess)
            {
                List<Funcionario> funcionarios = resultado.Value;

                listagemFuncionarios.AtualizarRegistros(funcionarios);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {funcionarios.Count} funcionário(s)");
            }
            else
            {
                MessageBox.Show(resultado.Errors[0].Message, "Visualização de Funcionário",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}