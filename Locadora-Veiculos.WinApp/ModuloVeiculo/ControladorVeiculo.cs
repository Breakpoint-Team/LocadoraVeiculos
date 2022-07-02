using Locadora_Veiculos.Dominio.ModuloVeiculo;
using Locadora_Veiculos.WinApp.Compartilhado;
using LocadoraVeiculos.Aplicacao.ModuloVeiculo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Locadora_Veiculos.WinApp.ModuloVeiculo
{
    public class ControladorVeiculo : ControladorBase
    {
        private IRepositorioVeiculo repositorioVeiculo;
        private ListagemVeiculoControl listagemVeiculo;
        private ServicoVeiculo servicoVeiculo;

        public ControladorVeiculo(IRepositorioVeiculo repositorioVeiculo, ServicoVeiculo servicoVeiculo)
        {
            this.repositorioVeiculo = repositorioVeiculo;
            this.servicoVeiculo = servicoVeiculo;
        }

        public override void Inserir()
        {
            var tela = new TelaCadastroVeiculoForm();
            tela.Veiculo = new Veiculo();
            tela.GravarRegistro = servicoVeiculo.Inserir;

            DialogResult resultado = tela.ShowDialog();
            if (resultado == DialogResult.OK)
                CarregarVeiculos();
        }

        public override void Editar()
        {
            Veiculo veiculoSelecionado = ObtemVeiculoSelecionado();

            if (veiculoSelecionado == null)
            {
                MessageBox.Show("Selecione um veículo primeiro",
                "Edição de Veículo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var tela = new TelaCadastroVeiculoForm();

            tela.Veiculo = veiculoSelecionado;

            tela.GravarRegistro = servicoVeiculo.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarVeiculos();
        }

        public override void Excluir()
        {
            Veiculo veiculoSelecionado = ObtemVeiculoSelecionado();

            if (veiculoSelecionado == null)
            {
                MessageBox.Show("Selecione um veículo primeiro",
                "Exclusão de Veículo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir o veículo?",
            "Exclusão de Veículo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repositorioVeiculo.Excluir(veiculoSelecionado);
                CarregarVeiculos();
            }
        }


        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolBoxVeiculo();
        }

        public override UserControl ObtemListagem()
        {
            if (listagemVeiculo == null)
                listagemVeiculo = new ListagemVeiculoControl();

            CarregarVeiculos();

            return listagemVeiculo;
        }

        private Veiculo ObtemVeiculoSelecionado()
        {
            var id = listagemVeiculo.ObtemIdVeiculoSelecionado();

            return repositorioVeiculo.SelecionarPorId(id);
        }

        private void CarregarVeiculos()
        {
            List<Veiculo> veiculos = repositorioVeiculo.SelecionarTodos();
            listagemVeiculo.AtualizarRegistros(veiculos);
            TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {veiculos.Count} veículo(s)");
        }
    }
}
