using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Bojechki_server.Database
{
    [Table("Order_Components")]
    public class OrderComponent
    {
        [Key]
        public int Id { get; set; }
        public int Order_Id { get; set; }
        public int Component_Id { get; set; }
        public int Quantity { get; set; }
    }
}
