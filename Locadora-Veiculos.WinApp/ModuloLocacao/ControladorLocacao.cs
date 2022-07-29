using FluentResults;
using Locadora_Veiculos.Dominio.ModuloCliente;
using Locadora_Veiculos.Dominio.ModuloCondutor;
using Locadora_Veiculos.Dominio.ModuloGrupoVeiculos;
using Locadora_Veiculos.Dominio.ModuloLocacao;
using Locadora_Veiculos.Dominio.ModuloPlanoCobranca;
using Locadora_Veiculos.Dominio.ModuloTaxa;
using Locadora_Veiculos.Dominio.ModuloVeiculo;
using Locadora_Veiculos.WinApp.Compartilhado;
using LocadoraVeiculos.Aplicacao.ModuloCliente;
using LocadoraVeiculos.Aplicacao.ModuloCondutor;
using LocadoraVeiculos.Aplicacao.ModuloGrupoVeiculos;
using LocadoraVeiculos.Aplicacao.ModuloLocacao;
using LocadoraVeiculos.Aplicacao.ModuloPlanoCobranca;
using LocadoraVeiculos.Aplicacao.ModuloTaxa;
using LocadoraVeiculos.Aplicacao.ModuloVeiculo;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Locadora_Veiculos.WinApp.ModuloLocacao
{
    public class ControladorLocacao : ControladorBase
    {
        private ListagemLocacaoControl listagemLocacoes;
        private readonly ServicoCondutor servicoCondutor;
        private readonly ServicoCliente servicoCliente;
        private readonly ServicoGrupoVeiculos servicoGrupoVeiculos;
        private readonly ServicoVeiculo servicoVeiculo;
        private readonly ServicoTaxa servicoTaxa;
        private readonly ServicoPlanoCobranca servicoPlanoCobranca;
        private readonly ServicoLocacao servicoLocacao;

        public ControladorLocacao(ServicoCondutor servicoCondutor,
            ServicoCliente servicoCliente, ServicoGrupoVeiculos servicoGrupoVeiculos,
            ServicoVeiculo servicoVeiculo, ServicoTaxa servicoTaxa,
            ServicoPlanoCobranca servicoPlanoCobranca, ServicoLocacao servicoLocacao)
        {
            this.servicoCondutor = servicoCondutor;
            this.servicoCliente = servicoCliente;
            this.servicoGrupoVeiculos = servicoGrupoVeiculos;
            this.servicoVeiculo = servicoVeiculo;
            this.servicoTaxa = servicoTaxa;
            this.servicoPlanoCobranca = servicoPlanoCobranca;
            this.servicoLocacao = servicoLocacao;
        }

        public override void Inserir()
        {
            var resultado = VerificarDependencias();

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
                "Inserção de Locação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCadastroLocacaoForm tela = 
                new TelaCadastroLocacaoForm(ObterClientes(), ObterCondutores(),
                ObterGruposDeVeiculo(),ObterVeiculos(),ObterTaxas(),ObterPlanosDeCobranca());

            tela.Locacao = new Locacao();

            tela.GravarRegistro = servicoLocacao.Inserir;

            if (tela.ShowDialog() == DialogResult.OK)
                CarregarLocacoes();
        }

        public override void Editar()
        {
            var id = listagemLocacoes.ObtemIdLocacaoSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione uma locação primeiro!",
                "Edição de Locação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Result<Locacao> resultado = servicoLocacao.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
                    "Edição de Locação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var locacaoSelecionada = resultado.Value;

            TelaCadastroLocacaoForm tela =
               new TelaCadastroLocacaoForm(ObterClientes(), ObterCondutores(),
               ObterGruposDeVeiculo(), ObterVeiculos(), ObterTaxas(), ObterPlanosDeCobranca());

            tela.Locacao = locacaoSelecionada;

            tela.GravarRegistro = servicoLocacao.Editar;

            if (tela.ShowDialog() == DialogResult.OK)
                CarregarLocacoes();
        }

        public override void Excluir()
        {
            var id = listagemLocacoes.ObtemIdLocacaoSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione uma locação primeiro!",
                "Exclusão de Locação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultadoSelecao = servicoLocacao.SelecionarPorId(id);

            if (resultadoSelecao.IsFailed)
            {
                MessageBox.Show(resultadoSelecao.Errors[0].Message,
                    "Exclusão de Locação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var locacaoSelecionada = resultadoSelecao.Value;

            if (MessageBox.Show("Deseja realmente excluir a locação?",
                "Exclusão de Locação", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var resultadoExclusao = servicoLocacao.Excluir(locacaoSelecionada);

                if (resultadoExclusao.IsSuccess)
                    CarregarLocacoes();
                else
                    MessageBox.Show(resultadoExclusao.Errors[0].Message,
                        "Exclusão de Locação", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolBoxLocacao();
        }

        public override UserControl ObtemListagem()
        {
            if (listagemLocacoes == null)
                listagemLocacoes = new ListagemLocacaoControl();

            CarregarLocacoes();

            return listagemLocacoes;
        }

        #region MÉTODOS PRIVADOS

        private void CarregarLocacoes()
        {
            var resultado = servicoLocacao.SelecionarTodos();

            if (resultado.IsSuccess)
            {
                List<Locacao> locacoes = resultado.Value;

                listagemLocacoes.AtualizarRegistros(locacoes);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {locacoes.Count} locação(ões)");
            }
            else
            {
                MessageBox.Show(resultado.Errors[0].Message, "Visualização de Locação",
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

        private List<Condutor> ObterCondutores()
        {
            var resultado = servicoCondutor.SelecionarTodos();

            List<Condutor> lista = new List<Condutor>();

            if (resultado.IsSuccess)
                lista = resultado.Value;

            return lista;
        }
        
        private List<GrupoVeiculos> ObterGruposDeVeiculo()
        {
            var resultado = servicoGrupoVeiculos.SelecionarTodos();

            List<GrupoVeiculos> lista = new List<GrupoVeiculos>();

            if (resultado.IsSuccess)
                lista = resultado.Value;

            return lista;
        }
        
        private List<Veiculo> ObterVeiculos()
        {
            var resultado = servicoVeiculo.SelecionarTodos();

            List<Veiculo> lista = new List<Veiculo>();

            if (resultado.IsSuccess)
                lista = resultado.Value;

            return lista;
        }
        
        private List<Taxa> ObterTaxas()
        {
            var resultado = servicoTaxa.SelecionarTodos();

            List<Taxa> lista = new List<Taxa>();

            if (resultado.IsSuccess)
                lista = resultado.Value;

            return lista;
        }

        private List<PlanoCobranca> ObterPlanosDeCobranca()
        {
            var resultado = servicoPlanoCobranca.SelecionarTodos();

            List<PlanoCobranca> lista = new List<PlanoCobranca>();

            if (resultado.IsSuccess)
                lista = resultado.Value;

            return lista;
        }

        private Result VerificarDependencias()
        {
            var resultadoCondutores = servicoCondutor.QuantidadeCondutoresCadastrados();

            if (resultadoCondutores.IsFailed)
            {
                return Result.Fail(resultadoCondutores.Errors[0].Message);
            }

            var qtdCondutores = resultadoCondutores.Value;

            if (qtdCondutores == 0)
            {
                return Result.Fail("Para cadastrar uma Locação, é necessário que haja um condutor cadastrado!");
            }

            var resultadoVeiculos = servicoVeiculo.QuantidadeVeiculosCadastrados();

            if (resultadoVeiculos.IsFailed)
            {
                return Result.Fail(resultadoVeiculos.Errors[0].Message);
            }

            var qtdVeiculos = resultadoVeiculos.Value;

            if (qtdVeiculos == 0)
            {
                return Result.Fail("Para cadastrar uma Locação, é necessário que haja um veículo cadastrado!");
            }

            var resultadoTaxas = servicoTaxa.QuantidadeTaxasCadastradas();

            if (resultadoTaxas.IsFailed)
            {
                return Result.Fail(resultadoTaxas.Errors[0].Message);
            }

            var qtdTaxas = resultadoTaxas.Value;

            if (qtdTaxas == 0)
            {
                return Result.Fail("Para cadastrar uma Locação, é necessário que haja uma taxa cadastrada!");
            }

            var resultadoPlanos = servicoPlanoCobranca.QuantidadePlanosCadastrados();

            if (resultadoPlanos.IsFailed)
            {
                return Result.Fail(resultadoPlanos.Errors[0].Message);
            }

            var qtdPlanos = resultadoPlanos.Value;

            if (qtdPlanos == 0)
            {
                return Result.Fail("Para cadastrar uma Locação, é necessário que haja um plano de cobrança cadastrado!");
            }

            return Result.Ok();
        }

        #endregion
    }
}
