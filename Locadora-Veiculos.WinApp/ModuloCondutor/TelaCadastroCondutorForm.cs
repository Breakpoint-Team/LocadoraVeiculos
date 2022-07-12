using FluentValidation.Results;
using Locadora_Veiculos.Dominio.ModuloCliente;
using Locadora_Veiculos.Dominio.ModuloCondutor;
using Locadora_Veiculos.Dominio.ModuloEndereco;
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
                if (condutor.DadosPopulados)
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
                txtNumero.Text = Convert.ToString(condutor.Endereco.Numero);
                txtRua.Text = condutor.Endereco.Logradouro;
                txtBairro.Text = condutor.Endereco.Bairro;
                txtCidade.Text = condutor.Endereco.Cidade;
                comboBoxEstado.SelectedItem = condutor.Endereco.Estado;
            }

            txtCnh.Text = condutor.Cnh;
            dateTimePickerDataValidadeCnh.Value = condutor.DataValidadeCnh;
        }

        private void ObterDadosTela()
        {
            condutor.Nome = txtNome.Text;
            condutor.Email = txtEmail.Text;
            condutor.Telefone = txtTelefone.Text;

            condutor.Endereco = new Endereco();
            if (string.IsNullOrEmpty(txtNumero.Text) == false)
                condutor.Endereco.Numero = int.Parse(txtNumero.Text);

            if (comboBoxEstado.SelectedIndex != -1)
                condutor.Endereco.Estado = comboBoxEstado.SelectedItem.ToString();

            condutor.Endereco.Logradouro = txtRua.Text;
            condutor.Endereco.Bairro = txtBairro.Text;
            condutor.Endereco.Cidade = txtCidade.Text;

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

            txtNome.Text = cliente.Nome;
            txtEmail.Text = cliente.Email;
            txtTelefone.Text = cliente.Telefone;
            txtCpf.Text = cliente.Documento;
            txtRua.Text = cliente.Endereco.Logradouro;
            txtBairro.Text = cliente.Endereco.Bairro;
            txtCidade.Text = cliente.Endereco.Cidade;
            comboBoxEstado.SelectedItem = cliente.Endereco.Estado;
            txtNumero.Text = cliente.Endereco.Numero.ToString();
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