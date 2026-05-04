using System;

namespace Bojechki.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int Client_Id { get; set; }
        public int Catalog_Id { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public decimal Price { get; set; }
    }
}