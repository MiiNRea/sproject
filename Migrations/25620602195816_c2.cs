using Microsoft.EntityFrameworkCore.Migrations;

namespace sproject.Migrations
{
    public partial class c2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerOrders_Inventories_inventory_id",
                table: "CustomerOrders");

            migrationBuilder.DropIndex(
                name: "IX_CustomerOrders_inventory_id",
                table: "CustomerOrders");

            migrationBuilder.DropColumn(
                name: "inventory_id",
                table: "CustomerOrders");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "inventory_id",
                table: "CustomerOrders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerOrders_inventory_id",
                table: "CustomerOrders",
                column: "inventory_id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerOrders_Inventories_inventory_id",
                table: "CustomerOrders",
                column: "inventory_id",
                principalTable: "Inventories",
                principalColumn: "inventory_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
