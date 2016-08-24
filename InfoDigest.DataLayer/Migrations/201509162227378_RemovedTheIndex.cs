namespace InfoDigest.DataLayer.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class RemovedTheIndex : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.AnswerOptions", "IX_AnswerOption");
            CreateIndex("dbo.AnswerOptions", "QuestionId", name: "IX_AnswerOption");
        }
        
        public override void Down()
        {
            DropIndex("dbo.AnswerOptions", "IX_AnswerOption");
            CreateIndex("dbo.AnswerOptions", new[] { "QuestionId", "IsCorrect" }, unique: true, name: "IX_AnswerOption");
        }
    }
}
