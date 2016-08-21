using System;
using System.Threading.Tasks;
using InfoDigest.Domain;

namespace InfoDigest.DataLayer.Repositories
{
    public interface IInfoDigestApplicationUnit : IDisposable
    {
        IGenericRepository<QuestionCategory> QuestionCategories { get;  }
        IGenericRepository<Question> Questions { get; }
        IGenericRepository<AnswerOption> AnswerOptions { get; }
        bool SaveChanges();
        Task<bool> SaveChangesAsync();
    }
}