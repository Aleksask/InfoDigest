using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using InfoDigest.DataLayer;
using InfoDigest.DataLayer.Repositories;
using InfoDigest.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InfoDigest.Tests
{
    [TestClass]
    public class DataLayerIntegrationTests
    {
        static DataLayerIntegrationTests()
        {
            
        }
        
        [TestInitialize]
        public void PrepareTestDatabase()
        {
            
        }

        [TestMethod]
        public void InstantiateTheContext()
        {
            Database.SetInitializer(new TestInfoDigestConfiguration());

            var dbCtxt = new InfoDigestContext("InfoDigestTests");

            try
            {
                QuestionRepository repo = new QuestionRepository(dbCtxt);
                repo.Add(new Question {QuestionText = "Yabba"});
                dbCtxt.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                
            }
            
        }
    }
}
