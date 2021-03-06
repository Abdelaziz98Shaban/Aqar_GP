
namespace DataAccess.Respository.IRepository
{
   public class CategoryRespository : Repository<Category> , ICategoryRepository
    {
        private readonly ApplicationDbContext _db;
        public CategoryRespository(ApplicationDbContext db) : base(db)
        {
            _db = db;
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
