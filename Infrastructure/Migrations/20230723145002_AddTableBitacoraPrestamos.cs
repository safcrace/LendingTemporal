using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class AddTableBitacoraPrestamos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entidades_TipoEntidad_TipoEntidadId",
                table: "Entidades");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TipoEntidad",
                table: "TipoEntidad");

            migrationBuilder.RenameTable(
                name: "TipoEntidad",
                newName: "TipoEntidades");

            migrationBuilder.AlterColumn<string>(
                name: "Alias",
                table: "Empresas",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TipoEntidades",
                table: "TipoEntidades",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "BitacoraPrestamos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrestamoId = table.Column<int>(type: "int", nullable: false),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Comentarios = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    TimeInStatus = table.Column<byte>(type: "tinyint", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Habilitado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BitacoraPrestamos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BitacoraPrestamos_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BitacoraPrestamos_Prestamos_PrestamoId",
                        column: x => x.PrestamoId,
                        principalTable: "Prestamos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BitacoraPrestamos_AppUserId",
                table: "BitacoraPrestamos",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BitacoraPrestamos_PrestamoId",
                table: "BitacoraPrestamos",
                column: "PrestamoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Entidades_TipoEntidades_TipoEntidadId",
                table: "Entidades",
                column: "TipoEntidadId",
                principalTable: "TipoEntidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entidades_TipoEntidades_TipoEntidadId",
                table: "Entidades");

            migrationBuilder.DropTable(
                name: "BitacoraPrestamos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TipoEntidades",
                table: "TipoEntidades");

            migrationBuilder.RenameTable(
                name: "TipoEntidades",
                newName: "TipoEntidad");

            migrationBuilder.AlterColumn<string>(
                name: "Alias",
                table: "Empresas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TipoEntidad",
                table: "TipoEntidad",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Entidades_TipoEntidad_TipoEntidadId",
                table: "Entidades",
                column: "TipoEntidadId",
                principalTable: "TipoEntidad",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
