using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class AddMotivoRechazoTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MotivoRechazoId",
                table: "Prestamos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MotivosRechazo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Habilitado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotivosRechazo", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_MotivoRechazoId",
                table: "Prestamos",
                column: "MotivoRechazoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prestamos_MotivosRechazo_MotivoRechazoId",
                table: "Prestamos",
                column: "MotivoRechazoId",
                principalTable: "MotivosRechazo",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prestamos_MotivosRechazo_MotivoRechazoId",
                table: "Prestamos");

            migrationBuilder.DropTable(
                name: "MotivosRechazo");

            migrationBuilder.DropIndex(
                name: "IX_Prestamos_MotivoRechazoId",
                table: "Prestamos");

            migrationBuilder.DropColumn(
                name: "MotivoRechazoId",
                table: "Prestamos");
        }
    }
}
