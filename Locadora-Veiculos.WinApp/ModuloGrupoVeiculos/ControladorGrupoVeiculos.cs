using Locadora_Veiculos.Dominio.ModuloGrupoVeiculos;
using Locadora_Veiculos.Infra.BancoDados.ModuloGrupoVeiculos;
using Locadora_Veiculos.WinApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Locadora_Veiculos.WinApp.ModuloGrupoVeiculos
{
    public class ControladorGrupoVeiculos : ControladorBase
    {
        private readonly RepositorioGrupoVeiculosEmBancoDados repositorioGrupoVeiculos;
        private ListagemGrupoVeiculosControl listagemGrupoVeiculos;
        public ControladorGrupoVeiculos(RepositorioGrupoVeiculosEmBancoDados repositorioGrupoVeiculos)
        {
            this.repositorioGrupoVeiculos = repositorioGrupoVeiculos;

        }
        public override void Inserir()
        {
            throw new NotImplementedException();
        }
        public override void Editar()
        {
            throw new NotImplementedException();
        }

        public override void Excluir()
        {
            throw new NotImplementedException();
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

        private void CarregarGrupos()
        {
            List<GrupoVeiculos> grupos = repositorioGrupoVeiculos.SelecionarTodos();

            listagemGrupoVeiculos.AtualizarRegistros(grupos);

            TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {grupos.Count} grupos(s) de veículos");
        }
    }
}
