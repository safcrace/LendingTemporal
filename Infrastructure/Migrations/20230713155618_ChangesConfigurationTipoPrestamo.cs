using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class ChangesConfigurationTipoPrestamo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InteresesRegiones");

            migrationBuilder.DropTable(
                name: "MoraRegiones");

            migrationBuilder.DropTable(
                name: "ParametrosRegiones");

            migrationBuilder.RenameColumn(
                name: "TasaMoraRegional",
                table: "TipoPrestamos",
                newName: "TasaMoraDepartamental");

            migrationBuilder.RenameColumn(
                name: "TasaInteresRegional",
                table: "TipoPrestamos",
                newName: "TasaInteresDepartamental");

            migrationBuilder.RenameColumn(
                name: "ParametrosRegional",
                table: "TipoPrestamos",
                newName: "PermisosJefeCreditos");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "TipoPrestamos",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "TipoPrestamos",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MontoMaximoComiteDirectores",
                table: "TipoPrestamos",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MontoMaximoComiteGerencia",
                table: "TipoPrestamos",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MontoMaximoJefeCreditos",
                table: "TipoPrestamos",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MontoMinimoComiteDirectores",
                table: "TipoPrestamos",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MontoMinimoComiteGerencia",
                table: "TipoPrestamos",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MontoMinimoJefeCreditos",
                table: "TipoPrestamos",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "ParametrosDepartamental",
                table: "TipoPrestamos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PermisosComiteDirectores",
                table: "TipoPrestamos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PermisosComiteGerencia",
                table: "TipoPrestamos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "TPA",
                table: "TipoPrestamos",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "InteresesDepartamentos",
                columns: table => new
                {
                    TipoPrestamoId = table.Column<int>(type: "int", nullable: false),
                    DepartamentoId = table.Column<int>(type: "int", nullable: false),
                    TasaMinima = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TasaMaxima = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TasaPredeterminada = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Habilitado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InteresesDepartamentos", x => new { x.TipoPrestamoId, x.DepartamentoId });
                    table.ForeignKey(
                        name: "FK_InteresesDepartamentos_Departamentos_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "Departamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InteresesDepartamentos_TipoPrestamos_TipoPrestamoId",
                        column: x => x.TipoPrestamoId,
                        principalTable: "TipoPrestamos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MoraDepartamentos",
                columns: table => new
                {
                    TipoPrestamoId = table.Column<int>(type: "int", nullable: false),
                    DepartamentoId = table.Column<int>(type: "int", nullable: false),
                    TasaMinima = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TasaMaxima = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TasaPredeterminada = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DiasGracia = table.Column<byte>(type: "tinyint", nullable: false),
                    Habilitado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoraDepartamentos", x => new { x.TipoPrestamoId, x.DepartamentoId });
                    table.ForeignKey(
                        name: "FK_MoraDepartamentos_Departamentos_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "Departamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MoraDepartamentos_TipoPrestamos_TipoPrestamoId",
                        column: x => x.TipoPrestamoId,
                        principalTable: "TipoPrestamos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParametrosDepartamentos",
                columns: table => new
                {
                    TipoPrestamoId = table.Column<int>(type: "int", nullable: false),
                    DepartamentoId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_ParametrosDepartamentos", x => new { x.TipoPrestamoId, x.DepartamentoId });
                    table.ForeignKey(
                        name: "FK_ParametrosDepartamentos_Departamentos_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "Departamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParametrosDepartamentos_TipoPrestamos_TipoPrestamoId",
                        column: x => x.TipoPrestamoId,
                        principalTable: "TipoPrestamos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InteresesDepartamentos_DepartamentoId",
                table: "InteresesDepartamentos",
                column: "DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_MoraDepartamentos_DepartamentoId",
                table: "MoraDepartamentos",
                column: "DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_ParametrosDepartamentos_DepartamentoId",
                table: "ParametrosDepartamentos",
                column: "DepartamentoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InteresesDepartamentos");

            migrationBuilder.DropTable(
                name: "MoraDepartamentos");

            migrationBuilder.DropTable(
                name: "ParametrosDepartamentos");

            migrationBuilder.DropColumn(
                name: "MontoMaximoComiteDirectores",
                table: "TipoPrestamos");

            migrationBuilder.DropColumn(
                name: "MontoMaximoComiteGerencia",
                table: "TipoPrestamos");

            migrationBuilder.DropColumn(
                name: "MontoMaximoJefeCreditos",
                table: "TipoPrestamos");

            migrationBuilder.DropColumn(
                name: "MontoMinimoComiteDirectores",
                table: "TipoPrestamos");

            migrationBuilder.DropColumn(
                name: "MontoMinimoComiteGerencia",
                table: "TipoPrestamos");

            migrationBuilder.DropColumn(
                name: "MontoMinimoJefeCreditos",
                table: "TipoPrestamos");

            migrationBuilder.DropColumn(
                name: "ParametrosDepartamental",
                table: "TipoPrestamos");

            migrationBuilder.DropColumn(
                name: "PermisosComiteDirectores",
                table: "TipoPrestamos");

            migrationBuilder.DropColumn(
                name: "PermisosComiteGerencia",
                table: "TipoPrestamos");

            migrationBuilder.DropColumn(
                name: "TPA",
                table: "TipoPrestamos");

            migrationBuilder.RenameColumn(
                name: "TasaMoraDepartamental",
                table: "TipoPrestamos",
                newName: "TasaMoraRegional");

            migrationBuilder.RenameColumn(
                name: "TasaInteresDepartamental",
                table: "TipoPrestamos",
                newName: "TasaInteresRegional");

            migrationBuilder.RenameColumn(
                name: "PermisosJefeCreditos",
                table: "TipoPrestamos",
                newName: "ParametrosRegional");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "TipoPrestamos",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "TipoPrestamos",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "InteresesRegiones",
                columns: table => new
                {
                    TipoPrestamoId = table.Column<int>(type: "int", nullable: false),
                    RegionId = table.Column<int>(type: "int", nullable: false),
                    Habilitado = table.Column<bool>(type: "bit", nullable: false),
                    TasaMaxima = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TasaMinima = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TasaPredeterminada = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
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
                    DiasGracia = table.Column<byte>(type: "tinyint", nullable: false),
                    Habilitado = table.Column<bool>(type: "bit", nullable: false),
                    TasaMaxima = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TasaMinima = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TasaPredeterminada = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
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
                    DiaFinMes = table.Column<byte>(type: "tinyint", nullable: false),
                    DiaInicioMes = table.Column<byte>(type: "tinyint", nullable: false),
                    DiaQuincena = table.Column<byte>(type: "tinyint", nullable: false),
                    Habilitado = table.Column<bool>(type: "bit", nullable: false),
                    MontoFijo = table.Column<bool>(type: "bit", nullable: false),
                    MontoMaximo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MontoMinimo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MontoPredeterminado = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MontoVariable = table.Column<bool>(type: "bit", nullable: false),
                    PlazoFijo = table.Column<bool>(type: "bit", nullable: false),
                    PlazoMaximo = table.Column<byte>(type: "tinyint", nullable: false),
                    PlazoMinimo = table.Column<byte>(type: "tinyint", nullable: false),
                    PlazoPredeterminado = table.Column<byte>(type: "tinyint", nullable: false),
                    PlazoVariable = table.Column<bool>(type: "bit", nullable: false)
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
        }
    }
}
