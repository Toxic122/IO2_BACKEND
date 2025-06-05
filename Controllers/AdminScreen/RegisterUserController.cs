using Microsoft.AspNetCore.Mvc;
using ISP2.Models.AdminScreen;
using ISP2.Services.AdminScreen;

namespace ISP2.Controllers.AdminScreen
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegisterUserController : ControllerBase
    {
        private readonly IRegisterUserService _registerService;

        public RegisterUserController(IRegisterUserService registerService)
        {
            _registerService = registerService;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterUserRequest request)
        {
            try
            {
                await _registerService.RegisterClientAsync(request);
                return Ok(new { message = "Rejestracja zakończona sukcesem." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpDelete("delete/{login}")]
        public async Task<IActionResult> DeleteUser(string login)
        {
            var success = await _registerService.DeleteUserByLoginAsync(login);
            if (!success)
            {
                return NotFound(new { message = "Użytkownik o podanym loginie nie istnieje." });
            }

            return Ok(new { message = "Użytkownik został usunięty." });
        }




    }
}
