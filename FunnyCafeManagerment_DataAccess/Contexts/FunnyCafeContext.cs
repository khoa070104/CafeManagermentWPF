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
        public DbSet<Revenue> Revenue { get; set; }
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
        }
    }
}