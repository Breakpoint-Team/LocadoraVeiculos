using Locadora_Veiculos.Dominio.Compartilhado;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora_Veiculos.Infra.BancoDados.ORM.ModuloPrecoCombustiveis
{
    public class MapeadorPrecoCombustivelORM : IEntityTypeConfiguration<PrecoCombustivel>
    {
        public void Configure(EntityTypeBuilder<PrecoCombustivel> builder)
        {
            builder.ToTable("TBPrecoCombustivel");
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.PrecoGasolina).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(x => x.PrecoDiesel).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(x => x.PrecoAlcool).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(x => x.PrecoGNV).HasColumnType("decimal(18,2)").IsRequired();

        }
    }
}
