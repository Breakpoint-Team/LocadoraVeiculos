using FluentValidation;
using FluentValidation.Results;
using Locadora_Veiculos.Dominio.ModuloGrupoVeiculos;
using Locadora_Veiculos.Infra.BancoDados.Compartilhado;
using System;
using System.Data.SqlClient;
using System.Linq;

namespace Locadora_Veiculos.Infra.BancoDados.ModuloGrupoVeiculos
{
    public class RepositorioGrupoVeiculosEmBancoDados : RepositorioBase<GrupoVeiculos, ValidadorGrupoVeiculos, MapeadorGrupoVeiculos> , IRepositorioGrupoVeiculos
    {
        protected override string sqlInserir =>
            @"INSERT INTO [TBGRUPOVEICULOS]
                (
                    [NOME]     
                )
            VALUES
                (
                    @NOME
                ); SELECT SCOPE_IDENTITY();";

        protected override string sqlEditar =>
                @" UPDATE [TBGRUPOVEICULOS]
                    SET 
                        [NOME] = @NOME
                    WHERE [ID] = @ID";

        protected override string sqlExcluir =>
           @"DELETE FROM [TBGRUPOVEICULOS]
                WHERE [ID] = @ID";

        protected override string sqlSelecionarPorId =>
        @"SELECT 
                [ID],       
                [NOME]
            FROM
                [TBGRUPOVEICULOS]
            WHERE 
             [ID] = @ID";

        protected override string sqlSelecionarTodos =>
        @"SELECT 
                [ID],       
                [NOME]
            FROM
                [TBGRUPOVEICULOS]";

        public override ValidationResult Validar(GrupoVeiculos registro)
        {
            var validator = new ValidadorGrupoVeiculos();

            var resultadoValidacao = validator.Validate(registro);

            if (resultadoValidacao.IsValid == false)
                return resultadoValidacao;

            var nomeEncontrado = SelecionarTodos()
               .Select(x => x.Nome.ToLower())
               .Contains(registro.Nome.ToLower());


            if (nomeEncontrado)
            {
                if(registro.Id == 0)
                resultadoValidacao.Errors.Add(new ValidationFailure("", "Nome já está cadastrado"));
                
                else if(registro.Id != 0 )
                resultadoValidacao.Errors.Add(new ValidationFailure("", "Nome já está cadastrado"));

            }

            return resultadoValidacao;
        }

    }
}
