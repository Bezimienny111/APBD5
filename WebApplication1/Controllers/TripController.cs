using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.DTO.Request;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/trips")]
    [ApiController]

    public class TripController : ControllerBase {

        private readonly IDbService _service;
        public TripController(IDbService dbService) {
            _service = dbService;
        }
        [HttpGet]
        public IActionResult GetTrips() {
            return Ok(_service.GetTrips());
        }
        [HttpPost("{idTrip}/clients")]
        public IActionResult AddClientToTrip([FromBody] AddClientReq tr, int idTrip)  {
            tr.IdTrip = idTrip;
            try {
                _service.RegClientTrip(tr);
            }catch(MyException e) {
               return StatusCode(e.i, e.Message);
            }
            return Ok();
        }
    }
}
        
