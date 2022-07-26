using Locadora_Veiculos.Dominio.ModuloVeiculo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Locadora_Veiculos.Infra.BancoDados.ORM.ModuloVeiculo
{
    public class MapeadorVeiculoORM : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.ToTable("TBVeiculo");
            builder.Property(x => x.Id).ValueGeneratedNever();          
            builder.Property(x => x.Modelo).HasColumnType("varchar(300)").IsRequired();
            builder.Property(x => x.Marca).HasColumnType("varchar(300)").IsRequired();
            builder.Property(x => x.Ano).HasColumnType("int").IsRequired();
            builder.Property(x => x.Cor).HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.Placa).HasColumnType("varchar(7)").IsRequired();
            builder.Property(x => x.TipoCombustivel).HasColumnType("varchar(300)").IsRequired();
            builder.Property(x => x.QuilometragemPercorrida).HasColumnType("int").IsRequired();
            builder.Property(x => x.CapacidadeTanque).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(x => x.Imagem).HasColumnType("varbinary(max)").IsRequired();
         
            builder.HasOne(x => x.GrupoVeiculos)
                 .WithMany()
                 .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
