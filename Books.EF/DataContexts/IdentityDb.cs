using Books.EF.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Books.EF.DataContexts
{
    //enable-migrations -ContextTypeName IdentityDb -MigrationsDirectory DataContexts\IdentityMigrations
    //enable-migrations -ContextTypeName ApplicationDb -MigrationsDirectory DataContexts\ApplicationMigrations
    //add-migration -ConfigurationTypeName Books.EF.DataContexts.IdentityMigrations.Configuration -Name "InitialDatabase"
    //add-migration -ConfigurationTypeName Books.EF.DataContexts.ApplicationMigrations.Configuration -Name "InitialDatabase"
    //update-database -ConfigurationTypeName Books.EF.DataContexts.IdentityMigrations.Configuration
    //update-database -ConfigurationTypeName Books.EF.DataContexts.ApplicationMigrations.Configuration
    public class IdentityDb : IdentityDbContext<ApplicationUser>
    {
        public IdentityDb()
            : base("BooksEntityFramework", throwIfV1Schema: false)
        {
        }

        public static IdentityDb Create()
        {
            return new IdentityDb();
        }
    }
}