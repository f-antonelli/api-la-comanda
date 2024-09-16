using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurante.Entities;
using Restaurante.Entities.Enums;
using System;

namespace Restaurante.Data.Seed
{
    public class EmpleadosSeed : IEntityTypeConfiguration<Empleados>
    {
        public void Configure(EntityTypeBuilder<Empleados> builder)
        {
            builder.HasData(
                // Bartenders (Sector: Bebida, Rol: Bartender)
                new Empleados
                {
                    Id = 1,
                    Nombre = "Juan Perez",
                    Usuario = "bartender1",
                    Password = "bartender1",
                    Rol = Roles.Bartender,
                    Sector = Sectores.Bebida,
                    FechaIngreso = new DateTime(2022, 5, 1)
                },
                new Empleados
                {
                    Id = 2,
                    Nombre = "Ana Lopez",
                    Usuario = "bartender2",
                    Password = "bartender2",
                    Rol = Roles.Bartender,
                    Sector = Sectores.Bebida,
                    FechaIngreso = new DateTime(2023, 3, 15)
                },

                // Cerveceros (Sector: Cerveza, Rol: Cervecero)
                new Empleados
                {
                    Id = 3,
                    Nombre = "Luis Fernandez",
                    Usuario = "cervecero1",
                    Password = "cervecero1",
                    Rol = Roles.Cervecero,
                    Sector = Sectores.Cerveza,
                    FechaIngreso = new DateTime(2021, 8, 20)
                },
                new Empleados
                {
                    Id = 4,
                    Nombre = "Marta Gutierrez",
                    Usuario = "cervecero2",
                    Password = "cervecero2",
                    Rol = Roles.Cervecero,
                    Sector = Sectores.Cerveza,
                    FechaIngreso = new DateTime(2022, 11, 10)
                },

                // Cocineros (Sector: Comida, Rol: Cocinero)
                new Empleados
                {
                    Id = 5,
                    Nombre = "Carlos Ruiz",
                    Usuario = "cocinero1",
                    Password = "cocinero1",
                    Rol = Roles.Cocinero,
                    Sector = Sectores.Comida,
                    FechaIngreso = new DateTime(2020, 1, 5)
                },
                new Empleados
                {
                    Id = 6,
                    Nombre = "Lucia Sanchez",
                    Usuario = "cocinero2",
                    Password = "cocinero2",
                    Rol = Roles.Cocinero,
                    Sector = Sectores.Comida,
                    FechaIngreso = new DateTime(2021, 4, 18)
                },

                // Mozos (Sector: Comida, Rol: Mozo)
                new Empleados
                {
                    Id = 7,
                    Nombre = "Pedro Mendez",
                    Usuario = "mozo1",
                    Password = "mozo1",
                    Rol = Roles.Mozo,
                    Sector = Sectores.Otro,
                    FechaIngreso = new DateTime(2023, 6, 25)
                },
                new Empleados
                {
                    Id = 8,
                    Nombre = "Sofia Herrera",
                    Usuario = "mozo2",
                    Password = "mozo2",
                    Rol = Roles.Mozo,
                    Sector = Sectores.Otro,
                    FechaIngreso = new DateTime(2022, 9, 30)
                },

                // Admins (Sector: Bebida, Rol: Socio)
                new Empleados
                {
                    Id = 9,
                    Nombre = "Marcos Diaz",
                    Usuario = "admin1",
                    Password = "admin1",
                    Rol = Roles.Socio,
                    Sector = Sectores.Otro,
                    FechaIngreso = new DateTime(2019, 12, 12)
                },
                new Empleados
                {
                    Id = 10,
                    Nombre = "Clara Martinez",
                    Usuario = "admin2",
                    Password = "admin2",
                    Rol = Roles.Socio,
                    Sector = Sectores.Otro,
                    FechaIngreso = new DateTime(2021, 7, 7)
                }
            );
        }
    }
}
