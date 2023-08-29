using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class FixTableTipoReferencias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReferenciasPersonas_TipoReferencia_TipoReferenciaId",
                table: "ReferenciasPersonas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TipoReferencia",
                table: "TipoReferencia");

            migrationBuilder.RenameTable(
                name: "TipoReferencia",
                newName: "TipoReferencias");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TipoReferencias",
                table: "TipoReferencias",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReferenciasPersonas_TipoReferencias_TipoReferenciaId",
                table: "ReferenciasPersonas",
                column: "TipoReferenciaId",
                principalTable: "TipoReferencias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReferenciasPersonas_TipoReferencias_TipoReferenciaId",
                table: "ReferenciasPersonas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TipoReferencias",
                table: "TipoReferencias");

            migrationBuilder.RenameTable(
                name: "TipoReferencias",
                newName: "TipoReferencia");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TipoReferencia",
                table: "TipoReferencia",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReferenciasPersonas_TipoReferencia_TipoReferenciaId",
                table: "ReferenciasPersonas",
                column: "TipoReferenciaId",
                principalTable: "TipoReferencia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
