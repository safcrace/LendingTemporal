using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class NewTablesPreEvaluacionAutorizado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "MontoRealSolicitado",
                table: "Prestamos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "ObjetivoCredito",
                table: "Prestamos",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrigenIngresosId",
                table: "Prestamos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrigenSolicitudId",
                table: "Prestamos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "OtrosIngresos",
                table: "Prestamos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "TokenAutorización",
                table: "Prestamos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClientesHabitualesId",
                table: "Personas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FehaInicioNegocio",
                table: "Personas",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "GananciasMensuales",
                table: "Personas",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "NumeroPersonasTrabajanId",
                table: "Personas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PoseeNegocio",
                table: "Personas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PoseeRegistroSAT",
                table: "Personas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "UbicacionNegocioId",
                table: "Personas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "VentasMensuales",
                table: "Personas",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "ClientesHabituales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Habilitado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientesHabituales", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrigenIngresos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Habilitado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrigenIngresos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrigenSolicitudes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Habilitado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrigenSolicitudes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoReferencia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Habilitado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoReferencia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UbicacionNegocios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Habilitado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UbicacionNegocios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReferenciasPersonas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonaId = table.Column<int>(type: "int", nullable: false),
                    TipoReferenciaId = table.Column<int>(type: "int", nullable: false),
                    NombreCompleto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Habilitado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReferenciasPersonas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReferenciasPersonas_Personas_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReferenciasPersonas_TipoReferencia_TipoReferenciaId",
                        column: x => x.TipoReferenciaId,
                        principalTable: "TipoReferencia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_OrigenIngresosId",
                table: "Prestamos",
                column: "OrigenIngresosId");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_OrigenSolicitudId",
                table: "Prestamos",
                column: "OrigenSolicitudId");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_ClientesHabitualesId",
                table: "Personas",
                column: "ClientesHabitualesId");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_NumeroPersonasTrabajanId",
                table: "Personas",
                column: "NumeroPersonasTrabajanId");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_UbicacionNegocioId",
                table: "Personas",
                column: "UbicacionNegocioId");

            migrationBuilder.CreateIndex(
                name: "IX_ReferenciasPersonas_PersonaId",
                table: "ReferenciasPersonas",
                column: "PersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_ReferenciasPersonas_TipoReferenciaId",
                table: "ReferenciasPersonas",
                column: "TipoReferenciaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_ClientesHabituales_ClientesHabitualesId",
                table: "Personas",
                column: "ClientesHabitualesId",
                principalTable: "ClientesHabituales",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_GrupoFamiliar_NumeroPersonasTrabajanId",
                table: "Personas",
                column: "NumeroPersonasTrabajanId",
                principalTable: "GrupoFamiliar",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_UbicacionNegocios_UbicacionNegocioId",
                table: "Personas",
                column: "UbicacionNegocioId",
                principalTable: "UbicacionNegocios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Prestamos_OrigenIngresos_OrigenIngresosId",
                table: "Prestamos",
                column: "OrigenIngresosId",
                principalTable: "OrigenIngresos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Prestamos_OrigenSolicitudes_OrigenSolicitudId",
                table: "Prestamos",
                column: "OrigenSolicitudId",
                principalTable: "OrigenSolicitudes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personas_ClientesHabituales_ClientesHabitualesId",
                table: "Personas");

            migrationBuilder.DropForeignKey(
                name: "FK_Personas_GrupoFamiliar_NumeroPersonasTrabajanId",
                table: "Personas");

            migrationBuilder.DropForeignKey(
                name: "FK_Personas_UbicacionNegocios_UbicacionNegocioId",
                table: "Personas");

            migrationBuilder.DropForeignKey(
                name: "FK_Prestamos_OrigenIngresos_OrigenIngresosId",
                table: "Prestamos");

            migrationBuilder.DropForeignKey(
                name: "FK_Prestamos_OrigenSolicitudes_OrigenSolicitudId",
                table: "Prestamos");

            migrationBuilder.DropTable(
                name: "ClientesHabituales");

            migrationBuilder.DropTable(
                name: "OrigenIngresos");

            migrationBuilder.DropTable(
                name: "OrigenSolicitudes");

            migrationBuilder.DropTable(
                name: "ReferenciasPersonas");

            migrationBuilder.DropTable(
                name: "UbicacionNegocios");

            migrationBuilder.DropTable(
                name: "TipoReferencia");

            migrationBuilder.DropIndex(
                name: "IX_Prestamos_OrigenIngresosId",
                table: "Prestamos");

            migrationBuilder.DropIndex(
                name: "IX_Prestamos_OrigenSolicitudId",
                table: "Prestamos");

            migrationBuilder.DropIndex(
                name: "IX_Personas_ClientesHabitualesId",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_Personas_NumeroPersonasTrabajanId",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_Personas_UbicacionNegocioId",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "MontoRealSolicitado",
                table: "Prestamos");

            migrationBuilder.DropColumn(
                name: "ObjetivoCredito",
                table: "Prestamos");

            migrationBuilder.DropColumn(
                name: "OrigenIngresosId",
                table: "Prestamos");

            migrationBuilder.DropColumn(
                name: "OrigenSolicitudId",
                table: "Prestamos");

            migrationBuilder.DropColumn(
                name: "OtrosIngresos",
                table: "Prestamos");

            migrationBuilder.DropColumn(
                name: "TokenAutorización",
                table: "Prestamos");

            migrationBuilder.DropColumn(
                name: "ClientesHabitualesId",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "FehaInicioNegocio",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "GananciasMensuales",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "NumeroPersonasTrabajanId",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "PoseeNegocio",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "PoseeRegistroSAT",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "UbicacionNegocioId",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "VentasMensuales",
                table: "Personas");
        }
    }
}
