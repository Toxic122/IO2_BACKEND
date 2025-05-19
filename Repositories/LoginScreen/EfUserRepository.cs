using Microsoft.EntityFrameworkCore;
using ISP2.Data;
using ISP2.Models.LoginScreen;

namespace ISP2.Repositories.LoginScreen
{
    public class EfUserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public EfUserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User?> AuthenticateAsync(string login, string password)
        {
            var client = await _context.Clients
                .FirstOrDefaultAsync(c => c.Login == login && c.Pass == password);

            if (client != null)
            {
                return new User
                {
                    Name = client.Imie,
                    Login = client.Login,
                    Role = client.Rola
                };
            }

            var employee = await _context.Employees
                .FirstOrDefaultAsync(e => e.Login == login && e.Pass == password);

            if (employee != null)
            {
                return new User
                {
                    Name = employee.Imie,
                    Login = employee.Login,
                    Role = employee.Rola
                };
            }

            return null;
        }
    }
}
