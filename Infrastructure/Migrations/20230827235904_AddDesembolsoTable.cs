using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class AddDesembolsoTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MediosDesembolso",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Habilitado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediosDesembolso", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposCuenta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Habilitado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposCuenta", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Desembolsos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PrestamoId = table.Column<int>(type: "int", nullable: true),
                    BancoId = table.Column<int>(type: "int", nullable: true),
                    MedioDesembolsoId = table.Column<int>(type: "int", nullable: true),
                    TipoCuentaId = table.Column<int>(type: "int", nullable: true),
                    NumeroCuenta = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    NombreEmisionCheque = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CantidadDesembolso = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Habilitado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desembolsos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Desembolsos_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Desembolsos_Bancos_BancoId",
                        column: x => x.BancoId,
                        principalTable: "Bancos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Desembolsos_MediosDesembolso_MedioDesembolsoId",
                        column: x => x.MedioDesembolsoId,
                        principalTable: "MediosDesembolso",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Desembolsos_Prestamos_PrestamoId",
                        column: x => x.PrestamoId,
                        principalTable: "Prestamos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Desembolsos_TiposCuenta_TipoCuentaId",
                        column: x => x.TipoCuentaId,
                        principalTable: "TiposCuenta",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Desembolsos_AppUserId",
                table: "Desembolsos",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Desembolsos_BancoId",
                table: "Desembolsos",
                column: "BancoId");

            migrationBuilder.CreateIndex(
                name: "IX_Desembolsos_MedioDesembolsoId",
                table: "Desembolsos",
                column: "MedioDesembolsoId");

            migrationBuilder.CreateIndex(
                name: "IX_Desembolsos_PrestamoId",
                table: "Desembolsos",
                column: "PrestamoId");

            migrationBuilder.CreateIndex(
                name: "IX_Desembolsos_TipoCuentaId",
                table: "Desembolsos",
                column: "TipoCuentaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Desembolsos");

            migrationBuilder.DropTable(
                name: "MediosDesembolso");

            migrationBuilder.DropTable(
                name: "TiposCuenta");
        }
    }
}
