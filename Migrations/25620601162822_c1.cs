using Microsoft.EntityFrameworkCore.Migrations;

namespace sproject.Migrations
{
    public partial class c1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseItems_BackOrders_backOrder_id",
                table: "PurchaseItems");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseItems_backOrder_id",
                table: "PurchaseItems");

            migrationBuilder.DropColumn(
                name: "backOrder_id",
                table: "PurchaseItems");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "backOrder_id",
                table: "PurchaseItems",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseItems_backOrder_id",
                table: "PurchaseItems",
                column: "backOrder_id");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseItems_BackOrders_backOrder_id",
                table: "PurchaseItems",
                column: "backOrder_id",
                principalTable: "BackOrders",
                principalColumn: "backOrder_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
