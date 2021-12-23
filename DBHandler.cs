using System;
using System.IO;
using DBHandlerClass;
using MySql.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;



namespace DBExecutorClass
{
    public class DbHandler : DbContext
    {
        public DbSet<TypeTable> Type_table { get; set; }
        public DbSet<PublishingTable> Publishing_table { get; set; }

        public DbHandler(DbContextOptions<DbHandler> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public static DbHandler Init()
        {
            var builder = new ConfigurationBuilder();
            var connectionString = builder
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build()
                .GetConnectionString("DefaultConnection");
            var optionsBuilder = new DbContextOptionsBuilder<DbHandler>();
            var options = optionsBuilder.UseMySQL(connectionString).Options;
            return new DbHandler(options);
        }

    }
}