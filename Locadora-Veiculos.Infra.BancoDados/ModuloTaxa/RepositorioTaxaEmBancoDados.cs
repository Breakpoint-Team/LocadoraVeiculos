using FluentValidation.Results;
using Locadora_Veiculos.Dominio.ModuloTaxa;
using Locadora_Veiculos.Infra.BancoDados.Compartilhado;
using System.Linq;

namespace Locadora_Veiculos.Infra.BancoDados.ModuloTaxa
{
    public class RepositorioTaxaEmBancoDados : RepositorioBase<Taxa, ValidadorTaxa, MapeadorTaxa>, IRepositorioTaxa
    {
        protected override string sqlInserir =>
            @"INSERT INTO [TBTAXA]
                (
                    [DESCRICAO],
                    [VALOR],
                    [TIPOCALCULO]
                )
            VALUES
                (
                    @DESCRICAO,
                    @VALOR,
                    @TIPOCALCULO
                ); SELECT SCOPE_IDENTITY();";

        protected override string sqlEditar =>
            @" UPDATE [TBTAXA]
                    SET 
                        [DESCRICAO] = @DESCRICAO,
                        [VALOR] = @VALOR,
                        [TIPOCALCULO] = @TIPOCALCULO
                    WHERE [ID] = @ID";

        protected override string sqlExcluir =>
            @"DELETE FROM [TBTAXA]
                WHERE [ID] = @ID";

        protected override string sqlSelecionarPorId =>
            @"SELECT 
                [ID],       
                [DESCRICAO],
                [VALOR],
                [TIPOCALCULO]
            FROM
                [TBTAXA]
            WHERE 
             [ID] = @ID";

        protected override string sqlSelecionarTodos =>
            @"SELECT 
                [ID],       
                [DESCRICAO],
                [VALOR],
                [TIPOCALCULO]
            FROM
                [TBTAXA]";

        public override ValidationResult Validar(Taxa registro)
        {
            var validator = new ValidadorTaxa();

            var resultadoValidacao = validator.Validate(registro);

            if (resultadoValidacao.IsValid == false)
                return resultadoValidacao;

            var nomeEncontrado = SelecionarTodos()
               .Select(x => x.Descricao.ToLower())
               .Contains(registro.Descricao.ToLower());

            if (nomeEncontrado)
            {
                if (registro.Id == 0)
                    resultadoValidacao.Errors.Add(new ValidationFailure("", "Descrição já está cadastrada"));

                else if (registro.Id != 0)
                    resultadoValidacao.Errors.Add(new ValidationFailure("", "Descrição já está cadastrada"));
            }

            return resultadoValidacao;
        }
    }
}