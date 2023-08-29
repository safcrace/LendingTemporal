using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class FixBitacoraFichaTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BitacoraPersonas");

            migrationBuilder.CreateTable(
                name: "BitacoraFichas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntidadId = table.Column<int>(type: "int", nullable: true),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AppUserAuthorizedId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Comentarios = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Habilitado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BitacoraFichas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BitacoraFichas_AspNetUsers_AppUserAuthorizedId",
                        column: x => x.AppUserAuthorizedId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BitacoraFichas_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BitacoraFichas_Entidades_EntidadId",
                        column: x => x.EntidadId,
                        principalTable: "Entidades",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BitacoraFichas_AppUserAuthorizedId",
                table: "BitacoraFichas",
                column: "AppUserAuthorizedId");

            migrationBuilder.CreateIndex(
                name: "IX_BitacoraFichas_AppUserId",
                table: "BitacoraFichas",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BitacoraFichas_EntidadId",
                table: "BitacoraFichas",
                column: "EntidadId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BitacoraFichas");

            migrationBuilder.CreateTable(
                name: "BitacoraPersonas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserAuthorizedId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PersonaId = table.Column<int>(type: "int", nullable: false),
                    Comentarios = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Habilitado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BitacoraPersonas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BitacoraPersonas_AspNetUsers_AppUserAuthorizedId",
                        column: x => x.AppUserAuthorizedId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BitacoraPersonas_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BitacoraPersonas_Personas_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BitacoraPersonas_AppUserAuthorizedId",
                table: "BitacoraPersonas",
                column: "AppUserAuthorizedId");

            migrationBuilder.CreateIndex(
                name: "IX_BitacoraPersonas_AppUserId",
                table: "BitacoraPersonas",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BitacoraPersonas_PersonaId",
                table: "BitacoraPersonas",
                column: "PersonaId");
        }
    }
}
