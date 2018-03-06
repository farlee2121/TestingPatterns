namespace Shared.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddActiveFlags : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TodoLists", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Users", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "IsActive");
            DropColumn("dbo.TodoLists", "IsActive");
        }
    }
}
