using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class Entity_Relation_Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "EstadoCivil",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "EstadoCivil",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "EstadoCivil",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "EstadoCivil",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Generos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Generos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "RelacionEntidades",
                columns: new[] { "Id", "EntidadHijaId", "EntidadPadreId", "FechaCreacion", "FechaModificacion", "Habilitado", "TipoRelacionId" },
                values: new object[] { 1, 2, 1, new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RelacionEntidades",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "EstadoCivil",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2023, 5, 16, 10, 19, 14, 359, DateTimeKind.Local).AddTicks(4937), new DateTime(2023, 5, 16, 10, 19, 14, 359, DateTimeKind.Local).AddTicks(4937) });

            migrationBuilder.UpdateData(
                table: "EstadoCivil",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2023, 5, 16, 10, 19, 14, 359, DateTimeKind.Local).AddTicks(4938), new DateTime(2023, 5, 16, 10, 19, 14, 359, DateTimeKind.Local).AddTicks(4938) });

            migrationBuilder.UpdateData(
                table: "EstadoCivil",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2023, 5, 16, 10, 19, 14, 359, DateTimeKind.Local).AddTicks(4939), new DateTime(2023, 5, 16, 10, 19, 14, 359, DateTimeKind.Local).AddTicks(4939) });

            migrationBuilder.UpdateData(
                table: "EstadoCivil",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2023, 5, 16, 10, 19, 14, 359, DateTimeKind.Local).AddTicks(4940), new DateTime(2023, 5, 16, 10, 19, 14, 359, DateTimeKind.Local).AddTicks(4940) });

            migrationBuilder.UpdateData(
                table: "Generos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2023, 5, 16, 10, 19, 14, 359, DateTimeKind.Local).AddTicks(4955), new DateTime(2023, 5, 16, 10, 19, 14, 359, DateTimeKind.Local).AddTicks(4956) });

            migrationBuilder.UpdateData(
                table: "Generos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaCreacion", "FechaModificacion" },
                values: new object[] { new DateTime(2023, 5, 16, 10, 19, 14, 359, DateTimeKind.Local).AddTicks(4957), new DateTime(2023, 5, 16, 10, 19, 14, 359, DateTimeKind.Local).AddTicks(4957) });
        }
    }
}
