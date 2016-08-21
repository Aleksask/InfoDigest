using System.Threading.Tasks;
using InfoDigest.Domain;

namespace InfoDigest.DataLayer.Repositories
{
    public class InfoDigestApplicationUnit : IInfoDigestApplicationUnit
    {
        private readonly InfoDigestContext _infoDigestCtxt;

        private IGenericRepository<QuestionCategory> _questionCategories;
        public IGenericRepository<QuestionCategory> QuestionCategories
        {
            get
            {
                return
                    _questionCategories =
                        _questionCategories ?? new GenericRepository<QuestionCategory>(_infoDigestCtxt);
            }
        }

        private IGenericRepository<Question> _questions;
        public IGenericRepository<Question> Questions
        {
            get { return _questions = _questions ?? new GenericRepository<Question>(_infoDigestCtxt); }
        }

        private IGenericRepository<AnswerOption> _answers;
        public IGenericRepository<AnswerOption> AnswerOptions
        {
            get { return _answers = _answers ?? new GenericRepository<AnswerOption>(_infoDigestCtxt); }
        }

        public InfoDigestApplicationUnit(InfoDigestContext infoDigestCtxt)
        {
            _infoDigestCtxt = infoDigestCtxt;
        }

        public bool SaveChanges()
        {
            return _infoDigestCtxt.SaveChanges() > 0;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _infoDigestCtxt.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
            _infoDigestCtxt.Dispose();
        }
    }
}