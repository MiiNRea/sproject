using Microsoft.EntityFrameworkCore.Migrations;

namespace sproject.Migrations
{
    public partial class c4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "purchase_type_name",
                table: "PurchaseOrders");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "purchase_type_name",
                table: "PurchaseOrders",
                nullable: true);
        }
    }
}
