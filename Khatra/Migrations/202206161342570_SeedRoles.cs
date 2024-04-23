namespace Khatra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SeedRoles : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'25c3ebb5-e22f-4627-9c52-6593403e1ba8', N'Admins')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'7bff10de-fd50-4119-a877-3cf9e27d6b36', N'Publishers')
                ");
        }

        public override void Down()
        {
        }
    }
}
