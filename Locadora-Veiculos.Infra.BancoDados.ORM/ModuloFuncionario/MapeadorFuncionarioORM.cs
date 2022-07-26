using Locadora_Veiculos.Dominio.ModuloFuncionario;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Locadora_Veiculos.Infra.BancoDados.ORM.ModuloFuncionario
{
    public class MapeadorFuncionarioORM : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.ToTable("TBFuncionario");
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.Nome).HasColumnType("varchar(300)").IsRequired();
            builder.Property(x => x.Login).HasColumnType("varchar(300)").IsRequired();
            builder.Property(x => x.Senha).HasColumnType("varchar(300)").IsRequired();
            builder.Property(x => x.DataAdmissao).IsRequired();
            builder.Property(x => x.Salario).IsRequired();
            builder.Property(x => x.EhAdmin).IsRequired();
            builder.Property(x => x.EstaAtivo).IsRequired();
        }
    }
}
