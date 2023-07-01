using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class Currency_To_Moneda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TipoPrestamos_Currency_CurrencyId",
                table: "TipoPrestamos");

            migrationBuilder.DropTable(
                name: "Currency");

            migrationBuilder.CreateTable(
                name: "Monedas",
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
                    table.PrimaryKey("PK_Monedas", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Monedas",
                columns: new[] { "Id", "Description", "FechaCreacion", "FechaModificacion", "Habilitado", "Name", "Symbol" },
                values: new object[] { 1, "Moneda de Guatemala", new DateTime(2023, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Quetzales", "Q" });

            migrationBuilder.InsertData(
                table: "Monedas",
                columns: new[] { "Id", "Description", "FechaCreacion", "FechaModificacion", "Habilitado", "Name", "Symbol" },
                values: new object[] { 2, "Moneda de Estados Unidos", new DateTime(2023, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Dolares", "$" });

            migrationBuilder.AddForeignKey(
                name: "FK_TipoPrestamos_Monedas_CurrencyId",
                table: "TipoPrestamos",
                column: "CurrencyId",
                principalTable: "Monedas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TipoPrestamos_Monedas_CurrencyId",
                table: "TipoPrestamos");

            migrationBuilder.DropTable(
                name: "Monedas");

            migrationBuilder.CreateTable(
                name: "Currency",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Habilitado = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Currency",
                columns: new[] { "Id", "Description", "FechaCreacion", "FechaModificacion", "Habilitado", "Name", "Symbol" },
                values: new object[] { 1, "Moneda de Guatemala", new DateTime(2023, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Quetzales", "Q" });

            migrationBuilder.InsertData(
                table: "Currency",
                columns: new[] { "Id", "Description", "FechaCreacion", "FechaModificacion", "Habilitado", "Name", "Symbol" },
                values: new object[] { 2, "Moneda de Estados Unidos", new DateTime(2023, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Dolares", "$" });

            migrationBuilder.AddForeignKey(
                name: "FK_TipoPrestamos_Currency_CurrencyId",
                table: "TipoPrestamos",
                column: "CurrencyId",
                principalTable: "Currency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
