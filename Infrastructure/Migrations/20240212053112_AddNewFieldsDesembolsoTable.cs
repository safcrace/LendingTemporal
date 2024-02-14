using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class AddNewFieldsDesembolsoTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Desembolsado",
                table: "DetalleDesembolsos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Desembolsado",
                table: "Desembolsos",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Desembolsado",
                table: "DetalleDesembolsos");

            migrationBuilder.DropColumn(
                name: "Desembolsado",
                table: "Desembolsos");
        }
    }
}
