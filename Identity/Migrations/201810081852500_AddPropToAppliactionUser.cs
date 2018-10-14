namespace Identity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPropToAppliactionUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "FavoriteBook", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "FavoriteBook");
        }
    }
}
