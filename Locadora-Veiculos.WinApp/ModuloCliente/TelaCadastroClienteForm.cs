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

        #region EVENTOS

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

        #endregion

        #region MÉTODOS PRIVADOS

        private void ObterDadosTela()
        {
            cliente.Nome = txtNome.Text;
            cliente.Email = txtEmail.Text;
            cliente.Telefone = txtTelefone.Text;

            cliente.Rua = txtRua.Text;
            cliente.Bairro = txtBairro.Text;
            cliente.Cidade = txtCidade.Text;
            cliente.TipoCliente = ObterTipoClienteDaTela();

            if (cliente.TipoCliente == TipoCliente.PessoaFisica)
                cliente.Documento = txtCpf.Text;
            else if (cliente.TipoCliente == TipoCliente.PessoaJuridica)
                cliente.Documento = txtCnpj.Text;

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
                txtCpf.Text = cliente.Documento;
            }
            else if (cliente.TipoCliente == TipoCliente.PessoaJuridica)
            {
                radioButtonPessoaJuridica.Checked = true;
                DesabilitarPessoaFisica();
                HabilitarPessoaJuridica();
                txtCnpj.Text = cliente.Documento;
            }
        }

        private void LimparCampos()
        {
            txtNome.Clear();
            txtEmail.Clear();
            txtTelefone.Clear();
            txtCpf.Clear();
            txtCnpj.Clear();
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

        private TipoCliente ObterTipoClienteDaTela()
        {
            TipoCliente retorno = TipoCliente.PessoaFisica;

            if (radioButtonPessoaFisica.Checked && string.IsNullOrEmpty(txtCpf.Text) == false)
                retorno = TipoCliente.PessoaFisica;
            else if (radioButtonPessoaJuridica.Checked && string.IsNullOrEmpty(txtCnpj.Text) == false)
                retorno = TipoCliente.PessoaJuridica;

            return retorno;
        }

        #endregion

        #region RODAPE
        private void TelaCadastroClienteForm_Load(object sender, EventArgs e)
        {
            TelaPrincipalForm.Instancia.AtualizarRodape("");
        }

        private void TelaCadastroClienteForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            TelaPrincipalForm.Instancia.AtualizarRodape("");
        }
        #endregion
    }
}