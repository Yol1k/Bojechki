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
                            case "GET_COMPONENTS": response = DbTablesHandler.HandleGetComponents(db); break;
                            case "GET_CLIENTS": response = DbTablesHandler.HandleGetClients(db); break;
                            case "GET_ORDERS": response = DbTablesHandler.HandleGetOrders(db); break;
                            case "LOGIN": response = LoginHandler.HandleLogin(db, parts); break;
                            case "REGISTER": response = RegisterHandler.HandleRegister(db, parts); break;
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
                Console.WriteLine($"Ошибка при обмене: {ex.Message}");
            }
            finally
            {
                client.Close();
                Console.WriteLine("Соединение закрыто.\n");
            }
        }
    }
}
