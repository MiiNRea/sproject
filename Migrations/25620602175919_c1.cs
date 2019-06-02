using Microsoft.EntityFrameworkCore.Migrations;

namespace sproject.Migrations
{
    public partial class c1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "product_id",
                table: "Inventories",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_product_id",
                table: "Inventories",
                column: "product_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_ProductInfos_product_id",
                table: "Inventories",
                column: "product_id",
                principalTable: "ProductInfos",
                principalColumn: "product_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_ProductInfos_product_id",
                table: "Inventories");

            migrationBuilder.DropIndex(
                name: "IX_Inventories_product_id",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "product_id",
                table: "Inventories");
        }
    }
}
