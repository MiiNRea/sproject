using Microsoft.EntityFrameworkCore.Migrations;

namespace sproject.Migrations
{
    public partial class c2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "purchaseItem_id",
                table: "BackOrders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BackOrders_purchaseItem_id",
                table: "BackOrders",
                column: "purchaseItem_id");

            migrationBuilder.AddForeignKey(
                name: "FK_BackOrders_PurchaseItems_purchaseItem_id",
                table: "BackOrders",
                column: "purchaseItem_id",
                principalTable: "PurchaseItems",
                principalColumn: "purchaseItem_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BackOrders_PurchaseItems_purchaseItem_id",
                table: "BackOrders");

            migrationBuilder.DropIndex(
                name: "IX_BackOrders_purchaseItem_id",
                table: "BackOrders");

            migrationBuilder.DropColumn(
                name: "purchaseItem_id",
                table: "BackOrders");
        }
    }
}
