using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class TablesConfigurationSid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CarpetaSidId",
                table: "Prestamos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AreaId",
                table: "Personas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ExpedienteSidId",
                table: "Entidades",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ArchivosPrestamo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrestamoId = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    DocumentoSidId = table.Column<int>(type: "int", nullable: false),
                    NombreDocumentoSid = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Habilitado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArchivosPrestamo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArchivosPrestamo_Prestamos_PrestamoId",
                        column: x => x.PrestamoId,
                        principalTable: "Prestamos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Habilitado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AreaPersonas",
                columns: table => new
                {
                    AreaId = table.Column<int>(type: "int", nullable: false),
                    PersonaId = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaPersonas", x => new { x.AreaId, x.PersonaId });
                    table.ForeignKey(
                        name: "FK_AreaPersonas_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AreaPersonas_Personas_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Personas_AreaId",
                table: "Personas",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_ArchivosPrestamo_PrestamoId",
                table: "ArchivosPrestamo",
                column: "PrestamoId");

            migrationBuilder.CreateIndex(
                name: "IX_AreaPersonas_PersonaId",
                table: "AreaPersonas",
                column: "PersonaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Areas_AreaId",
                table: "Personas",
                column: "AreaId",
                principalTable: "Areas",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Areas_AreaId",
                table: "Personas");

            migrationBuilder.DropTable(
                name: "ArchivosPrestamo");

            migrationBuilder.DropTable(
                name: "AreaPersonas");

            migrationBuilder.DropTable(
                name: "Areas");

            migrationBuilder.DropIndex(
                name: "IX_Personas_AreaId",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "CarpetaSidId",
                table: "Prestamos");

            migrationBuilder.DropColumn(
                name: "AreaId",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "ExpedienteSidId",
                table: "Entidades");
        }
    }
}
