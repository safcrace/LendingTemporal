using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class AddFieldsPermisosAnalistaTipoPrestamoTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "MontoMaximoAnalista",
                table: "TipoPrestamos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MontoMinimoAnalista",
                table: "TipoPrestamos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "PermisosAnalista",
                table: "TipoPrestamos",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MontoMaximoAnalista",
                table: "TipoPrestamos");

            migrationBuilder.DropColumn(
                name: "MontoMinimoAnalista",
                table: "TipoPrestamos");

            migrationBuilder.DropColumn(
                name: "PermisosAnalista",
                table: "TipoPrestamos");
        }
    }
}
