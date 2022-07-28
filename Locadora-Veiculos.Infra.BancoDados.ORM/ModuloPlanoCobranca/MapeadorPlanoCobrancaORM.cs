using Locadora_Veiculos.Dominio.ModuloPlanoCobranca;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Locadora_Veiculos.Infra.BancoDados.ORM.ModuloPlanoCobranca
{
    public class MapeadorPlanoCobrancaORM : IEntityTypeConfiguration<PlanoCobranca>
    {
        public void Configure(EntityTypeBuilder<PlanoCobranca> builder)
        {
            builder.ToTable("TBPlanoCobranca");
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.DiarioValorDia).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(x => x.DiarioValorKm).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(x => x.KmControladoValorDia).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(x => x.KmControladoValorKm).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(x => x.KmControladoLimiteKm).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(x => x.KmLivreValorDia).HasColumnType("decimal(18,2)").IsRequired();
            builder.HasOne(x => x.GrupoVeiculos)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
