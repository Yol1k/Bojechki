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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = @"G:\Bojechki\database\божечки.mdf";
            string connectionString = $@"Data Source=(localdb)\v13.0;AttachDbFilename={dbPath};Integrated Security=True;";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
