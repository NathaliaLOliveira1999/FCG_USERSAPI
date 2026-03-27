using FCG_USERSAPI.Interfaces.Services;
using FCG_USERSAPI.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FCG_USERSAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AccessProfileController : ControllerBase
    {
        private readonly IAccessProfileService _accessProfileService;

        public AccessProfileController(IAccessProfileService accessProfileService)
        {
            _accessProfileService = accessProfileService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll() => Ok(_accessProfileService.GetAll());

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var client = _accessProfileService.GetById(id);
            if (client == null)
                return NotFound();
            return Ok(client);
        }

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

        [HttpPut]
        public IActionResult Update(AccessProfileDto accessProfile)
        {
            if (accessProfile == null)
                return BadRequest("Preencha as informações do profile!");
            var retorno = _accessProfileService.Update(accessProfile);
            if (retorno.Success)
                return Ok(accessProfile);
            else return BadRequest(retorno.Error);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var retorno = _accessProfileService.Delete(id);
            if (retorno.Success)
                return Ok();
            else return BadRequest(retorno.Error);
        }
    }
}