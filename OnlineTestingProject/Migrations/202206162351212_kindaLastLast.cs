namespace OnlineTestingProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kindaLastLast : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Questions", "AnswerOptionsAmount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Questions", "AnswerOptionsAmount");
        }
    }
}
