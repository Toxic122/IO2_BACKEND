using ISP2.Models.LoginScreen;
using ISP2.Repositories.LoginScreen;
namespace ISP2.Services.LoginScreen
{
    public class LoginService : ILoginService
    {
        private readonly IUserRepository _userRepo;

        public LoginService(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<User?> LoginAsync(string login, string password)
        {
            return await _userRepo.AuthenticateAsync(login, password);
        }
    }
}
