namespace OnlineTestingProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IdsFIx : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TestAssignedGroups", "Group_GroupId", "dbo.Groups");
            DropForeignKey("dbo.TestAssignedGroups", "Test_TestId", "dbo.Tests");
            DropForeignKey("dbo.QuestionsInTests", "Question_QuestionId", "dbo.Questions");
            DropForeignKey("dbo.UserAnswers", "Question_QuestionId", "dbo.Questions");
            DropForeignKey("dbo.Questions", "Type_QuestionTypeId", "dbo.QuestionTypes");
            DropForeignKey("dbo.QuestionsInTests", "Test_TestId", "dbo.Tests");
            DropForeignKey("dbo.TestAssignedUsers", "Test_TestId", "dbo.Tests");
            DropForeignKey("dbo.UserAnswers", "Test_TestId", "dbo.Tests");
            DropIndex("dbo.TestAssignedGroups", new[] { "Group_GroupId" });
            DropIndex("dbo.TestAssignedGroups", new[] { "Test_TestId" });
            DropPrimaryKey("dbo.Groups");
            DropPrimaryKey("dbo.Questions");
            DropPrimaryKey("dbo.QuestionTypes");
            DropPrimaryKey("dbo.QuestionsInTests");
            DropPrimaryKey("dbo.Tests");
            DropPrimaryKey("dbo.TestAssignedGroups");
            DropPrimaryKey("dbo.TestAssignedUsers");
            DropPrimaryKey("dbo.UserAnswers");
            DropPrimaryKey("dbo.UsersInGroups");

            DropColumn("dbo.Groups", "GroupId");
            DropColumn("dbo.Questions", "QuestionId");
            DropColumn("dbo.QuestionTypes", "QuestionTypeId");
            DropColumn("dbo.QuestionsInTests", "QuestionsInTestId");
            DropColumn("dbo.Tests", "TestId");
            DropColumn("dbo.TestAssignedGroups", "TestAssignedGroupId");

            AddColumn("dbo.TestAssignedGroups", "Id", c => c.Int(nullable: false, identity: true));


            DropColumn("dbo.TestAssignedGroups", "Group_GroupId");
            DropColumn("dbo.TestAssignedGroups", "Test_TestId");
            DropColumn("dbo.TestAssignedUsers", "TestAssignedUserId");
            DropColumn("dbo.UserAnswers", "UserAnswerId");
            DropColumn("dbo.UsersInGroups", "UsersInGroupId");
            AddColumn("dbo.Groups", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Questions", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.QuestionTypes", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.QuestionsInTests", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Tests", "Id", c => c.Int(nullable: false, identity: true));

            AddColumn("dbo.TestAssignedGroups", "TestId", c => c.Int(nullable: false));
            AddColumn("dbo.TestAssignedGroups", "GroupId", c => c.Int(nullable: false));
            AddColumn("dbo.TestAssignedUsers", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.UserAnswers", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.UsersInGroups", "Id", c => c.Int(nullable: false, identity: true));






            RenameColumn(table: "dbo.Questions", name: "Type_QuestionTypeId", newName: "Type_Id");
            RenameColumn(table: "dbo.QuestionsInTests", name: "Question_QuestionId", newName: "Question_Id");
            RenameColumn(table: "dbo.QuestionsInTests", name: "Test_TestId", newName: "Test_Id");
            RenameColumn(table: "dbo.TestAssignedUsers", name: "Test_TestId", newName: "Test_Id");
            RenameColumn(table: "dbo.UserAnswers", name: "Question_QuestionId", newName: "Question_Id");
            RenameColumn(table: "dbo.UserAnswers", name: "Test_TestId", newName: "Test_Id");
            RenameIndex(table: "dbo.Questions", name: "IX_Type_QuestionTypeId", newName: "IX_Type_Id");
            RenameIndex(table: "dbo.QuestionsInTests", name: "IX_Question_QuestionId", newName: "IX_Question_Id");
            RenameIndex(table: "dbo.QuestionsInTests", name: "IX_Test_TestId", newName: "IX_Test_Id");
            RenameIndex(table: "dbo.TestAssignedUsers", name: "IX_Test_TestId", newName: "IX_Test_Id");
            RenameIndex(table: "dbo.UserAnswers", name: "IX_Question_QuestionId", newName: "IX_Question_Id");
            RenameIndex(table: "dbo.UserAnswers", name: "IX_Test_TestId", newName: "IX_Test_Id");


            AddPrimaryKey("dbo.Groups", "Id");
            AddPrimaryKey("dbo.Questions", "Id");
            AddPrimaryKey("dbo.QuestionTypes", "Id");
            AddPrimaryKey("dbo.QuestionsInTests", "Id");
            AddPrimaryKey("dbo.Tests", "Id");
            AddPrimaryKey("dbo.TestAssignedGroups", "Id");
            AddPrimaryKey("dbo.TestAssignedUsers", "Id");
            AddPrimaryKey("dbo.UserAnswers", "Id");
            AddPrimaryKey("dbo.UsersInGroups", "Id");
            AddForeignKey("dbo.QuestionsInTests", "Question_Id", "dbo.Questions", "Id");
            AddForeignKey("dbo.UserAnswers", "Question_Id", "dbo.Questions", "Id");
            AddForeignKey("dbo.Questions", "Type_Id", "dbo.QuestionTypes", "Id");
            AddForeignKey("dbo.QuestionsInTests", "Test_Id", "dbo.Tests", "Id");
            AddForeignKey("dbo.TestAssignedUsers", "Test_Id", "dbo.Tests", "Id");
            AddForeignKey("dbo.UserAnswers", "Test_Id", "dbo.Tests", "Id");

        }
        
        public override void Down()
        {
            AddColumn("dbo.UsersInGroups", "UsersInGroupId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.UserAnswers", "UserAnswerId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.TestAssignedUsers", "TestAssignedUserId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.TestAssignedGroups", "Test_TestId", c => c.Int());
            AddColumn("dbo.TestAssignedGroups", "Group_GroupId", c => c.Int());
            AddColumn("dbo.TestAssignedGroups", "TestAssignedGroupId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Tests", "TestId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.QuestionsInTests", "QuestionsInTestId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.QuestionTypes", "QuestionTypeId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Questions", "QuestionId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Groups", "GroupId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.UserAnswers", "Test_Id", "dbo.Tests");
            DropForeignKey("dbo.TestAssignedUsers", "Test_Id", "dbo.Tests");
            DropForeignKey("dbo.QuestionsInTests", "Test_Id", "dbo.Tests");
            DropForeignKey("dbo.Questions", "Type_Id", "dbo.QuestionTypes");
            DropForeignKey("dbo.UserAnswers", "Question_Id", "dbo.Questions");
            DropForeignKey("dbo.QuestionsInTests", "Question_Id", "dbo.Questions");
            DropPrimaryKey("dbo.UsersInGroups");
            DropPrimaryKey("dbo.UserAnswers");
            DropPrimaryKey("dbo.TestAssignedUsers");
            DropPrimaryKey("dbo.TestAssignedGroups");
            DropPrimaryKey("dbo.Tests");
            DropPrimaryKey("dbo.QuestionsInTests");
            DropPrimaryKey("dbo.QuestionTypes");
            DropPrimaryKey("dbo.Questions");
            DropPrimaryKey("dbo.Groups");
            DropColumn("dbo.UsersInGroups", "Id");
            DropColumn("dbo.UserAnswers", "Id");
            DropColumn("dbo.TestAssignedUsers", "Id");
            DropColumn("dbo.TestAssignedGroups", "GroupId");
            DropColumn("dbo.TestAssignedGroups", "TestId");
            DropColumn("dbo.TestAssignedGroups", "Id");
            DropColumn("dbo.Tests", "Id");
            DropColumn("dbo.QuestionsInTests", "Id");
            DropColumn("dbo.QuestionTypes", "Id");
            DropColumn("dbo.Questions", "Id");
            DropColumn("dbo.Groups", "Id");
            AddPrimaryKey("dbo.UsersInGroups", "UsersInGroupId");
            AddPrimaryKey("dbo.UserAnswers", "UserAnswerId");
            AddPrimaryKey("dbo.TestAssignedUsers", "TestAssignedUserId");
            AddPrimaryKey("dbo.TestAssignedGroups", "TestAssignedGroupId");
            AddPrimaryKey("dbo.Tests", "TestId");
            AddPrimaryKey("dbo.QuestionsInTests", "QuestionsInTestId");
            AddPrimaryKey("dbo.QuestionTypes", "QuestionTypeId");
            AddPrimaryKey("dbo.Questions", "QuestionId");
            AddPrimaryKey("dbo.Groups", "GroupId");
            RenameIndex(table: "dbo.UserAnswers", name: "IX_Test_Id", newName: "IX_Test_TestId");
            RenameIndex(table: "dbo.UserAnswers", name: "IX_Question_Id", newName: "IX_Question_QuestionId");
            RenameIndex(table: "dbo.TestAssignedUsers", name: "IX_Test_Id", newName: "IX_Test_TestId");
            RenameIndex(table: "dbo.QuestionsInTests", name: "IX_Test_Id", newName: "IX_Test_TestId");
            RenameIndex(table: "dbo.QuestionsInTests", name: "IX_Question_Id", newName: "IX_Question_QuestionId");
            RenameIndex(table: "dbo.Questions", name: "IX_Type_Id", newName: "IX_Type_QuestionTypeId");
            RenameColumn(table: "dbo.UserAnswers", name: "Test_Id", newName: "Test_TestId");
            RenameColumn(table: "dbo.UserAnswers", name: "Question_Id", newName: "Question_QuestionId");
            RenameColumn(table: "dbo.TestAssignedUsers", name: "Test_Id", newName: "Test_TestId");
            RenameColumn(table: "dbo.QuestionsInTests", name: "Test_Id", newName: "Test_TestId");
            RenameColumn(table: "dbo.QuestionsInTests", name: "Question_Id", newName: "Question_QuestionId");
            RenameColumn(table: "dbo.Questions", name: "Type_Id", newName: "Type_QuestionTypeId");
            CreateIndex("dbo.TestAssignedGroups", "Test_TestId");
            CreateIndex("dbo.TestAssignedGroups", "Group_GroupId");
            AddForeignKey("dbo.UserAnswers", "Test_TestId", "dbo.Tests", "TestId");
            AddForeignKey("dbo.TestAssignedUsers", "Test_TestId", "dbo.Tests", "TestId");
            AddForeignKey("dbo.QuestionsInTests", "Test_TestId", "dbo.Tests", "TestId");
            AddForeignKey("dbo.Questions", "Type_QuestionTypeId", "dbo.QuestionTypes", "QuestionTypeId");
            AddForeignKey("dbo.UserAnswers", "Question_QuestionId", "dbo.Questions", "QuestionId");
            AddForeignKey("dbo.QuestionsInTests", "Question_QuestionId", "dbo.Questions", "QuestionId");
            AddForeignKey("dbo.TestAssignedGroups", "Test_TestId", "dbo.Tests", "TestId");
            AddForeignKey("dbo.TestAssignedGroups", "Group_GroupId", "dbo.Groups", "GroupId");
        }
    }
}
