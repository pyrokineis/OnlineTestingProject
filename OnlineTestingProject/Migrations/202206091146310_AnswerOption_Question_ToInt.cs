namespace OnlineTestingProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnswerOption_Question_ToInt : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AnswersOptions", "Question_Id", "dbo.Questions");
            DropIndex("dbo.AnswersOptions", new[] { "Question_Id" });
            AddColumn("dbo.AnswersOptions", "QuestionId", c => c.Int(nullable: false));
            DropColumn("dbo.AnswersOptions", "Question_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AnswersOptions", "Question_Id", c => c.Int());
            DropColumn("dbo.AnswersOptions", "QuestionId");
            CreateIndex("dbo.AnswersOptions", "Question_Id");
            AddForeignKey("dbo.AnswersOptions", "Question_Id", "dbo.Questions", "Id");
        }
    }
}
