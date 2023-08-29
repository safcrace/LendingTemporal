using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class FixEstadoPrestamo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prestamos_EstadoPrestamos_EstadoPrestamoId",
                table: "Prestamos");

            migrationBuilder.DropTable(
                name: "ListadoProspectos");

            migrationBuilder.AlterColumn<int>(
                name: "EstadoPrestamoId",
                table: "Prestamos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Prestamos_EstadoPrestamos_EstadoPrestamoId",
                table: "Prestamos",
                column: "EstadoPrestamoId",
                principalTable: "EstadoPrestamos",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prestamos_EstadoPrestamos_EstadoPrestamoId",
                table: "Prestamos");

            migrationBuilder.AlterColumn<int>(
                name: "EstadoPrestamoId",
                table: "Prestamos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ListadoProspectos",
                columns: table => new
                {
                    AppUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CanalId = table.Column<int>(type: "int", nullable: false),
                    CanalNombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DPI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstadoPrestamoId = table.Column<int>(type: "int", nullable: false),
                    FechaIngreso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GestorAsignadoId = table.Column<int>(type: "int", nullable: false),
                    NIT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombreProspecto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SolicitudId = table.Column<int>(type: "int", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TiempoEnEstado = table.Column<int>(type: "int", nullable: false),
                    TipoEntidad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoEntidadId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Prestamos_EstadoPrestamos_EstadoPrestamoId",
                table: "Prestamos",
                column: "EstadoPrestamoId",
                principalTable: "EstadoPrestamos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
