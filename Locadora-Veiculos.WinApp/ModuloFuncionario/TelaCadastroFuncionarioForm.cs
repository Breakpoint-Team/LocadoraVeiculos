﻿using FluentValidation.Results;
using Locadora_Veiculos.Dominio.ModuloFuncionario;
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
    public partial class TelaCadastroFuncionarioForm : Form
    {
        public Funcionario Funcionario { get; internal set; }
        public Func<Funcionario, ValidationResult> GravarRegistro { get; internal set; }

        public TelaCadastroFuncionarioForm()
        {
            InitializeComponent();
        }


        private void TelaCadastroFuncionarioForm_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void radioButtonPessoaFisica_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
