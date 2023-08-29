using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class FixTablePersonas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SegmentoNegocioId",
                table: "Personas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubSegmentoNegocioId",
                table: "Personas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Personas_SegmentoNegocioId",
                table: "Personas",
                column: "SegmentoNegocioId");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_SubSegmentoNegocioId",
                table: "Personas",
                column: "SubSegmentoNegocioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_SegmentoNegocios_SegmentoNegocioId",
                table: "Personas",
                column: "SegmentoNegocioId",
                principalTable: "SegmentoNegocios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_SubSegmentoNegocios_SubSegmentoNegocioId",
                table: "Personas",
                column: "SubSegmentoNegocioId",
                principalTable: "SubSegmentoNegocios",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personas_SegmentoNegocios_SegmentoNegocioId",
                table: "Personas");

            migrationBuilder.DropForeignKey(
                name: "FK_Personas_SubSegmentoNegocios_SubSegmentoNegocioId",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_Personas_SegmentoNegocioId",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_Personas_SubSegmentoNegocioId",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "SegmentoNegocioId",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "SubSegmentoNegocioId",
                table: "Personas");
        }
    }
}
