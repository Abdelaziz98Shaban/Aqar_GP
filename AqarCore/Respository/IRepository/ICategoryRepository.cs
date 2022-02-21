using Models;

namespace DataAccess.Respository.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void Update(Category cat);
    }
}
