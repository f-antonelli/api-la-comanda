using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurante.Entities;
using Restaurante.Entities.Enums;

namespace Restaurante.Data.Seed
{
    public class ProductosSeed : IEntityTypeConfiguration<Productos>
    {
        public void Configure(EntityTypeBuilder<Productos> builder)
        {
            builder.HasData(
              new Productos  // Stock inicial
              {
                  Id = 1,
                  Sector = Sectores.Comida,
                  Nombre = "Milanesa a Caballo",
                  Descripcion = "Milanesa de carne con dos huevos fritos encima.",
                  Precio = 12.99f,
                  Stock = 12
              },
              new Productos // Stock inicial
              {
                  Id = 2,
                  Sector = Sectores.Comida,
                  Nombre = "Hamburguesas de Garbanzo",
                  Descripcion = "Dos hamburguesas vegetarianas hechas de garbanzo.",
                  Precio = 9.99f,
                  Stock = 8

              },
              new Productos // Stock inicial
              {
                  Id = 3,
                  Sector = Sectores.Cerveza,
                  Nombre = "Corona",
                  Descripcion = "Botella de cerveza Corona 355ml.",
                  Precio = 3.50f,
                    Stock = 3

              },
              new Productos // Stock inicial
              {
                  Id = 4,
                  Sector = Sectores.Bebida,
                  Nombre = "Daikiri",
                  Descripcion = "Cóctel de ron con jugo de limón y azúcar.",
                  Precio = 7.50f,
                  Stock = 2

              }

            );
        }
    }
}
