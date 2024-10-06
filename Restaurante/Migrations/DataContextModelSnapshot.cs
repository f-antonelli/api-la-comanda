﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Restaurante.Data;

#nullable disable

namespace Restaurante.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.33")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Restaurante.Entities.Comandas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("MesaId")
                        .HasColumnType("int");

                    b.Property<string>("NombreCliente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MesaId");

                    b.ToTable("Comandas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            MesaId = 1,
                            NombreCliente = "Carlos"
                        },
                        new
                        {
                            Id = 2,
                            MesaId = 2,
                            NombreCliente = "Laura"
                        },
                        new
                        {
                            Id = 3,
                            MesaId = 3,
                            NombreCliente = "Fernando"
                        });
                });

            modelBuilder.Entity("Restaurante.Entities.EmpleadoPedidos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("EmpleadoId")
                        .HasColumnType("int");

                    b.Property<int>("PedidoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmpleadoId");

                    b.HasIndex("PedidoId");

                    b.ToTable("EmpleadoPedidos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EmpleadoId = 5,
                            PedidoId = 1
                        },
                        new
                        {
                            Id = 2,
                            EmpleadoId = 5,
                            PedidoId = 2
                        },
                        new
                        {
                            Id = 3,
                            EmpleadoId = 3,
                            PedidoId = 3
                        },
                        new
                        {
                            Id = 4,
                            EmpleadoId = 1,
                            PedidoId = 4
                        },
                        new
                        {
                            Id = 5,
                            EmpleadoId = 1,
                            PedidoId = 5
                        },
                        new
                        {
                            Id = 6,
                            EmpleadoId = 5,
                            PedidoId = 6
                        },
                        new
                        {
                            Id = 7,
                            EmpleadoId = 5,
                            PedidoId = 7
                        },
                        new
                        {
                            Id = 8,
                            EmpleadoId = 5,
                            PedidoId = 8
                        },
                        new
                        {
                            Id = 9,
                            EmpleadoId = 1,
                            PedidoId = 9
                        },
                        new
                        {
                            Id = 10,
                            EmpleadoId = 1,
                            PedidoId = 10
                        });
                });

            modelBuilder.Entity("Restaurante.Entities.Empleados", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("FechaIngreso")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rol")
                        .HasColumnType("int");

                    b.Property<int>("Sector")
                        .HasColumnType("int");

                    b.Property<string>("Usuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Empleados");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FechaIngreso = new DateTime(2022, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "Juan Perez",
                            Password = "bartender1",
                            Rol = 0,
                            Sector = 1,
                            Usuario = "bartender1"
                        },
                        new
                        {
                            Id = 2,
                            FechaIngreso = new DateTime(2023, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "Ana Lopez",
                            Password = "bartender2",
                            Rol = 0,
                            Sector = 1,
                            Usuario = "bartender2"
                        },
                        new
                        {
                            Id = 3,
                            FechaIngreso = new DateTime(2021, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "Luis Fernandez",
                            Password = "cervecero1",
                            Rol = 1,
                            Sector = 2,
                            Usuario = "cervecero1"
                        },
                        new
                        {
                            Id = 4,
                            FechaIngreso = new DateTime(2022, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "Marta Gutierrez",
                            Password = "cervecero2",
                            Rol = 1,
                            Sector = 2,
                            Usuario = "cervecero2"
                        },
                        new
                        {
                            Id = 5,
                            FechaIngreso = new DateTime(2020, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "Carlos Ruiz",
                            Password = "cocinero1",
                            Rol = 2,
                            Sector = 0,
                            Usuario = "cocinero1"
                        },
                        new
                        {
                            Id = 6,
                            FechaIngreso = new DateTime(2021, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "Lucia Sanchez",
                            Password = "cocinero2",
                            Rol = 2,
                            Sector = 0,
                            Usuario = "cocinero2"
                        },
                        new
                        {
                            Id = 7,
                            FechaIngreso = new DateTime(2023, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "Pedro Mendez",
                            Password = "mozo1",
                            Rol = 3,
                            Sector = 3,
                            Usuario = "mozo1"
                        },
                        new
                        {
                            Id = 8,
                            FechaIngreso = new DateTime(2022, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "Sofia Herrera",
                            Password = "mozo2",
                            Rol = 3,
                            Sector = 3,
                            Usuario = "mozo2"
                        },
                        new
                        {
                            Id = 9,
                            FechaIngreso = new DateTime(2019, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "Marcos Diaz",
                            Password = "admin1",
                            Rol = 4,
                            Sector = 3,
                            Usuario = "admin1"
                        },
                        new
                        {
                            Id = 10,
                            FechaIngreso = new DateTime(2021, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "Clara Martinez",
                            Password = "admin2",
                            Rol = 4,
                            Sector = 3,
                            Usuario = "admin2"
                        });
                });

            modelBuilder.Entity("Restaurante.Entities.Mesas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Mesas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Codigo = "A1B2C",
                            Estado = 0
                        },
                        new
                        {
                            Id = 2,
                            Codigo = "D3E4F",
                            Estado = 1
                        },
                        new
                        {
                            Id = 3,
                            Codigo = "G5H6I",
                            Estado = 2
                        },
                        new
                        {
                            Id = 4,
                            Codigo = "J7K8L",
                            Estado = 3
                        });
                });

            modelBuilder.Entity("Restaurante.Entities.Pedidos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("ComandaId")
                        .HasColumnType("int");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreación")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaFinalizacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProductoId")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("TiempoEstimado")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.HasIndex("ComandaId");

                    b.HasIndex("ProductoId");

                    b.ToTable("Pedidos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Cantidad = 2,
                            ComandaId = 1,
                            Estado = 0,
                            FechaCreación = new DateTime(2024, 9, 4, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            FechaFinalizacion = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProductoId = 1,
                            TiempoEstimado = new TimeSpan(0, 0, 0, 0, 0)
                        },
                        new
                        {
                            Id = 2,
                            Cantidad = 1,
                            ComandaId = 2,
                            Estado = 0,
                            FechaCreación = new DateTime(2024, 9, 4, 13, 0, 0, 0, DateTimeKind.Unspecified),
                            FechaFinalizacion = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProductoId = 2,
                            TiempoEstimado = new TimeSpan(0, 0, 0, 0, 0)
                        },
                        new
                        {
                            Id = 3,
                            Cantidad = 3,
                            ComandaId = 1,
                            Estado = 3,
                            FechaCreación = new DateTime(2024, 9, 4, 11, 30, 0, 0, DateTimeKind.Unspecified),
                            FechaFinalizacion = new DateTime(2024, 9, 4, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            ProductoId = 3,
                            TiempoEstimado = new TimeSpan(0, 0, 30, 0, 0)
                        },
                        new
                        {
                            Id = 4,
                            Cantidad = 4,
                            ComandaId = 3,
                            Estado = 1,
                            FechaCreación = new DateTime(2024, 9, 4, 14, 0, 0, 0, DateTimeKind.Unspecified),
                            FechaFinalizacion = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProductoId = 4,
                            TiempoEstimado = new TimeSpan(0, 1, 15, 0, 0)
                        },
                        new
                        {
                            Id = 5,
                            Cantidad = 2,
                            ComandaId = 2,
                            Estado = 3,
                            FechaCreación = new DateTime(2024, 9, 4, 10, 0, 0, 0, DateTimeKind.Unspecified),
                            FechaFinalizacion = new DateTime(2024, 9, 4, 10, 40, 0, 0, DateTimeKind.Unspecified),
                            ProductoId = 4,
                            TiempoEstimado = new TimeSpan(0, 0, 40, 0, 0)
                        },
                        new
                        {
                            Id = 6,
                            Cantidad = 1,
                            ComandaId = 2,
                            Estado = 1,
                            FechaCreación = new DateTime(2024, 9, 4, 16, 0, 0, 0, DateTimeKind.Unspecified),
                            FechaFinalizacion = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProductoId = 1,
                            TiempoEstimado = new TimeSpan(0, 1, 10, 0, 0)
                        },
                        new
                        {
                            Id = 7,
                            Cantidad = 5,
                            ComandaId = 3,
                            Estado = 3,
                            FechaCreación = new DateTime(2024, 9, 4, 17, 30, 0, 0, DateTimeKind.Unspecified),
                            FechaFinalizacion = new DateTime(2024, 9, 4, 18, 50, 0, 0, DateTimeKind.Unspecified),
                            ProductoId = 2,
                            TiempoEstimado = new TimeSpan(0, 1, 20, 0, 0)
                        },
                        new
                        {
                            Id = 8,
                            Cantidad = 3,
                            ComandaId = 1,
                            Estado = 1,
                            FechaCreación = new DateTime(2024, 9, 4, 15, 0, 0, 0, DateTimeKind.Unspecified),
                            FechaFinalizacion = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProductoId = 3,
                            TiempoEstimado = new TimeSpan(0, 1, 0, 0, 0)
                        },
                        new
                        {
                            Id = 9,
                            Cantidad = 4,
                            ComandaId = 3,
                            Estado = 2,
                            FechaCreación = new DateTime(2024, 9, 4, 11, 0, 0, 0, DateTimeKind.Unspecified),
                            FechaFinalizacion = new DateTime(2024, 9, 4, 12, 30, 0, 0, DateTimeKind.Unspecified),
                            ProductoId = 4,
                            TiempoEstimado = new TimeSpan(0, 1, 30, 0, 0)
                        },
                        new
                        {
                            Id = 10,
                            Cantidad = 2,
                            ComandaId = 2,
                            Estado = 2,
                            FechaCreación = new DateTime(2024, 9, 4, 18, 0, 0, 0, DateTimeKind.Unspecified),
                            FechaFinalizacion = new DateTime(2024, 9, 4, 18, 50, 0, 0, DateTimeKind.Unspecified),
                            ProductoId = 4,
                            TiempoEstimado = new TimeSpan(0, 0, 50, 0, 0)
                        });
                });

            modelBuilder.Entity("Restaurante.Entities.Productos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Precio")
                        .HasColumnType("real");

                    b.Property<int>("Sector")
                        .HasColumnType("int");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Productos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descripcion = "Milanesa de carne con dos huevos fritos encima.",
                            Nombre = "Milanesa a Caballo",
                            Precio = 12.99f,
                            Sector = 0,
                            Stock = 12
                        },
                        new
                        {
                            Id = 2,
                            Descripcion = "Dos hamburguesas vegetarianas hechas de garbanzo.",
                            Nombre = "Hamburguesas de Garbanzo",
                            Precio = 9.99f,
                            Sector = 0,
                            Stock = 8
                        },
                        new
                        {
                            Id = 3,
                            Descripcion = "Botella de cerveza Corona 355ml.",
                            Nombre = "Corona",
                            Precio = 3.5f,
                            Sector = 2,
                            Stock = 3
                        },
                        new
                        {
                            Id = 4,
                            Descripcion = "Cóctel de ron con jugo de limón y azúcar.",
                            Nombre = "Daikiri",
                            Precio = 7.5f,
                            Sector = 1,
                            Stock = 2
                        });
                });

            modelBuilder.Entity("Restaurante.Entities.Comandas", b =>
                {
                    b.HasOne("Restaurante.Entities.Mesas", "Mesa")
                        .WithMany()
                        .HasForeignKey("MesaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mesa");
                });

            modelBuilder.Entity("Restaurante.Entities.EmpleadoPedidos", b =>
                {
                    b.HasOne("Restaurante.Entities.Empleados", "Empleado")
                        .WithMany()
                        .HasForeignKey("EmpleadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Restaurante.Entities.Pedidos", "Pedido")
                        .WithMany()
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empleado");

                    b.Navigation("Pedido");
                });

            modelBuilder.Entity("Restaurante.Entities.Pedidos", b =>
                {
                    b.HasOne("Restaurante.Entities.Comandas", "Comanda")
                        .WithMany()
                        .HasForeignKey("ComandaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Restaurante.Entities.Productos", "Producto")
                        .WithMany()
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Comanda");

                    b.Navigation("Producto");
                });
#pragma warning restore 612, 618
        }
    }
}
