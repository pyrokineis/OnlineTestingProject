namespace OnlineTestingProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QuestionTypeToInt : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Questions", "Type_Id", "dbo.QuestionTypes");
            DropIndex("dbo.Questions", new[] { "Type_Id" });
            AddColumn("dbo.Questions", "TypeId", c => c.Int(nullable: false));
            DropColumn("dbo.Questions", "Type_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Questions", "Type_Id", c => c.Int());
            DropColumn("dbo.Questions", "TypeId");
            CreateIndex("dbo.Questions", "Type_Id");
            AddForeignKey("dbo.Questions", "Type_Id", "dbo.QuestionTypes", "Id");
        }
    }
}
