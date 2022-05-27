namespace OnlineTestingProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserIdsToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Results", "UserId", c => c.String());
            AlterColumn("dbo.UserAnswers", "UserId", c => c.String());
            AlterColumn("dbo.TestAssignedUsers", "UserId", c => c.String());
            AlterColumn("dbo.UsersInGroups", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UsersInGroups", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.TestAssignedUsers", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.UserAnswers", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.Results", "UserId", c => c.Int(nullable: false));
        }
    }
}
