namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'8d3b8b42-b2e1-40d1-9207-b83ec554b34c', N'guest@vidly.com', 0, N'AGLIyEKpAh9KbAzR7OImEjIX8Gf/H9ZcIf2H1bYGhZn4uh6/pzE2RJDoMvV5tM+pgg==', N'6f2a4d81-4698-4b40-9ae8-63706fbb3787', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'95d9a205-d894-4d66-8e96-725bdcb10b1c', N'admin@vidly.com', 0, N'AGgpKvGdFwK3LLTfTEU18t1USNlHQytzJxaiscQtT6WzIECa5y9mj/N5UiWfOWfijw==', N'41d5a4cc-7263-45f6-922a-fd256e0d948e', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'd3c37639-7d1b-4029-89e0-be6c5b109999', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'95d9a205-d894-4d66-8e96-725bdcb10b1c', N'd3c37639-7d1b-4029-89e0-be6c5b109999')
");
        }
        
        public override void Down()
        {
        }
    }
}
