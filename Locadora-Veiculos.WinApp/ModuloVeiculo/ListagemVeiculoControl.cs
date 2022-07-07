using Locadora_Veiculos.Dominio.ModuloVeiculo;
using Locadora_Veiculos.WinApp.Compartilhado;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Locadora_Veiculos.WinApp.ModuloVeiculo
{
    public partial class ListagemVeiculoControl : UserControl
    {
        public ListagemVeiculoControl()
        {
            InitializeComponent();
            grid.ConfigurarGridZebrado();
            grid.ConfigurarGridSomenteLeitura();
            grid.Columns.AddRange(ObterColunas());
        }

        private DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[] {

                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Modelo", HeaderText = "Modelo"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Marca", HeaderText = "Marca"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Ano", HeaderText = "Ano"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Cor", HeaderText = "Cor"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Placa", HeaderText = "Placa"},

                new DataGridViewTextBoxColumn { DataPropertyName = "TipoCombustivel", HeaderText = "Tipo de Combustível"},

                new DataGridViewTextBoxColumn { DataPropertyName = "QuilometragemPercorrida", HeaderText = "Quilometragem Percorrida"},

                new DataGridViewTextBoxColumn { DataPropertyName = "CapacidadeTanque", HeaderText = "Capacidade do Tanque"},

                new DataGridViewTextBoxColumn { DataPropertyName = "GrupoVeiculos", HeaderText = "Grupo de Veículos"}
            };

            return colunas;
        }

        public void AtualizarRegistros(List<Veiculo> veiculos)
        {
            grid.Rows.Clear();
            foreach (var v in veiculos)
            {
                grid.Rows.Add(v.Id, v.Modelo, v.Marca, v.Ano, v.Cor, v.Placa, v.TipoCombustivel, v.QuilometragemPercorrida + " Km", v.CapacidadeTanque + " Litros", v.GrupoVeiculos.Nome);
            }
        }

        public int ObtemIdVeiculoSelecionado()
        {
            return grid.SelecionarId<int>();
        }
    }
}