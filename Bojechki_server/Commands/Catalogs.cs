using Bojechki_server.Database;
using Bojechki_server.Handlers;

namespace Bojechki_server.Commands
{
    public class GetCatalogsCommand : ICommand
    {
        public string Execute(AppDbContext db, string[] args)
        {
            return DbTablesHandler.HandleGetCatalogs(db.connectionString);
        }
    }

    public class AddCatalogCommand : ICommand
    {
        public string Execute(AppDbContext db, string[] args)
        {
            return DbTablesHandler.HandleAddCatalog(db.connectionString, args);
        }
    }

    public class UpdateCatalogCommand : ICommand
    {
        public string Execute(AppDbContext db, string[] args)
        {
            return DbTablesHandler.HandleUpdateCatalog(db.connectionString, args);
        }
    }

    public class DeleteCatalogCommand : ICommand
    {
        public string Execute(AppDbContext db, string[] args)
        {
            return DbTablesHandler.HandleUpdateCatalog(db.connectionString, args);
        }
    }
}
