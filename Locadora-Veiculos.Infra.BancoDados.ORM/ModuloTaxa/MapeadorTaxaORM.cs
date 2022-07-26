using Locadora_Veiculos.Dominio.ModuloTaxa;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Locadora_Veiculos.Infra.BancoDados.ORM.ModuloTaxa
{
    public class MapeadorTaxaORM : IEntityTypeConfiguration<Taxa>
    {
        public void Configure(EntityTypeBuilder<Taxa> builder)
        {
            throw new System.NotImplementedException();
        }
    }
}
