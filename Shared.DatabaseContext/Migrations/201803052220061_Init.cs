namespace Shared.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TodoItems",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        TodoListId = c.Guid(nullable: false),
                        Description = c.String(),
                        IsComplete = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TodoLists", t => t.TodoListId, cascadeDelete: true)
                .Index(t => t.TodoListId);
            
            CreateTable(
                "dbo.TodoLists",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TodoItems", "TodoListId", "dbo.TodoLists");
            DropForeignKey("dbo.TodoLists", "UserId", "dbo.Users");
            DropIndex("dbo.TodoLists", new[] { "UserId" });
            DropIndex("dbo.TodoItems", new[] { "TodoListId" });
            DropTable("dbo.Users");
            DropTable("dbo.TodoLists");
            DropTable("dbo.TodoItems");
        }
    }
}
