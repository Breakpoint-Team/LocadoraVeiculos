using FluentValidation;

namespace Locadora_Veiculos.Dominio.ModuloPlanoCobranca
{
    public class ValidadorPlanoCobranca : AbstractValidator<PlanoCobranca>
    {
        public ValidadorPlanoCobranca()
        {
            RuleFor(x => x.GrupoVeiculos)
                .NotNull().WithMessage("O campo 'Grupo de Veículos' é obrigatório!");

            RuleFor(x => x.DiarioValorDia)
                .GreaterThan(0).WithMessage("O campo 'Valor diário' do plano diário deve ser maior que 0 (zero)!");

            RuleFor(x => x.DiarioValorKm)
                .GreaterThan(0).WithMessage("O campo 'Valor por KM' do plano diário deve ser maior que 0 (zero)!");

            RuleFor(x => x.KmControladoValorDia)
                .GreaterThan(0).WithMessage("O campo 'Valor diário' do plano KM Controlado deve ser maior que 0 (zero)!");

            RuleFor(x => x.KmControladoValorKm)
                .GreaterThan(0).WithMessage("O campo 'Valor por KM' do plano KM Controlado deve ser maior que 0 (zero)!");

            RuleFor(x => x.KmControladoLimiteKm)
                .GreaterThan(0).WithMessage("O campo 'Limite de KM' do plano KM Controlado deve ser maior que 0 (zero)!");

            RuleFor(x => x.KmLivreValorDia)
                .GreaterThan(0).WithMessage("O campo 'Valor diário' do plano KM Livre deve ser maior que 0 (zero)!");
        }
    }
}