using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bojechki_server.Database
{
    [Table("Clients")]
    public class Client
    {
        [Key]
        public int Id { get; set; }
        public string Full_Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
    }
}
