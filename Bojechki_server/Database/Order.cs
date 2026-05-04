using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bojechki_server.Database
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public int Client_Id { get; set; }
        public int Catalog_Id { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public decimal Price { get; set; }
    }
}