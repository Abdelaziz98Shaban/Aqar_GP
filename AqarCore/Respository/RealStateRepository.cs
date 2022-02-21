
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
        public void AddNewRealState(RealState vm)
        {
            var newRealstate = new RealState()
            {
                Title = vm.Title,
                Description = vm.Description,
                VideoLink = vm.VideoLink,
                Address=vm.Address,
                BuildingNumber = vm.BuildingNumber,
                View=vm.View,
                AppartmentNumber = vm.AppartmentNumber,
                Area = vm.Area,
                Rooms = vm.Rooms,
                Baths = vm.Baths,
                Price = vm.Price,
                Status = vm.Status,
                EmergencyExit = vm.EmergencyExit,
                FirePlace = vm.FirePlace,
                SwimmingPool = vm.SwimmingPool,
                LaundryRoom = vm.LaundryRoom,
                
                CategoryId = vm.CategoryId
            };
            _db.RealStates.Add(newRealstate);
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
