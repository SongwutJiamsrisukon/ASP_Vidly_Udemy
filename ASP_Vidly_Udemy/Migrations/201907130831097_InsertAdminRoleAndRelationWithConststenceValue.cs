namespace ASP_Vidly_Udemy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertAdminRoleAndRelationWithConststenceValue : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'3cfec52e-2e87-4f97-b697-86d385d3d44d', N'admin@hotmail.com', 0, N'AOga5MzCZjAerRx7n2kNLzr4GKVYpPBP0ZNDrZik6zoKnwJDUAZHke9Xk7e2YXeerQ==', N'273f594b-c1a0-4e83-b005-04efb9236f82', NULL, 0, 0, NULL, 1, 0, N'admin@hotmail.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'e82a2cc2-5f38-45c7-ba55-d14518db2bd8', N'user@hotmail.com', 0, N'AO8sdLXuN+MwPzU7D6oHoolbJotlUXPVQeELJIKmQ1VjMdPuKargAk62PRdCKOjyUg==', N'1a0afcf4-5fe2-4537-80b1-29f5797efd27', NULL, 0, 0, NULL, 1, 0, N'user@hotmail.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'f86c09da-eebc-4394-965c-0e2524e9babc', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'3cfec52e-2e87-4f97-b697-86d385d3d44d', N'f86c09da-eebc-4394-965c-0e2524e9babc')
                ");
        }
        
        public override void Down()
        {
        }
    }
}
