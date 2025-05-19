using ISP2.Models.LoginScreen;

namespace ISP2.Services.LoginScreen
{
    public interface ILoginService
    {
        Task<User?> LoginAsync(string login, string password);
    }
}
