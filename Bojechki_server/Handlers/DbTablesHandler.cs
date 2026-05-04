using Bojechki_server.Database;
using System;
using System.Linq;

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

        public static string HandleAddComponent(AppDbContext db, string[] parts)
        {
            if (parts.Length < 6)
                return "FAIL|Неверный формат. Ожидается: название|тип|покупательская цена|розничная цена|количество на складе";

            try
            {
                var component = new Component
                {
                    Name = parts[1],
                    Type = parts[2],
                    Purchase_Price = decimal.Parse(parts[3]),
                    Retail_Price = decimal.Parse(parts[4]),
                    Stock_Quantity = int.Parse(parts[5])
                };

                db.Components.Add(component);
                db.SaveChanges();
                return "SUCCESS";
            }
            catch (Exception ex)
            {
                return $"FAIL|Ошибка добавления: {ex.Message}";
            }
        }

        public static string HandleUpdateComponent(AppDbContext db, string[] parts)
        {
            if (parts.Length < 7)
                return "FAIL|Неверный формат. Ожидается: id|название|тип|покупательская цена|розничная цена|количество на складе";

            if (!int.TryParse(parts[1], out int id))
                return "FAIL|Id должен быть числом";

            try
            {
                var component = db.Components.Find(id);
                if (component == null)
                    return "FAIL|Компонент не найден";

                component.Name = parts[2];
                component.Type = parts[3];
                component.Purchase_Price = decimal.Parse(parts[4]);
                component.Retail_Price = decimal.Parse(parts[5]);
                component.Stock_Quantity = int.Parse(parts[6]);

                db.SaveChanges();
                return "SUCCESS";
            }
            catch (Exception ex)
            {
                return $"FAIL|Ошибка обновления: {ex.Message}";
            }
        }

        public static string HandleDeleteComponent(AppDbContext db, string[] parts)
        {
            if (parts.Length < 2)
                return "FAIL|Не передан id";

            if (!int.TryParse(s: parts[1], out int id))
                return "FAIL|Id должен быть числом";

            try
            {
                var component = db.Components.Find(id);
                if (component == null)
                    return "FAIL|Компонент не найден";

                db.Components.Remove(component);
                db.SaveChanges();
                return "SUCCESS";
            }
            catch (Exception ex)
            {
                return $"FAIL|Ошибка удаления: {ex.Message}";
            }
        }

        public static string HandleSearchComponents(AppDbContext db, string[] parts)
        {
            return "";
        }
    }
}
