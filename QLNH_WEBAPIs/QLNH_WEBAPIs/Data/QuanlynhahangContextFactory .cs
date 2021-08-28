using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace QLNH_WEBAPIs.Data
{
    public class QuanlynhahangContextFactory : IDesignTimeDbContextFactory<QuanlynhahangContext>
    {

        /*
        QuanlynhahangContext IDesignTimeDbContextFactory<QuanlynhahangContext>.CreateDbContext(string[] args)
        {
            /*
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connect_str = configuration.GetConnectionString("MyConn");

            var optionsBuilder = new DbContextOptionsBuilder<QuanlynhahangContext>();
            optionsBuilder.UseMySql(connect_str, ServerVersion.AutoDetect(connect_str));

            return new QuanlynhahangContext(optionsBuilder.Options);
            *
        }
        */
        public QuanlynhahangContext CreateDbContext(string[] args)
        {
            throw new NotImplementedException();
        }
    }
}
