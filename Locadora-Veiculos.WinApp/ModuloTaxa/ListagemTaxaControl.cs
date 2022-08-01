using Locadora_Veiculos.Dominio.Compartilhado;
using Locadora_Veiculos.Dominio.ModuloTaxa;
using Locadora_Veiculos.WinApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Locadora_Veiculos.WinApp.ModuloTaxas
{
    public partial class ListagemTaxaControl : UserControl
    {
        public ListagemTaxaControl()
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

                new DataGridViewTextBoxColumn { DataPropertyName = "Descricao", HeaderText = "Descrição"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Valor", HeaderText = "Valor"},

                new DataGridViewTextBoxColumn { DataPropertyName = "TipoCalculo", HeaderText = "Tipo de Cálculo"},
                
                new DataGridViewTextBoxColumn { DataPropertyName = "TipoTaxa", HeaderText = "Tipo de Taxa"}

            };

            return colunas;
        }

        public void AtualizarRegistros(List<Taxa> taxas)
        {
            grid.Rows.Clear();
            foreach (var t in taxas)
            {
                grid.Rows.Add(t.Id, t.Descricao, "R$ " + t.Valor, 
                    t.TipoCalculo.GetDescription(), t.TipoTaxa.GetDescription());
            }
        }

        public Guid ObtemIdTaxaSelecionada()
        {
            return grid.SelecionarId<Guid>();
        }
    }
}