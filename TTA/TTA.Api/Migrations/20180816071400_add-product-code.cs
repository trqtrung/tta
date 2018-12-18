using Microsoft.EntityFrameworkCore.Migrations;

namespace TTA.Api.Migrations
{
    public partial class addproductcode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "product_code",
                table: "products",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "product_code",
            //    table: "products");
        }
    }
}
