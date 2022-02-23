
using DataAccess.Data;
using DataAccess.Respository.IRepository;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.viewModel;

namespace DataAccess.Respository
{
    public class RealstateRepository : Repository<RealState>, IRealstateRepository
    {
        private readonly ApplicationDbContext _db;

        public RealstateRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
       

        public IEnumerable<RealState> GetByStatus(string status)
        {
            return _db.RealStates.Where(x => x.Status == status).ToList();
        }
    

        public IEnumerable<RealState> SearchByID(int CatID, string st)
        {
            return _db.RealStates.Where(x => x.CategoryId == CatID && x.Address.State == st).ToList();
        }



        public IEnumerable<RealState> SearchByProp(RealStateVm prop )
        {
            string query = $"SELECT * FROM RealStates WHERE ";
            query += $"Status='{prop.Status}' ";
            if (prop.CategoryId != 0)  query += $"AND CategoryId={prop.CategoryId} ";
            if (prop.BuildingView is not null) query += $"AND BuildingView ='{prop.BuildingView}' ";
            if (prop.Rooms != 0) query += $"AND Rooms ='{prop.Rooms}' ";
            if (prop.Baths != 0) query += $"AND Baths ='{prop.Baths}' ";
            if (prop.Floor != 0) query += $"AND Floor ='{prop.Floor}' ";
            query += $"AND Area BETWEEN ${prop.minArea} and ${prop.maxArea} ";
            query += $"AND Price BETWEEN ${prop.minPrice} and ${prop.maxPrice} ";
            return  _db.RealStates.FromSqlRaw(query).ToList();

        }

        public void Update(RealState obj)
        {
            _db.RealStates.Update(obj);
        }
    }
}
