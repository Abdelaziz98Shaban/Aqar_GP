
namespace DataAccess.Respository.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category{ get; }
        IRealstateRepository Realstate { get; }
        ITransactions Transactions { get; }
        IFavoriteList FavoriteList { get; }
        IUserRepo Users { get; }
        void Save();
    }
}
