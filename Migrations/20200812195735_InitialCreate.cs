using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ComitBakery.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    DaysToSell = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Batch",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    InventoryItemId = table.Column<Guid>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    ProductionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Batch", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Batch_Items_InventoryItemId",
                        column: x => x.InventoryItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Batch_InventoryItemId",
                table: "Batch",
                column: "InventoryItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Batch");

            migrationBuilder.DropTable(
                name: "Items");
        }
    }
}
