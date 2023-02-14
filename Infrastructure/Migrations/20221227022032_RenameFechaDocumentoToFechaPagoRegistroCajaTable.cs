using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class RenameFechaDocumentoToFechaPagoRegistroCajaTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FechaDocumento",
                table: "RegistroCajas",
                newName: "FechaPago");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FechaPago",
                table: "RegistroCajas",
                newName: "FechaDocumento");
        }
    }
}
