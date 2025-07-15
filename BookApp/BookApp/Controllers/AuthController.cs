using LibraryManagementSystem.Core.DTOs;
using LibraryManagementSystem.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService) => _authService = authService;

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDTO dto)
        {
            await _authService.RegisterAsync(dto);
            return Ok(new { message = "Registration successful." });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO dto)
        {
            var token = await _authService.LoginAsync(dto);
            return Ok(new { token });
        }
    }
}
