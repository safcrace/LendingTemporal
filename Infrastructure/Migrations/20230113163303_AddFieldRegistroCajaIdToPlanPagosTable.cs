using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class AddFieldRegistroCajaIdToPlanPagosTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RegistroCajaId",
                table: "PlanPagos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlanPagos_RegistroCajaId",
                table: "PlanPagos",
                column: "RegistroCajaId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlanPagos_RegistroCajas_RegistroCajaId",
                table: "PlanPagos",
                column: "RegistroCajaId",
                principalTable: "RegistroCajas",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlanPagos_RegistroCajas_RegistroCajaId",
                table: "PlanPagos");

            migrationBuilder.DropIndex(
                name: "IX_PlanPagos_RegistroCajaId",
                table: "PlanPagos");

            migrationBuilder.DropColumn(
                name: "RegistroCajaId",
                table: "PlanPagos");
        }
    }
}
