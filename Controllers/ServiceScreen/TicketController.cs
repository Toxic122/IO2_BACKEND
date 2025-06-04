using ISP2.Repositories.ServiceScreen;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class TicketController : ControllerBase
{
    private readonly ITicketRepository _ticketRepo;

    public TicketController(ITicketRepository ticketRepo)
    {
        _ticketRepo = ticketRepo;
    }

    //GET /api/ticket/all
    [HttpGet("all")]
    public async Task<IActionResult> GetAllTickets()
    {
        var tickets = await _ticketRepo.GetAllTicketsAsync();
        return Ok(tickets);
    }

    //GET /api/ticket/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetTicketById(int id)
    {
        var ticket = await _ticketRepo.GetTicketByIdAsync(id);
        if (ticket == null)
            return NotFound($"Nie znaleziono zgłoszenia o wskazanym id - {id}");

        return Ok(ticket);
    }
}
