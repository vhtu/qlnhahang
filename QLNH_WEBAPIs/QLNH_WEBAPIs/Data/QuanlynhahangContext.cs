using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using QLNH_WEBAPIs.Configurations;
using QLNH_WEBAPIs.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace QLNH_WEBAPIs.Data
{
    public class QuanlynhahangContext : DbContext
    {

        //private string connect_str = "Server=localhost;Database=quanlynhahang;Port=3306; uid=root; password=";
        public DbSet<User> Users { set; get; }      // bảng users
        
        public DbSet<Item> Items { set; get; }      // bảng items
        public DbSet<test> Tests { set; get; }      // bảng items
        public DbSet<Category> Categories { set; get; }      // bảng items
        public DbSet<Guest> Guests { set; get; }      // bảng items
        public DbSet<GuestTable> GuestTables { set; get; }      // bảng items
        public DbSet<ItemImage> ItemImages { set; get; }      // bảng items
        public DbSet<Location> Locations { set; get; }      // bảng items
        public DbSet<Order> Orders { set; get; }      // bảng items
        public DbSet<OrderItem> OrderItems { set; get; }      // bảng items
        public DbSet<Role> Roles { set; get; }      // bảng items
        public DbSet<Status> Statuses { set; get; }      // bảng items
        public DbSet<Unit> Units { set; get; }      // bảng items
        public DbSet<UnitType> UnitTypes { set; get; }      // bảng items
        public object Configuration { get; }


        public QuanlynhahangContext(DbContextOptions<QuanlynhahangContext> options):base(options)
        {
            //Database.EnsureCreated();
           
        }
        
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            base.OnConfiguring(optionsBuilder);
            //optionsBuilder.UseLazyLoadingProxies();
            //optionsBuilder.UseMySql(connect_str, ServerVersion.AutoDetect(connect_str));
            //optionsBuilder.UseMySql(conn, ServerVersion.AutoDetect(conn));


        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Fluent API, định nghĩa trực tiếp tại đây
            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Description)
              //.HasColumnName("Mo_ta")    //Tùy chọn đặt lại tên cột Mo_ta (mặc định Description)
              .HasColumnType("varchar(20)")  // kiểu varchar(20)
              .HasDefaultValue("Chưa có mô tả")  // Giá trị mặc định
              .HasMaxLength(20);             // Độ dài của trường dữ liệu 20
            });
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Description)
              //.HasColumnName("Mo_ta")    //Tùy chọn đặt lại tên cột Mo_ta (mặc định Description)
              .HasColumnType("varchar(20)")  // kiểu varchar(20)
              .HasDefaultValue("Chưa có mô tả")  // Giá trị mặc định
              .HasMaxLength(20);             // Độ dài của trường dữ liệu 20
            });


            // khi định nghĩa Fluent API như ở bên trên (Category) có thể quá dài, we có thể tách ra thành file Configuration và add vào bên dưới
            modelBuilder.ApplyConfiguration(new GuestConfiguration());
            modelBuilder.ApplyConfiguration(new GuestTableConfiguration());
        }
    }
}
