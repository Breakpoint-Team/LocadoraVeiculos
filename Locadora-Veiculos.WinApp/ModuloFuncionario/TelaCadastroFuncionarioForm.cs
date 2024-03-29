﻿using FluentResults;
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
                PreencherDadosNaTela();
            }
        }

        public Func<Funcionario, Result<Funcionario>> GravarRegistro { get; set; }

        #region EVENTOS

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            ObterDadosTela();

            var resultadoValidacao = GravarRegistro(funcionario);

            if (resultadoValidacao.IsFailed)
            {
                string erro = resultadoValidacao.Errors[0].Message;

                if (erro.StartsWith("Falha no sistema"))
                {
                    MessageBox.Show(erro,
                    "Inserção de Funcionário", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                    DialogResult = DialogResult.None;
                }
            }
        }

        private void TelaCadastroFuncionarioForm_Load(object sender, EventArgs e)
        {
            TelaPrincipalForm.Instancia.AtualizarRodape("");
        }

        #endregion

        #region MÉTODOS PRIVADOS

        private void LimparCampos()
        {
            txtNome.Clear();
            txtLogin.Clear();
            txtSenha.Clear();
            numericSalario.Value = 0;
            checkBoxIsAdmin.Checked = false;
            dateTimePickerDataAdmissao.Value = DateTime.Today;
        }

        private void DefinirDataAdmissaoMaxima()
        {
            dateTimePickerDataAdmissao.MaxDate = DateTime.Today;
        }

        private void PreencherDadosNaTela()
        {
            txtNome.Text = funcionario.Nome;
            txtLogin.Text = funcionario.Login;
            txtSenha.Text = funcionario.Senha;
            numericSalario.Value = funcionario.Salario;

            if (funcionario.DataAdmissao.Date != new DateTime(1, 1, 1).Date)
                dateTimePickerDataAdmissao.Value = funcionario.DataAdmissao;

            if (funcionario.EhAdmin == true)
                checkBoxIsAdmin.Checked = true;
            else
                checkBoxIsAdmin.Checked = false;
        }

        private void ObterDadosTela()
        {
            funcionario.Nome = txtNome.Text;
            funcionario.Login = txtLogin.Text;
            funcionario.Senha = txtSenha.Text;
            funcionario.Salario = numericSalario.Value;


            funcionario.DataAdmissao = dateTimePickerDataAdmissao.Value;

            if (checkBoxIsAdmin.Checked == true)
                funcionario.EhAdmin = true;
            else
                funcionario.EhAdmin = false;
        }

        #endregion
    }
}