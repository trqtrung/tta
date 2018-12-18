using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TTA.Api.Migrations
{
    public partial class deletecustomersellingprice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_selling_prices_customers_customer_id",
                table: "selling_prices");

            migrationBuilder.DropIndex(
                name: "IX_selling_prices_customer_id",
                table: "selling_prices");

            migrationBuilder.DropColumn(
                name: "customer_id",
                table: "selling_prices");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "customer_id",
                table: "selling_prices",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_selling_prices_customer_id",
                table: "selling_prices",
                column: "customer_id");

            migrationBuilder.AddForeignKey(
                name: "FK_selling_prices_customers_customer_id",
                table: "selling_prices",
                column: "customer_id",
                principalTable: "customers",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
