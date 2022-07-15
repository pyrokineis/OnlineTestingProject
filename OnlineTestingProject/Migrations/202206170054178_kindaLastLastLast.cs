namespace OnlineTestingProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kindaLastLastLast : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserAnswers", "Question_Id", "dbo.Questions");
            DropIndex("dbo.UserAnswers", new[] { "Question_Id" });
            AddColumn("dbo.UserAnswers", "QuestionId", c => c.Int(nullable: false));
            DropColumn("dbo.UserAnswers", "Question_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserAnswers", "Question_Id", c => c.Int());
            DropColumn("dbo.UserAnswers", "QuestionId");
            CreateIndex("dbo.UserAnswers", "Question_Id");
            AddForeignKey("dbo.UserAnswers", "Question_Id", "dbo.Questions", "Id");
        }
    }
}
