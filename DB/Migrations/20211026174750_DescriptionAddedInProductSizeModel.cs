using Microsoft.EntityFrameworkCore.Migrations;

namespace DB.Migrations
{
    public partial class DescriptionAddedInProductSizeModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "productSizes",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "productSizes");
        }
    }
}
