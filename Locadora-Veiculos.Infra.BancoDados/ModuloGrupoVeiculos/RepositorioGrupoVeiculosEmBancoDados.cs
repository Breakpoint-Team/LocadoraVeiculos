using FluentValidation.Results;
using Locadora_Veiculos.Dominio.ModuloGrupoVeiculos;
using Locadora_Veiculos.Infra.BancoDados.Compartilhado;
using System;
using System.Linq;

namespace Locadora_Veiculos.Infra.BancoDados.ModuloGrupoVeiculos
{
    public class RepositorioGrupoVeiculosEmBancoDados : 
        RepositorioBase<GrupoVeiculos, ValidadorGrupoVeiculos, MapeadorGrupoVeiculos> ,
        IRepositorioGrupoVeiculos
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

        public GrupoVeiculos SelecionarGrupoVeiculosPorNome(string nome)
        {
            throw new NotImplementedException();
        }

        public override ValidationResult Validar(GrupoVeiculos registro)
        {
            var validator = new ValidadorGrupoVeiculos();

            var resultadoValidacao = validator.Validate(registro);

            if (resultadoValidacao.IsValid == false)
                return resultadoValidacao;

            bool nomeEncontrado = false;
            var grupos = SelecionarTodos();
            foreach (var g in grupos)
            {
                if (g.Nome.ToLower() == registro.Nome.ToLower() && g.Id != registro.Id)
                    nomeEncontrado = true;
            }


            if (nomeEncontrado)
                resultadoValidacao.Errors.Add(new ValidationFailure("", "Nome já está cadastrado"));
                
            return resultadoValidacao;
        }
    }
}