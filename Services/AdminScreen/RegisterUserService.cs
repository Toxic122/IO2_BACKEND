using ISP2.Data;
using ISP2.Models.AdminScreen;
using ISP2.Models.LoginScreen;
using ISP2.Repositories.LoginScreen;
using Microsoft.EntityFrameworkCore;

namespace ISP2.Services.AdminScreen
{
    public class RegisterUserService : IRegisterUserService
    {
        private readonly IUserRepository _userRepo;
        private readonly AppDbContext _context;

        public RegisterUserService(AppDbContext context, IUserRepository userRepo)
        {
            _context = context;
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

        public async Task<bool> DeleteUserByLoginAsync(string login)
        {
            var client = await _context.Clients.FirstOrDefaultAsync(k => k.Login == login);

            if (client != null)
            {
                var zgloszenia = await _context.Tickets.Where(z => z.IdKlient == client.IdKlient).ToListAsync();
                _context.Tickets.RemoveRange(zgloszenia);

                _context.Clients.Remove(client);
                await _context.SaveChangesAsync();
                return true;
            }

            var employee = await _context.Employees.FirstOrDefaultAsync(p => p.Login == login);
            if (employee != null)
            {
                var zgloszenia = await _context.Tickets.Where(z => z.IdPracownik== employee.IdPracownik).ToListAsync();
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }



    }
}
