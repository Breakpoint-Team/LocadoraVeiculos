using Locadora_Veiculos.Dominio.ModuloFuncionario;
using Locadora_Veiculos.WinApp.Compartilhado;
using LocadoraVeiculos.Aplicacao.ModuloFuncionario;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Locadora_Veiculos.WinApp.ModuloFuncionario
{
    public class ControladorFuncionario : ControladorBase
    {
        private readonly IRepositorioFuncionario repositorioFuncionario;
        private ListagemFuncionarioControl listagemFuncionarios;
        private readonly ServicoFuncionario servicoFuncionario;

        public ControladorFuncionario(IRepositorioFuncionario repositorioFuncionario, ServicoFuncionario servicoFuncionario)
        {
            this.repositorioFuncionario = repositorioFuncionario;
            this.servicoFuncionario = servicoFuncionario;
        }

        public override void Inserir()
        {
            var tela = new TelaCadastroFuncionarioForm();
            tela.Funcionario = new Funcionario();
            tela.GravarRegistro = servicoFuncionario.Inserir;
            DialogResult resultado = tela.ShowDialog();

            CarregarFuncionarios();
        }

        public override void Editar()
        {
            Funcionario funcionarioSelecionado = ObtemFuncionarioSelecionado();

            if (funcionarioSelecionado == null)
            {
                MessageBox.Show("Selecione um funcionário primeiro!",
                "Edição de Funcionário", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCadastroFuncionarioForm tela = new TelaCadastroFuncionarioForm();

            tela.Funcionario = funcionarioSelecionado.Clone();

            tela.GravarRegistro = servicoFuncionario.Editar;

            DialogResult resultado = tela.ShowDialog();

            CarregarFuncionarios();
        }

        public override void Excluir()
        {
            Funcionario funcionarioSelecionado = ObtemFuncionarioSelecionado();

            if (funcionarioSelecionado == null)
            {
                MessageBox.Show("Selecione um funcionário primeiro!",
                "Exclusão de Funcionário", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir o funcionário?",
                "Exclusão de Funcionário", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
                repositorioFuncionario.Excluir(funcionarioSelecionado);

            CarregarFuncionarios();
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

        private Funcionario ObtemFuncionarioSelecionado()
        {
            var id = listagemFuncionarios.ObtemIdFuncionarioSelecionado();

            return repositorioFuncionario.SelecionarPorId(id);
        }

        private void CarregarFuncionarios()
        {
            List<Funcionario> funcionarios = repositorioFuncionario.SelecionarTodos();
            listagemFuncionarios.AtualizarRegistros(funcionarios);
            TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {funcionarios.Count} funcionário(s)");
        }

        #endregion
    }
}