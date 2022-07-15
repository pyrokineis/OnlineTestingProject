namespace OnlineTestingProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kindaLastLastLast1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserAnswers", "Test_Id", "dbo.Tests");
            DropIndex("dbo.UserAnswers", new[] { "Test_Id" });
            AddColumn("dbo.UserAnswers", "TestId", c => c.Int(nullable: false));
            DropColumn("dbo.UserAnswers", "Test_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserAnswers", "Test_Id", c => c.Int());
            DropColumn("dbo.UserAnswers", "TestId");
            CreateIndex("dbo.UserAnswers", "Test_Id");
            AddForeignKey("dbo.UserAnswers", "Test_Id", "dbo.Tests", "Id");
        }
    }
}
