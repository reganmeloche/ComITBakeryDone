using Microsoft.EntityFrameworkCore.Migrations;

namespace ComitBakery.Migrations
{
    public partial class IsArchivedBatch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Batch");

            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "Batch",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "Batch");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Batch",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
