using Models;
using Models.viewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Respository.IRepository
{
    public interface IUserRepo : IRepository<ApplicationUser>
    {
        Task<AuthViewModel> RegisterAsync(RegisterViewModel model);
      Task<AuthViewModel> LoginAsync(LoginViewModel model);
       public Task<string> AddRoleAsync(AddRoleViewModel model);
        public void update(ApplicationUser User);
    }
}
