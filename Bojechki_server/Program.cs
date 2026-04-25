using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;

namespace Bojechki_server
{
    class Program
    {
        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
        }

        static void Main(string[] args)
        {
            TcpListener server = null;
            try
            {
                Int32 port = 13000;
                IPAddress localAddr = IPAddress.Parse("127.0.0.1");

                server = new TcpListener(localAddr, port);
                server.Start();

                Byte[] bytes = new Byte[1024];

                while (true)
                {
                    Console.Write("Ждём подключения... ");

                    TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine("Подключено!");

                    try
                    {
                        using (NetworkStream stream = client.GetStream())
                        {
                            int i = stream.Read(bytes, 0, bytes.Length);

                            if (i > 0)
                            {
                                string data = System.Text.Encoding.UTF8.GetString(bytes, 0, i);
                                Console.WriteLine("Получено: {0}", data);

                                string responseData = "";

                                using (var db = new AppDbContext())
                                {
                                    string[] parts = data.Split('|');
                                    string command = parts[0];

                                    switch (command)
                                    {
                                        case "GET_COMPONENTS":
                                            var components = db.Components.ToList();
                                            responseData = Newtonsoft.Json.JsonConvert.SerializeObject(components);
                                            break;

                                        case "GET_CLIENTS":
                                            var clients = db.Clients.ToList();
                                            responseData = Newtonsoft.Json.JsonConvert.SerializeObject(clients);
                                            break;

                                        case "GET_ORDERS":
                                            var orders = db.Orders.ToList();
                                            responseData = Newtonsoft.Json.JsonConvert.SerializeObject(orders);
                                            break;

                                        case "LOGIN":
                                            if (parts.Length == 3)
                                            {
                                                string email = parts[1];
                                                string password = parts[2];
                                                string hash = HashPassword(password);
                                                var user = db.Clients.FirstOrDefault(c => c.Email == email && c.Password == hash);
                                                if (user != null)
                                                    responseData = "SUCCESS";
                                                else
                                                    responseData = "FAIL|Неверная почта или пароль";
                                            }
                                            else
                                                responseData = "FAIL|Неверный формат запроса";
                                            break;

                                        case "REGISTER":
                                            if (parts.Length == 6)
                                            {
                                                string fullName = parts[1];
                                                string address = parts[2];
                                                string phone = parts[3];
                                                string email = parts[4];
                                                string password = parts[5];

                                                if (db.Clients.Any(c => c.Email == email))
                                                {
                                                    responseData = "FAIL|Пользователь с такой почтой уже зарегистрирован";
                                                }
                                                else
                                                {
                                                    var newClient = new Client
                                                    {
                                                        Email = email,
                                                        Password = HashPassword(password),
                                                        Full_Name = fullName,
                                                        Address = address,
                                                        Phone = phone,
                                                    };
                                                    db.Clients.Add(newClient);
                                                    db.SaveChanges();
                                                    responseData = "SUCCESS";
                                                }
                                            }
                                            else
                                                responseData = "FAIL|Неверный формат запроса";
                                            break;

                                        default:
                                            responseData = "UNKNOWN_COMMAND";
                                            break;
                                    }
                                }

                                byte[] msg = System.Text.Encoding.UTF8.GetBytes(responseData);
                                stream.Write(msg, 0, msg.Length);
                                Console.WriteLine("Отправлено: {0} байт", msg.Length);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Ошибка при обмене данными: " + ex.Message);
                        if (ex.InnerException != null)
                        {
                            Console.WriteLine("Внутренняя ошибка: " + ex.InnerException.Message);
                            if (ex.InnerException.InnerException != null)
                                Console.WriteLine("Внутренняя ошибка: " + ex.InnerException.InnerException.Message);
                        }
                    }
                    finally
                    {
                        client.Close();
                        Console.WriteLine("Соединение закрыто.\n");
                    }
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("Критическая ошибка сервера: {0}", e);
            }
            finally
            {
                if (server != null)
                    server.Stop();
            }

            Console.WriteLine("\nНажмите enter, чтобы продолжить...");
            Console.Read();
        }
    }

}