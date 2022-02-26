using Models;

namespace DataAccess.Respository.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        public  Task<IEnumerable<Category>> GetAllCategories();

      public void Update(Category cat);
        public Task<bool> IsvalidCategory(string id);

    }
}
