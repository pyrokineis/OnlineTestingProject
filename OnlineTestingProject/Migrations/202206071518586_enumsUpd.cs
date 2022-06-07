namespace OnlineTestingProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class enumsUpd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Questions", "Theme", c => c.Int(nullable: false));
            AddColumn("dbo.Tests", "Theme", c => c.Int(nullable: false));
            AlterColumn("dbo.Tests", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tests", "Status", c => c.String());
            DropColumn("dbo.Tests", "Theme");
            DropColumn("dbo.Questions", "Theme");
        }
    }
}
