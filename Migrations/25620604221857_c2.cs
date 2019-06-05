using Microsoft.EntityFrameworkCore.Migrations;

namespace sproject.Migrations
{
    public partial class c2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "purchase_id",
                table: "Borrows",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Borrows_purchase_id",
                table: "Borrows",
                column: "purchase_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Borrows_PurchaseOrders_purchase_id",
                table: "Borrows",
                column: "purchase_id",
                principalTable: "PurchaseOrders",
                principalColumn: "purchase_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Borrows_PurchaseOrders_purchase_id",
                table: "Borrows");

            migrationBuilder.DropIndex(
                name: "IX_Borrows_purchase_id",
                table: "Borrows");

            migrationBuilder.DropColumn(
                name: "purchase_id",
                table: "Borrows");
        }
    }
}
