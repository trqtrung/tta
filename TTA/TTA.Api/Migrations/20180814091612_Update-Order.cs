using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TTA.Api.Migrations
{
    public partial class UpdateOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "cancel_reason",
                table: "orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "customer_address",
                table: "orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "customer_name",
                table: "orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "customer_phone",
                table: "orders",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "order_date",
                table: "orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "payment_method",
                table: "orders",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "updated",
                table: "orders",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "updated",
                table: "customers",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cancel_reason",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "customer_address",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "customer_name",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "customer_phone",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "order_date",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "payment_method",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "updated",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "updated",
                table: "customers");
        }
    }
}
