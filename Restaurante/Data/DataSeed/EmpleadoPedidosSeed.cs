using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurante.Entities;

namespace Restaurante.Data.Seed
{
    public class EmpleadoPedidosSeed : IEntityTypeConfiguration<EmpleadoPedidos>
    {
        public void Configure(EntityTypeBuilder<EmpleadoPedidos> builder)
        {
            builder.HasData(
                new EmpleadoPedidos
                {
                    Id = 1,
                    EmpleadoId = 5,
                    PedidoId = 1
                },
                new EmpleadoPedidos
                {
                    Id = 2,
                    EmpleadoId = 5,
                    PedidoId = 2
                },
                new EmpleadoPedidos
                {
                    Id = 3,
                    EmpleadoId = 3,
                    PedidoId = 3
                },
                new EmpleadoPedidos
                {
                    Id = 4,
                    EmpleadoId = 1,
                    PedidoId = 4
                },
                new EmpleadoPedidos
                {
                    Id = 5,
                    EmpleadoId = 1,
                    PedidoId = 5
                },
                new EmpleadoPedidos
                {
                    Id = 6,
                    EmpleadoId = 5,
                    PedidoId = 6
                },
                new EmpleadoPedidos
                {
                    Id = 7,
                    EmpleadoId = 5,
                    PedidoId = 7
                },
                new EmpleadoPedidos
                {
                    Id = 8,
                    EmpleadoId = 5,
                    PedidoId = 8
                },
                new EmpleadoPedidos
                {
                    Id = 9,
                    EmpleadoId = 1,
                    PedidoId = 9
                },
                new EmpleadoPedidos
                {
                    Id = 10,
                    EmpleadoId = 1,
                    PedidoId = 10
                }
            );
        }
    }
}
