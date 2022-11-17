using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class AddEstadoOrigenTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EstadoOrigenId",
                table: "Prestamos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EstadosOrigen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Habilitado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadosOrigen", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_EstadoOrigenId",
                table: "Prestamos",
                column: "EstadoOrigenId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prestamos_EstadosOrigen_EstadoOrigenId",
                table: "Prestamos",
                column: "EstadoOrigenId",
                principalTable: "EstadosOrigen",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prestamos_EstadosOrigen_EstadoOrigenId",
                table: "Prestamos");

            migrationBuilder.DropTable(
                name: "EstadosOrigen");

            migrationBuilder.DropIndex(
                name: "IX_Prestamos_EstadoOrigenId",
                table: "Prestamos");

            migrationBuilder.DropColumn(
                name: "EstadoOrigenId",
                table: "Prestamos");
        }
    }
}
