namespace Books.EF.DataContexts.ApplicationMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DefaultSchema : DbMigration
    {
        public override void Up()
        {
            MoveTable(name: "dbo.Books", newSchema: "application");
        }
        
        public override void Down()
        {
            MoveTable(name: "application.Books", newSchema: "dbo");
        }
    }
}
