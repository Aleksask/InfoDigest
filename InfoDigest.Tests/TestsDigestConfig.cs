using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using InfoDigest.DataLayer;
using InfoDigest.Domain;

namespace InfoDigest.Tests
{
    public class TestInfoDigestConfiguration : DropCreateDatabaseAlways<InfoDigestContext>
    {
        protected override void Seed(InfoDigestContext context)
        {
            var newQuestion = new Question
            {
                Category = new QuestionCategory { CategoryName = "Istoriniai"},
                QuestionText = "Kas yra Lietuvos sostine?",
                AnswerOptions = new List<AnswerOption>
                {
                    new AnswerOption
                    {
                        AnswerExplanation = "Gediminas ikure Vilniu ir perkele ten sostine",
                        AnswerText = "Vilnius",
                        IsCorrect = true
                    },
                    new AnswerOption
                    {
                        AnswerText = "Kaunas",
                        IsCorrect = false
                    },
                    new AnswerOption
                    {
                        AnswerText = "Klaipeda",
                        IsCorrect = false
                    }
                }
            };
            
            context.Questions.AddOrUpdate(newQuestion);
            context.SaveChanges();

            base.Seed(context);
        }
    }
}