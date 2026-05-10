using Bojechki_server.Database;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Bojechki_server.Handlers
{
    public static class DbTablesHandler
    {
        //КОМПОНЕНТЫЧИ
        public static string HandleGetComponents(AppDbContext db)
        {
            var components = db.Components.ToList();
            return Newtonsoft.Json.JsonConvert.SerializeObject(components);
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

        //КАТАЛОГИЧИ
        public static string HandleGetCatalogs(string connectionString)
        {
            try
            {
                var catalogs = new List<Catalog>();
                string query = "SELECT id, name AS 'Название', type AS 'Тип', description AS 'Описание', price AS 'Цена' FROM Catalogs";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        catalogs.Add(new Catalog
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Type = reader.GetString(2),
                            Description = reader.GetString(3),
                            Price = reader.GetDecimal(4)
                        });
                    }
                }

                return Newtonsoft.Json.JsonConvert.SerializeObject(catalogs);
            }
            catch (Exception ex)
            {
                return $"FAIL|{ex.Message}";
            }
        }
        public static string HandleAddCatalog(string connectionString, string[] parts)
        {
            if (parts.Length != 5) return $"FAIL| Ожидается Название|Тип|Описание|Цена";

            try
            {
                string name = parts[1];
                string type = parts[2];
                string description = parts[3];
                decimal price = decimal.Parse(parts[4]);

                string query = @"INSERT INTO Catalogs (name, type, description, price) VALUES (@name, @type, @description, @price)";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@type", type);
                        command.Parameters.AddWithValue("@description", description);
                        command.Parameters.AddWithValue("@price", price);
                        command.ExecuteNonQuery();
                    }
                }

                return "SUCCESS";
            }
            catch (Exception ex)
            {
                return $"FAIL|{ex.Message}";
            }
        }

        public static string HandleUpdateCatalog(string connectionString, string[] parts)
        {
            if (parts.Length < 6) return $"FAIL| Ожидается Название|Тип|Описание|Цена";
            if (!int.TryParse(parts[1], out int id)) return "FAIL|Неверный id";

            try
            {
                string name = parts[2];
                string type = parts[3];
                string description = parts[4];
                decimal price = decimal.Parse(parts[5]);

                string query = @"UPDATE Catalogs SET name=@name, type=@type, description=@description, price=@price WHERE id=@id";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@type", type);
                        command.Parameters.AddWithValue("@description", description);
                        command.Parameters.AddWithValue("@price", price);
                        command.ExecuteNonQuery();

                        int rows = command.ExecuteNonQuery();
                        return rows > 0 ? "SUCCESS" : "FAIL|Каталог не найден";
                    }
                }
            }
            catch (Exception ex)
            {
                return $"FAIL|{ex.Message}";
            }
        }

        public static string HandleDeleteCatalog(string connectionString, string[] parts)
        {
            if (parts.Length < 2) return "FAIL|Не указан id";
            if (!int.TryParse(parts[1], out int id)) return "FAIL|Неверный id";

            try
            {
                string query = "DELETE FROM Catalogs WHERE id = @id";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        int rows = cmd.ExecuteNonQuery();
                        return rows > 0 ? "SUCCESS" : "FAIL|Каталог не найден";
                    }
                }
            }
            catch (Exception ex)
            {
                return $"FAIL|{ex.Message}";
            }
        }

        public static string HandleSearchCatalogs(AppDbContext db, string[] parts)
        {
            string txtSearch = parts.Length > 1 ? parts[1] : null;
            string filter = parts.Length > 2 ? parts[2] : null;
            string check = parts.Length > 3 ? parts[3] : "по убыванию";
            var query = db.Catalogs.AsQueryable();
            if (!string.IsNullOrEmpty(txtSearch))
            {
                query = query.Where(
                    c => c.Id.ToString().Contains(txtSearch) 
                || c.Name.Contains(txtSearch) 
                || c.Type.Contains(txtSearch) 
                || c.Price.ToString().Contains(txtSearch));
            }
            if (!string.IsNullOrEmpty(filter))
            {
                switch (filter.ToLower())
                {
                    case "name": query = query.OrderByDescending(c => c.Name); break;
                    case "type": query = query.OrderByDescending(c => c.Type); break;
                    case "description": query = query.OrderByDescending(c => c.Description); break;
                    case "price": query = query.OrderByDescending(c => c.Price); break;
                }
            }
            else
            {
                query.OrderByDescending(c => c.Id);
            }

            var result = query.ToList();
            return JsonConvert.SerializeObject(result);
        }

        public static string HandleSearchComponents(string connectionString, string[] parts)
        {
            string txtSearch = parts.Length > 1 ? parts[1] : null;
            string filter = txtSearch != null ? parts[2] : null;
            string check = parts.Length > 3 ? parts[3] : "0";

            string query = "SELECT * FROM Components";
            var parameters = new List<SqlParameter>();
            if (!string.IsNullOrEmpty(txtSearch))
            {
                query += @"WHERE Id LIKE @search 
                OR Name LIKE @search 
                OR CAST(Purchase_Price AS NVARCHAR(MAX)) LIKE @search
                OR CAST(Retail_Price AS NVARCHAR(MAX)) LIKE @search
                OR CAST(Stock_Quantity AS NVARCHAR(MAX)) LIKE @search";
                parameters.Add(new SqlParameter("@search", $"{txtSearch}"));
            }


            if (!string.IsNullOrEmpty(filter))
            {
                string SortDirection = check == "1" ? "DESC" : "ASC";
                query += $" ORDER BY {filter} {SortDirection}";
            }
            else
            {
                query += " ORDER BY Id ASC";
            }

            var components = new List<Component>();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddRange(parameters.ToArray());
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            components.Add(new Component
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Type = reader.GetString(2),
                                Purchase_Price = reader.GetDecimal(3),
                                Retail_Price = reader.GetDecimal(4),
                                Stock_Quantity = reader.GetInt32(5)
                            });
                        }
                    }
                }
            }

            return JsonConvert.SerializeObject(components);
        }

    }
}
