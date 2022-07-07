using Locadora_Veiculos.Dominio.ModuloPlanoCobranca;
using Locadora_Veiculos.WinApp.Compartilhado;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Locadora_Veiculos.WinApp.ModuloPlanoCobrança
{
    public partial class ListagemPlanoCobrancaControl : UserControl
    {
        public ListagemPlanoCobrancaControl()
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
                new DataGridViewTextBoxColumn { DataPropertyName = "DiarioValorDia", HeaderText = "Plano diário - Valor dia"},
                new DataGridViewTextBoxColumn { DataPropertyName = "DiarioValorKm", HeaderText = "Plano diário - Valor por Km"},
                new DataGridViewTextBoxColumn { DataPropertyName = "KmControladoValorDia", HeaderText = "Plano Km Controlado - Valor dia"},
                new DataGridViewTextBoxColumn { DataPropertyName = "KmControladoValorKm", HeaderText = "Plano Km Controlado - Valor por Km"},
                new DataGridViewTextBoxColumn { DataPropertyName = "KmControladoLimiteKm", HeaderText = "Plano Km Controlado - Limite de Km"},
                new DataGridViewTextBoxColumn { DataPropertyName = "KmLivreValorDia", HeaderText = "Plano Km Livre - Valor dia"},
                new DataGridViewTextBoxColumn { DataPropertyName = "grupoNome", HeaderText = "Grupo de Veículos"}

            };

            return colunas;
        }

        public void AtualizarRegistros(List<PlanoCobranca> planos)
        {
            grid.Rows.Clear();
            foreach (var plano in planos)
            {
                var grupoNome = plano.GrupoVeiculos.Nome;

                grid.Rows.Add(plano.Id, "R$ " + plano.DiarioValorDia, "R$ " + plano.DiarioValorKm,
                               "R$ " + plano.KmControladoValorDia, "R$ " + plano.KmControladoValorKm,
                               plano.KmControladoLimiteKm + " Km", "R$ " + plano.KmLivreValorDia, grupoNome);
            }
        }

        public int ObtemIdPlanoCobrancaSelecionado()
        {
            return grid.SelecionarId<int>();
        }
    }
}