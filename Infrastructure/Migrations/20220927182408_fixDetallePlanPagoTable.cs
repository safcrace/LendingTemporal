using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class fixDetallePlanPagoTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CuotaIva",
                table: "DetallePlanPagoTemporales",
                newName: "CuotaIvaIntereses");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CuotaIvaIntereses",
                table: "DetallePlanPagoTemporales",
                newName: "CuotaIva");
        }
    }
}
