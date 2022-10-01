using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class fixEstadoCuentaTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EstadoCuentas_RegistroCajas_RegistroCajaId",
                table: "EstadoCuentas");

            migrationBuilder.AlterColumn<int>(
                name: "RegistroCajaId",
                table: "EstadoCuentas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_EstadoCuentas_RegistroCajas_RegistroCajaId",
                table: "EstadoCuentas",
                column: "RegistroCajaId",
                principalTable: "RegistroCajas",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EstadoCuentas_RegistroCajas_RegistroCajaId",
                table: "EstadoCuentas");

            migrationBuilder.AlterColumn<int>(
                name: "RegistroCajaId",
                table: "EstadoCuentas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EstadoCuentas_RegistroCajas_RegistroCajaId",
                table: "EstadoCuentas",
                column: "RegistroCajaId",
                principalTable: "RegistroCajas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
