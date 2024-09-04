using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurante.Entities;
using Restaurante.Entities.Enums;
using System;

namespace Restaurante.Data.Seed
{
    public class MesasSeed : IEntityTypeConfiguration<Mesas>
    {
        public void Configure(EntityTypeBuilder<Mesas> builder)
        {
            builder.HasData(
                new Mesas
                {
                    Id = 1,
                    Codigo = "A1B2C",
                    Estado = EstadosMesa.ClienteEsperandoPedido
                },
                new Mesas
                {
                    Id = 2,
                    Codigo = "D3E4F",
                    Estado = EstadosMesa.ClienteComiendo
                },
                new Mesas
                {
                    Id = 3,
                    Codigo = "G5H6I",
                    Estado = EstadosMesa.ClientePagando
                },
                new Mesas
                {
                    Id = 4,
                    Codigo = "J7K8L",
                    Estado = EstadosMesa.Cerrada
                }
            );
        }
    }
}
