
using Locadora_Veiculos.Dominio.ModuloGrupoVeiculos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Locadora_Veiculos.Infra.BancoDados.ORM.ModuloGrupoVeiculos
{
    public class MapeadorGrupoVeiculosORM : IEntityTypeConfiguration<GrupoVeiculos>
    {
        public void Configure(EntityTypeBuilder<GrupoVeiculos> builder)
        {
            throw new System.NotImplementedException();
        }
    }
}
