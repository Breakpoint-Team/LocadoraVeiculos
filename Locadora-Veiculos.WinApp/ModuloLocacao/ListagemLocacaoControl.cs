using Locadora_Veiculos.Dominio.Compartilhado;
using Locadora_Veiculos.Dominio.ModuloLocacao;
using Locadora_Veiculos.WinApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Locadora_Veiculos.WinApp.ModuloLocacao
{
    public partial class ListagemLocacaoControl : UserControl
    {
        public ListagemLocacaoControl()
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
                new DataGridViewTextBoxColumn { DataPropertyName = "DataLocacao", HeaderText = "Data"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Nome", HeaderText = "Cliente"},
                new DataGridViewTextBoxColumn { DataPropertyName = "CNH", HeaderText = "CNH do condutor"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Modelo", HeaderText = "Veículo"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Placa", HeaderText = "Placa"},
                new DataGridViewTextBoxColumn { DataPropertyName = "TipoPlanoSelecionado", HeaderText = "Plano de cobrança"},
                new DataGridViewTextBoxColumn { DataPropertyName = "ValorTotalPervisto", HeaderText = "Total previsto"},
                new DataGridViewTextBoxColumn { DataPropertyName = "DataDevolucaoPrevista", HeaderText = "Devolução prevista"},
                new DataGridViewTextBoxColumn { DataPropertyName = "StatusLocacao", HeaderText = "Status locação"},
                new DataGridViewTextBoxColumn { DataPropertyName = "DataDevolucaoEfetiva", HeaderText = "Devolução efetiva"},
        };
            return colunas;
        }

        public Guid ObtemIdLocacaoSelecionado()
        {
            return grid.SelecionarId<Guid>();
        }
        public void AtualizarRegistros(List<Locacao> locacoes)
        {
            grid.Rows.Clear();
            foreach (Locacao locacao in locacoes)
            {
                grid.Rows.Add(
                    locacao.Id, locacao.DataLocacao,
                    locacao.Condutor.Cliente.Nome, locacao.Condutor.Cnh,
                    locacao.Veiculo.Modelo, locacao.Veiculo.Placa,
                    locacao.TipoPlanoSelecionado.GetDescription(),
                    locacao.ValorTotalPrevisto, locacao.DataDevolucaoPrevista.ToShortDateString(),
                    locacao.StatusLocacao.GetDescription(), locacao.DataDevolucaoEfetiva.Value.ToShortDateString());
            }
        }
    }
}
