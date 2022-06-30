using FluentValidation;

namespace Locadora_Veiculos.Dominio.ModuloFuncionario
{
    public class ValidadorFuncionario : AbstractValidator<Funcionario>
    {
        public ValidadorFuncionario()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O campo 'Nome' é obrigatório!")
                .NotNull().WithMessage("O campo 'Nome' é obrigatório!")
                .Matches(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ ]*$").WithMessage("Caracteres especiais não são permitidos!")
                .MinimumLength(2).WithMessage("O campo 'Nome' deve ter no mínimo 2 caracteres!");

            RuleFor(x => x.Login)
                .NotEmpty().WithMessage("O campo 'Login' é obrigatório!")
                .NotNull().WithMessage("O campo 'Login' é obrigatório!")
                .MinimumLength(4).WithMessage("O campo 'Login' deve ter no mínimo 4 caracteres!");

            RuleFor(x => x.Senha)
              .NotEmpty().WithMessage("O campo 'Senha' é obrigatório!")
              .NotNull().WithMessage("O campo 'Senha' é obrigatório!")
              .MinimumLength(8).WithMessage("'Senha' deve ter no mínimo 8 (oito) caracteres!");

            RuleFor(x => x.DataAdmissao)
              .NotEmpty().WithMessage("O campo 'Data de Admissão' é obrigatório!")
              .NotNull().WithMessage("O campo 'Data de Admissão' é obrigatório!");

            RuleFor(x => x.Salario)
              .NotEmpty().WithMessage("O campo 'Salário' é obrigatório!")
              .NotNull().WithMessage("O campo 'Salário' é obrigatório!");

            RuleFor(x => x.Salario)
                .GreaterThan(0)
                .WithMessage("O campo 'Salário' deve ser maior que 0 (zero)!");
        }
    }
}