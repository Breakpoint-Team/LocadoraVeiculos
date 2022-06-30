using FluentValidation.Results;
using Locadora_Veiculos.Dominio.ModuloFuncionario;
using System;

namespace LocadoraVeiculos.Aplicacao.ModuloFuncionario
{
    public class ServicoFuncionario
    {
        private IRepositorioFuncionario repositorioFuncionario;

        public ServicoFuncionario(IRepositorioFuncionario repositorioFuncionario)
        {
            this.repositorioFuncionario = repositorioFuncionario;
        }

        public ValidationResult Inserir(Funcionario funcionario)
        {
            ValidationResult resultadoValidacao = Validar(funcionario);

            if (resultadoValidacao.IsValid)
                repositorioFuncionario.Inserir(funcionario);

            return resultadoValidacao;
        }

        public ValidationResult Editar(Funcionario funcionario)
        {
            ValidationResult resultadoValidacao = Validar(funcionario);

            if (resultadoValidacao.IsValid)
                repositorioFuncionario.Editar(funcionario);

            return resultadoValidacao;
        }

        #region MÉTODOS PRIVADOS

        private ValidationResult Validar(Funcionario funcionario)
        {
            var validador = new ValidadorFuncionario();

            var resultadoValidacao = validador.Validate(funcionario);

            if (LoginDuplicado(funcionario))
                resultadoValidacao.Errors.Add(new ValidationFailure("Login", "Login já está cadastrado!"));

            return resultadoValidacao;
        }

        private bool LoginDuplicado(Funcionario funcionario)
        {
            var funcionarioEncontrado = repositorioFuncionario.SelecionarFuncionarioPorLogin(funcionario.Login);

            return funcionarioEncontrado != null &&
                   funcionarioEncontrado.Login.Equals(funcionario.Login, StringComparison.OrdinalIgnoreCase) &&
                   funcionarioEncontrado.Id != funcionario.Id;
        }
        
        #endregion
    }
}