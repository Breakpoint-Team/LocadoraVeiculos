using FluentValidation.Results;
using Locadora_Veiculos.Dominio.ModuloFuncionario;
using System;
using System.Windows.Forms;

namespace Locadora_Veiculos.WinApp.ModuloFuncionario
{
    public partial class TelaCadastroFuncionarioForm : Form
    {
        private Funcionario funcionario;

        public TelaCadastroFuncionarioForm()
        {
            InitializeComponent();
            DefinirDataAdmissaoMaxima();
        }

        public Funcionario Funcionario
        {
            get => funcionario;
            set
            {
                funcionario = value;
                if (funcionario.Id != 0)
                    PreencherDadosNaTela();

            }
        }

        

        public Func<Funcionario, ValidationResult> GravarRegistro { get; set; }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            ObterDadosTela();

            var resultadoValidacao = GravarRegistro(funcionario);

            if (resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;

                TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }
       
        #region MÉTODOS PRIVADOS

        private void LimparCampos()
        {
            txtNome.Clear();
            txtLogin.Clear();
            txtSenha.Clear();
            txtSalario.Clear();
            checkBoxIsAdmin.Checked = false;
            dateTimePickerDataAdmissao.Value = DateTime.Today;
        }

        private void DefinirDataAdmissaoMaxima()
        {
            dateTimePickerDataAdmissao.MaxDate = DateTime.Today;
        }

        private void PreencherDadosNaTela()
        {
            
        }

        private void ObterDadosTela()
        {
            funcionario.Nome = txtNome.Text;
            funcionario.Login = txtLogin.Text;
            funcionario.Senha = txtSenha.Text;
            funcionario.Salario = Convert.ToDecimal(txtSalario.Text);
            funcionario.DataAdmissao = dateTimePickerDataAdmissao.Value;

            if (checkBoxIsAdmin.Checked == true)
                funcionario.EhAdmin = true;
            else
                funcionario.EhAdmin = false;

        }

        #endregion

    }
}