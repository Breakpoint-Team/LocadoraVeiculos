using Locadora_Veiculos.Dominio.ModuloCliente;
using Locadora_Veiculos.Dominio.ModuloCondutor;
using Locadora_Veiculos.WinApp.Compartilhado;
using LocadoraVeiculos.Aplicacao.ModuloCondutor;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Locadora_Veiculos.WinApp.ModuloCondutor
{
    public class ControladorCondutor : ControladorBase
    {
        private readonly IRepositorioCondutor repositorioCondutor;
        private ListagemCondutoresControl listagemCondutores;
        private readonly ServicoCondutor servicoCondutor;
        private readonly IRepositorioCliente repositorioCliente;

        public ControladorCondutor(IRepositorioCondutor repositorioCondutor,
            Infra.BancoDados.ModuloCliente.RepositorioClienteEmBancoDados repositorioCliente,
            ServicoCondutor servicoCondutor)
        {
            this.repositorioCondutor = repositorioCondutor;
            this.servicoCondutor = servicoCondutor;
            this.repositorioCliente = repositorioCliente;
        }

        public override void Inserir()
        {
            int qtd = repositorioCliente.QuantidadeClientesCadastrados();

            if (qtd == 0)
            {
                MessageBox.Show("Para cadastrar um Condutor, é necessário que haja um Cliente cadastrado!",
                "Inserção de Condutor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCadastroCondutorForm tela = new TelaCadastroCondutorForm(ObterClientes());

            tela.Condutor = new Condutor();

            tela.GravarRegistro = servicoCondutor.Inserir;

            DialogResult resultado = tela.ShowDialog();

            CarregarCondutores();
        }

        public override void Editar()
        {
            Condutor condutorSelecionado = ObtemCondutorSelecionado();

            if (condutorSelecionado == null)
            {
                MessageBox.Show("Selecione um condutor primeiro!",
                "Edição de Condutor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCadastroCondutorForm tela = new TelaCadastroCondutorForm(ObterClientes());

            tela.Condutor = condutorSelecionado.Clone();

            tela.GravarRegistro = servicoCondutor.Editar;

            DialogResult resultado = tela.ShowDialog();

                CarregarCondutores();
        }

        public override void Excluir()
        {
            Condutor condutorSelecionado = ObtemCondutorSelecionado();

            if (condutorSelecionado == null)
            {
                MessageBox.Show("Selecione um condutor primeiro!",
                "Exclusão de Condutor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir o condutor?",
                "Exclusão de Condutor", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
                repositorioCondutor.Excluir(condutorSelecionado);

            CarregarCondutores();
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
            List<Condutor> condutores = repositorioCondutor.SelecionarTodos();

            listagemCondutores.AtualizarRegistros(condutores);

            TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {condutores.Count} condutor(es)");
        }

        private Condutor ObtemCondutorSelecionado()
        {
            var id = listagemCondutores.ObtemIdCondutorSelecionado();

            return repositorioCondutor.SelecionarPorId(id);
        }

        private List<Cliente> ObterClientes()
        {
            return repositorioCliente.SelecionarTodos();
        }

        #endregion
    }
}