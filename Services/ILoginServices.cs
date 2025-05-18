using ISP2.Models;

namespace ISP2.Services
{
    public interface ILoginService
    {
        Task<User?> LoginAsync(string login, string password);
    }
}
