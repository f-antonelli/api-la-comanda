using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurante.Migrations
{
    public partial class updatedEmpleadoPedido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "EmpleadoPedidos",
                keyColumn: "Id",
                keyValue: 3,
                column: "EmpleadoId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "EmpleadoPedidos",
                keyColumn: "Id",
                keyValue: 4,
                column: "EmpleadoId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "EmpleadoPedidos",
                keyColumn: "Id",
                keyValue: 5,
                column: "EmpleadoId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "EmpleadoPedidos",
                keyColumn: "Id",
                keyValue: 7,
                column: "EmpleadoId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "EmpleadoPedidos",
                keyColumn: "Id",
                keyValue: 9,
                column: "EmpleadoId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "EmpleadoPedidos",
                keyColumn: "Id",
                keyValue: 10,
                column: "EmpleadoId",
                value: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "EmpleadoPedidos",
                keyColumn: "Id",
                keyValue: 3,
                column: "EmpleadoId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "EmpleadoPedidos",
                keyColumn: "Id",
                keyValue: 4,
                column: "EmpleadoId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "EmpleadoPedidos",
                keyColumn: "Id",
                keyValue: 5,
                column: "EmpleadoId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "EmpleadoPedidos",
                keyColumn: "Id",
                keyValue: 7,
                column: "EmpleadoId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "EmpleadoPedidos",
                keyColumn: "Id",
                keyValue: 9,
                column: "EmpleadoId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "EmpleadoPedidos",
                keyColumn: "Id",
                keyValue: 10,
                column: "EmpleadoId",
                value: 5);
        }
    }
}
