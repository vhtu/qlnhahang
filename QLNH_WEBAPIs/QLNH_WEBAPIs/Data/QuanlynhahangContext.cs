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

        //private readonly IConfiguration _configuration;

        //private readonly string conn;

        private string connect_str = "Server=localhost;Database=quanlynhahang;Port=3306; uid=root; password=";
        public DbSet<User> users { set; get; }      // bảng users

        /*
        public QuanlynhahangContext(DbContextOptions<QuanlynhahangContext> options, IConfiguration configuration):base(options)
        {
            Database.EnsureCreated();
            this._configuration = configuration;
            this.conn = this._configuration.GetConnectionString("MyConn").ToString();
        }
        
        */
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseMySql(connect_str, ServerVersion.AutoDetect(connect_str));
            //optionsBuilder.UseMySql(conn, ServerVersion.AutoDetect(conn));


        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
