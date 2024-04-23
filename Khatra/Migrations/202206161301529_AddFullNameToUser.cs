namespace Khatra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFullNameToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "FullName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "FullName");
        }
    }
}
