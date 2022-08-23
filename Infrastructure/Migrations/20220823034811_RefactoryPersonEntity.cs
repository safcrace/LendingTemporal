using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class RefactoryPersonEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personas_AspNetUsers_AppUserId",
                table: "Personas");

            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Departamentos_DepartamentoNacmientoId",
                table: "Personas");

            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Departamentos_DepartamentoResidenciaId",
                table: "Personas");

            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Municipios_MunicipioNacimientoId",
                table: "Personas");

            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Municipios_MunicipioResidenciaId",
                table: "Personas");

            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Paises_NacionalidadId",
                table: "Personas");

            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Paises_PaisId",
                table: "Personas");

            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Relaciones_RelacionId",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_Personas_AppUserId",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_Personas_DepartamentoNacmientoId",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_Personas_DepartamentoResidenciaId",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_Personas_MunicipioNacimientoId",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_Personas_MunicipioResidenciaId",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_Personas_NacionalidadId",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_Personas_PaisId",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_Personas_RelacionId",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "DepartamentoNacmientoId",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "DepartamentoResidenciaId",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "MunicipioNacimientoId",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "MunicipioResidenciaId",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "NacionalidadId",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "PaisId",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "RelacionId",
                table: "Personas");

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PersonId",
                table: "AspNetUsers",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Personas_PersonId",
                table: "AspNetUsers",
                column: "PersonId",
                principalTable: "Personas",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Personas_PersonId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_PersonId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Personas",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DepartamentoNacmientoId",
                table: "Personas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DepartamentoResidenciaId",
                table: "Personas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MunicipioNacimientoId",
                table: "Personas",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MunicipioResidenciaId",
                table: "Personas",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NacionalidadId",
                table: "Personas",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaisId",
                table: "Personas",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "RelacionId",
                table: "Personas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Personas_AppUserId",
                table: "Personas",
                column: "AppUserId",
                unique: true,
                filter: "[AppUserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_DepartamentoNacmientoId",
                table: "Personas",
                column: "DepartamentoNacmientoId");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_DepartamentoResidenciaId",
                table: "Personas",
                column: "DepartamentoResidenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_MunicipioNacimientoId",
                table: "Personas",
                column: "MunicipioNacimientoId");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_MunicipioResidenciaId",
                table: "Personas",
                column: "MunicipioResidenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_NacionalidadId",
                table: "Personas",
                column: "NacionalidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_PaisId",
                table: "Personas",
                column: "PaisId");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_RelacionId",
                table: "Personas",
                column: "RelacionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_AspNetUsers_AppUserId",
                table: "Personas",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Departamentos_DepartamentoNacmientoId",
                table: "Personas",
                column: "DepartamentoNacmientoId",
                principalTable: "Departamentos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Departamentos_DepartamentoResidenciaId",
                table: "Personas",
                column: "DepartamentoResidenciaId",
                principalTable: "Departamentos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Municipios_MunicipioNacimientoId",
                table: "Personas",
                column: "MunicipioNacimientoId",
                principalTable: "Municipios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Municipios_MunicipioResidenciaId",
                table: "Personas",
                column: "MunicipioResidenciaId",
                principalTable: "Municipios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Paises_NacionalidadId",
                table: "Personas",
                column: "NacionalidadId",
                principalTable: "Paises",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Paises_PaisId",
                table: "Personas",
                column: "PaisId",
                principalTable: "Paises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Relaciones_RelacionId",
                table: "Personas",
                column: "RelacionId",
                principalTable: "Relaciones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
