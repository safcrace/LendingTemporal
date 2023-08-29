using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class AddFieldAnalistaToPrestamoTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AnalistaPrestamoId",
                table: "Prestamos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_AnalistaPrestamoId",
                table: "Prestamos",
                column: "AnalistaPrestamoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prestamos_Entidades_AnalistaPrestamoId",
                table: "Prestamos",
                column: "AnalistaPrestamoId",
                principalTable: "Entidades",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prestamos_Entidades_AnalistaPrestamoId",
                table: "Prestamos");

            migrationBuilder.DropIndex(
                name: "IX_Prestamos_AnalistaPrestamoId",
                table: "Prestamos");

            migrationBuilder.DropColumn(
                name: "AnalistaPrestamoId",
                table: "Prestamos");
        }
    }
}
