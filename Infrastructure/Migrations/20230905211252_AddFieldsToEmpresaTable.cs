using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class AddFieldsToEmpresaTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NombreCompleto",
                table: "ReferenciasPersonas",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClientesHabitualesId",
                table: "Empresas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Comentarios",
                table: "Empresas",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "GananciasMensuales",
                table: "Empresas",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "NumeroPersonasTrabajanId",
                table: "Empresas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrigenOtrosIngresos",
                table: "Empresas",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "OtrosIngresos",
                table: "Empresas",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "PoseeRegistroSAT",
                table: "Empresas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "UbicacionNegocioId",
                table: "Empresas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "VentasMensuales",
                table: "Empresas",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "ReferenciasEmpresas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpresaId = table.Column<int>(type: "int", nullable: false),
                    TipoReferenciaId = table.Column<int>(type: "int", nullable: false),
                    NombreCompleto = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Habilitado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReferenciasEmpresas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReferenciasEmpresas_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReferenciasEmpresas_TipoReferencias_TipoReferenciaId",
                        column: x => x.TipoReferenciaId,
                        principalTable: "TipoReferencias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_ClientesHabitualesId",
                table: "Empresas",
                column: "ClientesHabitualesId");

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_NumeroPersonasTrabajanId",
                table: "Empresas",
                column: "NumeroPersonasTrabajanId");

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_UbicacionNegocioId",
                table: "Empresas",
                column: "UbicacionNegocioId");

            migrationBuilder.CreateIndex(
                name: "IX_ReferenciasEmpresas_EmpresaId",
                table: "ReferenciasEmpresas",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_ReferenciasEmpresas_TipoReferenciaId",
                table: "ReferenciasEmpresas",
                column: "TipoReferenciaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Empresas_ClientesHabituales_ClientesHabitualesId",
                table: "Empresas",
                column: "ClientesHabitualesId",
                principalTable: "ClientesHabituales",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Empresas_GrupoFamiliar_NumeroPersonasTrabajanId",
                table: "Empresas",
                column: "NumeroPersonasTrabajanId",
                principalTable: "GrupoFamiliar",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Empresas_UbicacionNegocios_UbicacionNegocioId",
                table: "Empresas",
                column: "UbicacionNegocioId",
                principalTable: "UbicacionNegocios",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empresas_ClientesHabituales_ClientesHabitualesId",
                table: "Empresas");

            migrationBuilder.DropForeignKey(
                name: "FK_Empresas_GrupoFamiliar_NumeroPersonasTrabajanId",
                table: "Empresas");

            migrationBuilder.DropForeignKey(
                name: "FK_Empresas_UbicacionNegocios_UbicacionNegocioId",
                table: "Empresas");

            migrationBuilder.DropTable(
                name: "ReferenciasEmpresas");

            migrationBuilder.DropIndex(
                name: "IX_Empresas_ClientesHabitualesId",
                table: "Empresas");

            migrationBuilder.DropIndex(
                name: "IX_Empresas_NumeroPersonasTrabajanId",
                table: "Empresas");

            migrationBuilder.DropIndex(
                name: "IX_Empresas_UbicacionNegocioId",
                table: "Empresas");

            migrationBuilder.DropColumn(
                name: "ClientesHabitualesId",
                table: "Empresas");

            migrationBuilder.DropColumn(
                name: "Comentarios",
                table: "Empresas");

            migrationBuilder.DropColumn(
                name: "GananciasMensuales",
                table: "Empresas");

            migrationBuilder.DropColumn(
                name: "NumeroPersonasTrabajanId",
                table: "Empresas");

            migrationBuilder.DropColumn(
                name: "OrigenOtrosIngresos",
                table: "Empresas");

            migrationBuilder.DropColumn(
                name: "OtrosIngresos",
                table: "Empresas");

            migrationBuilder.DropColumn(
                name: "PoseeRegistroSAT",
                table: "Empresas");

            migrationBuilder.DropColumn(
                name: "UbicacionNegocioId",
                table: "Empresas");

            migrationBuilder.DropColumn(
                name: "VentasMensuales",
                table: "Empresas");

            migrationBuilder.AlterColumn<string>(
                name: "NombreCompleto",
                table: "ReferenciasPersonas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);
        }
    }
}
