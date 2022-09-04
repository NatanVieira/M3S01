

using Escola.Domain.DTO;
using Escola.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Escola.Api.Controllers {


    [ApiController]
    [Route("api/notas")]
    public class NotasMateriasController : ControllerBase {

        private readonly INotasMateriasService _notasService;
        
        [HttpGet("{id}")]
        public ActionResult<NotasMateriasDTO> Get([FromRoute] int id){
            try{
                return Ok(_notasService.ObterPorId(id));
            }catch{ return StatusCode(500);}

        }

        [HttpPost]
        public ActionResult Post([FromBody] NotasMateriasDTO notas){
            try{
                _notasService.InserirNotasMaterias(notas);
                return NoContent();
            }catch{ return StatusCode(500);}
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id,
                                 [FromBody] NotasMateriasDTO notas){
            try{
                _notasService.Atualizar(id, notas);
                return NoContent();
            }catch{ return StatusCode(500);}
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id){
            try{
                _notasService.ExcluirNotasMaterias(id);
                return NoContent();
            }catch{ return StatusCode(500);}
        }
    }
}