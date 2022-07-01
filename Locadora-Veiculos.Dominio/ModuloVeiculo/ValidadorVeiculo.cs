using FluentValidation;


namespace Locadora_Veiculos.Dominio.ModuloVeiculo
{
    public class ValidadorVeiculo : AbstractValidator<Veiculo>
    {
        public ValidadorVeiculo()
        {
            RuleFor(x => x.Modelo)
                .NotEmpty().WithMessage("O campo 'Modelo' é obrigatório!")
                .NotNull().WithMessage("O campo 'Modelo' é obrigatório!")
                .Matches(@"^[A-Za-z0-9-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ ]*$").WithMessage("Caracteres especiais não são permitidos!")
                .MinimumLength(3).WithMessage("O campo 'Modelo' deve ter no mínimo 3 (três) caracteres!");

            RuleFor(x => x.Marca)
                .NotEmpty().WithMessage("O campo 'Marca' é obrigatório!")
                .NotNull().WithMessage("O campo 'Marca' é obrigatório!")
                .Matches(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ ]*$").WithMessage("Caracteres especiais não são permitidos!")
                .MinimumLength(3).WithMessage("O campo 'Marca' deve ter no mínimo 3 (três) caracteres!");

            RuleFor(x => x.Ano)
                .NotEmpty().WithMessage("O campo 'Ano' é obrigatório!")
                .NotNull().WithMessage("O campo 'Ano' é obrigatório!")
                .GreaterThan(1919).WithMessage("O 'Ano' deve ser maior que 1919!");

            RuleFor(x => x.Cor)
                .NotEmpty().WithMessage("O campo 'Cor' é obrigatório!")
                .NotNull().WithMessage("O campo 'Cor' é obrigatório!")
                .Matches(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ ]*$").WithMessage("Caracteres especiais não são permitidos!")
                .MinimumLength(3).WithMessage("O campo 'Cor' deve ter no mínimo 3 (três) caracteres!");

            RuleFor(x => x.Placa)
                .NotEmpty().WithMessage("O campo 'Placa' é obrigatório!")
                .NotNull().WithMessage("O campo 'Placa' é obrigatório!")
                .Matches(@"^[A-Za-z0-9-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ ]*$").WithMessage("Caracteres especiais não são permitidos!")
                .MinimumLength(7).WithMessage("O campo 'Placa' deve ter 7 (sete) caracteres!")
                .MaximumLength(7).WithMessage("O campo 'Placa' deve ter 7 (sete) caracteres!");

            RuleFor(x => x.QuilometragemPercorrida)
                .NotEmpty().WithMessage("O campo 'Quilometragem Percorrida' é obrigatório!")
                .NotNull().WithMessage("O campo 'Quilometragem Percorrida' é obrigatório!");

            RuleFor(x => x.CapacidadeTanque)
                .NotEmpty().WithMessage("O campo 'Capacidade do Tanque' é obrigatório!")
                .NotNull().WithMessage("O campo 'Capacidade do Tanque' é obrigatório!")
                .GreaterThan(9).WithMessage("A 'Capacidade do Tanque' deve ser no mínimo 10!");

            RuleFor(x => x.GrupoVeiculos)
                .NotEmpty().WithMessage("O campo 'Grupo de Veículos' é obrigatório!")
                .NotNull().WithMessage("O campo 'Grupo de Veículos' é obrigatório!");


        }
    }
}
