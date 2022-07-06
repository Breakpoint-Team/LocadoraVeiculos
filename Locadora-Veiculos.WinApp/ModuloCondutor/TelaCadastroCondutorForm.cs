using FluentValidation.Results;
using Locadora_Veiculos.Dominio.ModuloCliente;
using Locadora_Veiculos.Dominio.ModuloCondutor;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Locadora_Veiculos.WinApp.ModuloCondutor
{
    public partial class TelaCadastroCondutorForm : Form
    {
        private Condutor condutor;
        private List<Cliente> clientes;

        public TelaCadastroCondutorForm(List<Cliente> clientes)
        {
            InitializeComponent();

            this.clientes = clientes;

            CarregarClientes();

            dateTimePickerDataValidadeCnh.MinDate = DateTime.Today;
        }

        public Condutor Condutor
        {
            get => condutor;
            set
            {
                condutor = value;
                if (condutor.Id != 0)
                    PreencherDadosNaTela();
            }
        }

        public Func<Condutor, ValidationResult> GravarRegistro { get; set; }

        #region EVENTOS

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparTodosOsCampos();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            ObterDadosTela();

            var resultadoValidacao = GravarRegistro(condutor);

            if (resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;

                TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }

        private void comboBoxClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            LimparCamposDeIdentificacao();
            txtCnh.Clear();
            dateTimePickerDataValidadeCnh.Value = DateTime.Today;

            var clienteSelecionado = ObterClienteSelecionado();

            if (clienteSelecionado == null || comboBoxClientes.SelectedIndex == -1)
                DesabilitarClienteCondutor();
            else if (clienteSelecionado.TipoCliente == TipoCliente.PessoaFisica)
                HabilitarClienteCondutor();
            else
                DesabilitarClienteCondutor();
        }

        private void checkBoxClienteCondutor_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxClienteCondutor.Checked && ObterClienteSelecionado() != null)
            {
                PreencherClienteCondutor();
                DesabilitarCamposDeIdentificacao();
            }
            else
            {
                LimparCamposDeIdentificacao();
                HabilitarCamposDeIdentificacao();
            }
        }

        private void TelaCadastroCondutorForm_Load(object sender, EventArgs e)
        {
            TelaPrincipalForm.Instancia.AtualizarRodape("");
        }


        #endregion

        #region MÉTODOS PRIVADOS

        private void PreencherDadosNaTela()
        {
            comboBoxClientes.SelectedItem = condutor.Cliente;

            if (condutor.ClienteCondutor)
            {
                PreencherClienteCondutor();
                checkBoxClienteCondutor.Checked = true;
            }
            else
            {
                txtNome.Text = condutor.Nome;
                txtEmail.Text = condutor.Email;
                txtTelefone.Text = condutor.Telefone;
                txtCpf.Text = condutor.Cpf;
                txtNumero.Text = Convert.ToString(condutor.Numero);
                txtRua.Text = condutor.Rua;
                txtBairro.Text = condutor.Bairro;
                txtCidade.Text = condutor.Cidade;
                comboBoxEstado.SelectedItem = condutor.Estado;
            }

            txtCnh.Text = condutor.Cnh;
            dateTimePickerDataValidadeCnh.Value = condutor.DataValidadeCnh;
        }

        private void ObterDadosTela()
        {
            condutor.Nome = txtNome.Text;
            condutor.Email = txtEmail.Text;
            condutor.Telefone = txtTelefone.Text;

            if (string.IsNullOrEmpty(txtNumero.Text) == false)
                condutor.Numero = int.Parse(txtNumero.Text);

            if (comboBoxEstado.SelectedIndex != -1)
                condutor.Estado = comboBoxEstado.SelectedItem.ToString();

            condutor.Rua = txtRua.Text;
            condutor.Bairro = txtBairro.Text;
            condutor.Cidade = txtCidade.Text;

            condutor.Cpf = txtCpf.Text;
            condutor.Cnh = txtCnh.Text;
            condutor.DataValidadeCnh = dateTimePickerDataValidadeCnh.Value;

            if (comboBoxClientes.SelectedIndex != -1)
                condutor.Cliente = (Cliente)comboBoxClientes.SelectedItem;
        }

        private void CarregarClientes()
        {
            if (clientes.Count > 0)
                foreach (var cliente in clientes)
                    comboBoxClientes.Items.Add(cliente);
        }

        private void PreencherClienteCondutor()
        {
            var cliente = ObterClienteSelecionado();

            //txtNome.Text = cliente.Nome;
            //txtEmail.Text = cliente.Email;
            //txtTelefone.Text = cliente.Telefone;
            //txtCpf.Text = cliente.Documento;
            //txtRua.Text = cliente.Rua;
            //txtBairro.Text = cliente.Bairro;
            //txtCidade.Text = cliente.Cidade;
            //comboBoxEstado.SelectedItem = cliente.Estado;
            //txtNumero.Text = cliente.Numero.ToString();
        }

        private Cliente ObterClienteSelecionado()
        {
            return (Cliente)comboBoxClientes.SelectedItem;
        }

        private void DesabilitarClienteCondutor()
        {
            checkBoxClienteCondutor.Checked = false;
            checkBoxClienteCondutor.Enabled = false;
        }

        private void HabilitarClienteCondutor()
        {
            checkBoxClienteCondutor.Checked = false;
            checkBoxClienteCondutor.Enabled = true;
        }

        private void LimparCamposDeIdentificacao()
        {
            txtNome.Clear();
            txtEmail.Clear();
            txtTelefone.Clear();
            txtCpf.Clear();
            txtRua.Clear();
            txtBairro.Clear();
            txtCidade.Clear();
            comboBoxEstado.SelectedIndex = -1;
            txtNumero.Clear();
        }

        private void DesabilitarCamposDeIdentificacao()
        {
            txtNome.Enabled = false;
            txtEmail.Enabled = false;
            txtTelefone.Enabled = false;
            txtCpf.Enabled = false;
            txtRua.Enabled = false;
            txtBairro.Enabled = false;
            txtCidade.Enabled = false;
            comboBoxEstado.Enabled = false;
            txtNumero.Enabled = false;
        }

        private void HabilitarCamposDeIdentificacao()
        {
            txtNome.Enabled = true;
            txtEmail.Enabled = true;
            txtTelefone.Enabled = true;
            txtCpf.Enabled = true;
            txtRua.Enabled = true;
            txtBairro.Enabled = true;
            txtCidade.Enabled = true;
            comboBoxEstado.Enabled = true;
            txtNumero.Enabled = true;
        }

        private void LimparTodosOsCampos()
        {
            comboBoxClientes.SelectedIndex = -1;
            checkBoxClienteCondutor.Checked = false;
            LimparCamposDeIdentificacao();

            txtCnh.Clear();
            dateTimePickerDataValidadeCnh.Value = DateTime.Today;
        }

        #endregion


    }
}