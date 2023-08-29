using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class AddBitacoraPersonaTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prestamos_OrigenIngresos_OrigenIngresosId",
                table: "Prestamos");

            migrationBuilder.DropTable(
                name: "OrigenIngresos");

            migrationBuilder.DropIndex(
                name: "IX_Prestamos_OrigenIngresosId",
                table: "Prestamos");

            migrationBuilder.DropColumn(
                name: "OrigenIngresosId",
                table: "Prestamos");

            migrationBuilder.DropColumn(
                name: "OtrosIngresos",
                table: "Prestamos");

            migrationBuilder.AddColumn<string>(
                name: "OrigenOtrosIngresos",
                table: "Personas",
                type: "nvarchar(75)",
                maxLength: 75,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "OtrosIngresos",
                table: "Personas",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "BitacoraPersonas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonaId = table.Column<int>(type: "int", nullable: false),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AppUserAuthorizedId = table.Column<string>(type: "nvarchar(450)", nullable: true),
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
                name: "IX_Personas_NIT",
                table: "Personas",
                column: "NIT",
                unique: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BitacoraPersonas");

            migrationBuilder.DropIndex(
                name: "IX_Personas_NIT",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "OrigenOtrosIngresos",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "OtrosIngresos",
                table: "Personas");

            migrationBuilder.AddColumn<int>(
                name: "OrigenIngresosId",
                table: "Prestamos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "OtrosIngresos",
                table: "Prestamos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "OrigenIngresos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Habilitado = table.Column<bool>(type: "bit", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrigenIngresos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_OrigenIngresosId",
                table: "Prestamos",
                column: "OrigenIngresosId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prestamos_OrigenIngresos_OrigenIngresosId",
                table: "Prestamos",
                column: "OrigenIngresosId",
                principalTable: "OrigenIngresos",
                principalColumn: "Id");
        }
    }
}
