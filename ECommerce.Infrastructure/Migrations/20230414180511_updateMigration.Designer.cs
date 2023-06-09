﻿// <auto-generated />
using System;
using ECommerce.Infrastructure.EFCore.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ECommerce.Infrastructure.EFCore.Migrations
{
    [DbContext(typeof(ECommerceDbContext))]
    [Migration("20230414180511_updateMigration")]
    partial class updateMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("dbo")
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ECommerce.Domain.AggregateModels.BasketAggregate.Basket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_on");

                    b.Property<int?>("GuestId")
                        .HasColumnType("int")
                        .HasColumnName("guest_id");

                    b.Property<bool>("Status")
                        .HasColumnType("bit")
                        .HasColumnName("basket_status");

                    b.Property<int>("TotalPrice")
                        .HasColumnType("int")
                        .HasColumnName("basket_total_price");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime2")
                        .HasColumnName("updated_on");

                    b.Property<int?>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("GuestId");

                    b.HasIndex("UserId");

                    b.ToTable("basket", "dbo");
                });

            modelBuilder.Entity("ECommerce.Domain.AggregateModels.BasketAggregate.BasketItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BasketId")
                        .HasColumnType("int")
                        .HasColumnName("basket_id");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_on");

                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("product_id");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("basket_item_quantity");

                    b.Property<int>("TotalPrice")
                        .HasColumnType("int")
                        .HasColumnName("basket_item_total_price");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime2")
                        .HasColumnName("updated_on");

                    b.HasKey("Id");

                    b.HasIndex("BasketId");

                    b.HasIndex("ProductId");

                    b.ToTable("basket_item", "dbo");
                });

            modelBuilder.Entity("ECommerce.Domain.AggregateModels.CategoryAggregate.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_on");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar")
                        .HasColumnName("category_name");

                    b.Property<int?>("ParentCategoryId")
                        .HasColumnType("int")
                        .HasColumnName("parent_category_id");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime2")
                        .HasColumnName("updated_on");

                    b.HasKey("Id");

                    b.ToTable("category", "dbo");
                });

            modelBuilder.Entity("ECommerce.Domain.AggregateModels.GuestAggregate.Guest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_on");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime2")
                        .HasColumnName("updated_on");

                    b.HasKey("Id");

                    b.ToTable("guest", "dbo");
                });

            modelBuilder.Entity("ECommerce.Domain.AggregateModels.ProductAggregate.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_on");

                    b.Property<int>("Inventory")
                        .HasColumnType("int")
                        .HasColumnName("product_inventory");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar")
                        .HasColumnName("product_name");

                    b.Property<int>("Price")
                        .HasColumnType("int")
                        .HasColumnName("product_price");

                    b.Property<bool>("Status")
                        .HasColumnType("bit")
                        .HasColumnName("product_status");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime2")
                        .HasColumnName("updated_on");

                    b.HasKey("Id");

                    b.ToTable("product", "dbo");
                });

            modelBuilder.Entity("ECommerce.Domain.AggregateModels.ProductAggregate.ProductCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("category_id");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_on");

                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("product_id");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime2")
                        .HasColumnName("updated_on");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ProductId");

                    b.ToTable("product_category", "dbo");
                });

            modelBuilder.Entity("ECommerce.Domain.AggregateModels.UserModels.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar")
                        .HasColumnName("city");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_on");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar")
                        .HasColumnName("last_name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar")
                        .HasColumnName("password");

                    b.Property<bool>("Status")
                        .HasColumnType("bit")
                        .HasColumnName("status");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime2")
                        .HasColumnName("updated_on");

                    b.HasKey("Id");

                    b.ToTable("user", "dbo");
                });

            modelBuilder.Entity("ECommerce.Domain.AggregateModels.BasketAggregate.Basket", b =>
                {
                    b.HasOne("ECommerce.Domain.AggregateModels.GuestAggregate.Guest", "Guest")
                        .WithMany("Baskets")
                        .HasForeignKey("GuestId")
                        .HasConstraintName("guest_basket_id_fk");

                    b.HasOne("ECommerce.Domain.AggregateModels.UserModels.User", "User")
                        .WithMany("Baskets")
                        .HasForeignKey("UserId")
                        .HasConstraintName("user_basket_id_fk");

                    b.Navigation("Guest");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ECommerce.Domain.AggregateModels.BasketAggregate.BasketItem", b =>
                {
                    b.HasOne("ECommerce.Domain.AggregateModels.BasketAggregate.Basket", "Basket")
                        .WithMany("Items")
                        .HasForeignKey("BasketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("basket_basket_item_id_fk");

                    b.HasOne("ECommerce.Domain.AggregateModels.ProductAggregate.Product", "Product")
                        .WithMany("Items")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("product_basket_item_id_fk");

                    b.Navigation("Basket");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ECommerce.Domain.AggregateModels.ProductAggregate.ProductCategory", b =>
                {
                    b.HasOne("ECommerce.Domain.AggregateModels.CategoryAggregate.Category", "Category")
                        .WithMany("ProductCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("category_product_category_id_fk");

                    b.HasOne("ECommerce.Domain.AggregateModels.ProductAggregate.Product", "Product")
                        .WithMany("ProductCategories")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("product_product_category_item_id_fk");

                    b.Navigation("Category");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ECommerce.Domain.AggregateModels.BasketAggregate.Basket", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("ECommerce.Domain.AggregateModels.CategoryAggregate.Category", b =>
                {
                    b.Navigation("ProductCategories");
                });

            modelBuilder.Entity("ECommerce.Domain.AggregateModels.GuestAggregate.Guest", b =>
                {
                    b.Navigation("Baskets");
                });

            modelBuilder.Entity("ECommerce.Domain.AggregateModels.ProductAggregate.Product", b =>
                {
                    b.Navigation("Items");

                    b.Navigation("ProductCategories");
                });

            modelBuilder.Entity("ECommerce.Domain.AggregateModels.UserModels.User", b =>
                {
                    b.Navigation("Baskets");
                });
#pragma warning restore 612, 618
        }
    }
}
