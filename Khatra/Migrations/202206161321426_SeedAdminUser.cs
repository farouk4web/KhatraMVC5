namespace Khatra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedAdminUser : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                    INSERT INTO [dbo].[AspNetUsers] 
                                ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [FullName], [UserImageSrc], [AboutMe]) 
                        VALUES (N'18f263cc-ec6b-4d91-955a-121e9f730eeb', N'farouk@khatra.com', 1, N'AN57mFQPPtIpkyHojCi58bJy5bnSQV0KuMd6r5f96XAj4VujifSzUX4w3NQlA5Pq9w==', N'aa920c9b-5eb6-4fad-9138-b5bb5a39439f', NULL, 0, 0, NULL, 1, 0, N'farouk@khatra.com', N'Farouk Abdelhamid', N'/Uploads/Users/user.png', N'Â–« «·„Õ ÊÌ ⁄»«—… ⁄‰ ‰’ ’€Ì— ÌﬁÊ„ Ì’› ‘Œ’Ì ﬂ')
            ");
        }
        
        public override void Down()
        {
        }
    }
}
