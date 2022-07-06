using FluentValidation;

namespace Locadora_Veiculos.Dominio.ModuloPlanoCobranca
{
    internal class ValidadorPlanoCobranca : AbstractValidator<PlanoCobranca>
    {
        public ValidadorPlanoCobranca()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O campo 'Nome' é obrigatório!")
                .NotNull().WithMessage("O campo 'Nome' é obrigatório!")
                .Matches(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ ]*$").WithMessage("O campo 'Nome' não aceita caracteres especiais e números!")
                .MinimumLength(2).WithMessage("O campo 'Nome' deve ter no mínimo 2 caracteres!");
        }
    }
}
