namespace Khatra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAboutMeToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "AboutMe", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "AboutMe");
        }
    }
}
