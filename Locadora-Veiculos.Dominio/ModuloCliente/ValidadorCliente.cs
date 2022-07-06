using FluentValidation;
using Locadora_Veiculos.Dominio.ModuloEndereco;
using System.Text.RegularExpressions;

namespace Locadora_Veiculos.Dominio.ModuloCliente
{
    public class ValidadorCliente : AbstractValidator<Cliente>
    {
        public ValidadorCliente()
        {
            RuleFor(x => x.Nome)
                .NotNull().WithMessage("O campo 'Nome' é obrigatório!")
                .NotEmpty().WithMessage("O campo 'Nome' é obrigatório!");

            When(x => string.IsNullOrEmpty(x.Nome) == false, () =>
            {
                RuleFor(x => x.Nome.Length)
                .GreaterThan(2)
                .WithMessage("O campo 'Nome' deve ter no mínimo 3 (três) caracteres!");

                RuleFor(x => x.Nome)
                .Matches(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ ]*$")
                .WithMessage("O campo 'Nome' não aceita caracteres especiais!");
            });

            RuleFor(x => x.Email)
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

            RuleFor(x => x.Telefone)
                .NotNull().WithMessage("O campo 'Telefone' é obrigatório!")
                .NotEmpty().WithMessage("O campo 'Telefone' é obrigatório!");

            RuleFor(x => x.Telefone)
              .Custom((telefone, context) =>
              {
                  if (string.IsNullOrEmpty(telefone) == false)
                  {
                      if ((Regex.IsMatch(telefone, @"^\([0-9]{2}\) [0-9]{5}\-[0-9]{4}$")) == false)
                          context.AddFailure("O campo 'Telefone' deve ser válido!");
                  }
              });

            When(x => x.TipoCliente == TipoCliente.PessoaFisica, () =>
            {
                RuleFor(x => x.Documento)
                .NotNull().WithMessage("O campo 'CPF' é obrigatório!")
                .NotEmpty().WithMessage("O campo 'CPF' é obrigatório!");

                RuleFor(x => x.Documento)
                .Custom((documehto, context) =>
                {
                    if (string.IsNullOrEmpty(documehto) == false)
                    {
                        if (Regex.IsMatch(documehto, @"^[0-9]{3}[\.][0-9]{3}[\.][0-9]{3}[\-][0-9]{2}", RegexOptions.IgnoreCase) == false)
                            context.AddFailure("O campo 'CPF' deve ser válido!");
                    }
                });
            });

            When(x => x.TipoCliente == TipoCliente.PessoaJuridica, () =>
            {
                RuleFor(x => x.Documento)
                .NotNull().WithMessage("O campo 'CNPJ' é obrigatório!")
                .NotEmpty().WithMessage("O campo 'CNPJ' é obrigatório!");

                RuleFor(x => x.Documento)
                .Custom((documento, context) =>
                {
                    if (string.IsNullOrEmpty(documento) == false)
                    {
                        if (Regex.IsMatch(documento, @"^[0-9]{2}[\.][0-9]{3}[\.][0-9]{3}[\/][0-9]{4}[-][0-9]{2}", RegexOptions.IgnoreCase) == false)
                            context.AddFailure("O campo 'CNPJ' deve ser válido!");
                    }
                });
            });

            RuleFor(x => x.Endereco)
                 .Custom((endereco, context) =>
                 {
                     if (endereco != null)
                     {
                         var resultadoValidacaoEndereco = new ValidadorEndereco().Validate(endereco);

                         if (resultadoValidacaoEndereco.IsValid == false)
                             foreach (var item in resultadoValidacaoEndereco.Errors)
                                 context.AddFailure(item.ErrorMessage);
                     }
                 });
        }
    }
}