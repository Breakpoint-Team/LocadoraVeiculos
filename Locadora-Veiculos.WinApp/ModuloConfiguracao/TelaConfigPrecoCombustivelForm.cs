using FluentResults;
using Locadora_Veiculos.Dominio.Compartilhado;
using System;
using System.Windows.Forms;

namespace Locadora_Veiculos.WinApp.ModuloConfiguracao
{
    public partial class TelaConfigPrecoCombustivelForm : Form
    {
        private PrecoCombustivel preco;
        public TelaConfigPrecoCombustivelForm()
        {
            InitializeComponent();
        }

        public PrecoCombustivel PrecoCombustivel
        {
            get {
                return preco;
                }
            set
            {
                preco = value;
                numPrecoGNV.Value = preco.PrecoGNV;
                numPrecoGasolina.Value = preco.PrecoGasolina;
                numPrecoDiesel.Value = preco.PrecoDiesel;
                numPrecoAlcool.Value = preco.PrecoAlcool;
            }
        }


        public Func<PrecoCombustivel, Result<PrecoCombustivel>> GravarRegistro { get; set; }


        private void btnGravar_Click(object sender, EventArgs e)
        {
            preco.PrecoGNV = numPrecoGNV.Value;
            preco.PrecoAlcool = numPrecoAlcool.Value;
            preco.PrecoGasolina = numPrecoGasolina.Value;
        }


    }
}
