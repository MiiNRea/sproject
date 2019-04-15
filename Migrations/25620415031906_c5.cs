using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace sproject.Migrations
{
    public partial class c5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PActivities",
                columns: table => new
                {
                    activity_id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    purchase_type_id = table.Column<int>(nullable: false),
                    purchase_id = table.Column<int>(nullable: false),
                    activity_date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PActivities", x => x.activity_id);
                    table.ForeignKey(
                        name: "FK_PActivities_PurchaseOrders_purchase_id",
                        column: x => x.purchase_id,
                        principalTable: "PurchaseOrders",
                        principalColumn: "purchase_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PActivities_PurchaseOrderTypes_purchase_type_id",
                        column: x => x.purchase_type_id,
                        principalTable: "PurchaseOrderTypes",
                        principalColumn: "Purchase_type_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PActivities_purchase_id",
                table: "PActivities",
                column: "purchase_id");

            migrationBuilder.CreateIndex(
                name: "IX_PActivities_purchase_type_id",
                table: "PActivities",
                column: "purchase_type_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PActivities");
        }
    }
}
