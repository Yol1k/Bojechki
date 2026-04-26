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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "божечки.mdf");
            string connectionString = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=G:\\Bojechki\\database\\божечки.mdf;Integrated Security=True;Connect Timeout=30";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
