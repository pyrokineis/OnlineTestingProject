namespace OnlineTestingProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lastlastlast : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.QuestionsInTests", "Test_Id", "dbo.Tests");
            DropIndex("dbo.QuestionsInTests", new[] { "Test_Id" });
            AddColumn("dbo.QuestionsInTests", "TestId", c => c.Int(nullable: false));
            DropColumn("dbo.QuestionsInTests", "Test_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.QuestionsInTests", "Test_Id", c => c.Int());
            DropColumn("dbo.QuestionsInTests", "TestId");
            CreateIndex("dbo.QuestionsInTests", "Test_Id");
            AddForeignKey("dbo.QuestionsInTests", "Test_Id", "dbo.Tests", "Id");
        }
    }
}
