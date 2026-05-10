using Bojechki_server.Database;
using Bojechki_server.Handlers;

namespace Bojechki_server.Commands
{
    public class LoginCommand : ICommand
    {
        public string Execute(AppDbContext db, string[] args)
        {
            return LoginHandler.HandleLogin(db, args);
        }
    }

    public class RegisterCommand : ICommand
    {
        public string Execute(AppDbContext db, string[] args)
        {
            return RegisterHandler.HandleRegister(db, args);
        }
    }
}