using DataAccess.Data;
using DataAccess.Respository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Respository
{
    public class Repository<T> : IRepository.IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;

        public Repository(ApplicationDbContext db)
        {
            _db = db;
            dbSet = _db.Set<T>();
        }
        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet.ToList();

        }

        public T GetById(Expression<Func<T, bool>> expression)
        {
            return dbSet.FirstOrDefault(expression);
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }
    }
}
