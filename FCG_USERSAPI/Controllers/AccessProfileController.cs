using FCG_USERSAPI.Interfaces.Services;
using FCG_USERSAPI.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FCG_USERSAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccessProfileController : ControllerBase
    {
        private readonly IAccessProfileService _accessProfileService;

        public AccessProfileController(IAccessProfileService accessProfileService)
        {
            _accessProfileService = accessProfileService;
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAll() => Ok(_accessProfileService.GetAll());

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var client = _accessProfileService.GetById(id);
            if (client == null)
                return NotFound();
            return Ok(client);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(AccessProfileDto accessProfile)
        {
            if (accessProfile == null)
                return BadRequest("Preencha as informações do profile!");
            var retorno = _accessProfileService.Add(accessProfile);
            if (retorno.Success)
                return Ok(accessProfile);
            else return BadRequest(retorno.Error);
        }
    }
}