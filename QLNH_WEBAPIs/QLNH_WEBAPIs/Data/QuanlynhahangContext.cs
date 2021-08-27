using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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

        private string connect_str = "Server=localhost;Database=quanlynhahang;Port=3306; uid=root; password=";
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

        public QuanlynhahangContext(DbContextOptions<QuanlynhahangContext> options, IConfiguration configuration):base(options)
        {
            //Database.EnsureCreated();
        }
        
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //optionsBuilder.UseMySql(connect_str, ServerVersion.AutoDetect(connect_str));
            //optionsBuilder.UseMySql(conn, ServerVersion.AutoDetect(conn));


        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
