

namespace DataAccess.Respository.IRepository
{
    public class FavoriteRepo : Repository<FavoriteList>, IFavoriteList 
    {
        private readonly ApplicationDbContext _db;

        public FavoriteRepo(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
       
    }
}
