using FluentValidation;

namespace Locadora_Veiculos.Dominio.ModuloTaxa
{
    public class ValidadorTaxa : AbstractValidator<Taxa>
    {
        public ValidadorTaxa()
        {
            RuleFor(x => x.Descricao)
                .NotEmpty().WithMessage("O campo 'Descrição' é obrigatório!")
                .NotNull().WithMessage("O campo 'Descrição' é obrigatório!")
                .Matches(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ ]*$").WithMessage("O campo 'Descrição' não aceita caracteres especiais e números!")
                .MinimumLength(2).WithMessage("O campo 'Descrição' deve ter no mínimo 2 caracteres!");

            RuleFor(x => x.Valor)
                .NotEmpty().WithMessage("O campo 'Valor' é obrigatório!")
                .NotNull().WithMessage("O campo 'Valor' é obrigatório!");

        }
    }
}