using Microsoft.EntityFrameworkCore.Migrations;

namespace DB.Migrations
{
    public partial class needed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Remark",
                table: "Sales",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Remark",
                table: "SaleDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Remark",
                table: "Purchases",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Remark",
                table: "PurchaseDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShortName",
                table: "productSizes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SizeName",
                table: "productSizes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FeatureDetailValue",
                table: "ProductFeatureDetail",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Remark",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "Remark",
                table: "SaleDetails");

            migrationBuilder.DropColumn(
                name: "Remark",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "Remark",
                table: "PurchaseDetails");

            migrationBuilder.DropColumn(
                name: "ShortName",
                table: "productSizes");

            migrationBuilder.DropColumn(
                name: "SizeName",
                table: "productSizes");

            migrationBuilder.DropColumn(
                name: "FeatureDetailValue",
                table: "ProductFeatureDetail");
        }
    }
}
