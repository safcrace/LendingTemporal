using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class FieldsValidationPersonaTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Municipios_MunicipioId1",
                table: "Personas");

            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Paises_PaisNacimientoId1",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_Personas_MunicipioId1",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_Personas_PaisNacimientoId1",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "MunicipioId1",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "PaisNacimientoId1",
                table: "Personas");

            migrationBuilder.AlterColumn<string>(
                name: "SegundoNombre",
                table: "Personas",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SegundoApellido",
                table: "Personas",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "PrimerNombre",
                table: "Personas",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "PrimerApellido",
                table: "Personas",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PaisNacimientoId",
                table: "Personas",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NumeroTelefonoLaboral",
                table: "Personas",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NumeroCelular",
                table: "Personas",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MunicipioId",
                table: "Personas",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DireccionLaboral",
                table: "Personas",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Comentarios",
                table: "Personas",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Colonia",
                table: "Personas",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApellidoCasada",
                table: "Personas",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Personas_MunicipioId",
                table: "Personas",
                column: "MunicipioId");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_PaisNacimientoId",
                table: "Personas",
                column: "PaisNacimientoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Municipios_MunicipioId",
                table: "Personas",
                column: "MunicipioId",
                principalTable: "Municipios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Paises_PaisNacimientoId",
                table: "Personas",
                column: "PaisNacimientoId",
                principalTable: "Paises",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Municipios_MunicipioId",
                table: "Personas");

            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Paises_PaisNacimientoId",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_Personas_MunicipioId",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_Personas_PaisNacimientoId",
                table: "Personas");

            migrationBuilder.AlterColumn<string>(
                name: "SegundoNombre",
                table: "Personas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SegundoApellido",
                table: "Personas",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PrimerNombre",
                table: "Personas",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "PrimerApellido",
                table: "Personas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "PaisNacimientoId",
                table: "Personas",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NumeroTelefonoLaboral",
                table: "Personas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NumeroCelular",
                table: "Personas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MunicipioId",
                table: "Personas",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DireccionLaboral",
                table: "Personas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Comentarios",
                table: "Personas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Colonia",
                table: "Personas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApellidoCasada",
                table: "Personas",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MunicipioId1",
                table: "Personas",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaisNacimientoId1",
                table: "Personas",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Personas_MunicipioId1",
                table: "Personas",
                column: "MunicipioId1");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_PaisNacimientoId1",
                table: "Personas",
                column: "PaisNacimientoId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Municipios_MunicipioId1",
                table: "Personas",
                column: "MunicipioId1",
                principalTable: "Municipios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Paises_PaisNacimientoId1",
                table: "Personas",
                column: "PaisNacimientoId1",
                principalTable: "Paises",
                principalColumn: "Id");
        }
    }
}
