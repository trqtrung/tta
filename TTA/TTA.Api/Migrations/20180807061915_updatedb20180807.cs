using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace TTA.Api.Migrations
{
    public partial class updatedb20180807 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "suppliers",
                newName: "phone");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "suppliers",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "suppliers",
                newName: "address");

            migrationBuilder.AddColumn<int>(
                name: "brand",
                table: "products",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "enabled",
                table: "products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "sku",
                table: "products",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "size_inch",
                table: "products",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "size_mm",
                table: "products",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "weight",
                table: "products",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "buying_prices",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    supplier_id = table.Column<int>(nullable: false),
                    product_id = table.Column<int>(nullable: false),
                    price_date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_buying_prices", x => x.id);
                    table.ForeignKey(
                        name: "FK_buying_prices_products_product_id",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_buying_prices_suppliers_supplier_id",
                        column: x => x.supplier_id,
                        principalTable: "suppliers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created = table.Column<DateTimeOffset>(nullable: false),
                    name = table.Column<string>(nullable: false),
                    phone = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    address = table.Column<string>(nullable: true),
                    username = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    salt = table.Column<string>(nullable: true),
                    last_login = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "selling_prices",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    customer_id = table.Column<int>(nullable: false),
                    CustomerId1 = table.Column<Guid>(nullable: true),
                    quantity_from = table.Column<int>(nullable: false),
                    quantity_to = table.Column<int>(nullable: false),
                    product_id = table.Column<int>(nullable: false),
                    price_date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_selling_prices", x => x.id);
                    table.ForeignKey(
                        name: "FK_selling_prices_customers_CustomerId1",
                        column: x => x.CustomerId1,
                        principalTable: "customers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_selling_prices_products_product_id",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_order_items_product_id",
                table: "order_items",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_buying_prices_product_id",
                table: "buying_prices",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_buying_prices_supplier_id",
                table: "buying_prices",
                column: "supplier_id");

            migrationBuilder.CreateIndex(
                name: "IX_selling_prices_CustomerId1",
                table: "selling_prices",
                column: "CustomerId1");

            migrationBuilder.CreateIndex(
                name: "IX_selling_prices_product_id",
                table: "selling_prices",
                column: "product_id");

            migrationBuilder.AddForeignKey(
                name: "FK_order_items_products_product_id",
                table: "order_items",
                column: "product_id",
                principalTable: "products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_order_items_products_product_id",
                table: "order_items");

            migrationBuilder.DropTable(
                name: "buying_prices");

            migrationBuilder.DropTable(
                name: "selling_prices");

            migrationBuilder.DropTable(
                name: "customers");

            migrationBuilder.DropIndex(
                name: "IX_order_items_product_id",
                table: "order_items");

            migrationBuilder.DropColumn(
                name: "brand",
                table: "products");

            migrationBuilder.DropColumn(
                name: "enabled",
                table: "products");

            migrationBuilder.DropColumn(
                name: "sku",
                table: "products");

            migrationBuilder.DropColumn(
                name: "size_inch",
                table: "products");

            migrationBuilder.DropColumn(
                name: "size_mm",
                table: "products");

            migrationBuilder.DropColumn(
                name: "weight",
                table: "products");

            migrationBuilder.RenameColumn(
                name: "phone",
                table: "suppliers",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "suppliers",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "address",
                table: "suppliers",
                newName: "Address");
        }
    }
}
