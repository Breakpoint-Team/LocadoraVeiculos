using FluentValidation;
using System.Text.RegularExpressions;

namespace Locadora_Veiculos.Dominio.ModuloGrupoVeiculos
{
    public class ValidadorGrupoVeiculos : AbstractValidator<GrupoVeiculos>
    {

        public ValidadorGrupoVeiculos()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O campo 'Nome' é obrigatório!")
                .NotNull().WithMessage("O campo 'Nome' é obrigatório!")
                .Matches(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ ]*$").WithMessage("Caracteres especiais não são permitidos!");
        }
    }
}
