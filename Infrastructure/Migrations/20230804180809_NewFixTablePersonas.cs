using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class NewFixTablePersonas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FehaInicioNegocio",
                table: "Personas",
                newName: "FechaInicioNegocio");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FechaInicioNegocio",
                table: "Personas",
                newName: "FehaInicioNegocio");
        }
    }
}
