using Locadora_Veiculos.Dominio.ModuloVeiculo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Locadora_Veiculos.Infra.BancoDados.ORM.ModuloVeiculo
{
    public class MapeadorVeiculoORM : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            throw new System.NotImplementedException();
        }
    }
}
