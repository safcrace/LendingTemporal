using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class AddNewFieldsToPersonaTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nombres",
                table: "Personas",
                newName: "SegundoApellido");

            migrationBuilder.RenameColumn(
                name: "Apellidos",
                table: "Personas",
                newName: "PrimerNombre");

            migrationBuilder.AddColumn<string>(
                name: "Colonia",
                table: "Personas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Comentarios",
                table: "Personas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DepartamentoId",
                table: "Personas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MunicipioId",
                table: "Personas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MunicipioId1",
                table: "Personas",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NumeroCelular",
                table: "Personas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NumeroTelefonoLaboral",
                table: "Personas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OcupacionId",
                table: "Personas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PaisNacimientoId",
                table: "Personas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaisNacimientoId1",
                table: "Personas",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrimerApellido",
                table: "Personas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SegundoNombre",
                table: "Personas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Ocupaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Habilitado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ocupaciones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposVivienda",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Habilitado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposVivienda", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Personas_DepartamentoId",
                table: "Personas",
                column: "DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_MunicipioId1",
                table: "Personas",
                column: "MunicipioId1");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_OcupacionId",
                table: "Personas",
                column: "OcupacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_PaisNacimientoId1",
                table: "Personas",
                column: "PaisNacimientoId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Departamentos_DepartamentoId",
                table: "Personas",
                column: "DepartamentoId",
                principalTable: "Departamentos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Municipios_MunicipioId1",
                table: "Personas",
                column: "MunicipioId1",
                principalTable: "Municipios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Ocupaciones_OcupacionId",
                table: "Personas",
                column: "OcupacionId",
                principalTable: "Ocupaciones",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Paises_PaisNacimientoId1",
                table: "Personas",
                column: "PaisNacimientoId1",
                principalTable: "Paises",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Departamentos_DepartamentoId",
                table: "Personas");

            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Municipios_MunicipioId1",
                table: "Personas");

            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Ocupaciones_OcupacionId",
                table: "Personas");

            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Paises_PaisNacimientoId1",
                table: "Personas");

            migrationBuilder.DropTable(
                name: "Ocupaciones");

            migrationBuilder.DropTable(
                name: "TiposVivienda");

            migrationBuilder.DropIndex(
                name: "IX_Personas_DepartamentoId",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_Personas_MunicipioId1",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_Personas_OcupacionId",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_Personas_PaisNacimientoId1",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "Colonia",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "Comentarios",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "DepartamentoId",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "MunicipioId",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "MunicipioId1",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "NumeroCelular",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "NumeroTelefonoLaboral",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "OcupacionId",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "PaisNacimientoId",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "PaisNacimientoId1",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "PrimerApellido",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "SegundoNombre",
                table: "Personas");

            migrationBuilder.RenameColumn(
                name: "SegundoApellido",
                table: "Personas",
                newName: "Nombres");

            migrationBuilder.RenameColumn(
                name: "PrimerNombre",
                table: "Personas",
                newName: "Apellidos");
        }
    }
}
