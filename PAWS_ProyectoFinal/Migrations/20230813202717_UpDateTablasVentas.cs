using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PAWS_ProyectoFinal.Migrations
{
    public partial class UpDateTablasVentas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetalleVenta_Venta_VentaId",
                table: "DetalleVenta");

            migrationBuilder.DropColumn(
                name: "MontoTotal",
                table: "Venta");

            migrationBuilder.DropColumn(
                name: "Venta_ID",
                table: "DetalleVenta");

            migrationBuilder.RenameColumn(
                name: "NumeroDocumento",
                table: "Venta",
                newName: "CorreoCliente");

            migrationBuilder.RenameColumn(
                name: "DocumentoCliente",
                table: "Venta",
                newName: "ClienteId");

            migrationBuilder.AlterColumn<int>(
                name: "VentaId",
                table: "DetalleVenta",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Producto",
                table: "DetalleVenta",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProductoId",
                table: "DetalleVenta",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleVenta_Venta_VentaId",
                table: "DetalleVenta",
                column: "VentaId",
                principalTable: "Venta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetalleVenta_Venta_VentaId",
                table: "DetalleVenta");

            migrationBuilder.DropColumn(
                name: "Producto",
                table: "DetalleVenta");

            migrationBuilder.DropColumn(
                name: "ProductoId",
                table: "DetalleVenta");

            migrationBuilder.RenameColumn(
                name: "CorreoCliente",
                table: "Venta",
                newName: "NumeroDocumento");

            migrationBuilder.RenameColumn(
                name: "ClienteId",
                table: "Venta",
                newName: "DocumentoCliente");

            migrationBuilder.AddColumn<decimal>(
                name: "MontoTotal",
                table: "Venta",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<int>(
                name: "VentaId",
                table: "DetalleVenta",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Venta_ID",
                table: "DetalleVenta",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleVenta_Venta_VentaId",
                table: "DetalleVenta",
                column: "VentaId",
                principalTable: "Venta",
                principalColumn: "Id");
        }
    }
}
