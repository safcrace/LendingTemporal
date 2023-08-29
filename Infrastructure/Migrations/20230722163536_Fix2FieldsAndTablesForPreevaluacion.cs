using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class Fix2FieldsAndTablesForPreevaluacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SegmentoNegocioId",
                table: "Empresas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubSegmentoNegocioId",
                table: "Empresas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_SegmentoNegocioId",
                table: "Empresas",
                column: "SegmentoNegocioId");

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_SubSegmentoNegocioId",
                table: "Empresas",
                column: "SubSegmentoNegocioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Empresas_SegmentoNegocios_SegmentoNegocioId",
                table: "Empresas",
                column: "SegmentoNegocioId",
                principalTable: "SegmentoNegocios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Empresas_SubSegmentoNegocios_SubSegmentoNegocioId",
                table: "Empresas",
                column: "SubSegmentoNegocioId",
                principalTable: "SubSegmentoNegocios",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empresas_SegmentoNegocios_SegmentoNegocioId",
                table: "Empresas");

            migrationBuilder.DropForeignKey(
                name: "FK_Empresas_SubSegmentoNegocios_SubSegmentoNegocioId",
                table: "Empresas");

            migrationBuilder.DropIndex(
                name: "IX_Empresas_SegmentoNegocioId",
                table: "Empresas");

            migrationBuilder.DropIndex(
                name: "IX_Empresas_SubSegmentoNegocioId",
                table: "Empresas");

            migrationBuilder.DropColumn(
                name: "SegmentoNegocioId",
                table: "Empresas");

            migrationBuilder.DropColumn(
                name: "SubSegmentoNegocioId",
                table: "Empresas");
        }
    }
}
