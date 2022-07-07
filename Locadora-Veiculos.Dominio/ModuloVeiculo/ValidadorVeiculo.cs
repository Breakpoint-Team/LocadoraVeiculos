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
                .Matches(@"^[A-Za-z0-9-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ ]*$").WithMessage("O campo 'Modelo' não aceita caracteres especiais!")
                .MinimumLength(2).WithMessage("O campo 'Modelo' deve ter no mínimo 2 (dois) caracteres!");

            RuleFor(x => x.Marca)
                .NotEmpty().WithMessage("O campo 'Marca' é obrigatório!")
                .NotNull().WithMessage("O campo 'Marca' é obrigatório!")
                .Matches(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ ]*$").WithMessage("O campo 'Marca' não aceita caracteres especiais e números!")
                .MinimumLength(2).WithMessage("O campo 'Marca' deve ter no mínimo 2 (dois) caracteres!");

            RuleFor(x => x.Ano)
                .NotEmpty().WithMessage("O campo 'Ano' é obrigatório!")
                .NotNull().WithMessage("O campo 'Ano' é obrigatório!")
                .GreaterThan(1919).WithMessage("O 'Ano' deve ser maior que 1919!");

            RuleFor(x => x.Cor)
                .NotEmpty().WithMessage("O campo 'Cor' é obrigatório!")
                .NotNull().WithMessage("O campo 'Cor' é obrigatório!")
                .Matches(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ ]*$").WithMessage("O campo 'Cor' não aceita caracteres especiais e números!")
                .MinimumLength(3).WithMessage("O campo 'Cor' deve ter no mínimo 3 (três) caracteres!");

            RuleFor(x => x.Placa)
                .NotEmpty().WithMessage("O campo 'Placa' é obrigatório!")
                .NotNull().WithMessage("O campo 'Placa' é obrigatório!")
                .Matches(@"^[A-Za-z0-9-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ ]*$").WithMessage("O campo 'Placa' não aceita caracteres especiais!")
                .MinimumLength(7).WithMessage("O campo 'Placa' deve ter 7 (sete) caracteres!")
                .MaximumLength(7).WithMessage("O campo 'Placa' deve ter 7 (sete) caracteres!")
                .Matches(@"[A-Z]{3}[0-9][0-9A-Z][0-9]{2}").WithMessage("Placa inválida!");



            RuleFor(x => x.QuilometragemPercorrida)
            .GreaterThan(-1).WithMessage("O campo 'Quilometragem Percorrida' é obrigatório!");

            RuleFor(x => x.TipoCombustivel)
                .NotEmpty().WithMessage("O campo 'Tipo de combustível' é obrigatório!")
                .NotNull().WithMessage("O campo 'Tipo de combustível' é obrigatório!");


            RuleFor(x => x.CapacidadeTanque)
                .NotEmpty().WithMessage("O campo 'Capacidade do Tanque' é obrigatório!")
                .NotNull().WithMessage("O campo 'Capacidade do Tanque' é obrigatório!")
                .GreaterThan(9).WithMessage("A 'Capacidade do Tanque' deve ser no mínimo 10!");

            RuleFor(x => x.GrupoVeiculos)
                .NotEmpty().WithMessage("O campo 'Grupo de Veículos' é obrigatório!")
                .NotNull().WithMessage("O campo 'Grupo de Veículos' é obrigatório!");

            RuleFor(x => x.Imagem)
            .NotEmpty().WithMessage("Por favor, selecione uma 'Imagem' do veículo!")
            .NotNull().WithMessage("Por favor, selecione uma 'Imagem' do veículo!");

        }
    }
}
