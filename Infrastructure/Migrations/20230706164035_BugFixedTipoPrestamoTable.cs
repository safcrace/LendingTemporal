using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class BugFixedTipoPrestamoTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TasInteresVariable",
                table: "TipoPrestamos",
                newName: "TasaInteresVariable");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TasaInteresVariable",
                table: "TipoPrestamos",
                newName: "TasInteresVariable");
        }
    }
}
