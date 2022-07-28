using Locadora_Veiculos.Dominio.ModuloLocacao;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Locadora_Veiculos.Infra.BancoDados.ORM.ModuloLocacao
{
    public class MapeadorLocacaoORM : IEntityTypeConfiguration<Locacao>
    {
        public void Configure(EntityTypeBuilder<Locacao> builder)
        {
            builder.ToTable("TBLocacao");
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.DataLocacao).IsRequired();
            builder.Property(x => x.DataDevolucaoPrevista).IsRequired();
            builder.Property(x => x.ValorTotalPrevisto).IsRequired();
            builder.Property(x => x.QuilometragemInicialVeiculo).IsRequired();
            builder.Property(x => x.QuilometragemFinalVeiculo);
            builder.Property(x => x.DataDevolucaoEfetiva);
            builder.Property(x => x.NivelTanqueDevolucao).HasConversion<int>();
            builder.Property(x => x.ValorTotalEfetivo);
            builder.Property(x => x.StatusLocacao).HasConversion<int>().IsRequired();
            builder.HasMany(x => x.Taxas);

            builder.HasOne(x => x.Cliente)
                    .WithOne()
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.GrupoVeiculos)
                    .WithOne()
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Veiculo)
                    .WithOne()
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.PlanoCobranca)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
