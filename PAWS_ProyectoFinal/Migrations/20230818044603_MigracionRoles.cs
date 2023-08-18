using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PAWS_ProyectoFinal.Migrations
{
    public partial class MigracionRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id_rol",
                table: "Usuario",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id_rol",
                table: "Usuario");
        }
    }
}
