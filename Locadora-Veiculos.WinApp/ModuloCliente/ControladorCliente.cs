using Locadora_Veiculos.Dominio.ModuloCliente;
using Locadora_Veiculos.WinApp.Compartilhado;
using LocadoraVeiculos.Aplicacao.ModuloCliente;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Locadora_Veiculos.WinApp.ModuloCliente
{
    public class ControladorCliente : ControladorBase
    {
        private readonly IRepositorioCliente repositorioCliente;
        private ListagemClientesControl listagemClientes;
        private readonly ServicoCliente servicoCliente;

        public ControladorCliente(IRepositorioCliente repositorioCliente, ServicoCliente servicoCliente)
        {
            this.repositorioCliente = repositorioCliente;
            this.servicoCliente = servicoCliente;
        }

        public override void Inserir()
        {
            TelaCadastroClienteForm tela = new TelaCadastroClienteForm();

            tela.Cliente = new Cliente();

            tela.GravarRegistro = servicoCliente.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarClientes();
        }

        public override void Editar()
        {
            Cliente clienteSelecionado = ObtemClienteSelecionado();

            if (clienteSelecionado == null)
            {
                MessageBox.Show("Selecione um cliente primeiro!",
                "Edição de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCadastroClienteForm tela = new TelaCadastroClienteForm();

            tela.Cliente = clienteSelecionado.Clone();

            tela.GravarRegistro = servicoCliente.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarClientes();
        }

        public override void Excluir()
        {
            Cliente clienteSelecionado = ObtemClienteSelecionado();

            if (clienteSelecionado == null)
            {
                MessageBox.Show("Selecione um cliente primeiro!",
                "Exclusão de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            int qtdCondutoresRelacionados = repositorioCliente.QuantidadeCondutoresRelacionadosAoCliente(clienteSelecionado.Id);

            if (qtdCondutoresRelacionados > 0)
            {
                MessageBox.Show("Não é possível excluir um Cliente que possui Condutores relacionados!",
                "Exclusão de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir o cliente?",
                "Exclusão de Cliente", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
                repositorioCliente.Excluir(clienteSelecionado);

            CarregarClientes();
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolBoxCliente();
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
            List<Cliente> clientes = repositorioCliente.SelecionarTodos();

            listagemClientes.AtualizarRegistros(clientes);

            TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {clientes.Count} cliente(s)");
        }

        private Cliente ObtemClienteSelecionado()
        {
            var id = listagemClientes.ObtemIdClienteSelecionado();

            return repositorioCliente.SelecionarPorId(id);
        }

        #endregion
    }
}