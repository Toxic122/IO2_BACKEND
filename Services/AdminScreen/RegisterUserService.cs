using ISP2.Models.AdminScreen;
using ISP2.Models.LoginScreen;
using ISP2.Repositories.LoginScreen;

namespace ISP2.Services.AdminScreen
{
    public class RegisterUserService : IRegisterUserService
    {
        private readonly IUserRepository _userRepo;

        public RegisterUserService(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task RegisterClientAsync(RegisterUserRequest request)
        {
            // walidacja czy login istnieje
            if (await _userRepo.LoginExistsAsync(request.Login))
                throw new Exception("Użytkownik o podanym loginie już istnieje.");

         

            if (request.idRola == 5)
            {
                var client = new Client
                {
                    Login = request.Login,
                    Pass = request.Pass,
                    Imie = request.Imie,
                    Nazwisko = request.Nazwisko,
                    Wiek = request.Wiek,
                    Telefon = request.Telefon,
                    Email= request.Email,
                    idUsluga = request.IdUsluga,
                    IdRola = request.idRola
                };

                await _userRepo.AddClientAsync(client);
            }
            else
            {
                var employee = new Employee
                {
                    Login = request.Login,
                    Pass = request.Pass,
                    Imie = request.Imie,
                    Nazwisko = request.Nazwisko,
                    Wiek = request.Wiek,
                    Telefon = request.Telefon,
                    Email = request.Email,
                    IdRola = request.idRola
                };

                await _userRepo.AddEmployeeAsync(employee);
            }
            
        }
    }
}
