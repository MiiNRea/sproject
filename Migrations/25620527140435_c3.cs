using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace sproject.Migrations
{
    public partial class c3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "manufacturer_date",
                table: "InventoryIn",
                newName: "manufacturer_year");

            migrationBuilder.AddColumn<DateTime>(
                name: "manufacturer_week",
                table: "InventoryIn",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "manufacturer_week",
                table: "InventoryIn");

            migrationBuilder.RenameColumn(
                name: "manufacturer_year",
                table: "InventoryIn",
                newName: "manufacturer_date");
        }
    }
}
