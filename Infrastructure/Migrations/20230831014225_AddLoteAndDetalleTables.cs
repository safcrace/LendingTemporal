using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class AddLoteAndDetalleTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AprobacionCreditos",
                table: "Desembolsos",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AprobacionDireccion",
                table: "Desembolsos",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AprobacionGerencia",
                table: "Desembolsos",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LoteId",
                table: "Desembolsos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TieneLote",
                table: "Desembolsos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Lotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TotalCreditos = table.Column<byte>(type: "tinyint", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Habilitado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lotes_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DetalleLotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoteId = table.Column<int>(type: "int", nullable: false),
                    NombreEmisionCheque = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Documento = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Habilitado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleLotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetalleLotes_Lotes_LoteId",
                        column: x => x.LoteId,
                        principalTable: "Lotes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Desembolsos_LoteId",
                table: "Desembolsos",
                column: "LoteId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleLotes_LoteId",
                table: "DetalleLotes",
                column: "LoteId");

            migrationBuilder.CreateIndex(
                name: "IX_Lotes_AppUserId",
                table: "Lotes",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Desembolsos_Lotes_LoteId",
                table: "Desembolsos",
                column: "LoteId",
                principalTable: "Lotes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Desembolsos_Lotes_LoteId",
                table: "Desembolsos");

            migrationBuilder.DropTable(
                name: "DetalleLotes");

            migrationBuilder.DropTable(
                name: "Lotes");

            migrationBuilder.DropIndex(
                name: "IX_Desembolsos_LoteId",
                table: "Desembolsos");

            migrationBuilder.DropColumn(
                name: "AprobacionCreditos",
                table: "Desembolsos");

            migrationBuilder.DropColumn(
                name: "AprobacionDireccion",
                table: "Desembolsos");

            migrationBuilder.DropColumn(
                name: "AprobacionGerencia",
                table: "Desembolsos");

            migrationBuilder.DropColumn(
                name: "LoteId",
                table: "Desembolsos");

            migrationBuilder.DropColumn(
                name: "TieneLote",
                table: "Desembolsos");
        }
    }
}
