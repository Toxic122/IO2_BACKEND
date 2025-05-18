using ISP2.Models;

namespace ISP2.Repositories
{
    public interface IUserRepository
    {
        Task<User?> AuthenticateAsync(string login, string password);
    }
}
