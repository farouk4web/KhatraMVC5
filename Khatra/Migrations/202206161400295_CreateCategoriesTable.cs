namespace Khatra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateCategoriesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Categories", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Categories", new[] { "UserId" });
            DropTable("dbo.Categories");
        }
    }
}
