
using DataAccess.Data;
using DataAccess.Respository.IRepository;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.viewModel;

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
            if (prop.minPrice is not null && prop.minPrice != 0 && prop.maxPrice is not null && prop.maxPrice != 0) 
                query += $"AND Area BETWEEN ${prop.minPrice} and ${prop.maxPrice} ";
            if (prop.minArea is not null && prop.minArea != 0 && prop.maxArea is not null && prop.maxArea != 0)
                query += $"AND Price BETWEEN ${prop.minArea} and ${prop.maxArea} ";
            return await _db.RealStates.FromSqlRaw(query).ToListAsync();

        }

        public void Update(RealState obj)
        {
            _db.RealStates.Update(obj);
        }
    }
}
