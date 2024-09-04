using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurante.Entities;
using Restaurante.Entities.Enums;
using System;

namespace Restaurante.Data.Seed
{
    public class PedidosSeed : IEntityTypeConfiguration<Pedidos>
    {
        public void Configure(EntityTypeBuilder<Pedidos> builder)
        {
            builder.HasData(
                new Pedidos
                {
                    Id = 1,
                    ComandaId = 1,
                    ProductoId = 1,
                    Cantidad = 2,
                    Estado = EstadosPedido.Ordenado,
                    FechaCreación = new DateTime(2024, 9, 4, 12, 0, 0),
                    
                },
                new Pedidos
                {
                    Id = 2,
                    ComandaId = 2,
                    ProductoId = 2,
                    Cantidad = 1,
                    Estado = EstadosPedido.Ordenado,
                    FechaCreación = new DateTime(2024, 9, 4, 13, 0, 0),
              
                },
                new Pedidos
                {
                    Id = 3,
                    ComandaId = 1,
                    ProductoId = 3,
                    Cantidad = 3,
                    Estado = EstadosPedido.Finalizado,
                    FechaCreación = new DateTime(2024, 9, 4, 11, 30, 0),
                    TiempoEstimado = new TimeSpan(0, 30, 0),
                    FechaFinalizacion = new DateTime(2024, 9, 4, 12, 0, 0)
                },
                new Pedidos
                {
                    Id = 4,
                    ComandaId = 3,
                    ProductoId = 4,
                    Cantidad = 4,
                    Estado = EstadosPedido.EnPreparación,
                    FechaCreación = new DateTime(2024, 9, 4, 14, 0, 0),
                    TiempoEstimado = new TimeSpan(1, 15, 0),
                },
                new Pedidos
                {
                    Id = 5,
                    ComandaId = 4,
                    ProductoId = 5,
                    Cantidad = 2,
                    Estado = EstadosPedido.Finalizado,
                    FechaCreación = new DateTime(2024, 9, 4, 10, 0, 0),
                    TiempoEstimado = new TimeSpan(0, 40, 0),
                    FechaFinalizacion = new DateTime(2024, 9, 4, 10, 40, 0)
                },
                new Pedidos
                {
                    Id = 6,
                    ComandaId = 2,
                    ProductoId = 1,
                    Cantidad = 1,
                    Estado = EstadosPedido.EnPreparación,
                    FechaCreación = new DateTime(2024, 9, 4, 16, 0, 0),
                    TiempoEstimado = new TimeSpan(1, 10, 0),
                },
                new Pedidos
                {
                    Id = 7,
                    ComandaId = 3,
                    ProductoId = 2,
                    Cantidad = 5,
                    Estado = EstadosPedido.Finalizado,
                    FechaCreación = new DateTime(2024, 9, 4, 17, 30, 0),
                    TiempoEstimado = new TimeSpan(1, 20, 0),
                    FechaFinalizacion = new DateTime(2024, 9, 4, 18, 50, 0)
                },
                new Pedidos
                {
                    Id = 8,
                    ComandaId = 1,
                    ProductoId = 3,
                    Cantidad = 3,
                    Estado = EstadosPedido.EnPreparación,
                    FechaCreación = new DateTime(2024, 9, 4, 15, 0, 0),
                    TiempoEstimado = new TimeSpan(1, 0, 0),
                },
                new Pedidos
                {
                    Id = 9,
                    ComandaId = 4,
                    ProductoId = 4,
                    Cantidad = 4,
                    Estado = EstadosPedido.ListoParaServir,
                    FechaCreación = new DateTime(2024, 9, 4, 11, 0, 0),
                    TiempoEstimado = new TimeSpan(1, 30, 0),
                    FechaFinalizacion = new DateTime(2024, 9, 4, 12, 30, 0)
                },
                new Pedidos
                {
                    Id = 10,
                    ComandaId = 2,
                    ProductoId = 5,
                    Cantidad = 2,
                    Estado = EstadosPedido.ListoParaServir,
                    FechaCreación = new DateTime(2024, 9, 4, 18, 0, 0),
                    TiempoEstimado = new TimeSpan(0, 50, 0),
                    FechaFinalizacion = new DateTime(2024, 9, 4, 18, 50, 0)
                }
            );
        }
    }
}
