using FluentValidation.Results;
using Locadora_Veiculos.Dominio.ModuloGrupoVeiculos;
using System;
using System.Windows.Forms;

namespace Locadora_Veiculos.WinApp.ModuloGrupoVeiculos
{
    public partial class TelaCadastroGrupoVeiculos : Form
    {
        private GrupoVeiculos grupoVeiculos;

        public TelaCadastroGrupoVeiculos()
        {
            InitializeComponent();
        }

        public Func<GrupoVeiculos, ValidationResult> GravarRegistro { get; set; }

        public GrupoVeiculos Grupo
        {
            get
            {
                return grupoVeiculos;
            }
            set
            {
                grupoVeiculos = value;
                txtNome.Text = grupoVeiculos.Nome;
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            grupoVeiculos.Nome = txtNome.Text;

            var resultadoValidacao = GravarRegistro(grupoVeiculos);
            if (resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;

                TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtNome.Clear();
        }

    }
}