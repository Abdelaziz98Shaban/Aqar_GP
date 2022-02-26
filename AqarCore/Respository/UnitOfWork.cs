

using DataAccess.Data;
using DataAccess.Helpers;
using DataAccess.Respository.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Models;

namespace DataAccess.Respository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly JWT _jwt;
        public UnitOfWork(ApplicationDbContext db, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IOptions<JWT> jwt)
        {
            _db = db;
            Category= new CategoryRespository(_db);
            Realstate = new RealStateRepository(_db);
            Transactions = new TransactionsRepository(_db);
            Users = new UserRepo(_db, userManager,roleManager,jwt);
        }
        public ICategoryRepository Category { get; private set; }
        public IRealstateRepository Realstate { get; private set; }
        public ITransactions Transactions { get; private set; }
        public IUserRepo Users { get; private set; }

        

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
