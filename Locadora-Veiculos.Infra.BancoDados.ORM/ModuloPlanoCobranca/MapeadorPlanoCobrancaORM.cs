using Locadora_Veiculos.Dominio.ModuloPlanoCobranca;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Locadora_Veiculos.Infra.BancoDados.ORM.ModuloPlanoCobranca
{
    public class MapeadorPlanoCobrancaORM : IEntityTypeConfiguration<PlanoCobranca>
    {
        public void Configure(EntityTypeBuilder<PlanoCobranca> builder)
        {
            throw new System.NotImplementedException();
        }
    }
}
