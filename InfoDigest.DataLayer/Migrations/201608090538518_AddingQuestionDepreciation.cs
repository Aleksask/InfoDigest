namespace InfoDigest.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingQuestionDepreciation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Questions", "Deprecated", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Questions", "Deprecated");
        }
    }
}
