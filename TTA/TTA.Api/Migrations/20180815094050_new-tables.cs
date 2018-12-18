using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace TTA.Api.Migrations
{
    public partial class newtables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "brand",
                table: "products",
                newName: "brand_id");

            migrationBuilder.AlterColumn<Guid>(
                name: "customer_id",
                table: "selling_prices",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.CreateTable(
                name: "product_descriptions",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(nullable: false),
                    language = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    created = table.Column<DateTime>(nullable: true),
                    product_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_descriptions", x => x.id);
                    table.ForeignKey(
                        name: "FK_product_descriptions_products_product_id",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_selling_prices_customer_id",
                table: "selling_prices",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_descriptions_product_id",
                table: "product_descriptions",
                column: "product_id");

            migrationBuilder.AddForeignKey(
                name: "FK_selling_prices_customers_customer_id",
                table: "selling_prices",
                column: "customer_id",
                principalTable: "customers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_selling_prices_customers_customer_id",
                table: "selling_prices");

            migrationBuilder.DropTable(
                name: "product_descriptions");

            migrationBuilder.DropIndex(
                name: "IX_selling_prices_customer_id",
                table: "selling_prices");

            migrationBuilder.RenameColumn(
                name: "brand_id",
                table: "products",
                newName: "brand");

            migrationBuilder.AlterColumn<int>(
                name: "customer_id",
                table: "selling_prices",
                nullable: false,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId1",
                table: "selling_prices",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_selling_prices_CustomerId1",
                table: "selling_prices",
                column: "CustomerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_selling_prices_customers_CustomerId1",
                table: "selling_prices",
                column: "CustomerId1",
                principalTable: "customers",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
