using EntityFramework.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EntityFramework.DataContexts
{
    //Para adicionar multiplos contexts: 
    // Enable-Migrations -ContextTypeName IdentityDbContext -MigrationsDirectory DataContexts\IdentityMigrations
    // Enable-Migrations -ContextTypeName ApplicationDbContext -MigrationsDirectory DataContexts\ApplicationMigrations
    public class IdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public IdentityDbContext()
            : base("EntityFramework", throwIfV1Schema: false)
        {
        }

        public static IdentityDbContext Create()
        {
            return new IdentityDbContext();
        }
    }
}