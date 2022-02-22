
using DataAccess.Data;
using DataAccess.Respository.IRepository;
using Models;

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

        public void Update(RealState obj)
        {
            _db.RealStates.Update(obj);
        }
    }
}
