using ECommerce.Domain.AggregateModels.BasketAggregate;
using ECommerce.Domain.AggregateModels.CategoryAggregate;
using ECommerce.Domain.AggregateModels.GuestAggregate;
using ECommerce.Domain.AggregateModels.ProductAggregate;
using ECommerce.Domain.AggregateModels.UserModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Infrastructure.EFCore.Context
{
    public class ECommerceDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }
        public ECommerceDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //var connectionString = _configuration.GetConnectionString("DbConnectionString");
            //if (string.IsNullOrEmpty(connectionString))
            //{
            //    throw new Exception("Connection string is null or empty.");
            //}

            if (!optionsBuilder.IsConfigured)
            {
                // make the configurations
                optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog= ECommerce;Persist Security Info=False;User ID=sa;Password=Doga123.;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False;Connection Timeout=30");
            }
        }

        //  DbSets
        public DbSet<User> Users { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }


        // Mapping
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");

            // Id Column tipine bak !!! Guid = uniqueidentifier ?
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(i => i.Id).HasColumnName("id").HasColumnType("int").ValueGeneratedOnAdd().UseIdentityColumn().IsRequired();
                entity.Property(i => i.FirstName).HasColumnName("first_name").HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
                entity.Property(i => i.LastName).HasColumnName("last_name").HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
                entity.Property(i => i.Email).HasColumnName("email").HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
                entity.Property(i => i.Password).HasColumnName("password").HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
                entity.Property(i => i.City).HasColumnName("city").HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
                entity.Property(i => i.Status).HasColumnName("status").IsRequired();
                entity.Property(i => i.CreatedOn).HasColumnName("created_on").HasColumnType("datetime2").IsRequired();
                entity.Property(i => i.UpdatedOn).HasColumnName("updated_on").HasColumnType("datetime2").IsRequired();

                // One-To-Many Relation (User - Basket)
                entity.HasMany(c => c.Baskets)
                    .WithOne(p => p.User)
                    .HasForeignKey(p => p.UserId)
                    .HasConstraintName("user_basket_id_fk");
            });

            modelBuilder.Entity<Guest>(entity =>
            {
                entity.ToTable("guest");

                entity.Property(i => i.Id).HasColumnName("id").HasColumnType("int").ValueGeneratedOnAdd().UseIdentityColumn().IsRequired();
                entity.Property(i => i.CreatedOn).HasColumnName("created_on").HasColumnType("datetime2").IsRequired();
                entity.Property(i => i.UpdatedOn).HasColumnName("updated_on").HasColumnType("datetime2").IsRequired();

                // One-To-Many Relation (Guest - Basket)
                entity.HasMany(c => c.Baskets)
                    .WithOne(p => p.Guest)
                    .HasForeignKey(p => p.GuestId)
                    .HasConstraintName("guest_basket_id_fk");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("category");

                entity.Property(i => i.Id).HasColumnName("id").HasColumnType("int").ValueGeneratedOnAdd().UseIdentityColumn().IsRequired();
                entity.Property(i => i.Name).HasColumnName("category_name").HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
                entity.Property(i => i.ParentCategoryId).HasColumnName("parent_category_id").HasColumnType("int").IsRequired(false);
                entity.Property(i => i.CreatedOn).HasColumnName("created_on").HasColumnType("datetime2").IsRequired();
                entity.Property(i => i.UpdatedOn).HasColumnName("updated_on").HasColumnType("datetime2").IsRequired();
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("product");

                entity.Property(i => i.Id).HasColumnName("id").HasColumnType("int").ValueGeneratedOnAdd().UseIdentityColumn().IsRequired();
                entity.Property(i => i.Name).HasColumnName("product_name").HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
                entity.Property(i => i.Price).HasColumnName("product_price").HasColumnType("int").IsRequired();
                entity.Property(i => i.Inventory).HasColumnName("product_inventory").HasColumnType("int").IsRequired();
                entity.Property(i => i.Status).HasColumnName("product_status").IsRequired();
                entity.Property(i => i.CreatedOn).HasColumnName("created_on").HasColumnType("datetime2").IsRequired();
                entity.Property(i => i.UpdatedOn).HasColumnName("updated_on").HasColumnType("datetime2").IsRequired();
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.ToTable("product_category");

                entity.Property(i => i.Id).HasColumnName("id").HasColumnType("int").ValueGeneratedOnAdd().UseIdentityColumn().IsRequired();
                entity.Property(i => i.CreatedOn).HasColumnName("created_on").HasColumnType("datetime2").IsRequired();
                entity.Property(i => i.UpdatedOn).HasColumnName("updated_on").HasColumnType("datetime2").IsRequired();
                entity.Property(i => i.CategoryId).HasColumnName("category_id").HasColumnType("int").IsRequired();
                entity.Property(i => i.ProductId).HasColumnName("product_id").HasColumnType("int").IsRequired();

                // One-To-Many Relation (Category - ProductCategory)
                entity.HasOne(c => c.Category)
                    .WithMany(p => p.ProductCategories)
                    .HasForeignKey(p => p.CategoryId)
                    .HasConstraintName("category_product_category_id_fk");

                // One-To-Many Relation (Product - ProductCategory)
                entity.HasOne(c => c.Product)
                    .WithMany(p => p.ProductCategories)
                    .HasForeignKey(p => p.ProductId)
                    .HasConstraintName("product_product_category_item_id_fk");
            });

            modelBuilder.Entity<Basket>(entity =>
            {
                entity.ToTable("basket");

                entity.Property(i => i.Id).HasColumnName("id").HasColumnType("int").ValueGeneratedOnAdd().UseIdentityColumn().IsRequired();
                entity.Property(i => i.TotalPrice).HasColumnName("basket_total_price").HasColumnType("int").IsRequired();
                entity.Property(i => i.Status).HasColumnName("basket_status").IsRequired();
                entity.Property(i => i.UserId).HasColumnName("user_id").HasColumnType("int").IsRequired(false);
                entity.Property(i => i.GuestId).HasColumnName("guest_id").HasColumnType("int").IsRequired(false);
                entity.Property(i => i.CreatedOn).HasColumnName("created_on").HasColumnType("datetime2").IsRequired();
                entity.Property(i => i.UpdatedOn).HasColumnName("updated_on").HasColumnType("datetime2").IsRequired();
            });

            modelBuilder.Entity<BasketItem>(entity =>
            {
                entity.ToTable("basket_item");

                entity.Property(i => i.Id).HasColumnName("id").HasColumnType("int").ValueGeneratedOnAdd().UseIdentityColumn().IsRequired();
                entity.Property(i => i.Quantity).HasColumnName("basket_item_quantity").HasColumnType("int").IsRequired();
                entity.Property(i => i.TotalPrice).HasColumnName("basket_item_total_price").HasColumnType("int").IsRequired();
                entity.Property(i => i.BasketId).HasColumnName("basket_id").HasColumnType("int").IsRequired();
                entity.Property(i => i.ProductId).HasColumnName("product_id").HasColumnType("int").IsRequired();
                entity.Property(i => i.CreatedOn).HasColumnName("created_on").HasColumnType("datetime2").IsRequired();
                entity.Property(i => i.UpdatedOn).HasColumnName("updated_on").HasColumnType("datetime2").IsRequired();

                // One-To-Many Relation (Basket - BasketItem)
                entity.HasOne(c => c.Basket)
                    .WithMany(p => p.Items)
                    .HasForeignKey(p => p.BasketId)
                    .HasConstraintName("basket_basket_item_id_fk");

                // One-To-Many Relation (Product - BasketItem)
                entity.HasOne(c => c.Product)
                    .WithMany(p => p.Items)
                    .HasForeignKey(p => p.ProductId)
                    .HasConstraintName("product_basket_item_id_fk");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
