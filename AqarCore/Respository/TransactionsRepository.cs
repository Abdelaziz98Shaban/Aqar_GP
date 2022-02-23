using DataAccess.Data;
using Models;

namespace DataAccess.Respository.IRepository
{
    public class TransactionsRepository : Repository<Transactions> , ITransactions 
    {
        private readonly ApplicationDbContext _db;

        public TransactionsRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}