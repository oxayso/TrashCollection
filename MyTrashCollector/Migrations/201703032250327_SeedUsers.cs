namespace MyTrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [FirstName], [LastName], [Street], [ZipCode], [Day_Id]) VALUES (N'b4788b6d-b8cf-43ae-9893-320281562b52', N'olivia@domain.com', 0, N'AL1Sk29gDAPUj3z6bxPP97qaOcsQkUPsJY6wxMFm8d6ZohE+UBh1SKna57ZngXHGQg==', N'bbc4ffa9-27da-4479-accd-f5854dd4c885', NULL, 0, 0, NULL, 1, 0, N'olivia@domain.com', NULL, NULL, NULL, NULL, NULL)
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [FirstName], [LastName], [Street], [ZipCode], [Day_Id]) VALUES (N'e2a00bc6-0e88-4f36-9e22-7825adcb269c', N'trashcollector@garbagebuddies.com', 0, N'AFfHikyJOAUPsRpGnq3bfAFQu2b9LXZBKc7ov4jHhazOW1ksDVOjb4UqzHGff0oGtw==', N'f648a8c9-7dfa-44c0-818e-bb3726a8c4e4', NULL, 0, 0, NULL, 1, 0, N'trashcollector@garbagebuddies.com', NULL, NULL, NULL, NULL, NULL)
            
            INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'ad4ed555-4861-4e66-827b-1d5a052ae98e', N'Worker')

            INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'e2a00bc6-0e88-4f36-9e22-7825adcb269c', N'ad4ed555-4861-4e66-827b-1d5a052ae98e')

        ");
        }
        
        public override void Down()
        {
        }
    }
}
