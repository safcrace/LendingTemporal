using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class FixTableBitacoraPrestamos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EstadoPrestamoId",
                table: "BitacoraPrestamos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NuevoEstadoPrestamoId",
                table: "BitacoraPrestamos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ListadoProspectos",
                columns: table => new
                {
                    SolicitudId = table.Column<int>(type: "int", nullable: false),
                    TipoEntidadId = table.Column<int>(type: "int", nullable: false),
                    TipoEntidad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaIngreso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NombreProspecto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DPI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NIT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CanalId = table.Column<int>(type: "int", nullable: false),
                    CanalNombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstadoPrestamoId = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GestorAsignadoId = table.Column<int>(type: "int", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TiempoEnEstado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateIndex(
                name: "IX_BitacoraPrestamos_EstadoPrestamoId",
                table: "BitacoraPrestamos",
                column: "EstadoPrestamoId");

            migrationBuilder.CreateIndex(
                name: "IX_BitacoraPrestamos_NuevoEstadoPrestamoId",
                table: "BitacoraPrestamos",
                column: "NuevoEstadoPrestamoId");

            migrationBuilder.AddForeignKey(
                name: "FK_BitacoraPrestamos_EstadoPrestamos_EstadoPrestamoId",
                table: "BitacoraPrestamos",
                column: "EstadoPrestamoId",
                principalTable: "EstadoPrestamos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BitacoraPrestamos_EstadoPrestamos_NuevoEstadoPrestamoId",
                table: "BitacoraPrestamos",
                column: "NuevoEstadoPrestamoId",
                principalTable: "EstadoPrestamos",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BitacoraPrestamos_EstadoPrestamos_EstadoPrestamoId",
                table: "BitacoraPrestamos");

            migrationBuilder.DropForeignKey(
                name: "FK_BitacoraPrestamos_EstadoPrestamos_NuevoEstadoPrestamoId",
                table: "BitacoraPrestamos");

            migrationBuilder.DropTable(
                name: "ListadoProspectos");

            migrationBuilder.DropIndex(
                name: "IX_BitacoraPrestamos_EstadoPrestamoId",
                table: "BitacoraPrestamos");

            migrationBuilder.DropIndex(
                name: "IX_BitacoraPrestamos_NuevoEstadoPrestamoId",
                table: "BitacoraPrestamos");

            migrationBuilder.DropColumn(
                name: "EstadoPrestamoId",
                table: "BitacoraPrestamos");

            migrationBuilder.DropColumn(
                name: "NuevoEstadoPrestamoId",
                table: "BitacoraPrestamos");
        }
    }
}
