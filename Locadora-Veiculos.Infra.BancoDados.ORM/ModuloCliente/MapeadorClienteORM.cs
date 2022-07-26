using Locadora_Veiculos.Dominio.ModuloCliente;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Locadora_Veiculos.Infra.BancoDados.ORM.ModuloCliente
{
    public class MapeadorClienteORM : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("TBCliente");
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.Nome).HasColumnType("varchar(300)").IsRequired();
            builder.Property(x => x.Documento).HasColumnType("varchar(30)").IsRequired();
            builder.Property(x => x.Email).HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.Telefone).HasColumnType("varchar(30)").IsRequired();
            builder.Property(x => x.TipoCliente).HasConversion<int>().IsRequired();

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