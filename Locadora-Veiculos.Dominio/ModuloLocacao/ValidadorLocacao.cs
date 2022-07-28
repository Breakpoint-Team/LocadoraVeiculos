using FluentValidation;

namespace Locadora_Veiculos.Dominio.ModuloLocacao
{
    public class ValidadorLocacao : AbstractValidator<Locacao>
    {
        public ValidadorLocacao()
        {
            RuleFor(x => x.Cliente)
                .NotNull()
                .WithMessage("O campo 'Cliente' é obrigatório!");

            RuleFor(x => x.CondutoresAtivos.Count)
                .GreaterThan(0)
                .WithMessage("O cliente selecionado deve ter pelo menos um Condutor Ativo!");

            RuleFor(x => x.GrupoVeiculos)
                .NotNull()
                .WithMessage("O campo 'Grupo de Veículos' é obrigatório!");

            RuleFor(x => x.Veiculo)
                .NotNull()
                .WithMessage("O campo 'Veiculo' é obrigatório!");

            RuleFor(x => x.PlanoCobranca)
                .NotNull()
                .WithMessage("O campo 'Plano de Cobrança' é obrigatório!");

            RuleFor(x => x.PlanoCobranca)
                .NotNull()
                .WithMessage("O campo 'Plano de Cobrança' é obrigatório!");

            RuleFor(x => x.DataLocacao)
                .NotNull()
                .WithMessage("O campo 'Data de Locação' é obrigatório!");

            RuleFor(x => x.DataDevolucaoPrevista)
                .NotNull()
                .WithMessage("O campo 'Data de Devolução Prevista' é obrigatório!")
                .GreaterThanOrEqualTo(x => x.DataLocacao)
                .WithMessage("O campo 'Data de Devolução Prevista' deve ser maior ou igual a data da locação!");

            RuleFor(x => x.ValorTotalPrevisto)
               .GreaterThan(0)
               .WithMessage("O campo 'Valor Total Previsto' deve ser maior que 0 (zero)!");

            RuleFor(x => x.QuilometragemInicialVeiculo)
               .Equal(x => x.Veiculo.QuilometragemPercorrida)
               .WithMessage("O campo 'Quilometragem Inicial' deve ser igual à quilometragem percorrida do veículo!");

            When(x => x.StatusLocacao == StatusLocacao.Fechada, () =>
            {
                RuleFor(x => x.QuilometragemFinalVeiculo)
                .GreaterThanOrEqualTo(x => x.QuilometragemInicialVeiculo)
                .WithMessage("O campo 'Quilometragem Final' deve ser maior ou igual à quilometragem inicial!");

                RuleFor(x => x.DataDevolucaoEfetiva)
                .NotNull()
                .WithMessage("O campo 'Data de Devolução Efetiva' é obrigatório!")
                .GreaterThanOrEqualTo(x => x.DataLocacao)
                .WithMessage("O campo 'Data de Devolução Efetiva' deve ser maior ou igual a data da locação!");

                RuleFor(x => x.NivelTanqueDevolucao)
                .NotNull()
                .WithMessage("O campo 'Nível do Tanque' é obrigatório!");

                RuleFor(x => x.ValorTotalEfetivo)
                .GreaterThanOrEqualTo(x => x.ValorTotalPrevisto)
                .WithMessage("O campo 'Valor Total Efetivo' deve ser maior ou igual ao valor total previsto!");
            });
        }
    }
}
