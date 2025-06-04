/*using ISP2.Models.ServiceScreen;
using ISP2.Repositories.ServiceScreen;
namespace ISP2.Services.ServiceScreen
{
    public class ServiceScreen : IServiceServices
    {
        private readonly ITicketRepository _TicketRepo;

        public ServiceScreen(ITicketRepository ticketRepo)
        {
            _TicketRepo = ticketRepo;
        }

        public async Task<Ticket?> LoginAsync(string login, string password)
        {
            return await _TicketRepo.AuthenticateAsync(login, password);
        }
    }
}
*/