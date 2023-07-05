using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class RegionDocumentosPrestamoTipoPrestamoChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "DisponibleOrganizaciones",
                table: "TipoPrestamos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DisponiblePersonas",
                table: "TipoPrestamos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "MonedaId",
                table: "TipoPrestamos",
                type: "int",
                nullable: true,
                defaultValue: 1);

            migrationBuilder.AddColumn<bool>(
                name: "ParametrosGeneral",
                table: "TipoPrestamos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ParametrosRegional",
                table: "TipoPrestamos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TasInteresVariable",
                table: "TipoPrestamos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TasaInteresFija",
                table: "TipoPrestamos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TasaInteresGeneral",
                table: "TipoPrestamos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TasaInteresRegional",
                table: "TipoPrestamos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "TasaIva",
                table: "TipoPrestamos",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "TasaMoraFija",
                table: "TipoPrestamos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TasaMoraGeneral",
                table: "TipoPrestamos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TasaMoraRegional",
                table: "TipoPrestamos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TasaMoraVariable",
                table: "TipoPrestamos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "TipoCuotaId",
                table: "TipoPrestamos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RegionId",
                table: "Departamentos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DocumentosPrestamos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoPrestamoId = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Habilitado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentosPrestamos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentosPrestamos_TipoPrestamos_TipoPrestamoId",
                        column: x => x.TipoPrestamoId,
                        principalTable: "TipoPrestamos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Monedas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Simbolo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Habilitado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monedas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Regiones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Habilitado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regiones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoCuotas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Habilitado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoCuotas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InteresesRegiones",
                columns: table => new
                {
                    TipoPrestamoId = table.Column<int>(type: "int", nullable: false),
                    RegionId = table.Column<int>(type: "int", nullable: false),
                    TasaMinima = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TasaMaxima = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TasaPredeterminada = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Habilitado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InteresesRegiones", x => new { x.TipoPrestamoId, x.RegionId });
                    table.ForeignKey(
                        name: "FK_InteresesRegiones_Regiones_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regiones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InteresesRegiones_TipoPrestamos_TipoPrestamoId",
                        column: x => x.TipoPrestamoId,
                        principalTable: "TipoPrestamos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MoraRegiones",
                columns: table => new
                {
                    TipoPrestamoId = table.Column<int>(type: "int", nullable: false),
                    RegionId = table.Column<int>(type: "int", nullable: false),
                    TasaMinima = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TasaMaxima = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TasaPredeterminada = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DiasGracia = table.Column<byte>(type: "tinyint", nullable: false),
                    Habilitado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoraRegiones", x => new { x.TipoPrestamoId, x.RegionId });
                    table.ForeignKey(
                        name: "FK_MoraRegiones_Regiones_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regiones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MoraRegiones_TipoPrestamos_TipoPrestamoId",
                        column: x => x.TipoPrestamoId,
                        principalTable: "TipoPrestamos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParametrosRegiones",
                columns: table => new
                {
                    TipoPrestamoId = table.Column<int>(type: "int", nullable: false),
                    RegionId = table.Column<int>(type: "int", nullable: false),
                    MontoFijo = table.Column<bool>(type: "bit", nullable: false),
                    MontoVariable = table.Column<bool>(type: "bit", nullable: false),
                    MontoMinimo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MontoMaximo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MontoPredeterminado = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PlazoFijo = table.Column<bool>(type: "bit", nullable: false),
                    PlazoVariable = table.Column<bool>(type: "bit", nullable: false),
                    PlazoMinimo = table.Column<byte>(type: "tinyint", nullable: false),
                    PlazoMaximo = table.Column<byte>(type: "tinyint", nullable: false),
                    PlazoPredeterminado = table.Column<byte>(type: "tinyint", nullable: false),
                    DiaInicioMes = table.Column<byte>(type: "tinyint", nullable: false),
                    DiaQuincena = table.Column<byte>(type: "tinyint", nullable: false),
                    DiaFinMes = table.Column<byte>(type: "tinyint", nullable: false),
                    Habilitado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParametrosRegiones", x => new { x.TipoPrestamoId, x.RegionId });
                    table.ForeignKey(
                        name: "FK_ParametrosRegiones_Regiones_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regiones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParametrosRegiones_TipoPrestamos_TipoPrestamoId",
                        column: x => x.TipoPrestamoId,
                        principalTable: "TipoPrestamos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TipoPrestamos_MonedaId",
                table: "TipoPrestamos",
                column: "MonedaId");

            migrationBuilder.CreateIndex(
                name: "IX_TipoPrestamos_TipoCuotaId",
                table: "TipoPrestamos",
                column: "TipoCuotaId");

            migrationBuilder.CreateIndex(
                name: "IX_Departamentos_RegionId",
                table: "Departamentos",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentosPrestamos_TipoPrestamoId",
                table: "DocumentosPrestamos",
                column: "TipoPrestamoId");

            migrationBuilder.CreateIndex(
                name: "IX_InteresesRegiones_RegionId",
                table: "InteresesRegiones",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_MoraRegiones_RegionId",
                table: "MoraRegiones",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_ParametrosRegiones_RegionId",
                table: "ParametrosRegiones",
                column: "RegionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Departamentos_Regiones_RegionId",
                table: "Departamentos",
                column: "RegionId",
                principalTable: "Regiones",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TipoPrestamos_Monedas_MonedaId",
                table: "TipoPrestamos",
                column: "MonedaId",
                principalTable: "Monedas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TipoPrestamos_TipoCuotas_TipoCuotaId",
                table: "TipoPrestamos",
                column: "TipoCuotaId",
                principalTable: "TipoCuotas",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departamentos_Regiones_RegionId",
                table: "Departamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_TipoPrestamos_Monedas_MonedaId",
                table: "TipoPrestamos");

            migrationBuilder.DropForeignKey(
                name: "FK_TipoPrestamos_TipoCuotas_TipoCuotaId",
                table: "TipoPrestamos");

            migrationBuilder.DropTable(
                name: "DocumentosPrestamos");

            migrationBuilder.DropTable(
                name: "InteresesRegiones");

            migrationBuilder.DropTable(
                name: "Monedas");

            migrationBuilder.DropTable(
                name: "MoraRegiones");

            migrationBuilder.DropTable(
                name: "ParametrosRegiones");

            migrationBuilder.DropTable(
                name: "TipoCuotas");

            migrationBuilder.DropTable(
                name: "Regiones");

            migrationBuilder.DropIndex(
                name: "IX_TipoPrestamos_MonedaId",
                table: "TipoPrestamos");

            migrationBuilder.DropIndex(
                name: "IX_TipoPrestamos_TipoCuotaId",
                table: "TipoPrestamos");

            migrationBuilder.DropIndex(
                name: "IX_Departamentos_RegionId",
                table: "Departamentos");

            migrationBuilder.DropColumn(
                name: "DisponibleOrganizaciones",
                table: "TipoPrestamos");

            migrationBuilder.DropColumn(
                name: "DisponiblePersonas",
                table: "TipoPrestamos");

            migrationBuilder.DropColumn(
                name: "MonedaId",
                table: "TipoPrestamos");

            migrationBuilder.DropColumn(
                name: "ParametrosGeneral",
                table: "TipoPrestamos");

            migrationBuilder.DropColumn(
                name: "ParametrosRegional",
                table: "TipoPrestamos");

            migrationBuilder.DropColumn(
                name: "TasInteresVariable",
                table: "TipoPrestamos");

            migrationBuilder.DropColumn(
                name: "TasaInteresFija",
                table: "TipoPrestamos");

            migrationBuilder.DropColumn(
                name: "TasaInteresGeneral",
                table: "TipoPrestamos");

            migrationBuilder.DropColumn(
                name: "TasaInteresRegional",
                table: "TipoPrestamos");

            migrationBuilder.DropColumn(
                name: "TasaIva",
                table: "TipoPrestamos");

            migrationBuilder.DropColumn(
                name: "TasaMoraFija",
                table: "TipoPrestamos");

            migrationBuilder.DropColumn(
                name: "TasaMoraGeneral",
                table: "TipoPrestamos");

            migrationBuilder.DropColumn(
                name: "TasaMoraRegional",
                table: "TipoPrestamos");

            migrationBuilder.DropColumn(
                name: "TasaMoraVariable",
                table: "TipoPrestamos");

            migrationBuilder.DropColumn(
                name: "TipoCuotaId",
                table: "TipoPrestamos");

            migrationBuilder.DropColumn(
                name: "RegionId",
                table: "Departamentos");
        }
    }
}
