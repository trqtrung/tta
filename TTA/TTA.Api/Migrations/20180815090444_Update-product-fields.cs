using Microsoft.EntityFrameworkCore.Migrations;

namespace TTA.Api.Migrations
{
    public partial class Updateproductfields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "height",
                table: "products",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "length",
                table: "products",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "width",
                table: "products",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "height",
                table: "products");

            migrationBuilder.DropColumn(
                name: "length",
                table: "products");

            migrationBuilder.DropColumn(
                name: "width",
                table: "products");
        }
    }
}
