using System.Linq.Expressions;

namespace DataAccess.Respository.IRepository
{
    public interface IRepository<T> where T : class
    {
       Task<IEnumerable<T>> GetAll();

        Task<T> GetById(Expression<Func<T, bool>> expression);

        void Add(T entity);

        void Remove(T entity);
    }
}
