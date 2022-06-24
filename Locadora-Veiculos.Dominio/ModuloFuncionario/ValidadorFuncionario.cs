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
                .Matches(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ ]*$").WithMessage("Caracteres especiais não são permitidos!");

            RuleFor(x => x.Login)
                .NotEmpty().WithMessage("O campo 'Login' é obrigatório!")
                .NotNull().WithMessage("O campo 'Login' é obrigatório!");

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

            //RuleFor(x => x.EhAdmin)
            //  .NotEmpty().WithMessage("O campo 'É Admin?' é obrigatório!");
        }
    }
}
