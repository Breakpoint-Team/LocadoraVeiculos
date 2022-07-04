using Locadora_Veiculos.Dominio.ModuloGrupoVeiculos;
using Locadora_Veiculos.WinApp.Compartilhado;
using LocadoraVeiculos.Aplicacao.ModuloGrupoVeiculos;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Locadora_Veiculos.WinApp.ModuloGrupoVeiculos
{
    public class ControladorGrupoVeiculos : ControladorBase
    {
        private readonly IRepositorioGrupoVeiculos repositorioGrupoVeiculos;
        private ListagemGrupoVeiculosControl listagemGrupoVeiculos;
        private readonly ServicoGrupoVeiculos servicoGrupoVeiculos;

        public ControladorGrupoVeiculos(IRepositorioGrupoVeiculos repositorioGrupoVeiculos,
            ServicoGrupoVeiculos servicoGrupoVeiculos)
        {
            this.repositorioGrupoVeiculos = repositorioGrupoVeiculos;
            this.servicoGrupoVeiculos = servicoGrupoVeiculos;
        }

        public override void Inserir()
        {
            var tela = new TelaCadastroGrupoVeiculosForm();
            tela.Grupo = new GrupoVeiculos();
            tela.GravarRegistro = servicoGrupoVeiculos.Inserir;

            DialogResult resultado = tela.ShowDialog();
            if (resultado == DialogResult.OK)
                CarregarGrupos();
        }

        public override void Editar()
        {
            GrupoVeiculos grupoVeiculosSelecionado = ObtemGrupoVeiculosSelecionado();

            if (grupoVeiculosSelecionado == null)
            {
                MessageBox.Show("Selecione um grupo de veículos primeiro!",
                "Edição de Grupo de Veículos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var tela = new TelaCadastroGrupoVeiculosForm();

            tela.Grupo = grupoVeiculosSelecionado;

            tela.GravarRegistro = servicoGrupoVeiculos.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarGrupos();
        }

        public override void Excluir()
        {
            GrupoVeiculos grupoVeiculosSelecionado = ObtemGrupoVeiculosSelecionado();

            if (grupoVeiculosSelecionado == null)
            {
                MessageBox.Show("Selecione um grupo de veículos primeiro!",
                "Exclusão de Grupo de Veículos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir o grupo de veículos?",
            "Exclusão de Grupo de Veículos", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                var resultadoExclusao = servicoGrupoVeiculos.Excluir(grupoVeiculosSelecionado);

                if (resultadoExclusao.IsValid == false)
                {
                    MessageBox.Show(resultadoExclusao.Errors[0].ErrorMessage,
                                    "Exclusão de Grupo de Veículos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            CarregarGrupos();
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolBoxGrupoVeiculos();
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
            List<GrupoVeiculos> grupos = repositorioGrupoVeiculos.SelecionarTodos();

            listagemGrupoVeiculos.AtualizarRegistros(grupos);

            TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {grupos.Count} grupo(s) de veículos");
        }

        private GrupoVeiculos ObtemGrupoVeiculosSelecionado()
        {
            var id = listagemGrupoVeiculos.ObtemIdGrupoVeiculosSelecionado();

            return repositorioGrupoVeiculos.SelecionarPorId(id);
        }

        #endregion
    }
}