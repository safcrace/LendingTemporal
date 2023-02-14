using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class PaisRelationshipWithDepartamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PaisId",
                table: "Departamentos",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Departamentos_PaisId",
                table: "Departamentos",
                column: "PaisId");

            migrationBuilder.AddForeignKey(
                name: "FK_Departamentos_Paises_PaisId",
                table: "Departamentos",
                column: "PaisId",
                principalTable: "Paises",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departamentos_Paises_PaisId",
                table: "Departamentos");

            migrationBuilder.DropIndex(
                name: "IX_Departamentos_PaisId",
                table: "Departamentos");

            migrationBuilder.DropColumn(
                name: "PaisId",
                table: "Departamentos");
        }
    }
}
