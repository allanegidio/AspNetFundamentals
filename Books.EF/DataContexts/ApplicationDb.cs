using Books.EF.Models;
using System.Data.Entity;

namespace Books.EF.DataContexts
{
    //enable-migrations -ContextTypeName IdentityDb -MigrationsDirectory DataContexts\IdentityMigrations
    //enable-migrations -ContextTypeName ApplicationDb -MigrationsDirectory DataContexts\ApplicationMigrations
    //add-migration -ConfigurationTypeName Books.EF.DataContexts.IdentityMigrations.Configuration -Name "InitialDatabase"
    //add-migration -ConfigurationTypeName Books.EF.DataContexts.ApplicationMigrations.Configuration -Name "InitialDatabase"
    //update-database -ConfigurationTypeName Books.EF.DataContexts.IdentityMigrations.Configuration
    //update-database -ConfigurationTypeName Books.EF.DataContexts.ApplicationMigrations.Configuration
    public class ApplicationDb : DbContext
    {
        public ApplicationDb()
            : base("BooksEntityFramework")
        {

        }

        public DbSet<Book> Books { get; set; }
    }
}