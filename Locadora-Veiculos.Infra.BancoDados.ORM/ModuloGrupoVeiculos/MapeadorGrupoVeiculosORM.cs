
using Locadora_Veiculos.Dominio.ModuloGrupoVeiculos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Locadora_Veiculos.Infra.BancoDados.ORM.ModuloGrupoVeiculos
{
    public class MapeadorGrupoVeiculosORM : IEntityTypeConfiguration<GrupoVeiculos>
    {
        public void Configure(EntityTypeBuilder<GrupoVeiculos> builder)
        {
            builder.ToTable("TBGrupoVeiculos");
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.Nome).HasColumnType("varchar(200)").IsRequired();
        }
    }
}
