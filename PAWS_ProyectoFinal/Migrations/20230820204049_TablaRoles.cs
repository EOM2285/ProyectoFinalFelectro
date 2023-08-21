using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PAWS_ProyectoFinal.Migrations
{
    public partial class TablaRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
            migrationBuilder.AddColumn<int>(
                name: "RollId",
                table: "Usuario",
                type: "int",
                nullable: false,
                defaultValue: "");


            migrationBuilder.CreateTable(
                name: "Rolls",
                columns: table => new
                {
                    IdRoll = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreRoll = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rolls", x => x.IdRoll);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_RollId",
                table: "Usuario",
                column: "RollId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Rolls_RollId",
                table: "Usuario",
                column: "RollId",
                principalTable: "Rolls",
                principalColumn: "IdRoll",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Rolls_RollId",
                table: "Usuario");

            migrationBuilder.DropTable(
                name: "Rolls");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_RollId",
                table: "Usuario");

            migrationBuilder.RenameColumn(
                name: "RollId",
                table: "Usuario",
                newName: "Id_rol");
        }
    }
}
