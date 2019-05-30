﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using sproject.Data;

namespace sproject.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("25620530185916_c3")]
    partial class c3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("sproject.Models.BackOrder", b =>
                {
                    b.Property<int>("backOrder_id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Product_id");

                    b.Property<DateTime>("backOrderDate");

                    b.Property<int>("purchaseItem_id");

                    b.HasKey("backOrder_id");

                    b.HasIndex("Product_id");

                    b.HasIndex("purchaseItem_id");

                    b.ToTable("BackOrder");
                });

            modelBuilder.Entity("sproject.Models.CustomerInfo", b =>
                {
                    b.Property<int>("customerinfo_id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("customer_name")
                        .IsRequired();

                    b.Property<string>("customer_phone")
                        .IsRequired();

                    b.HasKey("customerinfo_id");

                    b.ToTable("CustomerInfos");
                });

            modelBuilder.Entity("sproject.Models.CustomerOrder", b =>
                {
                    b.Property<int>("customerorder_id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("customerinfo_id");

                    b.Property<DateTime>("customerorder_date");

                    b.Property<int>("customerorder_qty");

                    b.Property<int>("product_id");

                    b.HasKey("customerorder_id");

                    b.HasIndex("customerinfo_id");

                    b.HasIndex("product_id");

                    b.ToTable("CustomerOrders");
                });

            modelBuilder.Entity("sproject.Models.Inventory", b =>
                {
                    b.Property<int>("inventory_id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("product_id");

                    b.HasKey("inventory_id");

                    b.HasIndex("product_id");

                    b.ToTable("Inventories");
                });

            modelBuilder.Entity("sproject.Models.InventoryIn", b =>
                {
                    b.Property<int>("inventoryin_id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("inventoryin_qty");

                    b.Property<int>("manufacturer_week");

                    b.Property<int>("manufacturer_year");

                    b.Property<int>("product_id");

                    b.Property<int>("purchaseItem_id");

                    b.Property<int>("purchase_id");

                    b.HasKey("inventoryin_id");

                    b.HasIndex("product_id");

                    b.HasIndex("purchaseItem_id");

                    b.HasIndex("purchase_id");

                    b.ToTable("InventoryIn");
                });

            modelBuilder.Entity("sproject.Models.PActivity", b =>
                {
                    b.Property<int>("activity_id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("activity_date");

                    b.Property<int>("purchaseItem_id");

                    b.Property<int>("purchase_type_id");

                    b.HasKey("activity_id");

                    b.HasIndex("purchaseItem_id");

                    b.HasIndex("purchase_type_id");

                    b.ToTable("PActivities");
                });

            modelBuilder.Entity("sproject.Models.ProductInfo", b =>
                {
                    b.Property<int>("product_id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("product_name")
                        .IsRequired();

                    b.Property<string>("product_series")
                        .IsRequired();

                    b.Property<string>("product_size")
                        .IsRequired();

                    b.Property<int>("supplier_id");

                    b.HasKey("product_id");

                    b.HasIndex("supplier_id");

                    b.ToTable("ProductInfos");
                });

            modelBuilder.Entity("sproject.Models.PurchaseItem", b =>
                {
                    b.Property<int>("purchaseItem_id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("product_id");

                    b.Property<double>("purchase_cost");

                    b.Property<int>("purchase_id");

                    b.Property<int>("purchase_type_id");

                    b.Property<int>("qty");

                    b.Property<double>("selling_price");

                    b.Property<int>("supplier_id");

                    b.HasKey("purchaseItem_id");

                    b.HasIndex("product_id");

                    b.HasIndex("purchase_id");

                    b.HasIndex("purchase_type_id");

                    b.HasIndex("supplier_id");

                    b.ToTable("PurchaseItems");
                });

            modelBuilder.Entity("sproject.Models.PurchaseOrder", b =>
                {
                    b.Property<int>("purchase_id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("purchase_date");

                    b.HasKey("purchase_id");

                    b.ToTable("PurchaseOrders");
                });

            modelBuilder.Entity("sproject.Models.PurchaseOrderType", b =>
                {
                    b.Property<int>("Purchase_type_id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Purchase_type_name");

                    b.HasKey("Purchase_type_id");

                    b.ToTable("PurchaseOrderTypes");
                });

            modelBuilder.Entity("sproject.Models.SupplierInfo", b =>
                {
                    b.Property<int>("supplier_id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("supplier_address");

                    b.Property<string>("supplier_name")
                        .IsRequired();

                    b.Property<string>("supplier_person");

                    b.Property<string>("supplier_phone");

                    b.Property<int>("supplier_type_id");

                    b.HasKey("supplier_id");

                    b.HasIndex("supplier_type_id");

                    b.ToTable("SupplierInfos");
                });

            modelBuilder.Entity("sproject.Models.SupplierPerformance", b =>
                {
                    b.Property<int>("SupplierPerformance_id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("backOrder_id");

                    b.Property<DateTime>("deliver_date");

                    b.Property<int>("leadTime");

                    b.Property<int>("purchaseItem_id");

                    b.Property<int>("purchase_id");

                    b.Property<int>("supplier_id");

                    b.HasKey("SupplierPerformance_id");

                    b.HasIndex("backOrder_id");

                    b.HasIndex("purchaseItem_id");

                    b.HasIndex("purchase_id");

                    b.HasIndex("supplier_id");

                    b.ToTable("SupplierPerformances");
                });

            modelBuilder.Entity("sproject.Models.SupplierType", b =>
                {
                    b.Property<int>("supplier_type_id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("supplier_type_name");

                    b.HasKey("supplier_type_id");

                    b.ToTable("SupplierTypes");
                });

            modelBuilder.Entity("sproject.Models.BackOrder", b =>
                {
                    b.HasOne("sproject.Models.ProductInfo", "productInfo")
                        .WithMany()
                        .HasForeignKey("Product_id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("sproject.Models.PurchaseItem", "purchaseItem")
                        .WithMany()
                        .HasForeignKey("purchaseItem_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("sproject.Models.CustomerOrder", b =>
                {
                    b.HasOne("sproject.Models.CustomerInfo", "customerInfo")
                        .WithMany()
                        .HasForeignKey("customerinfo_id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("sproject.Models.ProductInfo", "productInfo")
                        .WithMany()
                        .HasForeignKey("product_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("sproject.Models.Inventory", b =>
                {
                    b.HasOne("sproject.Models.ProductInfo", "productInfo")
                        .WithMany()
                        .HasForeignKey("product_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("sproject.Models.InventoryIn", b =>
                {
                    b.HasOne("sproject.Models.ProductInfo", "productinfo")
                        .WithMany()
                        .HasForeignKey("product_id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("sproject.Models.PurchaseItem", "purchaseItems")
                        .WithMany()
                        .HasForeignKey("purchaseItem_id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("sproject.Models.PurchaseOrder", "purchaseorder")
                        .WithMany()
                        .HasForeignKey("purchase_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("sproject.Models.PActivity", b =>
                {
                    b.HasOne("sproject.Models.PurchaseItem", "purchaseItem")
                        .WithMany()
                        .HasForeignKey("purchaseItem_id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("sproject.Models.PurchaseOrderType", "purchaseordertype")
                        .WithMany()
                        .HasForeignKey("purchase_type_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("sproject.Models.ProductInfo", b =>
                {
                    b.HasOne("sproject.Models.SupplierInfo", "supplierInfo")
                        .WithMany()
                        .HasForeignKey("supplier_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("sproject.Models.PurchaseItem", b =>
                {
                    b.HasOne("sproject.Models.ProductInfo", "productInfo")
                        .WithMany()
                        .HasForeignKey("product_id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("sproject.Models.PurchaseOrder")
                        .WithMany("purchase_items")
                        .HasForeignKey("purchase_id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("sproject.Models.PurchaseOrderType", "purchaseorder_type")
                        .WithMany()
                        .HasForeignKey("purchase_type_id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("sproject.Models.SupplierInfo", "supplierInfo")
                        .WithMany()
                        .HasForeignKey("supplier_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("sproject.Models.SupplierInfo", b =>
                {
                    b.HasOne("sproject.Models.SupplierType", "supplier_type")
                        .WithMany()
                        .HasForeignKey("supplier_type_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("sproject.Models.SupplierPerformance", b =>
                {
                    b.HasOne("sproject.Models.BackOrder", "backOrder")
                        .WithMany()
                        .HasForeignKey("backOrder_id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("sproject.Models.PurchaseItem", "purchaseItem")
                        .WithMany()
                        .HasForeignKey("purchaseItem_id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("sproject.Models.PurchaseOrder", "purchaseOrder")
                        .WithMany()
                        .HasForeignKey("purchase_id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("sproject.Models.SupplierInfo", "supplierInfo")
                        .WithMany()
                        .HasForeignKey("supplier_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
