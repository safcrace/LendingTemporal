using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class AddBatchFieldsToRegistroCajaTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "BatchDate",
                table: "RegistroCajas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "BatchKey",
                table: "RegistroCajas",
                type: "nvarchar(37)",
                maxLength: 37,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BatchDate",
                table: "RegistroCajas");

            migrationBuilder.DropColumn(
                name: "BatchKey",
                table: "RegistroCajas");
        }
    }
}
