using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltraBetting.Data
{
    public class UltraBettingContextFactory : IDesignTimeDbContextFactory<UltraBettingContext>
    {
        //public UltraBettingContext CreateDbContext(string[] args)
        //{
        //    var optionsBuilder = new DbContextOptionsBuilder<UltraBettingContext>();
        //    optionsBuilder.UseSqlite("Data Source==UltraBetting");

        //    return new UltraBettingContext(optionsBuilder.Options);
        //}

        public UltraBettingContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<UltraBettingContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            builder.UseSqlServer(connectionString);
            return new UltraBettingContext(builder.Options);
        }
    }
}
