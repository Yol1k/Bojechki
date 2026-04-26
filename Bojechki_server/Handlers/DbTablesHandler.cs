using System.Linq;
using Bojechki_server.Database;

namespace Bojechki_server.Handlers
{
    public static class DbTablesHandler
    {
        public static string HandleGetComponents(AppDbContext db)
        {
            var components = db.Components.ToList();
            return Newtonsoft.Json.JsonConvert.SerializeObject(components);
        }

        public static string HandleGetClients(AppDbContext db)
        {
            var clients = db.Clients.ToList();
            return Newtonsoft.Json.JsonConvert.SerializeObject(clients);
        }

        public static string HandleGetOrders(AppDbContext db)
        {
            var orders = db.Orders.ToList();
            return Newtonsoft.Json.JsonConvert.SerializeObject(orders);
        }
    }
}
