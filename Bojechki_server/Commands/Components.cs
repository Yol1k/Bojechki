using Bojechki_server.Database;
using Bojechki_server.Handlers;

namespace Bojechki_server.Commands
{
    public class GetComponentsCommand : ICommand
    {
        public string Execute(AppDbContext db, string[] args)
        {
            return DbTablesHandler.HandleGetComponents(db);
        }
    }

    public class AddComponentCommand : ICommand
    {
        public string Execute(AppDbContext db, string[] args)
        {
            return DbTablesHandler.HandleAddComponent(db, args);
        }
    }

    public class UpdateComponentCommand : ICommand
    {
        public string Execute(AppDbContext db, string[] args)
        {
            return DbTablesHandler.HandleUpdateComponent(db, args);
        }
    }

    public class DeleteComponentCommand : ICommand
    {
        public string Execute(AppDbContext db, string[] args)
        {
            return DbTablesHandler.HandleDeleteComponent(db, args);
        }
    }
}
