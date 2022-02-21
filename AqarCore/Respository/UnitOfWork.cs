

using DataAccess.Data;
using DataAccess.Respository.IRepository;

namespace DataAccess.Respository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category= new CategoryRespository(_db);
            Realstate = new RealstateRepository(_db);
            //Transactions = new TransactionsRepository(_db);
        }
        public ICategoryRepository Category { get; private set; }
        public IRealstateRepository Realstate { get; private set; }
        public ITransactions Transactions { get; private set; }

        

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
