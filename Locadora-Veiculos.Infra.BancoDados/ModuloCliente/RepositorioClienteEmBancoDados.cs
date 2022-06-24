using FluentValidation.Results;
using Locadora_Veiculos.Dominio.ModuloCliente;
using Locadora_Veiculos.Infra.BancoDados.Compartilhado;
using System.Linq;

namespace Locadora_Veiculos.Infra.BancoDados.ModuloCliente
{
    public class RepositorioClienteEmBancoDados : RepositorioBase<Cliente,
        ValidadorCliente, MapeadorCliente>, IRepositorioCliente
    {
        protected override string sqlInserir =>
            @"INSERT INTO [TBCLIENTE]
                 (
		            [NOME],
                    [DOCUMENTO],
                    [EMAIL],
                    [TELEFONE],
                    [TIPO_CLIENTE],
                    [CNH],
                    [ESTADO],
                    [CIDADE],
                    [BAIRRO],
                    [RUA],
                    [NUMERO]
		         )
            VALUES
                (
		            @NOME, 
                    @DOCUMENTO, 
                    @EMAIL,
                    @TELEFONE,
                    @TIPO_CLIENTE,
                    @CNH,
                    @ESTADO,
                    @CIDADE,
                    @BAIRRO,
                    @RUA,
                    @NUMERO
			);SELECT SCOPE_IDENTITY();";

        protected override string sqlEditar =>
            @"UPDATE [TBCLIENTE]
                SET
		            [NOME] = @NOME,
                    [DOCUMENTO] = @DOCUMENTO,
                    [EMAIL] = @EMAIL,
                    [TELEFONE] = @TELEFONE,
                    [TIPO_CLIENTE] = @TIPO_CLIENTE,
                    [CNH] = @CNH,
                    [ESTADO] = @ESTADO,
                    [CIDADE] = @CIDADE,
                    [BAIRRO] = @BAIRRO,
                    [RUA] = @RUA,
                    [NUMERO] = @NUMERO
                WHERE
                    [ID] = @ID";

        protected override string sqlExcluir =>
            @"DELETE FROM [TBCLIENTE]
                WHERE [ID] = @ID";

        protected override string sqlSelecionarPorId =>
            @"SELECT 
	            [ID],
                [NOME],
                [DOCUMENTO],
                [EMAIL],
                [TELEFONE],
                [TIPO_CLIENTE],
                [CNH],
                [ESTADO],
                [CIDADE],
                [BAIRRO],
                [RUA],
                [NUMERO]
            FROM
                [TBCLIENTE]
            WHERE
                [ID] = @ID";

        protected override string sqlSelecionarTodos =>
            @"SELECT 
	            [ID],
                [NOME],
                [DOCUMENTO],
                [EMAIL],
                [TELEFONE],
                [TIPO_CLIENTE],
                [CNH],
                [ESTADO],
                [CIDADE],
                [BAIRRO],
                [RUA],
                [NUMERO]
            FROM
                [TBCLIENTE]";

        public override ValidationResult Validar(Cliente registro)
        {
            var validator = new ValidadorCliente();

            var resultadoValidacao = validator.Validate(registro);

            if (resultadoValidacao.IsValid == false)
                return resultadoValidacao;

            bool documentoEncontrado;
        
            string tipoDocumento;
            
            VerificarDuplicidadeDeDocumento(registro,
                out documentoEncontrado, out tipoDocumento);

            if (documentoEncontrado)
            {
                if (registro.Id == 0)
                    resultadoValidacao.Errors.Add(new ValidationFailure("", $"{tipoDocumento} já está cadastrado"));
            }

            return resultadoValidacao;
        }

        private void VerificarDuplicidadeDeDocumento(Cliente registro, out bool documentoEncontrado, out string tipoDocumento)
        {
            documentoEncontrado = false;
            tipoDocumento = "";
            if (registro.TipoCliente == TipoCliente.PessoaFisica)
            {
                documentoEncontrado = SelecionarTodos()
                   .Select(x => x.Cpf)
                   .Contains(registro.Cpf);
                tipoDocumento = "CPF";
            }

            else if (registro.TipoCliente == TipoCliente.PessoaJuridica)
            {
                documentoEncontrado = SelecionarTodos()
                   .Select(x => x.Cnpj)
                   .Contains(registro.Cnpj);
                tipoDocumento = "CNPJ";
            }
        }
    }
}