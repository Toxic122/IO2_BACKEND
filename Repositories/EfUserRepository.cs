using ISP2.Models;
using Microsoft.EntityFrameworkCore;
using ISP2.Data;


namespace ISP2.Repositories
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
            
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Login == login && u.Pass == password);
        }
    }
}
