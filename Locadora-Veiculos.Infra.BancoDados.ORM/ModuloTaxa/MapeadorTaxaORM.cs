using Locadora_Veiculos.Dominio.ModuloTaxa;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Locadora_Veiculos.Infra.BancoDados.ORM.ModuloTaxa
{
    public class MapeadorTaxaORM : IEntityTypeConfiguration<Taxa>
    {
        public void Configure(EntityTypeBuilder<Taxa> builder)
        {
            builder.ToTable("TBTaxa");
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.Descricao).HasColumnType("varchar(300)").IsRequired();
            builder.Property(x => x.Valor).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(x => x.TipoCalculo).HasConversion<int>().IsRequired();
            //Teste para a criação da tabela TBLocaçãp
            builder.HasMany(x => x.Locacoes);
        }
    }
}
