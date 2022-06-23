using Locadora_Veiculos.Dominio.ModuloCliente;
using Locadora_Veiculos.WinApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Locadora_Veiculos.WinApp.ModuloCliente
{
    public partial class ListagemClientesControl : UserControl
    {
        public ListagemClientesControl()
        {
            InitializeComponent();
            grid.ConfigurarGridZebrado();
            grid.ConfigurarGridSomenteLeitura();
            grid.Columns.AddRange(ObterColunas());
        }

        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id"},

//                new DataGridViewTextBoxColumn { DataPropertyName = "Nome", HeaderText = "Nome da Cliente"},
            };

            return colunas;
        }

        public int ObtemNumeroClienteSelecionado()
        {
            return grid.SelecionarId<int>();
        }

        public void AtualizarRegistros(List<Cliente> Clientes)
        {
            grid.Rows.Clear();

            foreach (Cliente Cliente in Clientes)
                grid.Rows.Add(Cliente.Id);
        }
    }
}
