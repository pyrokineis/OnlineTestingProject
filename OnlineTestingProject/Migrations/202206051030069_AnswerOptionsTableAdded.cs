namespace OnlineTestingProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnswerOptionsTableAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AnswersOptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        Question_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.Question_Id)
                .Index(t => t.Question_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AnswersOptions", "Question_Id", "dbo.Questions");
            DropIndex("dbo.AnswersOptions", new[] { "Question_Id" });
            DropTable("dbo.AnswersOptions");
        }
    }
}
