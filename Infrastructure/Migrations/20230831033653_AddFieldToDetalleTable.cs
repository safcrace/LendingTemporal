using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class AddFieldToDetalleTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Aprobado",
                table: "Lotes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "TipoLote",
                table: "Lotes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Aprobado",
                table: "DetalleLotes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "SolicitudId",
                table: "DetalleLotes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Aprobado",
                table: "Lotes");

            migrationBuilder.DropColumn(
                name: "TipoLote",
                table: "Lotes");

            migrationBuilder.DropColumn(
                name: "Aprobado",
                table: "DetalleLotes");

            migrationBuilder.DropColumn(
                name: "SolicitudId",
                table: "DetalleLotes");
        }
    }
}
