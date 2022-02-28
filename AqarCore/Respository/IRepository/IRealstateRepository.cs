using Models;
using Models.viewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Respository.IRepository
{
   public interface IRealstateRepository : IRepository<RealState>
    {
        void Update(RealState rs);

        Task<IEnumerable<RealState>> SearchByID(int CatID, string type);
        Task<IEnumerable<RealState>> GetByStatus(string status);

       Task<IEnumerable<RealState>> SearchByProp(RealStateSearchVM prop);
        public List<RealState> favoriteLists(string userId);


    }
}
