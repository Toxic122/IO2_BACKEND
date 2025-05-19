using ISP2.Data;
using ISP2.Models.ConsultantScreen;
using ISP2.Models.LoginScreen;
using Microsoft.EntityFrameworkCore;

namespace ISP2.Repositories.ConsultantScreen
{
    public class EfConsultantRepository : IConsultantRepository
    {
        private readonly AppDbContext _context;

        public EfConsultantRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Client>> SearchClientsAsync(string? fullName)
        {
            return await _context.Clients
                .Where(c => string.IsNullOrEmpty(fullName) ||
                            (c.Imie + " " + c.Nazwisko).Contains(fullName))
                .ToListAsync();
        }
    }
}
