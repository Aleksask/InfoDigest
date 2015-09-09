using System.Linq;
using System.Threading.Tasks;

namespace InfoDigest.DataLayer.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        Task<TEntity> GetById(int id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void Delete(int id);
        void Detach(TEntity entity);
    }
}
