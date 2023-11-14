using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class AddFieldComentarioToReferenciasTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Comentario",
                table: "ReferenciasPersonas",
                type: "nvarchar(800)",
                maxLength: 800,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Comentario",
                table: "ReferenciasEmpresas",
                type: "nvarchar(800)",
                maxLength: 800,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comentario",
                table: "ReferenciasPersonas");

            migrationBuilder.DropColumn(
                name: "Comentario",
                table: "ReferenciasEmpresas");
        }
    }
}
