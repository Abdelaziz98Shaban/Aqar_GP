using Models;
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
        void AddNewRealState(RealState rs);

        IEnumerable<RealState> SearchByID(int CatID, string type);
    }
}
