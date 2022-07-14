using FluentResults;
using FluentValidation.Results;
using Locadora_Veiculos.Dominio.ModuloTaxa;
using System;
using System.Windows.Forms;

namespace Locadora_Veiculos.WinApp.ModuloTaxas
{
    public partial class TelaCadastroTaxaForm : Form
    {
        private Taxa taxa;

        public TelaCadastroTaxaForm()
        {
            InitializeComponent();
        }

        public Func<Taxa, Result<Taxa>> GravarRegistro { get; set; }

        public Taxa Taxa
        {
            get
            {
                return taxa;
            }

            set
            {
                taxa = value;
                    txtDescricao.Text = taxa.Descricao;
                    numericValor.Value = taxa.Valor;
                    if (taxa.TipoCalculo == 0)
                        radioButtonDiario.Checked = true;
                    else radioButtonFixo.Checked = true;
            }
        }

        #region EVENTOS

        private void btnGravar_Click(object sender, EventArgs e)
        {
            taxa.Descricao = txtDescricao.Text;
            taxa.Valor = numericValor.Value;

            taxa.TipoCalculo = (TipoCalculo)(radioButtonDiario.Checked == true ? 0 : 1);

            var resultadoValidacao = GravarRegistro(taxa);
            if (resultadoValidacao.IsFailed)
            {
                string erro = resultadoValidacao.Errors[0].Message;

                if (erro.StartsWith("Falha no sistema"))
                {
                    MessageBox.Show(erro,
                    "Inserção de Taxa", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            txtDescricao.Clear();
            numericValor.Value = 0;
        }

        private void TelaCadastroTaxaForm_Load(object sender, EventArgs e)
        {
            TelaPrincipalForm.Instancia.AtualizarRodape("");
        }

        #endregion
    }
}