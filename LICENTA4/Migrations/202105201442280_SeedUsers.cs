namespace LICENTA4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"  INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'5003c855-e9bc-4edd-b4ca-b564593dea41', N'user@user.com', 0, N'AHIoIotu5XgHI0zg24LVvmdhQFyEYgv4dU8a1HVwk3Pow6bQKeZmxJe2qauVSYfhBw==', N'24969e4e-64d4-4588-99f1-4597eae980fa', NULL, 0, 0, NULL, 1, 0, N'user@user.com')
                    INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'fb0be400-a6a5-4e98-bddb-bed3277b1616', N'admin@admin.com', 0, N'AOuqBCPFNG7sklzyZKasIlsucUvAwXgWbhuDak1vK5fDJYu8SIUYv7XaG+yZx+mDMw==', N'b67e3c19-4f16-4fca-96d4-456f58ffd3d4', NULL, 0, 0, NULL, 1, 0, N'admin@admin.com')
                
                    INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'0d465bdb-fc8e-405e-b1cf-6e0442cd99ea', N'CanManagePosts')

                    INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'fb0be400-a6a5-4e98-bddb-bed3277b1616', N'0d465bdb-fc8e-405e-b1cf-6e0442cd99ea')
                ");
        }
        
        public override void Down()
        {
        }
    }
}
