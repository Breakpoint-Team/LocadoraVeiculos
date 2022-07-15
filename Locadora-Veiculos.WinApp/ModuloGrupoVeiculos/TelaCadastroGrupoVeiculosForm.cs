using FluentResults;
using FluentValidation.Results;
using Locadora_Veiculos.Dominio.ModuloGrupoVeiculos;
using System;
using System.Windows.Forms;

namespace Locadora_Veiculos.WinApp.ModuloGrupoVeiculos
{
    public partial class TelaCadastroGrupoVeiculosForm : Form
    {
        private GrupoVeiculos grupoVeiculos;

        public TelaCadastroGrupoVeiculosForm()
        {
            InitializeComponent();
        }

        public Func<GrupoVeiculos, Result<GrupoVeiculos>> GravarRegistro { get; set; }

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

        #region EVENTOS

        private void btnGravar_Click(object sender, EventArgs e)
        {
            grupoVeiculos.Nome = txtNome.Text;

            var resultadoValidacao = GravarRegistro(grupoVeiculos);
            if (resultadoValidacao.IsFailed)
            {
                string erro = resultadoValidacao.Errors[0].Message;


                if (erro.StartsWith("Falha no sistema"))
                {
                    MessageBox.Show(erro,
                    "Inserção de Grupo de Veículos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                    DialogResult = DialogResult.None;
                }
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtNome.Clear();
        }

        private void TelaCadastroGrupoVeiculosForm_Load(object sender, EventArgs e)
        {
            TelaPrincipalForm.Instancia.AtualizarRodape("");
        }

        #endregion

    }
}