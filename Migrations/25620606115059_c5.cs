using Microsoft.EntityFrameworkCore.Migrations;

namespace sproject.Migrations
{
    public partial class c5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "backorder",
                table: "SupplierInfos");

            migrationBuilder.DropColumn(
                name: "leadtime",
                table: "SupplierInfos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "backorder",
                table: "SupplierInfos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "leadtime",
                table: "SupplierInfos",
                nullable: false,
                defaultValue: 0);
        }
    }
}
