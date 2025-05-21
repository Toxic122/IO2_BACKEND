using ISP2.Data;
using ISP2.Models.ServiceScreen;
using Microsoft.EntityFrameworkCore;

namespace ISP2.Repositories.ServiceScreen
{
    public class EfTicketRepository : ITicketRepository
    {
        private readonly AppDbContext _context;

        public EfTicketRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Ticket>> GetAllTicketsAsync()
        {
            return await _context.Tickets
                .Include(t => t.TypZgloszenia)
                .Include(t => t.Status)
                .Include(t => t.ClientLogin)
                .Include(t => t.EmployeeLogin)
                .ToListAsync();
        }

        public async Task<Ticket?> GetTicketByIdAsync(int id)
        {
            return await _context.Tickets
                .Include(t => t.TypZgloszenia)
                .Include(t => t.Status)
                .Include(t => t.ClientLogin)
                .Include(t => t.EmployeeLogin)
                .FirstOrDefaultAsync(t => t.IdZgloszenia == id);
        }
    }
}
