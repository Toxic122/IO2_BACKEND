using ISP2.Models;
using ISP2.Repositories;
using ISP2.Services;
namespace ISP2.Services
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
