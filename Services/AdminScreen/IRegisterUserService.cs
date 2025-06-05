using ISP2.Models.AdminScreen;
using System.Threading.Tasks;

namespace ISP2.Services.AdminScreen
{
    public interface IRegisterUserService
    {
        Task RegisterClientAsync(RegisterUserRequest request);
        Task<bool> DeleteUserByLoginAsync(string login);

    }
}
