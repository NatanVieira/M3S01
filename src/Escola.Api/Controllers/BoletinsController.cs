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

        [HttpPost]
        public IActionResult Post([FromBody] BoletimDTO boletim){
            try{
                _boletim.InserirBoletim(boletim);
                return NoContent();
            }catch{ return StatusCode(500);}
        }
    }
}