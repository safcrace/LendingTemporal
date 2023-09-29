using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class AddFieldToDetallePlanPagoTemporalTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PrestamoId",
                table: "DetallePlanPagoTemporales",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DetallePlanPagoTemporales_PrestamoId",
                table: "DetallePlanPagoTemporales",
                column: "PrestamoId");

            migrationBuilder.AddForeignKey(
                name: "FK_DetallePlanPagoTemporales_Prestamos_PrestamoId",
                table: "DetallePlanPagoTemporales",
                column: "PrestamoId",
                principalTable: "Prestamos",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetallePlanPagoTemporales_Prestamos_PrestamoId",
                table: "DetallePlanPagoTemporales");

            migrationBuilder.DropIndex(
                name: "IX_DetallePlanPagoTemporales_PrestamoId",
                table: "DetallePlanPagoTemporales");

            migrationBuilder.DropColumn(
                name: "PrestamoId",
                table: "DetallePlanPagoTemporales");
        }
    }
}
