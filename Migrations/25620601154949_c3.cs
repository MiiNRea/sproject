using Microsoft.EntityFrameworkCore.Migrations;

namespace sproject.Migrations
{
    public partial class c3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "invento_qty",
                table: "Inventories",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "invento_qty",
                table: "Inventories");
        }
    }
}
