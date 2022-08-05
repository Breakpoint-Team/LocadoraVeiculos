
using Locadora_Veiculos.Infra.BancoDados.Compartilhado;

namespace Locadora_Veiculos.Infra.ORM.Tests.Compartilhado
{
    public abstract class RepositorioORMTestBase
    {
        public void LimparTabelas()
        {
            Db.ExecutarSql("DELETE FROM LOCACAOTAXA;");
            Db.ExecutarSql("DELETE FROM TBLOCACAO;");
            Db.ExecutarSql("DELETE FROM TBTAXA");
            Db.ExecutarSql("DELETE FROM TBPLANOCOBRANCA;");
            Db.ExecutarSql("DELETE FROM TBVEICULO;");
            Db.ExecutarSql("DELETE FROM TBGRUPOVEICULOS;");
            Db.ExecutarSql("DELETE FROM TBCONDUTOR;");
            Db.ExecutarSql("DELETE FROM TBCLIENTE;");
            Db.ExecutarSql("DELETE FROM TBFUNCIONARIO;");
        }
    }
}
