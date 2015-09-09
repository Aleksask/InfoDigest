using System.Data.Entity;
using InfoDigest.Domain;

namespace InfoDigest.DataLayer.Repositories
{
    public class QuestionCategoryRepository : GenericRepository<QuestionCategory>
    {
        public QuestionCategoryRepository(DbContext context) : base(context)
        {
        }
    }
}