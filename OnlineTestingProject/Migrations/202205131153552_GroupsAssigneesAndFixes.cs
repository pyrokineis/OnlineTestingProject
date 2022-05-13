namespace OnlineTestingProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GroupsAssigneesAndFixes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CorrectAnswers", "Question_QuestionId", "dbo.Questions");
            DropForeignKey("dbo.UserAnswers", "AnswerType_AnswerTypeId", "dbo.AnswerTypes");
            DropIndex("dbo.CorrectAnswers", new[] { "Question_QuestionId" });
            DropIndex("dbo.UserAnswers", new[] { "AnswerType_AnswerTypeId" });
            CreateTable(
                "dbo.TestAssignedGroups",
                c => new
                    {
                        TestAssignedGroupId = c.Int(nullable: false, identity: true),
                        Group_GroupId = c.Int(),
                        Test_TestId = c.Int(),
                    })
                .PrimaryKey(t => t.TestAssignedGroupId)
                .ForeignKey("dbo.Groups", t => t.Group_GroupId)
                .ForeignKey("dbo.Tests", t => t.Test_TestId)
                .Index(t => t.Group_GroupId)
                .Index(t => t.Test_TestId);
            
            CreateTable(
                "dbo.TestAssignedUsers",
                c => new
                    {
                        TestAssignedUserId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Test_TestId = c.Int(),
                    })
                .PrimaryKey(t => t.TestAssignedUserId)
                .ForeignKey("dbo.Tests", t => t.Test_TestId)
                .Index(t => t.Test_TestId);
            
            AddColumn("dbo.Questions", "AnswerData", c => c.String());
            AddColumn("dbo.UserAnswers", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.UserAnswers", "Result", c => c.Int(nullable: false));
            AddColumn("dbo.UserAnswers", "Question_QuestionId", c => c.Int());
            CreateIndex("dbo.UserAnswers", "Question_QuestionId");
            AddForeignKey("dbo.UserAnswers", "Question_QuestionId", "dbo.Questions", "QuestionId");
            DropColumn("dbo.UserAnswers", "AnswerType_AnswerTypeId");
            DropTable("dbo.AnswerTypes");
            DropTable("dbo.CorrectAnswers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CorrectAnswers",
                c => new
                    {
                        CorrectAnswerId = c.Int(nullable: false, identity: true),
                        AnswerData = c.String(),
                        Question_QuestionId = c.Int(),
                    })
                .PrimaryKey(t => t.CorrectAnswerId);
            
            CreateTable(
                "dbo.AnswerTypes",
                c => new
                    {
                        AnswerTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.AnswerTypeId);
            
            AddColumn("dbo.UserAnswers", "AnswerType_AnswerTypeId", c => c.Int());
            DropForeignKey("dbo.TestAssignedUsers", "Test_TestId", "dbo.Tests");
            DropForeignKey("dbo.TestAssignedGroups", "Test_TestId", "dbo.Tests");
            DropForeignKey("dbo.TestAssignedGroups", "Group_GroupId", "dbo.Groups");
            DropForeignKey("dbo.UserAnswers", "Question_QuestionId", "dbo.Questions");
            DropIndex("dbo.TestAssignedUsers", new[] { "Test_TestId" });
            DropIndex("dbo.TestAssignedGroups", new[] { "Test_TestId" });
            DropIndex("dbo.TestAssignedGroups", new[] { "Group_GroupId" });
            DropIndex("dbo.UserAnswers", new[] { "Question_QuestionId" });
            DropColumn("dbo.UserAnswers", "Question_QuestionId");
            DropColumn("dbo.UserAnswers", "Result");
            DropColumn("dbo.UserAnswers", "UserId");
            DropColumn("dbo.Questions", "AnswerData");
            DropTable("dbo.TestAssignedUsers");
            DropTable("dbo.TestAssignedGroups");
            CreateIndex("dbo.UserAnswers", "AnswerType_AnswerTypeId");
            CreateIndex("dbo.CorrectAnswers", "Question_QuestionId");
            AddForeignKey("dbo.UserAnswers", "AnswerType_AnswerTypeId", "dbo.AnswerTypes", "AnswerTypeId");
            AddForeignKey("dbo.CorrectAnswers", "Question_QuestionId", "dbo.Questions", "QuestionId");
        }
    }
}
