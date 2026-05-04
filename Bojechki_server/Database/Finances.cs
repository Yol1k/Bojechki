using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bojechki_server.Database
{
    [Table("Finances")]
    public class Finance
    {
        [Key]
        public int Id { get; set; }
        public int Order_Id { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
    }
}
