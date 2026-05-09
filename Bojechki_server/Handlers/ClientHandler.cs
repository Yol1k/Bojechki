using System;
using System.Net.Sockets;
using System.Text;
using Bojechki_server.Database;

namespace Bojechki_server.Handlers
{
    public static class ClientHandler
    {
        public static void ProcessClient(TcpClient client)
        {
            try
            {
                using (NetworkStream stream = client.GetStream())
                {
                    byte[] bytes = new byte[1024];
                    int i = stream.Read(bytes, 0, bytes.Length);
                    if (i == 0) return;

                    string data = Encoding.UTF8.GetString(bytes, 0, i);
                    Console.WriteLine($"Получено: {data}");

                    string response = "";
                    using (var db = new AppDbContext())
                    {
                        string[] parts = data.Split('|');
                        string command = parts[0];

                        switch (command)
                        {
                            //авторизация
                            case "LOGIN": response = LoginHandler.HandleLogin(db, parts); break;
                            case "REGISTER": response = RegisterHandler.HandleRegister(db, parts); break;
                            //компоненты (orm)
                            case "GET_COMPONENTS": response = DbTablesHandler.HandleGetComponents(db); break;
                            case "ADD_COMPONENT": response = DbTablesHandler.HandleAddComponent(db, parts); break;
                            case "UPDATE_COMPONENT": response = DbTablesHandler.HandleUpdateComponent(db, parts); break;
                            case "DELETE_COMPONENT": response = DbTablesHandler.HandleDeleteComponent(db, parts); break;
                            //каталоги (сырой sql)
                            case "GET_CATALOGS": response = DbTablesHandler.HandleGetCatalogs(db.connectionString); break;
                            case "ADD_CATALOG": response = DbTablesHandler.HandleAddCatalog(db.connectionString, parts); break;
                            case "UPDATE_CATALOG": response = DbTablesHandler.HandleUpdateCatalog(db.connectionString, parts); break;
                            case "DELETE_CATALOG": response = DbTablesHandler.HandleDeleteCatalog(db.connectionString, parts); break;
                            default: response = "UNKNOWN_COMMAND"; break;
                        }
                    }

                    byte[] msg = Encoding.UTF8.GetBytes(response);
                    stream.Write(msg, 0, msg.Length);
                    Console.WriteLine($"Отправлено {msg.Length} байт");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при обмене: {ex.Message} {ex.InnerException}");
            }
            finally
            {
                client.Close();
                Console.WriteLine("Соединение закрыто.\n");
            }
        }
    }
}
