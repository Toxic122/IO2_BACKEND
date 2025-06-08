using ISP2.Models.ConsultantScreen;
using ISP2.Models.LoginScreen;

namespace ISP2.Repositories.ConsultantScreen
{
    public interface IConsultantRepository
    {
        Task<List<UserSearchRequest>> SearchUsersAsync(string? query);
        Task<List<UserSearchRequest>> GetAllUsersAsync();

    }
}
