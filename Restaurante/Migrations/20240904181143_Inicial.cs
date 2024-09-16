using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurante.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Usuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rol = table.Column<int>(type: "int", nullable: false),
                    Sector = table.Column<int>(type: "int", nullable: false),
                    FechaIngreso = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mesas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mesas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sector = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Precio = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comandas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MesaId = table.Column<int>(type: "int", nullable: false),
                    NombreCliente = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comandas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comandas_Mesas_MesaId",
                        column: x => x.MesaId,
                        principalTable: "Mesas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComandaId = table.Column<int>(type: "int", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    FechaCreación = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFinalizacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TiempoEstimado = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedidos_Comandas_ComandaId",
                        column: x => x.ComandaId,
                        principalTable: "Comandas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pedidos_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Empleados",
                columns: new[] { "Id", "FechaIngreso", "Nombre", "Password", "Rol", "Sector", "Usuario" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Juan Perez", "bartender1", 0, 1, "bartender1" },
                    { 2, new DateTime(2023, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ana Lopez", "bartender2", 0, 1, "bartender2" },
                    { 3, new DateTime(2021, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Luis Fernandez", "cervecero1", 1, 2, "cervecero1" },
                    { 4, new DateTime(2022, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marta Gutierrez", "cervecero2", 1, 2, "cervecero2" },
                    { 5, new DateTime(2020, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Carlos Ruiz", "cocinero1", 2, 0, "cocinero1" },
                    { 6, new DateTime(2021, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lucia Sanchez", "cocinero2", 2, 0, "cocinero2" },
                    { 7, new DateTime(2023, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pedro Mendez", "mozo1", 3, 3, "mozo1" },
                    { 8, new DateTime(2022, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sofia Herrera", "mozo2", 3, 3, "mozo2" },
                    { 9, new DateTime(2019, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marcos Diaz", "admin1", 4, 3, "admin1" },
                    { 10, new DateTime(2021, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Clara Martinez", "admin2", 4, 3, "admin2" }
                });

            migrationBuilder.InsertData(
                table: "Mesas",
                columns: new[] { "Id", "Codigo", "Estado" },
                values: new object[,]
                {
                    { 1, "A1B2C", 0 },
                    { 2, "D3E4F", 1 },
                    { 3, "G5H6I", 2 },
                    { 4, "J7K8L", 3 }
                });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "Descripcion", "Nombre", "Precio", "Sector" },
                values: new object[,]
                {
                    { 1, "Milanesa de carne con dos huevos fritos encima.", "Milanesa a Caballo", 12.99f, 0 },
                    { 2, "Dos hamburguesas vegetarianas hechas de garbanzo.", "Hamburguesas de Garbanzo", 9.99f, 0 },
                    { 3, "Botella de cerveza Corona 355ml.", "Corona", 3.5f, 2 },
                    { 4, "Cóctel de ron con jugo de limón y azúcar.", "Daikiri", 7.5f, 1 }
                });

            migrationBuilder.InsertData(
                table: "Comandas",
                columns: new[] { "Id", "MesaId", "NombreCliente" },
                values: new object[] { 1, 1, "Carlos" });

            migrationBuilder.InsertData(
                table: "Comandas",
                columns: new[] { "Id", "MesaId", "NombreCliente" },
                values: new object[] { 2, 2, "Laura" });

            migrationBuilder.InsertData(
                table: "Comandas",
                columns: new[] { "Id", "MesaId", "NombreCliente" },
                values: new object[] { 3, 3, "Fernando" });

            migrationBuilder.InsertData(
                table: "Pedidos",
                columns: new[] { "Id", "Cantidad", "ComandaId", "Estado", "FechaCreación", "FechaFinalizacion", "ProductoId", "TiempoEstimado" },
                values: new object[,]
                {
                    { 1, 2, 1, 0, new DateTime(2024, 9, 4, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new TimeSpan(0, 0, 0, 0, 0) },
                    { 2, 1, 2, 0, new DateTime(2024, 9, 4, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new TimeSpan(0, 0, 0, 0, 0) },
                    { 3, 3, 1, 3, new DateTime(2024, 9, 4, 11, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 4, 12, 0, 0, 0, DateTimeKind.Unspecified), 3, new TimeSpan(0, 0, 30, 0, 0) },
                    { 4, 4, 3, 1, new DateTime(2024, 9, 4, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, new TimeSpan(0, 1, 15, 0, 0) },
                    { 5, 2, 2, 3, new DateTime(2024, 9, 4, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 4, 10, 40, 0, 0, DateTimeKind.Unspecified), 4, new TimeSpan(0, 0, 40, 0, 0) },
                    { 6, 1, 2, 1, new DateTime(2024, 9, 4, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new TimeSpan(0, 1, 10, 0, 0) },
                    { 7, 5, 3, 3, new DateTime(2024, 9, 4, 17, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 4, 18, 50, 0, 0, DateTimeKind.Unspecified), 2, new TimeSpan(0, 1, 20, 0, 0) },
                    { 8, 3, 1, 1, new DateTime(2024, 9, 4, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new TimeSpan(0, 1, 0, 0, 0) },
                    { 9, 4, 3, 2, new DateTime(2024, 9, 4, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 4, 12, 30, 0, 0, DateTimeKind.Unspecified), 4, new TimeSpan(0, 1, 30, 0, 0) },
                    { 10, 2, 2, 2, new DateTime(2024, 9, 4, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 4, 18, 50, 0, 0, DateTimeKind.Unspecified), 4, new TimeSpan(0, 0, 50, 0, 0) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comandas_MesaId",
                table: "Comandas",
                column: "MesaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ComandaId",
                table: "Pedidos",
                column: "ComandaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ProductoId",
                table: "Pedidos",
                column: "ProductoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Comandas");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Mesas");
        }
    }
}
