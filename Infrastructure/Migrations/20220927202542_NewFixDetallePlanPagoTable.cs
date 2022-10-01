using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class NewFixDetallePlanPagoTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Saldo",
                table: "DetallePlanPagoTemporales",
                newName: "SaldoCapital");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SaldoCapital",
                table: "DetallePlanPagoTemporales",
                newName: "Saldo");
        }
    }
}
