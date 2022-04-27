namespace OnlineTestingProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstButNotLast : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AnswerTypes",
                c => new
                    {
                        AnswerTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.AnswerTypeId);
            
            CreateTable(
                "dbo.CorrectAnswers",
                c => new
                    {
                        CorrectAnswerId = c.Int(nullable: false, identity: true),
                        AnswerData = c.String(),
                        Question_QuestionId = c.Int(),
                    })
                .PrimaryKey(t => t.CorrectAnswerId)
                .ForeignKey("dbo.Questions", t => t.Question_QuestionId)
                .Index(t => t.Question_QuestionId);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        QuestionId = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        Type_QuestionTypeId = c.Int(),
                    })
                .PrimaryKey(t => t.QuestionId)
                .ForeignKey("dbo.QuestionTypes", t => t.Type_QuestionTypeId)
                .Index(t => t.Type_QuestionTypeId);
            
            CreateTable(
                "dbo.QuestionTypes",
                c => new
                    {
                        QuestionTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.QuestionTypeId);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        GroupId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.GroupId);
            
            CreateTable(
                "dbo.QuestionsInTests",
                c => new
                    {
                        QuestionsInTestId = c.Int(nullable: false, identity: true),
                        Question_QuestionId = c.Int(),
                        Test_TestId = c.Int(),
                    })
                .PrimaryKey(t => t.QuestionsInTestId)
                .ForeignKey("dbo.Questions", t => t.Question_QuestionId)
                .ForeignKey("dbo.Tests", t => t.Test_TestId)
                .Index(t => t.Question_QuestionId)
                .Index(t => t.Test_TestId);
            
            CreateTable(
                "dbo.Tests",
                c => new
                    {
                        TestId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Status = c.String(),
                        Date = c.DateTime(nullable: false),
                        Author_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.TestId)
                .ForeignKey("dbo.Users", t => t.Author_Id)
                .Index(t => t.Author_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Results",
                c => new
                    {
                        ResultId = c.Int(nullable: false, identity: true),
                        User = c.Int(nullable: false),
                        IsTrue = c.Boolean(nullable: false),
                        Answer_UserAnswerId = c.Int(),
                        Test_TestId = c.Int(),
                    })
                .PrimaryKey(t => t.ResultId)
                .ForeignKey("dbo.UserAnswers", t => t.Answer_UserAnswerId)
                .ForeignKey("dbo.Tests", t => t.Test_TestId)
                .Index(t => t.Answer_UserAnswerId)
                .Index(t => t.Test_TestId);
            
            CreateTable(
                "dbo.UserAnswers",
                c => new
                    {
                        UserAnswerId = c.Int(nullable: false, identity: true),
                        Data = c.String(),
                        AnswerType_AnswerTypeId = c.Int(),
                    })
                .PrimaryKey(t => t.UserAnswerId)
                .ForeignKey("dbo.AnswerTypes", t => t.AnswerType_AnswerTypeId)
                .Index(t => t.AnswerType_AnswerTypeId);
            
            CreateTable(
                "dbo.UsersInGroups",
                c => new
                    {
                        UsersInGroupId = c.Int(nullable: false, identity: true),
                        User = c.Int(nullable: false),
                        Group = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UsersInGroupId);
            
            AddForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Results", "Test_TestId", "dbo.Tests");
            DropForeignKey("dbo.Results", "Answer_UserAnswerId", "dbo.UserAnswers");
            DropForeignKey("dbo.UserAnswers", "AnswerType_AnswerTypeId", "dbo.AnswerTypes");
            DropForeignKey("dbo.QuestionsInTests", "Test_TestId", "dbo.Tests");
            DropForeignKey("dbo.Tests", "Author_Id", "dbo.Users");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.Users");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.Users");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.Users");
            DropForeignKey("dbo.QuestionsInTests", "Question_QuestionId", "dbo.Questions");
            DropForeignKey("dbo.CorrectAnswers", "Question_QuestionId", "dbo.Questions");
            DropForeignKey("dbo.Questions", "Type_QuestionTypeId", "dbo.QuestionTypes");
            DropIndex("dbo.UserAnswers", new[] { "AnswerType_AnswerTypeId" });
            DropIndex("dbo.Results", new[] { "Test_TestId" });
            DropIndex("dbo.Results", new[] { "Answer_UserAnswerId" });
            DropIndex("dbo.Tests", new[] { "Author_Id" });
            DropIndex("dbo.QuestionsInTests", new[] { "Test_TestId" });
            DropIndex("dbo.QuestionsInTests", new[] { "Question_QuestionId" });
            DropIndex("dbo.Questions", new[] { "Type_QuestionTypeId" });
            DropIndex("dbo.CorrectAnswers", new[] { "Question_QuestionId" });
            DropTable("dbo.UsersInGroups");
            DropTable("dbo.UserAnswers");
            DropTable("dbo.Results");
            DropTable("dbo.Users");
            DropTable("dbo.Tests");
            DropTable("dbo.QuestionsInTests");
            DropTable("dbo.Groups");
            DropTable("dbo.QuestionTypes");
            DropTable("dbo.Questions");
            DropTable("dbo.CorrectAnswers");
            DropTable("dbo.AnswerTypes");
        }
    }
}
