using APIControleTarefasComAutenticação.Application.DTO_s;
using APIControleTarefasComAutenticação.Application.Interfaces;
using APIControleTarefasComAutenticação.Domain.Entities;
using APIControleTarefasComAutenticação.Infrastructure.Security;
using Microsoft.AspNetCore.Mvc;

namespace APIControleTarefasComAutenticação.API.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJwtService _jwtService;

        public AuthController(
            IUserService userService,
            IJwtService jwtService)
        {
            _userService = userService;
            _jwtService = jwtService;
        }

        [HttpPost("registrar")]
        public async Task<IActionResult> Register(RegisterUserDto dto)
        {
            try
            {
                await _userService.RegisterAsync(dto);
                return Ok(new { message = "Usuario registrado com sucesso" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserDto dto)
        {
            try
            {
                var user = await _userService.LoginAsync(dto);
                var token = _jwtService.GenerateToken(
                new User
                {
                    Id = user.Id,
                    Email = user.Email
                });
                return Ok(new { token });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
