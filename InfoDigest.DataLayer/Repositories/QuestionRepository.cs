using System.Data.Entity;
using InfoDigest.Domain;

namespace InfoDigest.DataLayer.Repositories
{
    public class QuestionRepository : GenericRepository<Question>
    {
        public QuestionRepository(DbContext context) : base(context)
        {
        }
    }
}