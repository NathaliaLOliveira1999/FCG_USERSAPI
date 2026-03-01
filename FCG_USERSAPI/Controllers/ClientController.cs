using FCG_USERSAPI.Interfaces.Services;
using FCG_USERSAPI.Models.DTO;
using FCG_USERSAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FCG_USERSAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [Authorize]
        [HttpGet("GetAll")]
        public IActionResult GetAll() => Ok(_clientService.GetAll());

        [Authorize]
        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var client = _clientService.GetById(id);
            if (client == null)
                return NotFound();
            return Ok(client);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(ClientDto client)
        {
            if (client == null)
                return BadRequest("Preencha as informações do usuário!");
            var retorno = _clientService.Add(client);
            if (retorno.Success)
                return Ok(client);
            else return BadRequest(retorno.Error);
        }

        [Authorize]
        [HttpPut]
        public IActionResult Update(ClientDto client)
        {
            if (client == null)
                return BadRequest("Preencha as informações do cliente!");
            var retorno = _clientService.Update(client);
            if (retorno.Success)
                return Ok(client);
            else return BadRequest(retorno.Error);
        }

        [Authorize]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var retorno = _clientService.Delete(id);
            if (retorno.Success)
                return Ok();
            else return BadRequest(retorno.Error);
        }
    }
}