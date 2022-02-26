
namespace DataAccess.Respository.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category{ get; }
        IRealstateRepository Realstate { get; }
        ITransactions Transactions { get; }
        IUserRepo Users { get; }
        void Save();
    }
}
