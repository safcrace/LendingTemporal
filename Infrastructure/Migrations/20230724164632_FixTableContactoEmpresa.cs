using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class FixTableContactoEmpresa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "ContactosEmpresas",
                newName: "PrimerNombre");

            migrationBuilder.AddColumn<string>(
                name: "ApellidoCasada",
                table: "ContactosEmpresas",
                type: "nvarchar(75)",
                maxLength: 75,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Celular",
                table: "ContactosEmpresas",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CorreoElectronico",
                table: "ContactosEmpresas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrimerApellido",
                table: "ContactosEmpresas",
                type: "nvarchar(75)",
                maxLength: 75,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SegundoApellido",
                table: "ContactosEmpresas",
                type: "nvarchar(75)",
                maxLength: 75,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SegundoNombre",
                table: "ContactosEmpresas",
                type: "nvarchar(75)",
                maxLength: 75,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TelefonoPrincipal",
                table: "ContactosEmpresas",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "CambioEstado",
                table: "BitacoraPrestamos",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApellidoCasada",
                table: "ContactosEmpresas");

            migrationBuilder.DropColumn(
                name: "Celular",
                table: "ContactosEmpresas");

            migrationBuilder.DropColumn(
                name: "CorreoElectronico",
                table: "ContactosEmpresas");

            migrationBuilder.DropColumn(
                name: "PrimerApellido",
                table: "ContactosEmpresas");

            migrationBuilder.DropColumn(
                name: "SegundoApellido",
                table: "ContactosEmpresas");

            migrationBuilder.DropColumn(
                name: "SegundoNombre",
                table: "ContactosEmpresas");

            migrationBuilder.DropColumn(
                name: "TelefonoPrincipal",
                table: "ContactosEmpresas");

            migrationBuilder.DropColumn(
                name: "CambioEstado",
                table: "BitacoraPrestamos");

            migrationBuilder.RenameColumn(
                name: "PrimerNombre",
                table: "ContactosEmpresas",
                newName: "Nombre");
        }
    }
}
