using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class AddFieldCompanyPayrollLoan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmpresaPrestamoId",
                table: "Prestamos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_EmpresaPrestamoId",
                table: "Prestamos",
                column: "EmpresaPrestamoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prestamos_Entidades_EmpresaPrestamoId",
                table: "Prestamos",
                column: "EmpresaPrestamoId",
                principalTable: "Entidades",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prestamos_Entidades_EmpresaPrestamoId",
                table: "Prestamos");

            migrationBuilder.DropIndex(
                name: "IX_Prestamos_EmpresaPrestamoId",
                table: "Prestamos");

            migrationBuilder.DropColumn(
                name: "EmpresaPrestamoId",
                table: "Prestamos");
        }
    }
}
