using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class FieldsAndTablesForPreevaluacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Ocupaciones_OcupacionId",
                table: "Personas");

            migrationBuilder.RenameColumn(
                name: "OcupacionId",
                table: "Personas",
                newName: "OcupacionSinFinId");

            migrationBuilder.RenameColumn(
                name: "NumeroTelefonoLaboral",
                table: "Personas",
                newName: "NumeroTelefonoNegocio");

            migrationBuilder.RenameColumn(
                name: "DireccionLaboral",
                table: "Personas",
                newName: "NombreNegocio");

            migrationBuilder.RenameIndex(
                name: "IX_Personas_OcupacionId",
                table: "Personas",
                newName: "IX_Personas_OcupacionSinFinId");

            migrationBuilder.AddColumn<int>(
                name: "CanalIngresoId",
                table: "Prestamos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MontoInteresadoId",
                table: "Prestamos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductoInteresadoId",
                table: "Prestamos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DepartamentoNegocioId",
                table: "Personas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DireccionNegocio",
                table: "Personas",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EscolaridadId",
                table: "Personas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GrupoFamiliarId",
                table: "Personas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MunicipioNegocioId",
                table: "Personas",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Direccion",
                table: "Empresas",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "Alias",
                table: "Empresas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "DepartamentoId",
                table: "Empresas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaInicioOperaciones",
                table: "Empresas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "MunicipioId",
                table: "Empresas",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CanalesIngresos",
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
                    table.PrimaryKey("PK_CanalesIngresos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactosEmpresas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpresaId = table.Column<int>(type: "int", nullable: true),
                    OcupacionId = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Habilitado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactosEmpresas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactosEmpresas_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContactosEmpresas_Ocupaciones_OcupacionId",
                        column: x => x.OcupacionId,
                        principalTable: "Ocupaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmpresasCelulares",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Habilitado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpresasCelulares", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Escolaridad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(125)", maxLength: 125, nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Habilitado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Escolaridad", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GrupoFamiliar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Habilitado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrupoFamiliar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MontosInteresados",
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
                    table.PrimaryKey("PK_MontosInteresados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OcupacionSinFin",
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
                    table.PrimaryKey("PK_OcupacionSinFin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductosInteresados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Habilitado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductosInteresados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SegmentoNegocios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(125)", maxLength: 125, nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Habilitado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SegmentoNegocios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubSegmentoNegocios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SegmentoNegocioId = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(125)", maxLength: 125, nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Habilitado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubSegmentoNegocios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubSegmentoNegocios_SegmentoNegocios_SegmentoNegocioId",
                        column: x => x.SegmentoNegocioId,
                        principalTable: "SegmentoNegocios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_CanalIngresoId",
                table: "Prestamos",
                column: "CanalIngresoId");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_MontoInteresadoId",
                table: "Prestamos",
                column: "MontoInteresadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_ProductoInteresadoId",
                table: "Prestamos",
                column: "ProductoInteresadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_DepartamentoNegocioId",
                table: "Personas",
                column: "DepartamentoNegocioId");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_EscolaridadId",
                table: "Personas",
                column: "EscolaridadId");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_GrupoFamiliarId",
                table: "Personas",
                column: "GrupoFamiliarId");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_MunicipioNegocioId",
                table: "Personas",
                column: "MunicipioNegocioId");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_NumeroDocumento",
                table: "Personas",
                column: "NumeroDocumento",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_DepartamentoId",
                table: "Empresas",
                column: "DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_MunicipioId",
                table: "Empresas",
                column: "MunicipioId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactosEmpresas_EmpresaId",
                table: "ContactosEmpresas",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactosEmpresas_OcupacionId",
                table: "ContactosEmpresas",
                column: "OcupacionId");

            migrationBuilder.CreateIndex(
                name: "IX_SubSegmentoNegocios_SegmentoNegocioId",
                table: "SubSegmentoNegocios",
                column: "SegmentoNegocioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Empresas_Departamentos_DepartamentoId",
                table: "Empresas",
                column: "DepartamentoId",
                principalTable: "Departamentos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Empresas_Municipios_MunicipioId",
                table: "Empresas",
                column: "MunicipioId",
                principalTable: "Municipios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Departamentos_DepartamentoNegocioId",
                table: "Personas",
                column: "DepartamentoNegocioId",
                principalTable: "Departamentos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Escolaridad_EscolaridadId",
                table: "Personas",
                column: "EscolaridadId",
                principalTable: "Escolaridad",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_GrupoFamiliar_GrupoFamiliarId",
                table: "Personas",
                column: "GrupoFamiliarId",
                principalTable: "GrupoFamiliar",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Municipios_MunicipioNegocioId",
                table: "Personas",
                column: "MunicipioNegocioId",
                principalTable: "Municipios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Ocupaciones_OcupacionSinFinId",
                table: "Personas",
                column: "OcupacionSinFinId",
                principalTable: "Ocupaciones",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Prestamos_CanalesIngresos_CanalIngresoId",
                table: "Prestamos",
                column: "CanalIngresoId",
                principalTable: "CanalesIngresos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Prestamos_MontosInteresados_MontoInteresadoId",
                table: "Prestamos",
                column: "MontoInteresadoId",
                principalTable: "MontosInteresados",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Prestamos_ProductosInteresados_ProductoInteresadoId",
                table: "Prestamos",
                column: "ProductoInteresadoId",
                principalTable: "ProductosInteresados",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empresas_Departamentos_DepartamentoId",
                table: "Empresas");

            migrationBuilder.DropForeignKey(
                name: "FK_Empresas_Municipios_MunicipioId",
                table: "Empresas");

            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Departamentos_DepartamentoNegocioId",
                table: "Personas");

            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Escolaridad_EscolaridadId",
                table: "Personas");

            migrationBuilder.DropForeignKey(
                name: "FK_Personas_GrupoFamiliar_GrupoFamiliarId",
                table: "Personas");

            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Municipios_MunicipioNegocioId",
                table: "Personas");

            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Ocupaciones_OcupacionSinFinId",
                table: "Personas");

            migrationBuilder.DropForeignKey(
                name: "FK_Prestamos_CanalesIngresos_CanalIngresoId",
                table: "Prestamos");

            migrationBuilder.DropForeignKey(
                name: "FK_Prestamos_MontosInteresados_MontoInteresadoId",
                table: "Prestamos");

            migrationBuilder.DropForeignKey(
                name: "FK_Prestamos_ProductosInteresados_ProductoInteresadoId",
                table: "Prestamos");

            migrationBuilder.DropTable(
                name: "CanalesIngresos");

            migrationBuilder.DropTable(
                name: "ContactosEmpresas");

            migrationBuilder.DropTable(
                name: "EmpresasCelulares");

            migrationBuilder.DropTable(
                name: "Escolaridad");

            migrationBuilder.DropTable(
                name: "GrupoFamiliar");

            migrationBuilder.DropTable(
                name: "MontosInteresados");

            migrationBuilder.DropTable(
                name: "OcupacionSinFin");

            migrationBuilder.DropTable(
                name: "ProductosInteresados");

            migrationBuilder.DropTable(
                name: "SubSegmentoNegocios");

            migrationBuilder.DropTable(
                name: "SegmentoNegocios");

            migrationBuilder.DropIndex(
                name: "IX_Prestamos_CanalIngresoId",
                table: "Prestamos");

            migrationBuilder.DropIndex(
                name: "IX_Prestamos_MontoInteresadoId",
                table: "Prestamos");

            migrationBuilder.DropIndex(
                name: "IX_Prestamos_ProductoInteresadoId",
                table: "Prestamos");

            migrationBuilder.DropIndex(
                name: "IX_Personas_DepartamentoNegocioId",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_Personas_EscolaridadId",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_Personas_GrupoFamiliarId",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_Personas_MunicipioNegocioId",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_Personas_NumeroDocumento",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_Empresas_DepartamentoId",
                table: "Empresas");

            migrationBuilder.DropIndex(
                name: "IX_Empresas_MunicipioId",
                table: "Empresas");

            migrationBuilder.DropColumn(
                name: "CanalIngresoId",
                table: "Prestamos");

            migrationBuilder.DropColumn(
                name: "MontoInteresadoId",
                table: "Prestamos");

            migrationBuilder.DropColumn(
                name: "ProductoInteresadoId",
                table: "Prestamos");

            migrationBuilder.DropColumn(
                name: "DepartamentoNegocioId",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "DireccionNegocio",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "EscolaridadId",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "GrupoFamiliarId",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "MunicipioNegocioId",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "Alias",
                table: "Empresas");

            migrationBuilder.DropColumn(
                name: "DepartamentoId",
                table: "Empresas");

            migrationBuilder.DropColumn(
                name: "FechaInicioOperaciones",
                table: "Empresas");

            migrationBuilder.DropColumn(
                name: "MunicipioId",
                table: "Empresas");

            migrationBuilder.RenameColumn(
                name: "OcupacionSinFinId",
                table: "Personas",
                newName: "OcupacionId");

            migrationBuilder.RenameColumn(
                name: "NumeroTelefonoNegocio",
                table: "Personas",
                newName: "NumeroTelefonoLaboral");

            migrationBuilder.RenameColumn(
                name: "NombreNegocio",
                table: "Personas",
                newName: "DireccionLaboral");

            migrationBuilder.RenameIndex(
                name: "IX_Personas_OcupacionSinFinId",
                table: "Personas",
                newName: "IX_Personas_OcupacionId");

            migrationBuilder.AlterColumn<string>(
                name: "Direccion",
                table: "Empresas",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Ocupaciones_OcupacionId",
                table: "Personas",
                column: "OcupacionId",
                principalTable: "Ocupaciones",
                principalColumn: "Id");
        }
    }
}
