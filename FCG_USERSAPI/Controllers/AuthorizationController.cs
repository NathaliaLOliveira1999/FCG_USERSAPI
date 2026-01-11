using FCG_USERSAPI.Interfaces.Services;
using FCG_USERSAPI.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace FCG_USERSAPI.Controllers
{
    public class AuthorizationController : Controller
    {
        private readonly IUserService _userService;

        public AuthorizationController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto login)
        {
            // 1️ Buscar usuário pelo e-mail
            var user = _userService.GetByUser(login.UserName);

            if (user == null)
                return Unauthorized("Usuário não encontrado");

            // 2️ Validar senha com hash
            if (!BCrypt.Net.BCrypt.Verify(login.PasswordHash, user.PasswordHash))
                return Unauthorized("Senha incorreta");

            // 3️ Gerar token JWT
            var token = _userService.GenerateToken(user);

            return Ok(new { token });
        }
    }
}