using FluentValidation;

namespace Locadora_Veiculos.Dominio.ModuloEndereco
{
    public class ValidadorEndereco : AbstractValidator<Endereco>
    {
        public ValidadorEndereco()
        {
            RuleFor(x => x.Estado)
                    .NotNull().WithMessage("O campo 'Estado' é obrigatório!")
                    .NotEmpty().WithMessage("O campo 'Estado' é obrigatório!");

            When(x => string.IsNullOrEmpty(x.Estado) == false, () =>
                {
                    RuleFor(x => x.Estado.Length)
                    .Equal(2)
                    .WithMessage("O campo 'Estado' deve ter somente 2 (dois) caracteres!");

                    RuleFor(x => x.Estado)
               .Matches(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ ]*$")
               .WithMessage("O campo 'Estado' não aceita caracteres especiais e números");

                });

            RuleFor(x => x.Cidade)
                .NotNull().WithMessage("O campo 'Cidade' é obrigatório!")
                .NotEmpty().WithMessage("O campo 'Cidade' é obrigatório!");

            When(x => string.IsNullOrEmpty(x.Cidade) == false, () =>
                {
                    RuleFor(x => x.Cidade.Length)
                .GreaterThan(2)
                .WithMessage("O campo 'Cidade' deve ter no mínimo 3 (três) caracteres!");

                    RuleFor(x => x.Cidade)
               .Matches(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ ]*$")
               .WithMessage("O campo 'Cidade' não aceita caracteres especiais e números!");

                });

            RuleFor(x => x.Bairro)
               .NotNull().WithMessage("O campo 'Bairro' é obrigatório!")
               .NotEmpty().WithMessage("O campo 'Bairro' é obrigatório!");

            When(x => string.IsNullOrEmpty(x.Bairro) == false, () =>
                {
                    RuleFor(x => x.Bairro.Length)
                .GreaterThan(2)
                .WithMessage("O campo 'Bairro' deve ter no mínimo 3 (três) caracteres!");

                    RuleFor(x => x.Bairro)
                .Matches(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ ]*$")
                .WithMessage("O campo 'Bairro' não aceita caracteres especiais e números!");
                });

            RuleFor(x => x.Logradouro)
                .NotNull().WithMessage("O campo 'Logradouro' é obrigatório!")
                .NotEmpty().WithMessage("O campo 'Logradouro' é obrigatório!");

            When(x => string.IsNullOrEmpty(x.Logradouro) == false, () =>
                {
                    RuleFor(x => x.Logradouro.Length)
                    .GreaterThan(2)
                    .WithMessage("O campo 'Logradouro' deve ter no mínimo 3 (três) caracteres!");

                    RuleFor(x => x.Logradouro)
                    .Matches(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ0123456789 ]*$")
                    .WithMessage("O campo 'Logradouro' não aceita caracteres especiais!");

                });
        }
    }
}