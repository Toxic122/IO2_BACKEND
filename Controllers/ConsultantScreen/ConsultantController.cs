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

    [HttpGet("search-users")]
    public async Task<IActionResult> SearchClients([FromQuery] string? FullName)
    {
        var results = await _consultantRepo.SearchUsersAsync(FullName);
        return Ok(results);
    }

    [HttpGet("all-users")]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _consultantRepo.GetAllUsersAsync();
        return Ok(users);
    }


}
