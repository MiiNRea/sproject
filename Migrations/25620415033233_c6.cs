using Microsoft.EntityFrameworkCore.Migrations;

namespace sproject.Migrations
{
    public partial class c6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "purchase_lot",
                table: "PurchaseOrders");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "purchase_lot",
                table: "PurchaseOrders",
                nullable: false,
                defaultValue: 0);
        }
    }
}
