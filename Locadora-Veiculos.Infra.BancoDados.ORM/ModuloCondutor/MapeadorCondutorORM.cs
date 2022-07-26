using Locadora_Veiculos.Dominio.ModuloCondutor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Locadora_Veiculos.Infra.BancoDados.ORM.ModuloCondutor
{
    public class MapeadorCondutorORM : IEntityTypeConfiguration<Condutor>
    {
        public void Configure(EntityTypeBuilder<Condutor> builder)
        {
            builder.ToTable("TBCondutor");
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.Nome).HasColumnType("varchar(300)").IsRequired();
            builder.Property(x => x.Telefone).HasColumnType("varchar(30)").IsRequired();
            builder.Property(x => x.Email).HasColumnType("varchar(300)").IsRequired();
            builder.Property(x => x.Cpf).HasColumnType("varchar(30)").IsRequired();
            builder.Property(x => x.Cnh).HasColumnType("varchar(30)").IsRequired();
            builder.Property(x => x.DataValidadeCnh).IsRequired();
            builder.HasOne(x => x.Cliente)
                .WithMany()
                .HasForeignKey(x => x.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.OwnsOne(
                    x => x.Endereco,
                        endereco =>
                        {
                            endereco.Property(x => x.Estado).HasColumnType("varchar(3)").IsRequired();
                            endereco.Property(x => x.Cidade).HasColumnType("varchar(300)").IsRequired();
                            endereco.Property(x => x.Bairro).HasColumnType("varchar(300)").IsRequired();
                            endereco.Property(x => x.Logradouro).HasColumnType("varchar(300)").IsRequired();
                            endereco.Property(x => x.Numero).IsRequired();
                        }).Navigation(x => x.Endereco).IsRequired();
        }

    }
}