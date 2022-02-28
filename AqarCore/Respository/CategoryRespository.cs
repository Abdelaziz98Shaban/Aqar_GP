
namespace DataAccess.Respository.IRepository
{
   public class CategoryRespository : Repository<Category> , ICategoryRepository
    {
        private readonly ApplicationDbContext _db;
        public CategoryRespository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        

        public  async Task<IEnumerable<Category>> GetAll()
        {
            return await _db.Category.OrderBy(cat=>cat.Name).Include(cat => cat.RealStates).ToListAsync();

        }
        public void Update(Category obj)
        {
            _db.Category.Update(obj);
        }

        public async Task<Category> GetById(Expression<Func<Category, bool>> expression)
        {
            return await _db.Category.Include(cat => cat.RealStates).FirstOrDefaultAsync(expression);
        }
        public Task<bool> IsvalidCategory(string id)
        {
            return _db.Category.AnyAsync(cat => cat.Id == id);
        }
    }
}
