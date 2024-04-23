namespace Khatra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUserToAdmins : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'18f263cc-ec6b-4d91-955a-121e9f730eeb', N'25c3ebb5-e22f-4627-9c52-6593403e1ba8')");
        }
        
        public override void Down()
        {
        }
    }
}
