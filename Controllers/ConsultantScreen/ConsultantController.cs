using ISP2.Models.ConsultantScreen;
using ISP2.Repositories.ConsultantScreen;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ConsultantController : ControllerBase
{
    private readonly IConsultantRepository _consultantRepo;

    public ConsultantController(IConsultantRepository consultantRepo)
    {
        _consultantRepo = consultantRepo;
    }

    [HttpGet("search-clients")]
    public async Task<IActionResult> SearchClients([FromQuery] string? FullName)
    {
        var results = await _consultantRepo.SearchClientsAsync(FullName);
        return Ok(results);
    }
}
