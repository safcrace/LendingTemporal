using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class AddDetalleDesembolsosTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Desembolsos_Bancos_BancoId",
                table: "Desembolsos");

            migrationBuilder.DropForeignKey(
                name: "FK_Desembolsos_Lotes_LoteId",
                table: "Desembolsos");

            migrationBuilder.DropForeignKey(
                name: "FK_Desembolsos_MediosDesembolso_MedioDesembolsoId",
                table: "Desembolsos");

            migrationBuilder.DropForeignKey(
                name: "FK_Desembolsos_TiposCuenta_TipoCuentaId",
                table: "Desembolsos");

            migrationBuilder.DropIndex(
                name: "IX_Desembolsos_BancoId",
                table: "Desembolsos");

            migrationBuilder.DropIndex(
                name: "IX_Desembolsos_LoteId",
                table: "Desembolsos");

            migrationBuilder.DropIndex(
                name: "IX_Desembolsos_MedioDesembolsoId",
                table: "Desembolsos");

            migrationBuilder.DropIndex(
                name: "IX_Desembolsos_TipoCuentaId",
                table: "Desembolsos");

            migrationBuilder.DropColumn(
                name: "BancoId",
                table: "Desembolsos");

            migrationBuilder.DropColumn(
                name: "LoteId",
                table: "Desembolsos");

            migrationBuilder.DropColumn(
                name: "MedioDesembolsoId",
                table: "Desembolsos");

            migrationBuilder.DropColumn(
                name: "NombreEmisionCheque",
                table: "Desembolsos");

            migrationBuilder.DropColumn(
                name: "NumeroCuenta",
                table: "Desembolsos");

            migrationBuilder.DropColumn(
                name: "TieneLote",
                table: "Desembolsos");

            migrationBuilder.DropColumn(
                name: "TipoCuentaId",
                table: "Desembolsos");

            migrationBuilder.RenameColumn(
                name: "CantidadDesembolso",
                table: "Desembolsos",
                newName: "MontoDesembolso");

            migrationBuilder.CreateTable(
                name: "DetalleDesembolsos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DesembolsoId = table.Column<int>(type: "int", nullable: false),
                    BancoId = table.Column<int>(type: "int", nullable: true),
                    MedioDesembolsoId = table.Column<int>(type: "int", nullable: true),
                    TipoCuentaId = table.Column<int>(type: "int", nullable: true),
                    LoteId = table.Column<int>(type: "int", nullable: true),
                    NumeroCuenta = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    NombreEmisionCheque = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CantidadDesembolso = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Comentario = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TieneLote = table.Column<bool>(type: "bit", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Habilitado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleDesembolsos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetalleDesembolsos_Bancos_BancoId",
                        column: x => x.BancoId,
                        principalTable: "Bancos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DetalleDesembolsos_Desembolsos_DesembolsoId",
                        column: x => x.DesembolsoId,
                        principalTable: "Desembolsos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleDesembolsos_Lotes_LoteId",
                        column: x => x.LoteId,
                        principalTable: "Lotes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DetalleDesembolsos_MediosDesembolso_MedioDesembolsoId",
                        column: x => x.MedioDesembolsoId,
                        principalTable: "MediosDesembolso",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DetalleDesembolsos_TiposCuenta_TipoCuentaId",
                        column: x => x.TipoCuentaId,
                        principalTable: "TiposCuenta",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Entrevistas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrestamoId = table.Column<int>(type: "int", nullable: true),
                    Texto = table.Column<string>(type: "nvarchar(max)", maxLength: 25000, nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Habilitado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entrevistas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Entrevistas_Prestamos_PrestamoId",
                        column: x => x.PrestamoId,
                        principalTable: "Prestamos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetalleDesembolsos_BancoId",
                table: "DetalleDesembolsos",
                column: "BancoId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleDesembolsos_DesembolsoId",
                table: "DetalleDesembolsos",
                column: "DesembolsoId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleDesembolsos_LoteId",
                table: "DetalleDesembolsos",
                column: "LoteId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleDesembolsos_MedioDesembolsoId",
                table: "DetalleDesembolsos",
                column: "MedioDesembolsoId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleDesembolsos_TipoCuentaId",
                table: "DetalleDesembolsos",
                column: "TipoCuentaId");

            migrationBuilder.CreateIndex(
                name: "IX_Entrevistas_PrestamoId",
                table: "Entrevistas",
                column: "PrestamoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalleDesembolsos");

            migrationBuilder.DropTable(
                name: "Entrevistas");

            migrationBuilder.RenameColumn(
                name: "MontoDesembolso",
                table: "Desembolsos",
                newName: "CantidadDesembolso");

            migrationBuilder.AddColumn<int>(
                name: "BancoId",
                table: "Desembolsos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LoteId",
                table: "Desembolsos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MedioDesembolsoId",
                table: "Desembolsos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NombreEmisionCheque",
                table: "Desembolsos",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NumeroCuenta",
                table: "Desembolsos",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TieneLote",
                table: "Desembolsos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "TipoCuentaId",
                table: "Desembolsos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Desembolsos_BancoId",
                table: "Desembolsos",
                column: "BancoId");

            migrationBuilder.CreateIndex(
                name: "IX_Desembolsos_LoteId",
                table: "Desembolsos",
                column: "LoteId");

            migrationBuilder.CreateIndex(
                name: "IX_Desembolsos_MedioDesembolsoId",
                table: "Desembolsos",
                column: "MedioDesembolsoId");

            migrationBuilder.CreateIndex(
                name: "IX_Desembolsos_TipoCuentaId",
                table: "Desembolsos",
                column: "TipoCuentaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Desembolsos_Bancos_BancoId",
                table: "Desembolsos",
                column: "BancoId",
                principalTable: "Bancos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Desembolsos_Lotes_LoteId",
                table: "Desembolsos",
                column: "LoteId",
                principalTable: "Lotes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Desembolsos_MediosDesembolso_MedioDesembolsoId",
                table: "Desembolsos",
                column: "MedioDesembolsoId",
                principalTable: "MediosDesembolso",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Desembolsos_TiposCuenta_TipoCuentaId",
                table: "Desembolsos",
                column: "TipoCuentaId",
                principalTable: "TiposCuenta",
                principalColumn: "Id");
        }
    }
}
