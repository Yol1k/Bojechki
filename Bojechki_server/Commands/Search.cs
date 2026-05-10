using Bojechki_server.Database;
using Bojechki_server.Handlers;

namespace Bojechki_server.Commands
{
    public class SearchCatalogsCommand : ICommand
    {
        public string Execute(AppDbContext db, string[] args)
        {
            return DbTablesHandler.HandleSearchCatalogs(db, args);
        }
    }

    public class SearchComponentsCommand : ICommand
    {
        public string Execute(AppDbContext db, string[] args)
        {
            return DbTablesHandler.HandleSearchComponents(db.connectionString, args);
        }
    }
}
