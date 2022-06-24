using Locadora_Veiculos.Dominio.ModuloCliente;
using Locadora_Veiculos.WinApp.Compartilhado;
using System.Collections.Generic;
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
                new DataGridViewTextBoxColumn { DataPropertyName = "Nome", HeaderText = "Nome"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Telefone", HeaderText = "Telefone"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Email", HeaderText = "Email"},
                new DataGridViewTextBoxColumn { DataPropertyName = "TipoCliente", HeaderText = "Tipo"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Cpf", HeaderText = "CPF"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Cnpj", HeaderText = "CNPJ"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Cnh", HeaderText = "CNH"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Estado", HeaderText = "Estado"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Cidade", HeaderText = "Cidade"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Bairro", HeaderText = "Bairro"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Rua", HeaderText = "Rua"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Numero", HeaderText = "Número"},
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
            foreach (Cliente cliente in Clientes)
            {
                grid.Rows.Add(cliente.Id, cliente.Nome, cliente.Telefone, cliente.Email,
                              cliente.TipoCliente, cliente.Cpf, cliente.Cnpj, cliente.Cnh,
                              cliente.Estado, cliente.Cidade, cliente.Bairro, cliente.Rua, cliente.Numero);
            }

        }
    }
}
