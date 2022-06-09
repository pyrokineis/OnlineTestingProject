namespace OnlineTestingProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestCreatorFromUserToString : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tests", "Creator_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Tests", new[] { "Creator_Id" });
            AddColumn("dbo.Tests", "CreatorLogin", c => c.String());
            DropColumn("dbo.Tests", "Creator_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tests", "Creator_Id", c => c.String(maxLength: 128));
            DropColumn("dbo.Tests", "CreatorLogin");
            CreateIndex("dbo.Tests", "Creator_Id");
            AddForeignKey("dbo.Tests", "Creator_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
