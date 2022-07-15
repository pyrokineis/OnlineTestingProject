namespace OnlineTestingProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UberLast : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Questions", "Type", c => c.Int(nullable: false));
            DropColumn("dbo.Questions", "TypeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Questions", "TypeId", c => c.Int(nullable: false));
            DropColumn("dbo.Questions", "Type");
        }
    }
}
