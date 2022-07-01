using FluentValidation.Results;
using Locadora_Veiculos.Dominio.ModuloCondutor;
using System;
using System.Windows.Forms;

namespace Locadora_Veiculos.WinApp.ModuloCondutor
{
    public partial class TelaCadastroCondutorForm : Form
    {
        private Condutor condutor;

        public TelaCadastroCondutorForm()
        {
            InitializeComponent();
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

        #region MÉTODOS PRIVADOS

        private void PreencherDadosNaTela()
        {
            throw new NotImplementedException();
        }
        
        #endregion
    }
}