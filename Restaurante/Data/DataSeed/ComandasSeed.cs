using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurante.Entities;

namespace Restaurante.Data.Seed
{
    public class ComandasSeed : IEntityTypeConfiguration<Comandas>
    {
        public void Configure(EntityTypeBuilder<Comandas> builder)
        {
            builder.HasData(
                new Comandas
                {
                    Id = 1,
                    MesaId = 1,
                    NombreCliente = "Carlos"
                },
                new Comandas
                {
                    Id = 2,
                    MesaId = 2,
                    NombreCliente = "Laura"
                },
                new Comandas
                {
                    Id = 3,
                    MesaId = 3,
                    NombreCliente = "Fernando"
                }
            );
        }
    }
}
