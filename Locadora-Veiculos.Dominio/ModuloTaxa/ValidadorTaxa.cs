using FluentValidation;


namespace Locadora_Veiculos.Dominio.ModuloTaxa
{
    public class ValidadorTaxa : AbstractValidator<Taxa>
    {
        public ValidadorTaxa()
        {
            RuleFor(x => x.Descricao)
                .NotEmpty().WithMessage("O campo 'Descrição' é obrigatório!")
                .NotNull().WithMessage("O campo 'Descrição' é obrigatório!");

            RuleFor(x => x.Valor)
                .NotEmpty().WithMessage("O campo 'Valor' é obrigatório!")
                .NotNull().WithMessage("O campo 'Valor' é obrigatório!");

            //RuleFor(x => x.TipoCalculo)
            //     .NotEmpty().WithMessage("O campo 'Tipo de Cálculo' é obrigatório!")
            //    .NotNull().WithMessage("O campo 'Tipo de Cálculo' é obrigatório!");
        }
    }
}
