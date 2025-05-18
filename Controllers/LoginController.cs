using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using ISP2.Models;
using ISP2.Services;

namespace ISP2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] ISP2.Models.LoginRequest request)
        {
            var user = await _loginService.LoginAsync(request.Login, request.Password);

            if (user == null)
                return Unauthorized(new { success = false, message = "Nieprawidłowy login lub hasło." });

            return Ok(new
            {
                success = true,
                role = user.Role,
                name = user.Name
            });
        }
    }
}
