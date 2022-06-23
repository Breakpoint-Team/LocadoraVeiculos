using FluentValidation;
using System.Text.RegularExpressions;

namespace Locadora_Veiculos.Dominio.ModuloCliente
{
    public class ValidadorCliente : AbstractValidator<Cliente>
    {
        public ValidadorCliente()
        {
            RuleFor(cliente => cliente.Nome)
                .NotNull().WithMessage("O campo 'Nome' é obrigatório!")
                .NotEmpty().WithMessage("O campo 'Nome' é obrigatório!");

            When(cliente => string.IsNullOrEmpty(cliente.Nome) == false, () =>
            {
                RuleFor(cliente => cliente.Nome.Length)
                .GreaterThan(2)
                .WithMessage("O campo 'Nome' deve ter no mínimo 3 caracteres!");
            });

            RuleFor(cliente => cliente.Rua)
                .NotNull().WithMessage("O campo 'Rua' é obrigatório!")
                .NotEmpty().WithMessage("O campo 'Rua' é obrigatório!");

            When(cliente => string.IsNullOrEmpty(cliente.Rua) == false, () =>
            {
                RuleFor(cliente => cliente.Rua.Length)
                .GreaterThan(4)
                .WithMessage("O campo 'Rua' deve ter no mínimo 5 caracteres!");
            });

            RuleFor(cliente => cliente.Bairro)
               .NotNull().WithMessage("O campo 'Bairro' é obrigatório!")
               .NotEmpty().WithMessage("O campo 'Bairro' é obrigatório!");

            When(cliente => string.IsNullOrEmpty(cliente.Bairro) == false, () =>
            {
                RuleFor(cliente => cliente.Bairro.Length)
                .GreaterThan(4)
                .WithMessage("O campo 'Bairro' deve ter no mínimo 5 caracteres!");
            });

            RuleFor(cliente => cliente.Cidade)
                .NotNull().WithMessage("O campo 'Cidade' é obrigatório!")
                .NotEmpty().WithMessage("O campo 'Cidade' é obrigatório!");

            When(cliente => string.IsNullOrEmpty(cliente.Cidade) == false, () =>
            {
                RuleFor(cliente => cliente.Cidade.Length)
                .GreaterThan(4)
                .WithMessage("O campo 'Cidade' deve ter no mínimo 5 caracteres!");
            });

            RuleFor(cliente => cliente.Estado)
                .NotNull().WithMessage("O campo 'Estado' é obrigatório!")
                .NotEmpty().WithMessage("O campo 'Estado' é obrigatório!");

            When(cliente => string.IsNullOrEmpty(cliente.Estado) == false, () =>
            {
                RuleFor(cliente => cliente.Estado.Length)
                    .Equal(2)
                    .WithMessage("O campo 'Estado' deve ter somente 2 caracteres!");
            });


            When(cliente => cliente.TipoCliente == TipoCliente.PessoaJuridica, () =>
            {
                RuleFor(cliente => cliente.Cnpj)
                .NotNull().WithMessage("O campo 'CNPJ' é obrigatório!")
                .NotEmpty().WithMessage("O campo 'CNPJ' é obrigatório!");

                RuleFor(cliente => cliente.Cnpj)
                .Custom((cnpj, context) =>
                {
                    if (string.IsNullOrEmpty(cnpj) == false)
                    {
                        if (Regex.IsMatch(cnpj, @"^[0-9]{2}[\.][0-9]{3}[\.][0-9]{3}[\/][0-9]{4}[-][0-9]{2}", RegexOptions.IgnoreCase) == false)
                            context.AddFailure("O campo 'CNPJ' deve ser válido!");
                    }
                });
            });

            When(cliente => cliente.TipoCliente == TipoCliente.PessoaFisica, () =>
            {
                RuleFor(cliente => cliente.Cpf)
                .NotNull().WithMessage("O campo 'CPF' é obrigatório!")
                .NotEmpty().WithMessage("O campo 'CPF' é obrigatório!");

                RuleFor(cliente => cliente.Cpf)
                .Custom((cpf, context) =>
                {
                    if (string.IsNullOrEmpty(cpf) == false)
                    {
                        if (Regex.IsMatch(cpf, @"^[0-9]{3}[\.][0-9]{3}[\.][0-9]{3}[\-][0-9]{2}", RegexOptions.IgnoreCase) == false)
                            context.AddFailure("O campo 'CPF' deve ser válido!");
                    }
                });
            });

            RuleFor(cliente => cliente.Telefone)
                .NotNull().WithMessage("O campo 'Telefone' é obrigatório!")
                .NotEmpty().WithMessage("O campo 'Telefone' é obrigatório!");

            RuleFor(x => x.Telefone)
              .Custom((telefone, context) =>
              {
                  if (string.IsNullOrEmpty(telefone) == false)
                  {
                      if ((Regex.IsMatch(telefone, @"^\([1-9]{2}\) (?:[2-8]|9 [1-9])[0-9]{3}\-?[0-9]{4}$")) == false)
                          context.AddFailure("O campo 'Telefone' deve ser válido!");
                  }
              });

            RuleFor(cliente => cliente.Email)
                .NotNull().WithMessage("O campo 'Email' é obrigatório!")
                .NotEmpty().WithMessage("O campo 'Email' é obrigatório!");

            RuleFor(x => x.Email)
              .Custom((email, context) =>
              {
                  if (string.IsNullOrEmpty(email) == false)
                  {
                      if (System.Net.Mail.MailAddress.TryCreate(email, out _) == false)
                          context.AddFailure("O campo 'Email' deve ser válido!");
                  }
              });

            RuleFor(cliente => cliente.Cnh)
              .NotNull().WithMessage("O campo 'CNH' é obrigatório!")
              .NotEmpty().WithMessage("O campo 'CNH' é obrigatório!");

            RuleFor(x => x.Cnh)
              .Custom((cnh, context) =>
              {
                  if (string.IsNullOrEmpty(cnh) == false)
                  {
                      if ((Regex.IsMatch(cnh, @"^[0-9]{9}")) == false)
                          context.AddFailure("O campo 'CNH' deve ser válido!");
                  }
              });
        }
    }
}
