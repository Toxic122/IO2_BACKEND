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
                .Include(c => c.Rola)
                .FirstOrDefaultAsync(c => c.Login == login && c.Pass == password);

            if (client != null)
            {
                return new User
                {
                    Name = client.Imie,
                    Login = client.Login,
                    Rola = client.Rola?.Rola ?? "BRAK ROLI"
                };
            }

            var employee = await _context.Employees
                .Include(e => e.Rola)
                .FirstOrDefaultAsync(e => e.Login == login && e.Pass == password);

            if (employee != null)
            {
                return new User
                {
                    Name = employee.Imie,
                    Login = employee.Login,
                    Rola = employee.Rola?.Rola ?? "BRAK ROLI"
                };
            }

            return null;


        }

        public async Task<bool> LoginExistsAsync(string login)
        {
            return await _context.Clients.AnyAsync(c => c.Login == login)
            || await _context.Employees.AnyAsync(e => e.Login == login);
        }

        public async Task AddClientAsync(Client client)
        {
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();
        }

        public async Task AddEmployeeAsync(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
        }

    }


}
