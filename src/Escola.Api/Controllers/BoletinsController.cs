using Microsoft.AspNetCore.Mvc;
using Escola.Domain.DTO;
using Escola.Domain.Interfaces.Services;

namespace Escola.Api.Controllers {

    [ApiController]
    [Route("api/[controller]")]
    public class BoletinsController : ControllerBase {

        private readonly IBoletimService _boletim;

        public BoletinsController(IBoletimService boletim){
            _boletim = boletim;
        }
        
        [HttpGet("{id}")]
        public ActionResult<BoletimDTO> Get([FromRoute] int id){
            try {
                return Ok(_boletim.ObterPorId(id));
            }catch{ return StatusCode(500);}
        }
    }
}