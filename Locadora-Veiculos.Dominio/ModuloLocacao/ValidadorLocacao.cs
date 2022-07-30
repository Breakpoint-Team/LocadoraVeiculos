using FluentValidation;
using Locadora_Veiculos.Dominio.ModuloVeiculo;

namespace Locadora_Veiculos.Dominio.ModuloLocacao
{
    public class ValidadorLocacao : AbstractValidator<Locacao>
    {
        public ValidadorLocacao()
        {
            RuleFor(x => x.Condutor)
                .NotNull()
                .WithMessage("O campo 'Condutor' é obrigatório!");

            When(x => x.Condutor != null, () =>
            {
                RuleFor(x => x.Condutor.DataValidadeCnh.Date)
                    .GreaterThanOrEqualTo(x => x.DataDevolucaoPrevista.Date)
                    .WithMessage("A data de validade da CNH do condutor selecionado não deve ser menor que a data de devolução prevista!");
            });

            RuleFor(x => x.GrupoVeiculos)
                .NotNull()
                .WithMessage("O campo 'Grupo de Veículos' é obrigatório!");
            RuleFor(x => x.Veiculo)
                .NotNull()
                .WithMessage("O campo 'Veículo' é obrigatório!");

            When(x => x.Veiculo != null, () =>
            {
                RuleFor(x => x.Veiculo.StatusVeiculo)
                .Equal(StatusVeiculo.Disponivel)
                .WithMessage("O veículo selecionado já está locado!");
            });

            RuleFor(x => x.PlanoCobranca)
                .NotNull()
                .WithMessage("O campo 'Plano de Cobrança' é obrigatório!");

            RuleFor(x => x.DataLocacao)
                .NotNull()
                .WithMessage("O campo 'Data de Locação' é obrigatório!")
                .NotEmpty()
                .WithMessage("O campo 'Data de Locação' é obrigatório!");

            RuleFor(x => x.DataDevolucaoPrevista)
                .NotNull().WithMessage("O campo 'Data de Devolução Prevista' é obrigatório!")
                .NotEmpty().WithMessage("O campo 'Data de Devolução Prevista' é obrigatório!")
                .GreaterThanOrEqualTo(x => x.DataLocacao)
                .WithMessage("O campo 'Data de Devolução Prevista' deve ser maior ou igual a data da locação!");

            RuleFor(x => x.ValorTotalPrevisto)
               .GreaterThan(0)
               .WithMessage("O campo 'Valor Total Previsto' deve ser maior que 0 (zero)!");


            When(x => x.StatusLocacao == StatusLocacao.Fechada, () =>
            {
                RuleFor(x => x.QuilometragemFinalVeiculo)
                .GreaterThanOrEqualTo(x => x.QuilometragemInicialVeiculo)
                .WithMessage("O campo 'Quilometragem Final' deve ser maior ou igual à quilometragem inicial!");

                RuleFor(x => x.DataDevolucaoEfetiva)
                .NotNull().WithMessage("O campo 'Data de Devolução Efetiva' é obrigatório!")
                .NotEmpty().WithMessage("O campo 'Data de Devolução Efetiva' é obrigatório!")
                .GreaterThanOrEqualTo(x => x.DataLocacao)
                .WithMessage("O campo 'Data de Devolução Efetiva' deve ser maior ou igual a data da locação!");

                RuleFor(x => x.NivelTanqueDevolucao)
                .NotNull()
                .WithMessage("O campo 'Nível do Tanque' é obrigatório!");

                RuleFor(x => x.ValorTotalEfetivo)
                .NotNull().WithMessage("O campo 'Valor Total Efetivo' é obrigatório!")
                .GreaterThan(0).WithMessage("O campo 'Valor Total Efetivo' deve ser maior que 0 (zero)!");
            });
        }

    }
}
