using ISP2.Models.LoginScreen;

namespace ISP2.Repositories.LoginScreen
{
    public interface IUserRepository
    {
        Task<User?> AuthenticateAsync(string login, string password);
        Task<bool> LoginExistsAsync(string login);
        Task AddClientAsync(Client client);
        Task AddEmployeeAsync(Employee employee);
    }
}
