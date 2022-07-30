using Locadora_Veiculos.Dominio.ModuloGrupoVeiculos;
using Locadora_Veiculos.WinApp.Compartilhado;
using LocadoraVeiculos.Aplicacao.ModuloGrupoVeiculos;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Locadora_Veiculos.WinApp.ModuloGrupoVeiculos
{
    public class ControladorGrupoVeiculos : ControladorBase
    {
        private ListagemGrupoVeiculosControl listagemGrupoVeiculos;
        private ServicoGrupoVeiculos servicoGrupoVeiculos;

        public ControladorGrupoVeiculos(ServicoGrupoVeiculos servicoGrupoVeiculos)
        {
            this.servicoGrupoVeiculos = servicoGrupoVeiculos;
        }

        public override void Inserir()
        {
            var tela = new TelaCadastroGrupoVeiculosForm();
            tela.Grupo = new GrupoVeiculos();
            tela.GravarRegistro = servicoGrupoVeiculos.Inserir;

            DialogResult resultado = tela.ShowDialog();
            CarregarGrupos();
        }

        public override void Editar()
        {
            var id = listagemGrupoVeiculos.ObtemIdGrupoVeiculosSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um grupo de veículos primeiro!",
                "Edição de Grupo de Veículos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            var resultado = servicoGrupoVeiculos.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
                    "Edição de Grupo de Veículos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var grupoVeiculosSelecionado = resultado.Value;

            var tela = new TelaCadastroGrupoVeiculosForm();

            tela.Grupo = grupoVeiculosSelecionado;

            tela.GravarRegistro = servicoGrupoVeiculos.Editar;

            if (tela.ShowDialog() == DialogResult.OK)
                CarregarGrupos();
        }

        public override void Excluir()
        {
            var id = listagemGrupoVeiculos.ObtemIdGrupoVeiculosSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um grupo de veículos primeiro!",
                "Exclusão de Grupo de Veículos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultado = servicoGrupoVeiculos.SelecionarPorId(id);


            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
                "Exclusão de Grupo de Veículos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            var grupoVeiculosSelecionado = resultado.Value;


            if (MessageBox.Show("Deseja realmente excluir o grupo de veículos?", "Exclusão de Grupo de Veículos",
                  MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var resultadoExclusao = servicoGrupoVeiculos.Excluir(grupoVeiculosSelecionado);

                if (resultadoExclusao.IsSuccess)
                    CarregarGrupos();
                else
                    MessageBox.Show(resultadoExclusao.Errors[0].Message,
                        "Exclusão de Grupo de Veículos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxGrupoVeiculos();
        }

        public override UserControl ObtemListagem()
        {
            if (listagemGrupoVeiculos == null)
                listagemGrupoVeiculos = new ListagemGrupoVeiculosControl();

            CarregarGrupos();

            return listagemGrupoVeiculos;
        }

        #region MÉTODOS PRIVADOS

        private void CarregarGrupos()
        {
            var resultado = servicoGrupoVeiculos.SelecionarTodos();


            if (resultado.IsSuccess)
            {
                List<GrupoVeiculos> grupos = resultado.Value;

                listagemGrupoVeiculos.AtualizarRegistros(grupos);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {grupos.Count} grupo(s) de veículos(s)");
            }
            else
            {
                MessageBox.Show(resultado.Errors[0].Message, "Visualização de Grupo de Veículos",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        #endregion
    }
}