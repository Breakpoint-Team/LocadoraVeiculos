using Locadora_Veiculos.Dominio.ModuloFuncionario;
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

namespace Locadora_Veiculos.WinApp.ModuloFuncionario
{
    public partial class ListagemFuncionarioControl : UserControl
    {
        public ListagemFuncionarioControl()
        {
            InitializeComponent();
        }

        internal void AtualizarRegistros(List<Funcionario> funcionarios)
        {
            throw new NotImplementedException();
        }
        public int ObtemIdFuncionarioSelecionado()
        {
            return grid.SelecionarId<int>();
        }
    }
}
