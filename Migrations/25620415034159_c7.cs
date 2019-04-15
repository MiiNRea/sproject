using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace sproject.Migrations
{
    public partial class c7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InventoryIn",
                columns: table => new
                {
                    inventoryin_id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    purchase_id = table.Column<int>(nullable: false),
                    product_id = table.Column<int>(nullable: false),
                    inventoryin_qty = table.Column<int>(nullable: false),
                    manufacturer_date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryIn", x => x.inventoryin_id);
                    table.ForeignKey(
                        name: "FK_InventoryIn_ProductInfos_product_id",
                        column: x => x.product_id,
                        principalTable: "ProductInfos",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventoryIn_PurchaseOrders_purchase_id",
                        column: x => x.purchase_id,
                        principalTable: "PurchaseOrders",
                        principalColumn: "purchase_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InventoryIn_product_id",
                table: "InventoryIn",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryIn_purchase_id",
                table: "InventoryIn",
                column: "purchase_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InventoryIn");
        }
    }
}
