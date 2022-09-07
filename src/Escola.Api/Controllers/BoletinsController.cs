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
            return Ok(_boletim.ObterPorId(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] BoletimDTO boletim){
            _boletim.InserirBoletim(boletim);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id,
                                 [FromBody] BoletimDTO boletim){
            _boletim.Atualizar(id, boletim);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id){
            _boletim.ExcluirBoletim(id);
            return NoContent();
        }
    }
}