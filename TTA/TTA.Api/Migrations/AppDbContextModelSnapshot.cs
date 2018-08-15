﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TTA.Api.Data;

namespace TTA.Api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.0-rtm-30799")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("TTA.Api.Models.BuyingPrice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<DateTime>("PriceDate")
                        .HasColumnName("price_date");

                    b.Property<int>("ProductId")
                        .HasColumnName("product_id");

                    b.Property<int>("SupplierId")
                        .HasColumnName("supplier_id");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("SupplierId");

                    b.ToTable("buying_prices");
                });

            modelBuilder.Entity("TTA.Api.Models.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Address")
                        .HasColumnName("address");

                    b.Property<DateTimeOffset>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("created");

                    b.Property<string>("Email")
                        .HasColumnName("email");

                    b.Property<DateTime>("LastLogin")
                        .HasColumnName("last_login");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .HasColumnName("password");

                    b.Property<string>("Phone")
                        .HasColumnName("phone");

                    b.Property<string>("Salt")
                        .HasColumnName("salt");

                    b.Property<DateTimeOffset>("Updated")
                        .HasColumnName("updated");

                    b.Property<string>("Username")
                        .HasColumnName("username");

                    b.HasKey("Id");

                    b.ToTable("customers");
                });

            modelBuilder.Entity("TTA.Api.Models.OptionList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnName("key");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name");

                    b.Property<Guid?>("RecordGuid")
                        .HasColumnName("record_guid");

                    b.Property<string>("Value")
                        .HasColumnName("value");

                    b.Property<DateTime>("updated_timestamp");

                    b.HasKey("Id");

                    b.ToTable("option_lists");
                });

            modelBuilder.Entity("TTA.Api.Models.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("CancelReason")
                        .HasColumnName("cancel_reason");

                    b.Property<string>("Client")
                        .HasColumnName("client");

                    b.Property<string>("ClientOrderId")
                        .HasColumnName("client_order_id");

                    b.Property<DateTimeOffset>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("created");

                    b.Property<string>("CustomerAddress")
                        .HasColumnName("customer_address");

                    b.Property<Guid?>("CustomerId")
                        .HasColumnName("customer_id");

                    b.Property<string>("CustomerName")
                        .HasColumnName("customer_name");

                    b.Property<string>("CustomerPhone")
                        .HasColumnName("customer_phone");

                    b.Property<DateTime?>("Delivered")
                        .HasColumnName("delivered");

                    b.Property<string>("Note")
                        .HasColumnName("note");

                    b.Property<DateTime?>("OrderDate")
                        .HasColumnName("order_date");

                    b.Property<string>("OrderNo")
                        .IsRequired()
                        .HasColumnName("order_no");

                    b.Property<string>("PaymentMethod")
                        .HasColumnName("payment_method");

                    b.Property<DateTime?>("ReceivePayment")
                        .HasColumnName("receive_payment");

                    b.Property<string>("ShippingService")
                        .HasColumnName("shipping_service");

                    b.Property<string>("Stage")
                        .HasColumnName("stage");

                    b.Property<decimal?>("Total")
                        .HasColumnName("total");

                    b.Property<DateTimeOffset>("Updated")
                        .HasColumnName("updated");

                    b.Property<DateTime>("updated_timestamp");

                    b.HasKey("Id");

                    b.HasAlternateKey("Id", "OrderNo");

                    b.ToTable("orders");
                });

            modelBuilder.Entity("TTA.Api.Models.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<decimal>("Discount")
                        .HasColumnName("discount");

                    b.Property<Guid>("OrderId")
                        .HasColumnName("order_id");

                    b.Property<decimal>("Price")
                        .HasColumnName("price");

                    b.Property<int>("ProductId")
                        .HasColumnName("product_id");

                    b.Property<int>("Quantity")
                        .HasColumnName("quantity");

                    b.Property<DateTime>("updated_timestamp");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("order_items");
                });

            modelBuilder.Entity("TTA.Api.Models.OrderTracking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<int?>("Action")
                        .HasColumnName("Action");

                    b.Property<Guid>("OrderId")
                        .HasColumnName("order_id");

                    b.Property<DateTime>("TrackingTime")
                        .HasColumnName("tracking_time");

                    b.Property<string>("Type")
                        .HasColumnName("type");

                    b.Property<DateTime>("updated_timestamp");

                    b.HasKey("Id");

                    b.ToTable("order_tracking");
                });

            modelBuilder.Entity("TTA.Api.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<int?>("Brand")
                        .HasColumnName("brand");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("created");

                    b.Property<string>("Description")
                        .HasColumnName("description");

                    b.Property<bool?>("Enabled")
                        .HasColumnName("enabled");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name");

                    b.Property<string>("SKU")
                        .HasColumnName("sku");

                    b.Property<decimal?>("SizeInch")
                        .HasColumnName("size_inch");

                    b.Property<decimal?>("SizeMM")
                        .HasColumnName("size_mm");

                    b.Property<int?>("Type")
                        .HasColumnName("type");

                    b.Property<decimal?>("Weight")
                        .HasColumnName("weight");

                    b.Property<DateTime>("updated_timestamp");

                    b.HasKey("Id");

                    b.ToTable("products");
                });

            modelBuilder.Entity("TTA.Api.Models.SellingPrice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<int>("CustomerId")
                        .HasColumnName("customer_id");

                    b.Property<Guid?>("CustomerId1");

                    b.Property<DateTime>("PriceDate")
                        .HasColumnName("price_date");

                    b.Property<int>("ProductId")
                        .HasColumnName("product_id");

                    b.Property<int>("QuantityFrom")
                        .HasColumnName("quantity_from");

                    b.Property<int>("QuantityTo")
                        .HasColumnName("quantity_to");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId1");

                    b.HasIndex("ProductId");

                    b.ToTable("selling_prices");
                });

            modelBuilder.Entity("TTA.Api.Models.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Address")
                        .HasColumnName("address");

                    b.Property<DateTime?>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("created");

                    b.Property<string>("Email")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name");

                    b.Property<string>("Phone")
                        .HasColumnName("phone");

                    b.Property<DateTime>("updated_timestamp");

                    b.HasKey("Id");

                    b.ToTable("suppliers");
                });

            modelBuilder.Entity("TTA.Api.Models.BuyingPrice", b =>
                {
                    b.HasOne("TTA.Api.Models.Product", "Product")
                        .WithMany("BuyingPrices")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TTA.Api.Models.Supplier", "Supplier")
                        .WithMany("ProductPrices")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TTA.Api.Models.OrderItem", b =>
                {
                    b.HasOne("TTA.Api.Models.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TTA.Api.Models.Product", "Product")
                        .WithMany("OrderItems")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TTA.Api.Models.SellingPrice", b =>
                {
                    b.HasOne("TTA.Api.Models.Customer", "Customer")
                        .WithMany("SellingPrices")
                        .HasForeignKey("CustomerId1");

                    b.HasOne("TTA.Api.Models.Product", "Product")
                        .WithMany("SellingPrices")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
