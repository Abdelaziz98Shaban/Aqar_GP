using DataAccess.Data;
using Models;

namespace DataAccess.Respository.IRepository
{
    public class FavoriteRepo : Repository<FavoriteList>, IFavoriteList 
    {
        private readonly ApplicationDbContext _db;

        public FavoriteRepo(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        //public async Task<IEnumerable<RealState>> SearchByID(string userid, string realid)
        //{
        //    return await _db.FavoriteList.Where(x => x.RealstateId == realid && x.UserId == userid).ToList();
        //}
    }
}
