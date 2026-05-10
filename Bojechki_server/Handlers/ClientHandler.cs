using Bojechki_server.Commands;
using Bojechki_server.Database;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace Bojechki_server.Handlers
{
    public static class ClientHandler
    {
        private static readonly Dictionary<string, ICommand> _commands = new Dictionary<string, ICommand>()
        {
            ["LOGIN"] = new LoggerDecoratorCommand( new LoginCommand() ),
            ["REGISTER"] = new LoggerDecoratorCommand ( new RegisterCommand() ),
            ["GET_COMPONENTS"] = new LoggerDecoratorCommand ( new GetComponentsCommand() ),
            ["ADD_COMPONENT"] = new LoggerDecoratorCommand ( new AddComponentCommand() ),
            ["UPDATE_COMPONENT"] = new LoggerDecoratorCommand(new UpdateComponentCommand()),
            ["DELETE_COMPONENT"] = new LoggerDecoratorCommand(new DeleteComponentCommand()),
            ["GET_CATALOGS"] = new LoggerDecoratorCommand(new GetCatalogsCommand()),
            ["ADD_CATALOG"] = new LoggerDecoratorCommand(new AddCatalogCommand()),
            ["UPDATE_CATALOG"] = new LoggerDecoratorCommand(new UpdateCatalogCommand()),
            ["DELETE_CATALOG"] = new LoggerDecoratorCommand(new DeleteCatalogCommand()),
            ["SEARCH_CATALOGS"] = new LoggerDecoratorCommand(new SearchCatalogsCommand()),
            ["SEARCH_COMPONENTS"] = new LoggerDecoratorCommand(new SearchComponentsCommand()),
        };

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

                    string response = "";
                    using (var db = new AppDbContext())
                    {
                        string[] parts = data.Split('|');
                        string part = parts[0];

                        if (_commands.TryGetValue(part, out ICommand command))
                        {
                            response = command.Execute(db, parts);
                        }
                        else
                        {
                            response = "UNKNOWN_COMMAND";
                        }
                    }

                    byte[] msg = Encoding.UTF8.GetBytes(response);
                    stream.Write(msg, 0, msg.Length);
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
