using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class FieldFixCountryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FechaUltimaModificacion",
                table: "Paises",
                newName: "FechaModificacion");

            migrationBuilder.RenameColumn(
                name: "FechaUltimaModificacion",
                table: "Municipios",
                newName: "FechaModificacion");

            migrationBuilder.RenameColumn(
                name: "Enabled",
                table: "Municipios",
                newName: "Habilitado");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FechaModificacion",
                table: "Paises",
                newName: "FechaUltimaModificacion");

            migrationBuilder.RenameColumn(
                name: "Habilitado",
                table: "Municipios",
                newName: "Enabled");

            migrationBuilder.RenameColumn(
                name: "FechaModificacion",
                table: "Municipios",
                newName: "FechaUltimaModificacion");
        }
    }
}
