using ISP2.Models.ServiceScreen;

namespace ISP2.Repositories.ServiceScreen
{
    public interface ITicketRepository
    {
        Task<List<Ticket>> GetAllTicketsAsync();
        Task<Ticket?> GetTicketByIdAsync(int id);
    }
}
