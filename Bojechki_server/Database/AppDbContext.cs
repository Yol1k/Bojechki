using Microsoft.EntityFrameworkCore;
using System;
using System.IO;

namespace Bojechki_server.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<Component> Components { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Finance> Finances { get; set; }
        public DbSet<Catalog> Catalogs { get; set; }
        public DbSet<OrderComponent> OrderComponents { get; set; }

        private static string DbFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Database");
        private static string MdfFile = Path.Combine(DbFolder, "божечки.mdf");
        public string connectionString = $@"Data Source=(localdb)\MSSQLLocalDB;AttachDbFilename={MdfFile};Integrated Security=True;";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}
