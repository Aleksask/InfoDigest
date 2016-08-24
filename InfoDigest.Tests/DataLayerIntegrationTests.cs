using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using InfoDigest.DataLayer;
using InfoDigest.DataLayer.Repositories;
using InfoDigest.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InfoDigest.Tests
{
    [TestClass]
    public class DataLayerIntegrationTests
    {   
        [TestInitialize]
        public void PrepareTestDatabase()
        {
            Database.SetInitializer(new TestInfoDigestConfiguration());
        }

        [TestMethod]
        public void Should_create_new_question_category_with_the_question_if_it_didnt_exist()
        {
            
        }

        [TestMethod]
        public void Should_not_create_questions_without_answer_options()
        {
            
        }

        [TestMethod]
        public void InstantiateTheContext()
        {
            var dbCtxt = new InfoDigestContext("InfoDigestTests");

            try
            {
                QuestionRepository repo = new QuestionRepository(dbCtxt);
                repo.Add(new Question {QuestionText = "Yabba"});
                dbCtxt.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                throw e;
            }
            
        }
    }
}
