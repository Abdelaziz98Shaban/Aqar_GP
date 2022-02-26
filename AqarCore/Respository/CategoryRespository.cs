
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DataAccess.Respository.IRepository
{
   public class CategoryRespository : Repository<Category> , ICategoryRepository
    {
        private readonly ApplicationDbContext _db;
        public CategoryRespository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        

        public  async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await _db.Category.OrderBy(cat=>cat.Name).ToListAsync();

        }
        public void Update(Category obj)
        {
            _db.Category.Update(obj);
        }

        public Task<bool> IsvalidCategory(string id)
        {
            return _db.Category.AnyAsync(cat => cat.Id == id);
        }
    }
}
