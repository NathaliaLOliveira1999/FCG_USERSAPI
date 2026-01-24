using FCG_USERSAPI.Interfaces.Services;
using FCG_USERSAPI.Models.DTO;
using FCG_USERSAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FCG_USERSAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {

        private readonly IUserService _userService; 
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAll() => Ok(_userService.GetAll());

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _userService.GetById(id);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        [Authorize]
        [HttpGet("/Users/GetByUser")]
        public IActionResult GetByUser(string userName)
        {
            var user = _userService.GetByUser(userName);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(UserDto user)
        {
            if (user == null)
                return BadRequest("Preencha as informações do usuário!");
            var retorno = _userService.Add(user, user.IdClient);
            if (retorno.Success)
                return Ok(user);
            else return BadRequest(retorno.Error);
        }
    }
}
