
namespace DataAccess.Respository
{
    public class RealStateRepository : Repository<RealState>, IRealstateRepository
    {
        private readonly ApplicationDbContext _db;

        public RealStateRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

     
        public async Task<IEnumerable<RealState>> GetByStatus(string status)
        {
            return await _db.RealStates.Where(x => x.Status == status).ToListAsync();
        }
    

        public async Task<IEnumerable<RealState>> SearchByID(int CatID, string st)
        {
            return  await _db.RealStates.Where(x => int.Parse(x.CategoryId)== CatID && x.Address.State == st).ToListAsync();
        }



        public async Task<IEnumerable<RealState> >SearchByProp(RealStateSearchVM prop )
        {
           
            string query = $"SELECT * FROM RealStates WHERE ";
            query += $"Status='{prop.Status}' ";
            if (prop.CategoryId != 0)  query += $"AND CategoryId={prop.CategoryId} ";
            if (prop.BuildingView is not null) query += $"AND BuildingView ='{prop.BuildingView}' ";
            if (prop.Rooms is not null && prop.Rooms != 0 ) query += $"AND Rooms ='{prop.Rooms}' ";
            if (prop.Baths is not null && prop.Baths != 0 ) query += $"AND Baths ='{prop.Baths}' ";
            if (prop.Floor is not null && prop.Floor != 0 ) query += $"AND Floor ='{prop.Floor}' ";
            if (prop.minPrice is not null && prop.maxPrice is not null ) 
            query += $"AND Area BETWEEN ${prop.minPrice} and ${prop.maxPrice} ";
            if (prop.minArea is not null  && prop.maxArea is not null )
            query += $"AND Price BETWEEN ${prop.minArea} and ${prop.maxArea} ";
            return await _db.RealStates.FromSqlRaw(query).ToListAsync();

        }

        public List<RealState>? favoriteLists(string userId)
        {
            var favList = new List<RealState>();
            var fav = _db.FavoriteList?.Where(x => x.UserId==userId).Include(real=> real.RealState).ToList();
            if(fav?.Count != 0)
            {
            foreach (var item in fav)
            {
                favList.Add(item.RealState);
            }
            return favList;

            }
            return null;
        }
        public void Update(RealState obj)
        {
            _db.RealStates.Update(obj);
        }
    }
}
