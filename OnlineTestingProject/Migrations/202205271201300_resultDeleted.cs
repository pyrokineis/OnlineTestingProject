namespace OnlineTestingProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class resultDeleted : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Results", "Answer_UserAnswerId", "dbo.UserAnswers");
            DropForeignKey("dbo.Results", "Test_TestId", "dbo.Tests");
            DropIndex("dbo.Results", new[] { "Answer_UserAnswerId" });
            DropIndex("dbo.Results", new[] { "Test_TestId" });
            AddColumn("dbo.UserAnswers", "Test_TestId", c => c.Int());
            CreateIndex("dbo.UserAnswers", "Test_TestId");
            AddForeignKey("dbo.UserAnswers", "Test_TestId", "dbo.Tests", "TestId");
            DropTable("dbo.Results");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Results",
                c => new
                    {
                        ResultId = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        IsTrue = c.Boolean(nullable: false),
                        Answer_UserAnswerId = c.Int(),
                        Test_TestId = c.Int(),
                    })
                .PrimaryKey(t => t.ResultId);
            
            DropForeignKey("dbo.UserAnswers", "Test_TestId", "dbo.Tests");
            DropIndex("dbo.UserAnswers", new[] { "Test_TestId" });
            DropColumn("dbo.UserAnswers", "Test_TestId");
            CreateIndex("dbo.Results", "Test_TestId");
            CreateIndex("dbo.Results", "Answer_UserAnswerId");
            AddForeignKey("dbo.Results", "Test_TestId", "dbo.Tests", "TestId");
            AddForeignKey("dbo.Results", "Answer_UserAnswerId", "dbo.UserAnswers", "UserAnswerId");
        }
    }
}
