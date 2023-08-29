using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class FixFieldsAndTablesForPreevaluacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Ocupaciones_OcupacionSinFinId",
                table: "Personas");

            migrationBuilder.DropForeignKey(
                name: "FK_Prestamos_DestinoPrestamos_DestinoPrestamoId",
                table: "Prestamos");

            migrationBuilder.DropForeignKey(
                name: "FK_Prestamos_TipoPrestamos_TipoPrestamoId",
                table: "Prestamos");

            migrationBuilder.AlterColumn<int>(
                name: "TipoPrestamoId",
                table: "Prestamos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DestinoPrestamoId",
                table: "Prestamos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Telefono",
                table: "Empresas",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Empresas",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Alias",
                table: "Empresas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_OcupacionSinFin_OcupacionSinFinId",
                table: "Personas",
                column: "OcupacionSinFinId",
                principalTable: "OcupacionSinFin",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Prestamos_DestinoPrestamos_DestinoPrestamoId",
                table: "Prestamos",
                column: "DestinoPrestamoId",
                principalTable: "DestinoPrestamos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Prestamos_TipoPrestamos_TipoPrestamoId",
                table: "Prestamos",
                column: "TipoPrestamoId",
                principalTable: "TipoPrestamos",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personas_OcupacionSinFin_OcupacionSinFinId",
                table: "Personas");

            migrationBuilder.DropForeignKey(
                name: "FK_Prestamos_DestinoPrestamos_DestinoPrestamoId",
                table: "Prestamos");

            migrationBuilder.DropForeignKey(
                name: "FK_Prestamos_TipoPrestamos_TipoPrestamoId",
                table: "Prestamos");

            migrationBuilder.AlterColumn<int>(
                name: "TipoPrestamoId",
                table: "Prestamos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DestinoPrestamoId",
                table: "Prestamos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Telefono",
                table: "Empresas",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Empresas",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Alias",
                table: "Empresas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Ocupaciones_OcupacionSinFinId",
                table: "Personas",
                column: "OcupacionSinFinId",
                principalTable: "Ocupaciones",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Prestamos_DestinoPrestamos_DestinoPrestamoId",
                table: "Prestamos",
                column: "DestinoPrestamoId",
                principalTable: "DestinoPrestamos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prestamos_TipoPrestamos_TipoPrestamoId",
                table: "Prestamos",
                column: "TipoPrestamoId",
                principalTable: "TipoPrestamos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
