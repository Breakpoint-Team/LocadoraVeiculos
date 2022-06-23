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
            get
            {
                return cliente;
            }
            set
            {
                cliente = value;
                //txtNumero.Text = disciplina.Numero.ToString();
                //txtNomeDisciplina.Text = disciplina.Nome;
            }
        }

        public Func<Cliente, ValidationResult> GravarRegistro { get; set; }

    }
}
