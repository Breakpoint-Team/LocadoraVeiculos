

using Locadora_Veiculos.Dominio.ModuloTaxa;
using Locadora_Veiculos.Infra.BancoDados.Compartilhado;

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
    }
}
