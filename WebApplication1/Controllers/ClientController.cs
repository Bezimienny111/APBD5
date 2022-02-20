using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/clients")]
    [ApiController]
    public class ClientController : ControllerBase {
        private readonly IDbService _service;

        public ClientController(IDbService Dbservice) {
            _service = Dbservice;
        }

        [HttpDelete("{idClient}")]
        public IActionResult deleteClient(int idClient) {
            try {
                _service.DeleteClient(idClient);
            }catch(MyException e) {
                return StatusCode(e.i,e.Message);
            }
            return Ok();
        }
    }
}