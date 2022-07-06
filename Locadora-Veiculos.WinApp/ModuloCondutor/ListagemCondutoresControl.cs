using Locadora_Veiculos.Dominio.ModuloCondutor;
using Locadora_Veiculos.WinApp.Compartilhado;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Locadora_Veiculos.WinApp.ModuloCondutor
{
    public partial class ListagemCondutoresControl : UserControl
    {
        public ListagemCondutoresControl()
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
                new DataGridViewTextBoxColumn { DataPropertyName = "Cpf", HeaderText = "CPF"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Cnh", HeaderText = "CNH"},
                new DataGridViewTextBoxColumn { DataPropertyName = "DataValidadeCnh", HeaderText = "Validade CNH"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Cliente", HeaderText = "Cliente"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Estado", HeaderText = "Estado"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Cidade", HeaderText = "Cidade"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Bairro", HeaderText = "Bairro"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Logradouro", HeaderText = "Logradouro"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Numero", HeaderText = "Número"},
        };
            return colunas;
        }

        public int ObtemIdCondutorSelecionado()
        {
            return grid.SelecionarId<int>();
        }

        public void AtualizarRegistros(List<Condutor> condutores)
        {
            grid.Rows.Clear();
            foreach (Condutor condutor in condutores)
            {
                grid.Rows.Add(condutor.Id, condutor.Nome, condutor.Telefone, condutor.Email,
                               condutor.Cpf, condutor.Cnh, condutor.DataValidadeCnh.ToShortDateString(),
                              condutor.Cliente, condutor.Endereco.Estado, condutor.Endereco.Cidade,
                              condutor.Endereco.Bairro, condutor.Endereco.Logradouro, condutor.Endereco.Numero);
            }
        }
    }
}