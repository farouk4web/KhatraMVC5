namespace Khatra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatePostsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        Content = c.String(nullable: false),
                        PublishedDate = c.DateTime(nullable: false),
                        Views = c.Int(nullable: false),
                        ImageSrc = c.String(),
                        CategoryId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.CategoryId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Posts", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Posts", new[] { "UserId" });
            DropIndex("dbo.Posts", new[] { "CategoryId" });
            DropTable("dbo.Posts");
        }
    }
}
