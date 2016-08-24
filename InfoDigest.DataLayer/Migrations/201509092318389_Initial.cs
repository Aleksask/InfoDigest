namespace InfoDigest.DataLayer.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.QuestionCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false, maxLength: 300, fixedLength: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QuestionText = c.String(nullable: false, maxLength: 500),
                        Image = c.Binary(),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.QuestionCategories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.AnswerOptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCorrect = c.Boolean(nullable: false),
                        AnswerText = c.String(),
                        AnswerUrl = c.String(),
                        AnswerExplanation = c.String(),
                        QuestionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true)
                .Index(t => new { t.QuestionId, t.IsCorrect }, unique: true, name: "IX_AnswerOption");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Questions", "CategoryId", "dbo.QuestionCategories");
            DropForeignKey("dbo.AnswerOptions", "QuestionId", "dbo.Questions");
            DropIndex("dbo.AnswerOptions", "IX_AnswerOption");
            DropIndex("dbo.Questions", new[] { "CategoryId" });
            DropTable("dbo.AnswerOptions");
            DropTable("dbo.Questions");
            DropTable("dbo.QuestionCategories");
        }
    }
}
