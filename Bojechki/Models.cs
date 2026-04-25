using System;

namespace Bojechki
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
}