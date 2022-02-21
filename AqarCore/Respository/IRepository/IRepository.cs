using System.Linq.Expressions;

namespace DataAccess.Respository.IRepository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();

        T GetById(Expression<Func<T, bool>> expression);

        void Add(T entity);

        void Remove(T entity);
    }
}
