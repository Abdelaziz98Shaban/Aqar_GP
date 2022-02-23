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

        IEnumerable<RealState> SearchByID(int CatID, string type);
        IEnumerable<RealState> GetByStatus(string status);

        IEnumerable<RealState> SearchByProp(RealStateVm prop);


    }
}
