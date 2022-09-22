using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class FixEstadoCuentaTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EstadoCuenta_AspNetUsers_AppUserId",
                table: "EstadoCuenta");

            migrationBuilder.DropForeignKey(
                name: "FK_EstadoCuenta_Prestamos_PrestamoId",
                table: "EstadoCuenta");

            migrationBuilder.DropForeignKey(
                name: "FK_EstadoCuenta_TipoTransaccion_TipoTransaccionId",
                table: "EstadoCuenta");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EstadoCuenta",
                table: "EstadoCuenta");

            migrationBuilder.RenameTable(
                name: "EstadoCuenta",
                newName: "EstadoCuentas");

            migrationBuilder.RenameIndex(
                name: "IX_EstadoCuenta_TipoTransaccionId",
                table: "EstadoCuentas",
                newName: "IX_EstadoCuentas_TipoTransaccionId");

            migrationBuilder.RenameIndex(
                name: "IX_EstadoCuenta_PrestamoId",
                table: "EstadoCuentas",
                newName: "IX_EstadoCuentas_PrestamoId");

            migrationBuilder.RenameIndex(
                name: "IX_EstadoCuenta_AppUserId",
                table: "EstadoCuentas",
                newName: "IX_EstadoCuentas_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EstadoCuentas",
                table: "EstadoCuentas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EstadoCuentas_AspNetUsers_AppUserId",
                table: "EstadoCuentas",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EstadoCuentas_Prestamos_PrestamoId",
                table: "EstadoCuentas",
                column: "PrestamoId",
                principalTable: "Prestamos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EstadoCuentas_TipoTransaccion_TipoTransaccionId",
                table: "EstadoCuentas",
                column: "TipoTransaccionId",
                principalTable: "TipoTransaccion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EstadoCuentas_AspNetUsers_AppUserId",
                table: "EstadoCuentas");

            migrationBuilder.DropForeignKey(
                name: "FK_EstadoCuentas_Prestamos_PrestamoId",
                table: "EstadoCuentas");

            migrationBuilder.DropForeignKey(
                name: "FK_EstadoCuentas_TipoTransaccion_TipoTransaccionId",
                table: "EstadoCuentas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EstadoCuentas",
                table: "EstadoCuentas");

            migrationBuilder.RenameTable(
                name: "EstadoCuentas",
                newName: "EstadoCuenta");

            migrationBuilder.RenameIndex(
                name: "IX_EstadoCuentas_TipoTransaccionId",
                table: "EstadoCuenta",
                newName: "IX_EstadoCuenta_TipoTransaccionId");

            migrationBuilder.RenameIndex(
                name: "IX_EstadoCuentas_PrestamoId",
                table: "EstadoCuenta",
                newName: "IX_EstadoCuenta_PrestamoId");

            migrationBuilder.RenameIndex(
                name: "IX_EstadoCuentas_AppUserId",
                table: "EstadoCuenta",
                newName: "IX_EstadoCuenta_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EstadoCuenta",
                table: "EstadoCuenta",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EstadoCuenta_AspNetUsers_AppUserId",
                table: "EstadoCuenta",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EstadoCuenta_Prestamos_PrestamoId",
                table: "EstadoCuenta",
                column: "PrestamoId",
                principalTable: "Prestamos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EstadoCuenta_TipoTransaccion_TipoTransaccionId",
                table: "EstadoCuenta",
                column: "TipoTransaccionId",
                principalTable: "TipoTransaccion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
