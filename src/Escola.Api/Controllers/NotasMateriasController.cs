

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
            return Ok(_notasService.ObterPorId(id));
        }

        [HttpPost]
        public ActionResult Post([FromBody] NotasMateriasDTO notas){
            _notasService.InserirNotasMaterias(notas);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id,
                                 [FromBody] NotasMateriasDTO notas){
            _notasService.Atualizar(id, notas);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id){
            _notasService.ExcluirNotasMaterias(id);
            return NoContent();
        }
    }
}