namespace OnlineTestingProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestUpdated_TestResultAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TestResults",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TestId = c.Int(nullable: false),
                        UserId = c.String(),
                        Score = c.Int(nullable: false),
                        FinishDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Tests", "PointsPerQuestion", c => c.Int(nullable: false));
            AddColumn("dbo.Tests", "QuestionsAmount", c => c.Int(nullable: false));
            AddColumn("dbo.Tests", "MaxPoints", c => c.Int(nullable: false));
            DropColumn("dbo.Tests", "FinishDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tests", "FinishDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Tests", "MaxPoints");
            DropColumn("dbo.Tests", "QuestionsAmount");
            DropColumn("dbo.Tests", "PointsPerQuestion");
            DropTable("dbo.TestResults");
        }
    }
}
