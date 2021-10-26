using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DB.Migrations
{
    public partial class SupplierTypeAddedTOSupplierTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductFeature_ProductTypes_ProductTypeId",
                table: "ProductFeature");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductFeatureDetail_ProductFeature_ProductFeatureId",
                table: "ProductFeatureDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductFeatureDetail",
                table: "ProductFeatureDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductFeature",
                table: "ProductFeature");

            migrationBuilder.RenameTable(
                name: "ProductFeatureDetail",
                newName: "ProductFeatureDetails");

            migrationBuilder.RenameTable(
                name: "ProductFeature",
                newName: "ProductFeatures");

            migrationBuilder.RenameIndex(
                name: "IX_ProductFeatureDetail_ProductFeatureId",
                table: "ProductFeatureDetails",
                newName: "IX_ProductFeatureDetails_ProductFeatureId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductFeature_ProductTypeId",
                table: "ProductFeatures",
                newName: "IX_ProductFeatures_ProductTypeId");

            migrationBuilder.AddColumn<int>(
                name: "SupplierTypeId",
                table: "Suppliers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductFeatureDetails",
                table: "ProductFeatureDetails",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductFeatures",
                table: "ProductFeatures",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CustomerTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descriptions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SaleTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SaleTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SupplierTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_SupplierTypeId",
                table: "Suppliers",
                column: "SupplierTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductFeatureDetails_ProductFeatures_ProductFeatureId",
                table: "ProductFeatureDetails",
                column: "ProductFeatureId",
                principalTable: "ProductFeatures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductFeatures_ProductTypes_ProductTypeId",
                table: "ProductFeatures",
                column: "ProductTypeId",
                principalTable: "ProductTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_SupplierTypes_SupplierTypeId",
                table: "Suppliers",
                column: "SupplierTypeId",
                principalTable: "SupplierTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductFeatureDetails_ProductFeatures_ProductFeatureId",
                table: "ProductFeatureDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductFeatures_ProductTypes_ProductTypeId",
                table: "ProductFeatures");

            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_SupplierTypes_SupplierTypeId",
                table: "Suppliers");

            migrationBuilder.DropTable(
                name: "CustomerTypes");

            migrationBuilder.DropTable(
                name: "PurchaseTypes");

            migrationBuilder.DropTable(
                name: "SaleTypes");

            migrationBuilder.DropTable(
                name: "SupplierTypes");

            migrationBuilder.DropIndex(
                name: "IX_Suppliers_SupplierTypeId",
                table: "Suppliers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductFeatures",
                table: "ProductFeatures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductFeatureDetails",
                table: "ProductFeatureDetails");

            migrationBuilder.DropColumn(
                name: "SupplierTypeId",
                table: "Suppliers");

            migrationBuilder.RenameTable(
                name: "ProductFeatures",
                newName: "ProductFeature");

            migrationBuilder.RenameTable(
                name: "ProductFeatureDetails",
                newName: "ProductFeatureDetail");

            migrationBuilder.RenameIndex(
                name: "IX_ProductFeatures_ProductTypeId",
                table: "ProductFeature",
                newName: "IX_ProductFeature_ProductTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductFeatureDetails_ProductFeatureId",
                table: "ProductFeatureDetail",
                newName: "IX_ProductFeatureDetail_ProductFeatureId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductFeature",
                table: "ProductFeature",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductFeatureDetail",
                table: "ProductFeatureDetail",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductFeature_ProductTypes_ProductTypeId",
                table: "ProductFeature",
                column: "ProductTypeId",
                principalTable: "ProductTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductFeatureDetail_ProductFeature_ProductFeatureId",
                table: "ProductFeatureDetail",
                column: "ProductFeatureId",
                principalTable: "ProductFeature",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
