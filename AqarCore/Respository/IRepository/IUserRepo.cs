
namespace DataAccess.Respository.IRepository
{
    public interface IUserRepo : IRepository<ApplicationUser>
    {
        public Task<AuthViewModel> RegisterAsync(RegisterViewModel model);
        public Task<AuthViewModel> LoginAsync(LoginViewModel model);
        public Task<string> AddRoleAsync(AddRoleViewModel model);
        public Task<AuthViewModel> RefreshTokenAsync(string token);
        public Task<bool> RevokeTokenAsync(string token);

        public void update(ApplicationUser User);
    }
}
