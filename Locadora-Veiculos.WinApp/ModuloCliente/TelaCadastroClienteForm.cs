using FluentValidation.Results;
using Locadora_Veiculos.Dominio.ModuloCliente;
using System;
using System.Windows.Forms;

namespace Locadora_Veiculos.WinApp.ModuloCliente
{
    public partial class TelaCadastroClienteForm : Form
    {
        private Cliente cliente;

        public TelaCadastroClienteForm()
        {
            InitializeComponent();
        }

        public Cliente Cliente
        {
            get => cliente;
            set
            {
                cliente = value;
                if (cliente.Id != 0)
                    PreencherDadosNaTela();
                else
                {
                    HabilitarPessoaFisica();
                    radioButtonPessoaFisica.Checked = true;
                    DesabilitarPessoaJuridica();
                }
            }
        }

        public Func<Cliente, ValidationResult> GravarRegistro { get; set; }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            ObterDadosTela();

            var resultadoValidacao = GravarRegistro(cliente);

            if (resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;

                TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void radioButtonPessoaFisica_CheckedChanged(object sender, EventArgs e)
        {
            HabilitarPessoaFisica();
            DesabilitarPessoaJuridica();


        }

        private void radioButtonPessoaJuridica_CheckedChanged(object sender, EventArgs e)
        {
            HabilitarPessoaJuridica();
            DesabilitarPessoaFisica();
        }

        private void ObterDadosTela()
        {
            cliente.Nome = txtNome.Text;
            cliente.Email = txtEmail.Text;
            cliente.Telefone = txtTelefone.Text;
            cliente.Cpf = txtCpf.Text;
            cliente.Cnpj = txtCnpj.Text;
            cliente.Cnh = txtCnh.Text;
            cliente.Rua = txtRua.Text;
            cliente.Bairro = txtBairro.Text;
            cliente.Cidade = txtCidade.Text;
            cliente.TipoCliente = ObterTipoCliente();
            if (string.IsNullOrEmpty(txtNumero.Text) == false)
                cliente.Numero = int.Parse(txtNumero.Text);
            if (comboBoxEstado.SelectedIndex != -1)
                cliente.Estado = comboBoxEstado.SelectedItem.ToString();
        }

        private void PreencherDadosNaTela()
        {
            txtNome.Text = cliente.Nome;
            txtEmail.Text = cliente.Email;
            txtTelefone.Text = cliente.Telefone;
            txtCpf.Text = cliente.Cpf;
            txtCnpj.Text = cliente.Cnpj;
            txtCnh.Text = cliente.Cnh;
            txtNumero.Text = Convert.ToString(cliente.Numero);
            txtRua.Text = cliente.Rua;
            txtBairro.Text = cliente.Bairro;
            txtCidade.Text = cliente.Cidade;
            comboBoxEstado.SelectedItem = cliente.Estado;
            PreencherTipoCliente();
        }

        private void PreencherTipoCliente()
        {
            if (cliente.TipoCliente == TipoCliente.PessoaFisica)
            {
                radioButtonPessoaFisica.Checked = true;
                DesabilitarPessoaJuridica();
                HabilitarPessoaFisica();
                txtCpf.Text = cliente.Cpf;
            }
            else if (cliente.TipoCliente == TipoCliente.PessoaJuridica)
            {
                radioButtonPessoaJuridica.Checked = true;
                DesabilitarPessoaFisica();
                HabilitarPessoaJuridica();
                txtCnpj.Text = cliente.Cnpj;
            }
        }

        private void LimparCampos()
        {
            txtNome.Clear();
            txtEmail.Clear();
            txtTelefone.Clear();
            txtCpf.Clear();
            txtCnpj.Clear();
            txtCnh.Clear();
            txtNumero.Clear();
            txtRua.Clear();
            txtBairro.Clear();
            txtCidade.Clear();
            comboBoxEstado.SelectedIndex = -1;
            radioButtonPessoaFisica.Checked = true;
        }

        private void HabilitarPessoaFisica()
        {
            txtCpf.Enabled = true;
        }

        private void HabilitarPessoaJuridica()
        {
            txtCnpj.Enabled = true;
        }

        private void DesabilitarPessoaFisica()
        {
            txtCpf.Clear();
            txtCpf.Enabled = false;
        }

        private void DesabilitarPessoaJuridica()
        {
            txtCnpj.Clear();
            txtCnpj.Enabled = false;
        }

        private TipoCliente ObterTipoCliente()
        {
            TipoCliente retorno = TipoCliente.PessoaFisica;

            if (radioButtonPessoaFisica.Checked && string.IsNullOrEmpty(txtCpf.Text) == false)
                retorno = TipoCliente.PessoaFisica;
            else if (radioButtonPessoaJuridica.Checked && string.IsNullOrEmpty(txtCnpj.Text) == false)
                retorno = TipoCliente.PessoaJuridica;

            return retorno;
        }
    }
}
