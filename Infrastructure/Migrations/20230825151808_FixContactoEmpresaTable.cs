using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class FixContactoEmpresaTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactosEmpresas_Ocupaciones_OcupacionId",
                table: "ContactosEmpresas");

            migrationBuilder.AlterColumn<int>(
                name: "OcupacionId",
                table: "ContactosEmpresas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactosEmpresas_Ocupaciones_OcupacionId",
                table: "ContactosEmpresas",
                column: "OcupacionId",
                principalTable: "Ocupaciones",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactosEmpresas_Ocupaciones_OcupacionId",
                table: "ContactosEmpresas");

            migrationBuilder.AlterColumn<int>(
                name: "OcupacionId",
                table: "ContactosEmpresas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactosEmpresas_Ocupaciones_OcupacionId",
                table: "ContactosEmpresas",
                column: "OcupacionId",
                principalTable: "Ocupaciones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
