using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class AddFieldTipoViviendaToPersonaTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipoViviendaId",
                table: "Personas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Personas_TipoViviendaId",
                table: "Personas",
                column: "TipoViviendaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_TiposVivienda_TipoViviendaId",
                table: "Personas",
                column: "TipoViviendaId",
                principalTable: "TiposVivienda",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personas_TiposVivienda_TipoViviendaId",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_Personas_TipoViviendaId",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "TipoViviendaId",
                table: "Personas");
        }
    }
}
