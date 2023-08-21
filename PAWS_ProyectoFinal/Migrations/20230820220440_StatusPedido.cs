using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PAWS_ProyectoFinal.Migrations
{
    public partial class StatusPedido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StatusPedido",
                table: "Venta",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusPedido",
                table: "Venta");
        }
    }
}
