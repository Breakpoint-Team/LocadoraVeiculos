﻿using Locadora_Veiculos.Dominio.ModuloGrupoVeiculos;
using Locadora_Veiculos.Dominio.ModuloPlanoCobranca;
using Locadora_Veiculos.WinApp.Compartilhado;
using LocadoraVeiculos.Aplicacao.ModuloGrupoVeiculos;
using LocadoraVeiculos.Aplicacao.ModuloPlanoCobranca;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Locadora_Veiculos.WinApp.ModuloPlanoCobrança
{
    public class ControladorPlanoCobranca : ControladorBase
    {

        private readonly ServicoPlanoCobranca servicoPlanoCobranca;
        private readonly ServicoGrupoVeiculos servicoGrupoVeiculos;
        private ListagemPlanoCobrancaControl listagemPlanoCobranca;

        public ControladorPlanoCobranca(ServicoPlanoCobranca servicoPlanoCobranca, ServicoGrupoVeiculos servicoGrupoVeiculos)
        {

            this.servicoPlanoCobranca = servicoPlanoCobranca;
            this.servicoGrupoVeiculos = servicoGrupoVeiculos;
        }

        public override void Inserir()
        {
            var resultado = servicoGrupoVeiculos.QuantidadeGrupoVeiculosCadastrados();

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
               "Inserção de Plano de Cobrança", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var qtd = resultado.Value;
            if (qtd < 1)
            {
                MessageBox.Show("Para cadastrar um Plano de Cobrança, é necessário que haja um Grupo de Veículos cadastrado!",
                "Inserção de Plano de Cobrança", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var tela = new TelaCadastroPlanoCobrancaForm(ObterGrupos());

            tela.PlanoCobranca = new PlanoCobranca();

            tela.GravarRegistro = servicoPlanoCobranca.Inserir;

            if (tela.ShowDialog() == DialogResult.OK)
                CarregarPlanos();
        }

        public override void Editar()
        {
            var id = listagemPlanoCobranca.ObtemIdPlanoCobrancaSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um plano de cobrança primeiro!",
                "Edição de Plano de Cobrança", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultado = servicoPlanoCobranca.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message, "Edição de Plano de Cobrança", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var planoCobrancaSelecionado = resultado.Value;

            var tela = new TelaCadastroPlanoCobrancaForm(ObterGrupos());

            tela.PlanoCobranca = planoCobrancaSelecionado;

            tela.GravarRegistro = servicoPlanoCobranca.Editar;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                CarregarPlanos();
            }
        }

        public override void Excluir()
        {
            var id = listagemPlanoCobranca.ObtemIdPlanoCobrancaSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um plano de cobrança primeiro!",
                "Exclusão de Plano de Cobrança", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultado = servicoPlanoCobranca.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message, "Exclusão de Plano de Cobrança", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var planoCobrancaSelecionado = resultado.Value;

            if (MessageBox.Show("Deseja realmente excluir o plano de cobrança?",
            "Exclusão de Plano de Cobrança", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var resultadoExclusao = servicoPlanoCobranca.Excluir(planoCobrancaSelecionado);
                if (resultadoExclusao.IsSuccess)
                    CarregarPlanos();

                else
                {
                    MessageBox.Show(resultadoExclusao.Errors[0].Message,
                        "Exclusão plano de cobrança", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxPlanoCobranca();
        }

        public override UserControl ObtemListagem()
        {
            if (listagemPlanoCobranca == null)
                listagemPlanoCobranca = new ListagemPlanoCobrancaControl();

            CarregarPlanos();

            return listagemPlanoCobranca;
        }

        #region MÉTODOS PRIVADOS

        private void CarregarPlanos()
        {
            var resultado = servicoPlanoCobranca.SelecionarTodos();

            if (resultado.IsSuccess)
            {
                List<PlanoCobranca> planos = resultado.Value;

                listagemPlanoCobranca.AtualizarRegistros(planos);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {planos.Count} plano(s) de cobrança(s)");
            }
            else
            {
                MessageBox.Show(resultado.Errors[0].Message, "Visualização de Plano de Cobranças",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<GrupoVeiculos> ObterGrupos()
        {
            var resultado = servicoGrupoVeiculos.SelecionarTodos();

            List<GrupoVeiculos> grupos = new List<GrupoVeiculos>();

            if (resultado.IsSuccess)
            {
                grupos = resultado.Value;
            }

            return grupos;
        }

        #endregion
    }
}
