using EntityFramework.Models;
using System.Data.Entity;

namespace EntityFramework.DataContexts
{
    //Para adicionar multiplos contexts: 
    // Enable-Migrations -ContextTypeName IdentityDbContext -MigrationsDirectory DataContexts\IdentityMigrations
    // Enable-Migrations -ContextTypeName ApplicationDbContext -MigrationsDirectory DataContexts\ApplicationMigrations
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("EntityFramework")
        {
        }

        public DbSet<Book> Books { get; set; }
    }
}