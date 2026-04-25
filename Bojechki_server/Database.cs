using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Remoting.Contexts;
using static System.Net.Mime.MediaTypeNames;

namespace Bojechki_server
{
    public class Component
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public decimal Retail_Price { get; set; }
        public int Stock_Quantity { get; set; }
    }

    public class Client
    {
        public int Id { get; set; }
        public string Full_Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
    }

    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
    }

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