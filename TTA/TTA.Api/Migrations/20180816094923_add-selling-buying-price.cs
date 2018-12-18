using Microsoft.EntityFrameworkCore.Migrations;

namespace TTA.Api.Migrations
{
    public partial class addsellingbuyingprice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "price",
                table: "selling_prices",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "price",
                table: "buying_prices",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "price",
                table: "selling_prices");

            migrationBuilder.DropColumn(
                name: "price",
                table: "buying_prices");
        }
    }
}
