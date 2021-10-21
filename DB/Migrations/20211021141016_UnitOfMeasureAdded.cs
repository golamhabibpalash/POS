using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DB.Migrations
{
    public partial class UnitOfMeasureAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UoM",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "UnitOfMeasureId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "UnitOfMeasure",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitOfMeasure", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_UnitOfMeasureId",
                table: "Products",
                column: "UnitOfMeasureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_UnitOfMeasure_UnitOfMeasureId",
                table: "Products",
                column: "UnitOfMeasureId",
                principalTable: "UnitOfMeasure",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_UnitOfMeasure_UnitOfMeasureId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "UnitOfMeasure");

            migrationBuilder.DropIndex(
                name: "IX_Products_UnitOfMeasureId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UnitOfMeasureId",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "UoM",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
