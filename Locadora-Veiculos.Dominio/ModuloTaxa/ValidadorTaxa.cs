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
                .Matches(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ ]*$").WithMessage("Caracteres especiais não são permitidos!"); 

            RuleFor(x => x.Valor)
                .NotEmpty().WithMessage("O campo 'Valor' é obrigatório!")
                .NotNull().WithMessage("O campo 'Valor' é obrigatório!");

        }
    }
}