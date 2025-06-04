using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using ISP2.Services.LoginScreen;

namespace ISP2.Controllers.LoginScreen
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
        public async Task<IActionResult> Login([FromBody] Models.LoginScreen.LoginRequest request)
        {
            var user = await _loginService.LoginAsync(request.Login, request.Password);

            if (user == null)
                return Unauthorized(new { success = false, message = "Nieprawidłowy login lub hasło." });
            if(user.Rola ==null)
                return Unauthorized(new { success = false, message = "Brak przypisanej roli do użytkownika - skontaktuj się z administratorem" });

            return Ok(new
            {
                success = true,
                role = user.Rola,
                name = user.Name
            });
        }
    }
}
