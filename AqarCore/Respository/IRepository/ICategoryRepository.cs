using Models;

namespace DataAccess.Respository.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
      public void Update(Category cat);
        public Task<bool> IsvalidCategory(string id);

    }
}
