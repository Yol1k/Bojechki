using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Bojechki_server.Database
{
    [Table("Clients")]
    public class Client
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
    }

    [Table("Components")]
    public class Component
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal RetailPrice { get; set; }
        public int StockQuantity { get; set; }
    }

    [Table("Orders")]
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int CatalogId { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public decimal Price { get; set; }
    }

    [Table("Order_Components")]
    public class OrderComponent
    {
        [Key]
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ComponentId { get; set; }
        public int Quantity { get; set; }
    }

    [Table("Finances")]
    public class Finance
    {
        [Key]
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
    }

    [Table("Catalog")]
    public class Catalog
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
    }
}