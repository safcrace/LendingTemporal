using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class Credit_Login_Lending_Type : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurrencyId",
                table: "TipoPrestamos",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "DiasGracia",
                table: "TipoPrestamos",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                name: "MaxCuotas",
                table: "TipoPrestamos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "MaxGastos",
                table: "TipoPrestamos",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MaxInteres",
                table: "TipoPrestamos",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MaxMonto",
                table: "TipoPrestamos",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MaxMora",
                table: "TipoPrestamos",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "MinCuotas",
                table: "TipoPrestamos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "MinGastos",
                table: "TipoPrestamos",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MinInteres",
                table: "TipoPrestamos",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MinMonto",
                table: "TipoPrestamos",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MinMora",
                table: "TipoPrestamos",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "Currency",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Habilitado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocumentosPrestamo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoPrestamoId = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Habilitado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentosPrestamo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentosPrestamo_TipoPrestamos_TipoPrestamoId",
                        column: x => x.TipoPrestamoId,
                        principalTable: "TipoPrestamos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Currency",
                columns: new[] { "Id", "Description", "FechaCreacion", "FechaModificacion", "Habilitado", "Name", "Symbol" },
                values: new object[] { 1, "Moneda de Guatemala", new DateTime(2023, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Quetzales", "Q" });

            migrationBuilder.InsertData(
                table: "Currency",
                columns: new[] { "Id", "Description", "FechaCreacion", "FechaModificacion", "Habilitado", "Name", "Symbol" },
                values: new object[] { 2, "Moneda de Estados Unidos", new DateTime(2023, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Dolares", "$" });

            migrationBuilder.CreateIndex(
                name: "IX_TipoPrestamos_CurrencyId",
                table: "TipoPrestamos",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentosPrestamo_TipoPrestamoId",
                table: "DocumentosPrestamo",
                column: "TipoPrestamoId");

            migrationBuilder.AddForeignKey(
                name: "FK_TipoPrestamos_Currency_CurrencyId",
                table: "TipoPrestamos",
                column: "CurrencyId",
                principalTable: "Currency",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TipoPrestamos_Currency_CurrencyId",
                table: "TipoPrestamos");

            migrationBuilder.DropTable(
                name: "Currency");

            migrationBuilder.DropTable(
                name: "DocumentosPrestamo");

            migrationBuilder.DropIndex(
                name: "IX_TipoPrestamos_CurrencyId",
                table: "TipoPrestamos");

            migrationBuilder.DropColumn(
                name: "CurrencyId",
                table: "TipoPrestamos");

            migrationBuilder.DropColumn(
                name: "DiasGracia",
                table: "TipoPrestamos");

            migrationBuilder.DropColumn(
                name: "DisponibleOrganizaciones",
                table: "TipoPrestamos");

            migrationBuilder.DropColumn(
                name: "DisponiblePersonas",
                table: "TipoPrestamos");

            migrationBuilder.DropColumn(
                name: "MaxCuotas",
                table: "TipoPrestamos");

            migrationBuilder.DropColumn(
                name: "MaxGastos",
                table: "TipoPrestamos");

            migrationBuilder.DropColumn(
                name: "MaxInteres",
                table: "TipoPrestamos");

            migrationBuilder.DropColumn(
                name: "MaxMonto",
                table: "TipoPrestamos");

            migrationBuilder.DropColumn(
                name: "MaxMora",
                table: "TipoPrestamos");

            migrationBuilder.DropColumn(
                name: "MinCuotas",
                table: "TipoPrestamos");

            migrationBuilder.DropColumn(
                name: "MinGastos",
                table: "TipoPrestamos");

            migrationBuilder.DropColumn(
                name: "MinInteres",
                table: "TipoPrestamos");

            migrationBuilder.DropColumn(
                name: "MinMonto",
                table: "TipoPrestamos");

            migrationBuilder.DropColumn(
                name: "MinMora",
                table: "TipoPrestamos");
        }
    }
}
