namespace OnlineTestingProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateTimesAddedToTestAndMiniIdFix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TestAssignedUsers", "Test_Id", "dbo.Tests");
            DropIndex("dbo.TestAssignedUsers", new[] { "Test_Id" });
            AddColumn("dbo.Tests", "CreationDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Tests", "Deadline", c => c.DateTime(nullable: false));
            AddColumn("dbo.Tests", "FinishDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Tests", "Creator_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.TestAssignedUsers", "TestId", c => c.Int(nullable: false));
            CreateIndex("dbo.Tests", "Creator_Id");
            AddForeignKey("dbo.Tests", "Creator_Id", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Tests", "Date");
            DropColumn("dbo.TestAssignedUsers", "Test_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TestAssignedUsers", "Test_Id", c => c.Int());
            AddColumn("dbo.Tests", "Date", c => c.DateTime(nullable: false));
            DropForeignKey("dbo.Tests", "Creator_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Tests", new[] { "Creator_Id" });
            DropColumn("dbo.TestAssignedUsers", "TestId");
            DropColumn("dbo.Tests", "Creator_Id");
            DropColumn("dbo.Tests", "FinishDate");
            DropColumn("dbo.Tests", "Deadline");
            DropColumn("dbo.Tests", "CreationDate");
            CreateIndex("dbo.TestAssignedUsers", "Test_Id");
            AddForeignKey("dbo.TestAssignedUsers", "Test_Id", "dbo.Tests", "Id");
        }
    }
}
