using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bojechki_server.Database
{
    [Table("Components")]
    public class Component
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public decimal Purchase_Price { get; set; }
        public decimal Retail_Price { get; set; }
        public int Stock_Quantity { get; set; }
    }
}