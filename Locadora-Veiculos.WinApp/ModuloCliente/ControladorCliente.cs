using Locadora_Veiculos.Dominio.ModuloCliente;
using Locadora_Veiculos.WinApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Locadora_Veiculos.WinApp.ModuloCliente
{
    public class ControladorCliente : ControladorBase
    {
        private readonly IRepositioCliente repositorioCliente;
        private ListagemClientesControl listagemClientes;

        public ControladorCliente(IRepositioCliente repositorioCliente)
        {
            this.repositorioCliente = repositorioCliente;
        }

        public override void Editar()
        {
            throw new NotImplementedException();
        }

        public override void Excluir()
        {
            throw new NotImplementedException();
        }

        public override void Inserir()
        {
            throw new NotImplementedException();
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

        private void CarregarClientes()
        {
            List<Cliente> clientes = repositorioCliente.SelecionarTodos();

            listagemClientes.AtualizarRegistros(clientes);

            TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {clientes.Count} cliente(s)");
        }
    }
}
