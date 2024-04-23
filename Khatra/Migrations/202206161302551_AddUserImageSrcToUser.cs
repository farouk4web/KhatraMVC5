namespace Khatra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserImageSrcToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "UserImageSrc", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "UserImageSrc");
        }
    }
}
