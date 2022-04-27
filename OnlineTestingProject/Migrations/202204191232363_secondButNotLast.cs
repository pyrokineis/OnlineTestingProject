namespace OnlineTestingProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class secondButNotLast : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Results", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.UsersInGroups", "UserId", c => c.Int(nullable: false));
            DropColumn("dbo.Results", "User");
            DropColumn("dbo.UsersInGroups", "User");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UsersInGroups", "User", c => c.Int(nullable: false));
            AddColumn("dbo.Results", "User", c => c.Int(nullable: false));
            DropColumn("dbo.UsersInGroups", "UserId");
            DropColumn("dbo.Results", "UserId");
        }
    }
}
