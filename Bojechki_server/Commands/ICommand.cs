using Bojechki_server.Database;

namespace Bojechki_server.Commands
{
    public interface ICommand
    {
        string Execute(AppDbContext db, string[] args);
    }
}
