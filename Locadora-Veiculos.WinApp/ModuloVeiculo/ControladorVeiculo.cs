using Locadora_Veiculos.Dominio.ModuloGrupoVeiculos;
using Locadora_Veiculos.Dominio.ModuloVeiculo;
using Locadora_Veiculos.WinApp.Compartilhado;
using LocadoraVeiculos.Aplicacao.ModuloGrupoVeiculos;
using LocadoraVeiculos.Aplicacao.ModuloVeiculo;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Locadora_Veiculos.WinApp.ModuloVeiculo
{
    public class ControladorVeiculo : ControladorBase
    {
        private ListagemVeiculoControl listagemVeiculo;
        private ServicoVeiculo servicoVeiculo;
        private ServicoGrupoVeiculos servicoGrupoVeiculos;
        public ControladorVeiculo(ServicoVeiculo servicoVeiculo, ServicoGrupoVeiculos servicoGrupoVeiculos)
        {
            this.servicoVeiculo = servicoVeiculo;
            this.servicoGrupoVeiculos = servicoGrupoVeiculos;
        }

        public override void Inserir()
        {
            var resultado = servicoGrupoVeiculos.QuantidadeGrupoVeiculosCadastrados();

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
               "Inserção de Veículo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var qtd = resultado.Value;
            if(qtd < 1) { 
                MessageBox.Show("Para cadastrar um Veículo, é necessário que haja um Grupo de Veículos cadastrado!",
                "Inserção de Veículo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var tela = new TelaCadastroVeiculoForm();
            tela.Veiculo = new Veiculo();
            tela.GravarRegistro = servicoVeiculo.Inserir;

            if(tela.ShowDialog() == DialogResult.OK)
                CarregarVeiculos();
        }

        public override void Editar()
        {
            var id = listagemVeiculo.ObtemIdVeiculoSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um veículo primeiro!",
                "Edição de Veículo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultado = servicoVeiculo.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message, "Edição de Veículo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var veiculoSelecionado = resultado.Value;

            var tela = new TelaCadastroVeiculoForm();
            tela.Veiculo = veiculoSelecionado;
            tela.GravarRegistro = servicoVeiculo.Editar;

            if(tela.ShowDialog() == DialogResult.OK)
                CarregarVeiculos();
        }

        public override void Excluir()
        {
            var id = listagemVeiculo.ObtemIdVeiculoSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um veículo primeiro!",
                "Exclusão de Veículo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultado = servicoVeiculo.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
                "Exclusão de Veículo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var veiculoSelecionado = resultado.Value;



            if(MessageBox.Show("Deseja realmente excluir o veículo?",
            "Exclusão de Veículo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var resultadoExclusao = servicoVeiculo.Excluir(veiculoSelecionado);
                if (resultadoExclusao.IsSuccess)
                    CarregarVeiculos();
                else
                {
                    MessageBox.Show(resultadoExclusao.Errors[0].Message,
                  "Exclusão de Veículo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxVeiculo();
        }

        public override UserControl ObtemListagem()
        {
            if (listagemVeiculo == null)
                listagemVeiculo = new ListagemVeiculoControl();

            CarregarVeiculos();

            return listagemVeiculo;
        }

        #region MÉTODOS PRIVADOS

        private void CarregarVeiculos()
        {
            var resultado = servicoVeiculo.SelecionarTodos();

            if (resultado.IsSuccess)
            {
                List<Veiculo> veiculos = resultado.Value;
                listagemVeiculo.AtualizarRegistros(veiculos);
                TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {veiculos.Count} veículo(s)");
            }
            else
            {
                MessageBox.Show(resultado.Errors[0].Message, "Visualização de Veículo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}