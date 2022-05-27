namespace OnlineTestingProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserInGroupIdFix : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UsersInGroups", "GroupId", c => c.Int(nullable: false));
            DropColumn("dbo.UsersInGroups", "Group");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UsersInGroups", "Group", c => c.Int(nullable: false));
            DropColumn("dbo.UsersInGroups", "GroupId");
        }
    }
}
