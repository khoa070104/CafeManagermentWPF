using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using FunnyCafeManagerment_DataAccess.Models;

namespace FunnyCafeManagerment_DataAccess.Contexts
{
    public class FunnyCafeContext : DbContext
    {
        public DbSet<Problem> Problems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Revenue> Revenues { get; set; }
        public DbSet<ProductFavorite> ProductFavorites { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Đọc chuỗi kết nối từ appsettings.json
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().ToTable("Categories"); // Chỉ định tên bảng là "Categories"
            
            // Đảm bảo rằng TableId là tự tăng
            modelBuilder.Entity<Table>()
                .Property(t => t.TableId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProductId).HasName("PK__Products__B40CC6ED9D8E1EB3");

                entity.Property(e => e.ProductId)
                    .HasColumnName("ProductID");

                entity.Property(e => e.CategoryId)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("CategoryID");

                entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
                entity.Property(e => e.ProductImage).IsUnicode(false);
                entity.Property(e => e.ProductName).HasMaxLength(255);

                entity.HasOne(d => d.Category).WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Products__Catego__412EB0B6");

                // Cấu hình mối quan hệ với ProductFavorite
                entity.HasMany(e => e.ProductFavorites)
                    .WithOne(e => e.Product)
                    .HasForeignKey(e => e.ProductID);
            });

            modelBuilder.Entity<ProductFavorite>(entity =>
            {
                entity.HasKey(e => e.ProductFavoriteID);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductFavorites)
                    .HasForeignKey(d => d.ProductID)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__ProductFa__Produ__6B24EA82");
            });
        }
    }
}