namespace OnlineTestingProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QuestionInTestEntityToInt : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.QuestionsInTests", "Question_Id", "dbo.Questions");
            DropIndex("dbo.QuestionsInTests", new[] { "Question_Id" });
            AddColumn("dbo.QuestionsInTests", "QuestionId", c => c.Int(nullable: false));
            DropColumn("dbo.QuestionsInTests", "Question_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.QuestionsInTests", "Question_Id", c => c.Int());
            DropColumn("dbo.QuestionsInTests", "QuestionId");
            CreateIndex("dbo.QuestionsInTests", "Question_Id");
            AddForeignKey("dbo.QuestionsInTests", "Question_Id", "dbo.Questions", "Id");
        }
    }
}
